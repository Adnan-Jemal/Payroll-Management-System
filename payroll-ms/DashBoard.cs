using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using payroll_ms;

namespace PayrollApp
{
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();
            this.Load += Dashboard_Load;  // Wait until the form is fully loaded to call LoadDashboardData()
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            string connectionString = Program.connectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Get total employee count
                    using (SqlCommand cmd = new SqlCommand("GetEmployeeCount", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        int employeeCount = (int)cmd.ExecuteScalar();
                        numberOfEmployeesLabel.Text = $"Number of Employees: {employeeCount}";
                        employeeCountLabel.Text = $"Employee Count: {employeeCount}";
                    }

                    // Calculate total payroll for the current month
                    using (SqlCommand cmd = new SqlCommand("GetTotalPayrollForMonth", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        object result = cmd.ExecuteScalar();
                        decimal totalPayroll = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                        totalPayrollLabel.Text = $"Total Payroll for the Month: ${totalPayroll:N2}";
                    }

                    // Calculate average salary
                    using (SqlCommand cmd = new SqlCommand("GetAverageSalary", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        object result = cmd.ExecuteScalar();
                        decimal averageSalary = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                        averageSalaryLabel.Text = $"Average Salary: ${averageSalary:N2}";
                    }

                    // Get last payroll run date
                    using (SqlCommand cmd = new SqlCommand("GetLastPayrollRunDate", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        object result = cmd.ExecuteScalar();
                        DateTime? lastPayrollDate = result as DateTime?;
                        recentPayrollRunLabel.Text = lastPayrollDate.HasValue
                            ? $"Last Payroll Run: {lastPayrollDate.Value.ToShortDateString()}"
                            : "Last Payroll Run: Not available";
                    }

                    // Get new employees in the last month
                    using (SqlCommand cmd = new SqlCommand("GetNewHiresLastMonth", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        int newHiresCount = (int)cmd.ExecuteScalar();
                        newHiresListBox.Items.Clear();
                        newHiresListBox.Items.Add($"New Employees in the Last Month: {newHiresCount}");
                    }

                    // Upcoming payroll information
                    upcomingPaymentsListBox.Items.Clear();
                    upcomingPaymentsListBox.Items.Add("Next Payroll Run: 10th of every month");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        private void addEmployeeButton_Click(object sender, EventArgs e)
        {
            AddEmployeeForm addEmployeeForm = new AddEmployeeForm();
            addEmployeeForm.ShowDialog();
            LoadDashboardData(); // Refresh dashboard after adding an employee
        }

        private void generatePaySlipButton_Click(object sender, EventArgs e)
        {
            GeneratePaySlipForm generatePaySlipForm = new GeneratePaySlipForm();
            generatePaySlipForm.ShowDialog();
        }

        private void ProcessPayrollButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Get pay date from user (example using MonthCalendar)
                using (var dateForm = new PayDateSelectionForm())
                {
                    if (dateForm.ShowDialog() == DialogResult.OK)
                    {
                        using (SqlConnection connection = new SqlConnection(Program.connectionString))
                        {
                            connection.Open();
                            using (SqlCommand cmd = new SqlCommand("ProcessPayroll", connection))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@PayDate", dateForm.SelectedDate);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Payroll processed successfully!");
                        LoadDashboardData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing payroll: {ex.Message}");
            }
        }
    }
}