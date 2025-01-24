using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using payroll_ms;

namespace PayrollApp
{
    public partial class UpdateEmployeeDetails : Form
    {
        private string connectionString = Program.connectionString;
        private string employeeId; // Store the selected employee's ID

        public UpdateEmployeeDetails(string empId)
        {
            InitializeComponent();
            employeeId = empId;
            LoadEmployeeDetails();
            LoadDepartments(); // Load departments into the ComboBox
        }

        // Method to load employee details into the text boxes
        private void LoadEmployeeDetails()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Use the GetEmployeeDetails stored procedure
                    SqlCommand command = new SqlCommand("GetEmployeeDetails", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        firstNameTextBox.Text = reader["FirstName"].ToString();
                        lastNameTextBox.Text = reader["LastName"].ToString();
                        emailTextBox.Text = reader["Email"].ToString();
                        addressTextBox.Text = reader["Address"].ToString();
                        baseSalaryTextBox.Text = reader["Salary"].ToString(); // Load the employee's current salary
                        statusComboBox.SelectedItem = reader["Status"].ToString(); // Load the employee's current status

                        // Set the selected department in the ComboBox
                        int departmentId = Convert.ToInt32(reader["DepartmentId"]);
                        departmentComboBox.SelectedValue = departmentId;

                        // Load positions for the selected department
                        LoadPositions(departmentId);

                        // Set the selected position in the ComboBox
                        int positionId = Convert.ToInt32(reader["PositionId"]);
                        positionComboBox.SelectedValue = positionId;
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employee details: " + ex.Message);
            }
        }

        // Method to load departments into the ComboBox
        private void LoadDepartments()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Use the GetAllDepartments stored procedure
                    SqlCommand command = new SqlCommand("GetAllDepartments", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable departmentTable = new DataTable();
                    dataAdapter.Fill(departmentTable);

                    // Bind the data to the ComboBox
                    departmentComboBox.DataSource = departmentTable;
                    departmentComboBox.DisplayMember = "DepartmentName"; // What the user sees
                    departmentComboBox.ValueMember = "DepartmentId";    // What the program uses

                    // Add an event handler for when the department selection changes
                    departmentComboBox.SelectedIndexChanged += DepartmentComboBox_SelectedIndexChanged;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading departments: " + ex.Message);
            }
        }

        // Event handler for department selection change
        private void DepartmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (departmentComboBox.SelectedValue != null)
            {
                int departmentId = (int)departmentComboBox.SelectedValue;
                LoadPositions(departmentId);
            }
        }

        // Method to load positions for the selected department
        private void LoadPositions(int departmentId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Use the GetPositionsByDepartment stored procedure
                    SqlCommand command = new SqlCommand("GetPositionsByDepartment", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DepartmentId", departmentId);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable positionTable = new DataTable();
                    dataAdapter.Fill(positionTable);

                    // Bind the data to the ComboBox
                    positionComboBox.DataSource = positionTable;
                    positionComboBox.DisplayMember = "PositionName"; // What the user sees
                    positionComboBox.ValueMember = "PositionId";    // What the program uses

                    // Add an event handler for when the position selection changes
                    positionComboBox.SelectedIndexChanged += PositionComboBox_SelectedIndexChanged;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading positions: " + ex.Message);
            }
        }

        // Event handler for position selection change
        private void PositionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (positionComboBox.SelectedValue != null)
            {
                int positionId = (int)positionComboBox.SelectedValue;
                LoadBaseSalary(positionId);
            }
        }

        // Method to load the BaseSalary for the selected position
        private void LoadBaseSalary(int positionId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT BaseSalary FROM Positions WHERE PositionId = @PositionId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PositionId", positionId);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        baseSalaryTextBox.Text = result.ToString(); // Update the BaseSalary textbox
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading BaseSalary: " + ex.Message);
            }
        }

        // Update employee details when the "Save" button is clicked
        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Get the edited salary from the textbox
                    decimal salary;
                    if (!decimal.TryParse(baseSalaryTextBox.Text, out salary))
                    {
                        MessageBox.Show("Invalid salary value. Please enter a valid number.");
                        return;
                    }

                    // Use the UpdateEmployee stored procedure
                    SqlCommand command = new SqlCommand("UpdateEmployee", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    command.Parameters.AddWithValue("@FirstName", firstNameTextBox.Text);
                    command.Parameters.AddWithValue("@LastName", lastNameTextBox.Text);
                    command.Parameters.AddWithValue("@DepartmentId", departmentComboBox.SelectedValue);
                    command.Parameters.AddWithValue("@PositionId", positionComboBox.SelectedValue);
                    command.Parameters.AddWithValue("@Email", emailTextBox.Text);
                    command.Parameters.AddWithValue("@Address", addressTextBox.Text);
                    command.Parameters.AddWithValue("@Salary", salary); // Use the edited salary
                    command.Parameters.AddWithValue("@Status", statusComboBox.SelectedItem.ToString()); // Use the selected status

                    command.ExecuteNonQuery();
                    MessageBox.Show("Employee details updated successfully!");

                    connection.Close();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating employee details: " + ex.Message);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show(
                "Are you sure you want to cancel without saving changes?",
                "Confirm Cancel",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}