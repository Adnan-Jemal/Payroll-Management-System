using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using payroll_ms;

namespace PayrollApp
{
    public partial class AddEmployeeForm : Form
    {
        public AddEmployeeForm()
        {
            InitializeComponent();
            LoadDepartmentNames();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Validate user input
            if (string.IsNullOrWhiteSpace(nameTextBox.Text) || string.IsNullOrWhiteSpace(lastNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(emailTextBox.Text) || cBoxAddEmpDep.SelectedItem == null ||
                string.IsNullOrWhiteSpace(addressTextBox.Text) || dateOfEmploymentPicker.Value == null ||
                string.IsNullOrWhiteSpace(basicSalaryTextBox.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // SQL Server connection string (use your actual server name here)
            string connectionString = Program.connectionString;

            // Use the AddEmployee stored procedure
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Fetch the BaseSalary for the selected position
                    string getBaseSalaryQuery = "SELECT BaseSalary FROM Positions WHERE PositionId = @PositionId";
                    conn.Open();
                    double baseSalary;
                    using (SqlCommand cmd = new SqlCommand(getBaseSalaryQuery, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@PositionId", cBoxAddEmpPosition.SelectedValue);
                        baseSalary = Convert.ToDouble(cmd.ExecuteScalar());
                    }

                    // Validate that the employee's salary is not below the BaseSalary
                    double employeeSalary = Convert.ToDouble(basicSalaryTextBox.Text);
                    if (employeeSalary < baseSalary)
                    {
                        throw new Exception("Salary cannot be below the base salary for this position.");
                    }

                    // Insert into Employees table using the AddEmployee stored procedure
                    using (SqlCommand cmd = new SqlCommand("AddEmployee", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@FirstName", nameTextBox.Text);
                        cmd.Parameters.AddWithValue("@LastName", lastNameTextBox.Text);
                        cmd.Parameters.AddWithValue("@Email", emailTextBox.Text);
                        cmd.Parameters.AddWithValue("@DateOfEmployment", dateOfEmploymentPicker.Value);
                        cmd.Parameters.AddWithValue("@DepartmentId", cBoxAddEmpDep.SelectedValue);
                        cmd.Parameters.AddWithValue("@PositionId", cBoxAddEmpPosition.SelectedValue);
                        cmd.Parameters.AddWithValue("@Address", addressTextBox.Text);
                        cmd.Parameters.AddWithValue("@Salary", employeeSalary);

                        cmd.ExecuteNonQuery();  // Insert employee, the trigger will handle EmployeeId generation
                    }

                    MessageBox.Show("Employee added successfully!");
                    this.Close();  // Close the form after saving
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void LoadDepartmentNames()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Program.connectionString))
                {
                    connection.Open();

                    // Use the GetAllDepartments stored procedure
                    using (SqlCommand command = new SqlCommand("GetAllDepartments", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable departmentTable = new DataTable();
                        dataAdapter.Fill(departmentTable);

                        // Bind the data to the ComboBox
                        cBoxAddEmpDep.DataSource = departmentTable;
                        cBoxAddEmpDep.DisplayMember = "DepartmentName"; // What the user sees
                        cBoxAddEmpDep.ValueMember = "DepartmentId";    // What the program uses
                        cBoxAddEmpDep.SelectedIndex = -1;              // Ensure no selection by default
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading departments: " + ex.Message);
            }
        }

       private void LoadPositionNames(int departmentId)
{
    try
    {
        using (SqlConnection connection = new SqlConnection(Program.connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("GetPositionsByDepartment", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@DepartmentId", departmentId);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable positionsTable = new DataTable();
                dataAdapter.Fill(positionsTable);

                // Check if positions exist
                if (positionsTable.Rows.Count == 0)
                {
                    MessageBox.Show("No positions found for this department.");
                    cBoxAddEmpPosition.DataSource = null;
                    return;
                }

                // Bind the data to the ComboBox
                cBoxAddEmpPosition.DataSource = positionsTable;
                cBoxAddEmpPosition.DisplayMember = "PositionName";
                cBoxAddEmpPosition.ValueMember = "PositionId";
                cBoxAddEmpPosition.SelectedIndex = -1;
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error loading positions: {ex.Message}");
    }
}

        private void cBoxAddEmpDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxAddEmpDep.SelectedValue != null)
            {
                cBoxAddEmpPosition.Enabled = true;
                int departmentId = Convert.ToInt32(cBoxAddEmpDep.SelectedValue);
                LoadPositionNames(departmentId);
            }
            else
            {
                cBoxAddEmpPosition.Enabled = false;
            }
        }

        private void cBoxAddEmpPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cBoxAddEmpPosition.SelectedItem != null)
                {
                    // Get the selected DataRowView
                    DataRowView selectedRow = (DataRowView)cBoxAddEmpPosition.SelectedItem;

                    // Extract PositionId from the DataRow
                    int positionId = Convert.ToInt32(selectedRow["PositionId"]);

                    using (SqlConnection conn = new SqlConnection(Program.connectionString))
                    {
                        conn.Open();
                        string query = "SELECT BaseSalary FROM Positions WHERE PositionId = @PositionId";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@PositionId", positionId);
                            object result = cmd.ExecuteScalar();

                            if (result != null && result != DBNull.Value)
                            {
                                basicSalaryTextBox.Text = result.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Base Salary: " + ex.Message);
            }
        }
    }
}