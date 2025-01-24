using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using payroll_ms;

namespace PayrollApp
{
    public partial class PayrollForm : UserControl
    {
        private string connectionString = Program.connectionString;

        // Style properties
        private readonly Color HeaderBackColor = Color.FromArgb(0, 138, 158);
        private readonly Color HeaderForeColor = Color.White;
        private readonly Color RowBackColorEven = Color.FromArgb(245, 245, 245);
        private readonly Font DataFont = new Font("Segoe UI", 9.5f);

        public PayrollForm()
        {
            InitializeComponent();
            ConfigureGridLayout();
        }

        private void ConfigureGridLayout()
        {
            // Configure grid columns
            gridLayout.ColumnCount = 6;
            gridLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f)); // Name
            gridLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15f)); // Base
            gridLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15f)); // Bonus
            gridLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15f)); // Deductions
            gridLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15f)); // Tax
            gridLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15f)); // Net
            
            gridLayout.RowStyles.Clear();
            gridLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        }

        private void ButtonGeneratePayroll_Click(object sender, EventArgs e)
        {
            try
            {
                buttonGeneratePayroll.Enabled = false;
                Cursor = Cursors.WaitCursor;

                // Validation code
                if (comboBoxMonth.SelectedItem == null || comboBoxYear.SelectedItem == null)
                {
                    MessageBox.Show("Please select a valid month and year.", "Validation Error", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string monthName = comboBoxMonth.SelectedItem.ToString();
                int month = Array.IndexOf(CultureInfo.CurrentCulture.DateTimeFormat.MonthNames, monthName) + 1;
                int year = (int)comboBoxYear.SelectedItem;

                // Validate selected date
                DateTime selectedDate = new DateTime(year, month, 1);
                if (selectedDate > DateTime.Now.Date)
                {
                    MessageBox.Show("Cannot generate payroll for future months.", "Validation Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                PopulatePayrollGrid(month, year);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating payroll: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                buttonGeneratePayroll.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void PopulatePayrollGrid(int month, int year)
        {
            try
            {
                List<EmployeePayrollData> payrollDataList = FetchPayrollDataFromDatabase(month, year);

                gridLayout.Controls.Clear();
                gridLayout.RowStyles.Clear();
                
                // Add header row
                AddHeaderRow();

                // Add data rows
                int rowIndex = 1;
                foreach (var payrollData in payrollDataList)
                {
                    AddPayrollRow(rowIndex++, payrollData);
                }

                // Update grid size
                gridLayout.Size = gridLayout.PreferredSize;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error populating payroll grid: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<EmployeePayrollData> FetchPayrollDataFromDatabase(int month, int year)
        {
            List<EmployeePayrollData> payrollDataList = new List<EmployeePayrollData>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetPayrollData", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Month", month);
                    command.Parameters.AddWithValue("@Year", year);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            decimal baseSalary = Convert.ToDecimal(reader["Salary"]);
                            decimal bonus = Convert.ToDecimal(reader["TotalBonus"]);
                            decimal deductions = Convert.ToDecimal(reader["TotalDeductions"]);
                            decimal tax = CalculateTax(baseSalary);
                            decimal netSalary = baseSalary + bonus - deductions - tax;

                            payrollDataList.Add(new EmployeePayrollData
                            {
                                EmployeeName = reader["EmployeeName"].ToString(),
                                BaseSalary = baseSalary,
                                Bonus = bonus,
                                Deductions = deductions,
                                Tax = tax,
                                NetSalary = netSalary
                            });
                        }
                    }
                }
            }
            return payrollDataList;
        }

        private decimal CalculateTax(decimal baseSalary)
        {
            // Tax calculation logic 
            if (baseSalary <= 5500) return baseSalary * 0.10m;
            if (baseSalary <= 8000) return baseSalary * 0.15m;
            if (baseSalary <= 11000) return baseSalary * 0.20m;
            return baseSalary * 0.25m;
        }

        private void AddHeaderRow()
        {
            string[] headers = { "Employee Name", "Base Salary", "Bonus", "Deductions", "Tax", "Net Salary" };
            
            for (int col = 0; col < headers.Length; col++)
            {
                var headerLabel = new Label
                {
                    Text = headers[col],
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    BackColor = HeaderBackColor,
                    ForeColor = HeaderForeColor,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(0)
                };
                
                gridLayout.Controls.Add(headerLabel, col, 0);
            }
        }

        private void AddPayrollRow(int row, EmployeePayrollData payrollData)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-US");
            
            object[] rowData =
            {
                payrollData.EmployeeName,
                payrollData.BaseSalary.ToString("C2", culture),
                payrollData.Bonus.ToString("C2", culture),
                payrollData.Deductions.ToString("C2", culture),
                payrollData.Tax.ToString("C2", culture),
                payrollData.NetSalary.ToString("C2", culture)
            };

            for (int col = 0; col < rowData.Length; col++)
            {
                var cell = new Label
                {
                    Text = rowData[col].ToString(),
                    Font = DataFont,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    BackColor = row % 2 == 0 ? Color.White : RowBackColorEven,
                    Margin = new Padding(0, 2, 0, 2)
                };

                gridLayout.Controls.Add(cell, col, row);
            }
            
            gridLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        }
    }

    public class EmployeePayrollData
    {
        public string EmployeeName { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal Bonus { get; set; }
        public decimal Deductions { get; set; }
        public decimal Tax { get; set; }
        public decimal NetSalary { get; set; }
    }
}