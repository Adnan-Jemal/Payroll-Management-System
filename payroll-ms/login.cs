using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using payroll_ms;

namespace PayrollApp
{
    public partial class Form1 : Form
    {
        private string _connectionString = Program.connectionString; // Update with your connection string

        public Form1()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("AuthenticateUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters for the stored procedure
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        // Execute the stored procedure
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            // Authentication successful
                            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Open the main panel or next form
                            MainPanelForm mainPanel = new MainPanelForm();
                            mainPanel.Show();
                            this.Hide(); // Hide the login form
                        }
                        else
                        {
                            // Authentication failed
                            MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetPasswordLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open the ResetPasswordForm when the link is clicked
            ResetPasswordForm resetPasswordForm = new ResetPasswordForm();
            resetPasswordForm.Show();
        }

        private void RegisterLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 loginForm3 = new Form2();
            loginForm3.Show();
            this.Hide();
        }
    }
}