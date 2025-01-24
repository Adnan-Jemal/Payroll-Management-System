using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using payroll_ms;

namespace PayrollApp
{
    public partial class Form2 : Form
    {
        private string _connectionString = Program.connectionString;

        public Form2()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            // Validate inputs
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

                    // Check if the user already exists using a query
                    string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                    using (SqlCommand checkUserCommand = new SqlCommand(checkUserQuery, connection))
                    {
                        checkUserCommand.Parameters.AddWithValue("@Username", username);

                        int userCount = (int)checkUserCommand.ExecuteScalar();

                        if (userCount > 0)
                        {
                            // User already exists
                            MessageBox.Show("Username already exists. Please log in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            // Redirect to the login page
                            Form1 loginForm1 = new Form1();
                            loginForm1.Show();
                            this.Hide();
                            return;
                        }
                    }

                    // If the user does not exist, proceed with registration
                    string registerQuery = @"
                            INSERT INTO Users (Username, PasswordHash)
                            VALUES (@Username, HASHBYTES('SHA2_256', @Password))";

                    using (SqlCommand registerCommand = new SqlCommand(registerQuery, connection))
                    {
                        registerCommand.Parameters.AddWithValue("@Username", username);
                        registerCommand.Parameters.AddWithValue("@Password", password);

                        registerCommand.ExecuteNonQuery();
                    }
                }

                // Show success message
                MessageBox.Show("Registration successful! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Redirect to the login page
                Form1 loginForm2 = new Form1();
                loginForm2.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loginLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Redirect to the login page
            Form1 loginForm3 = new Form1();
            loginForm3.Show();
            this.Hide();
        }
    }
}