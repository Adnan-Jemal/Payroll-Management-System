using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using payroll_ms;

namespace PayrollApp
{
    public partial class UpdateDepartmentForm : Form
    {
        private string connectionString = Program.connectionString;
        private int departmentId;

        public UpdateDepartmentForm(int departmentId, string departmentName, string description, string status)
        {
            InitializeComponent();
            this.departmentId = departmentId;
            departmentTextbox.Text = departmentName;
            descriptionTextbox.Text = description;
            statusComboBox.SelectedItem = status;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                string departmentName = departmentTextbox.Text.Trim();
                string description = descriptionTextbox.Text.Trim();
                string status = statusComboBox.SelectedItem.ToString();

                if (string.IsNullOrEmpty(departmentName))
                {
                    MessageBox.Show("Please enter a valid department name.");
                    return;
                }

                // Use the UpdateDepartment stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("UpdateDepartment", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DepartmentId", departmentId);
                        cmd.Parameters.AddWithValue("@DepartmentName", departmentName);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@Status", status);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Department updated successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating the department: " + ex.Message);
            }
        }
    }
}