using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using payroll_ms;

namespace PayrollApp
{
    public partial class UpdatePositionForm : Form
    {
        private string connectionString = Program.connectionString;
        private int positionId;

        public UpdatePositionForm(int positionId, string positionName, string description, decimal baseSalary, int departmentId)
        {
            InitializeComponent();
            this.positionId = positionId;
            positionTextbox.Text = positionName;
            descriptionTextbox.Text = description;
            baseSalaryTextbox.Text = baseSalary.ToString();
            LoadDepartmentNames(departmentId); // Pass departmentId instead of departmentName
        }

        private void LoadDepartmentNames(int selectedDepartmentId)
        {
            try
            {
                string query = "SELECT DepartmentId, DepartmentName FROM Departments ORDER BY DepartmentName";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable departmentTable = new DataTable();
                    dataAdapter.Fill(departmentTable);

                    // Bind the data to the ComboBox
                    departmentComboBox.DataSource = departmentTable;
                    departmentComboBox.DisplayMember = "DepartmentName"; // What the user sees
                    departmentComboBox.ValueMember = "DepartmentId";    // What the program uses

                    // Set the selected department
                    departmentComboBox.SelectedValue = selectedDepartmentId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading departments: " + ex.Message);
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                string positionName = positionTextbox.Text.Trim();
                string description = descriptionTextbox.Text.Trim();

                if (!decimal.TryParse(baseSalaryTextbox.Text.Trim(), out decimal baseSalary) || baseSalary <= 0)
                {
                    MessageBox.Show("Please enter a valid base salary.");
                    return;
                }

                // Get the selected department ID
                if (departmentComboBox.SelectedValue == null)
                {
                    MessageBox.Show("Please select a valid department.");
                    return;
                }
                int departmentId = (int)departmentComboBox.SelectedValue;

                if (string.IsNullOrEmpty(positionName))
                {
                    MessageBox.Show("Please enter a position name.");
                    return;
                }

                // Use the UpdatePosition stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("UpdatePosition", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PositionId", positionId);
                        cmd.Parameters.AddWithValue("@PositionName", positionName);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@BaseSalary", baseSalary);
                        cmd.Parameters.AddWithValue("@DepartmentId", departmentId);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Position updated successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating the position: " + ex.Message);
            }
        }
    }
}