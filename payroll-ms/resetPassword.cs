using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using payroll_ms;

namespace PayrollApp
{
    public partial class ResetPasswordForm : Form
    {
        private string connectionString = Program.connectionString;

        public ResetPasswordForm()
        {
            InitializeComponent();
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text.Trim();
            string newPassword = newPasswordTextBox.Text.Trim();
            string confirmPassword = confirmPasswordTextBox.Text.Trim();

            // Validate inputs
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Call the stored procedure to reset the password
            bool success = ResetPasswordInDatabase(username, newPassword);

            if (success)
            {
                MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Close the form after password change
            }
            else
            {
                MessageBox.Show("Failed to change password. Username not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Resets the password in the database using the ResetPassword stored procedure.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>True if the password was updated successfully; otherwise, false.</returns>
        private bool ResetPasswordInDatabase(string username, string newPassword)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("ResetPassword", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@NewPassword", newPassword);

                        // Execute the stored procedure and check the result
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int success = Convert.ToInt32(reader["Success"]);
                                return success == 1;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error resetting password: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }
    }
}