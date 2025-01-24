using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using payroll_ms;

namespace PayrollApp
{
    public partial class EmployeeManagement : UserControl
    {
        private string connectionString = Program.connectionString;

        public EmployeeManagement()
        {
            InitializeComponent();
            LoadEmployeeData();
        }

        // Method to load employee data from the database and display it in the DataGridView
        private void LoadEmployeeData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Use the GetEmployeeDetails stored procedure
                    using (SqlCommand command = new SqlCommand("GetEmployees", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Execute the stored procedure
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable employeeTable = new DataTable();
                        dataAdapter.Fill(employeeTable);

                        // Bind the DataTable to the DataGridView
                        employeeDataGridView.DataSource = employeeTable;

                        // Format columns
                        employeeDataGridView.Columns["EmployeeId"].HeaderText = "Employee ID";
                        employeeDataGridView.Columns["FirstName"].HeaderText = "First Name";
                        employeeDataGridView.Columns["LastName"].HeaderText = "Last Name";
                        employeeDataGridView.Columns["Email"].HeaderText = "Email";
                        employeeDataGridView.Columns["DateOfEmployment"].HeaderText = "Date of Employment";
                        employeeDataGridView.Columns["DepartmentId"].HeaderText = "Department ID";
                        employeeDataGridView.Columns["PositionId"].HeaderText = "Position ID";
                        employeeDataGridView.Columns["Address"].HeaderText = "Address";
                        employeeDataGridView.Columns["Salary"].HeaderText = "Salary";
                        employeeDataGridView.Columns["Status"].HeaderText = "Status";

                        // Format Salary column as currency
                        employeeDataGridView.Columns["Salary"].DefaultCellStyle.Format = "C2";

                        // Format DateOfEmployment column
                        employeeDataGridView.Columns["DateOfEmployment"].DefaultCellStyle.Format = "yyyy-MM-dd";

                        // Auto-resize columns
                        employeeDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employee data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Search Button Click Handler (Search functionality)
        private void searchButton_Click(object sender, EventArgs e)
        {
            string searchTerm = searchTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Use a SQL query to filter employees based on the search term
                        string query = @"
                            SELECT 
                                EmployeeId, 
                                FirstName, 
                                LastName, 
                                Email, 
                                DateOfEmployment, 
                                DepartmentId, 
                                PositionId, 
                                Address, 
                                Salary, 
                                Status
                            FROM Employees
                            WHERE FirstName LIKE @SearchTerm OR LastName LIKE @SearchTerm
                            ORDER BY EmployeeId";

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                        dataAdapter.SelectCommand.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                        DataTable employeeTable = new DataTable();
                        dataAdapter.Fill(employeeTable);

                        // Bind the filtered results to the DataGridView
                        employeeDataGridView.DataSource = employeeTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error searching employee data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // If no search term is entered, reload the full employee data
                LoadEmployeeData();
            }
        }

        // Update Button Click Handler
        private void updateButton_Click(object sender, EventArgs e)
        {
            if (employeeDataGridView.SelectedRows.Count > 0)
            {
                string employeeId = Convert.ToString(employeeDataGridView.SelectedRows[0].Cells["EmployeeId"].Value);

                // Open the UpdateEmployeeDetails form with the selected employee's ID
                UpdateEmployeeDetails updateForm = new UpdateEmployeeDetails(employeeId);
                updateForm.ShowDialog();

                // Refresh the employee data after updating
                LoadEmployeeData();
            }
            else
            {
                MessageBox.Show("Please select an employee to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add Employee Button Click Handler
        private void addEmployeeButton_Click(object sender, EventArgs e)
        {
            // Open the AddEmployeeForm
            AddEmployeeForm addEmployeeForm = new AddEmployeeForm();
            addEmployeeForm.ShowDialog();

            // Refresh the employee data after adding a new employee
            LoadEmployeeData();
        }
    }
}