using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using payroll_ms;

namespace PayrollApp
{
    public partial class JobListForm : Form
    {
        private string connectionString = Program.connectionString;

        public JobListForm()
        {
            InitializeComponent();
            this.submitButton.Click += new EventHandler(this.submitButton_Click); // Event handler for the submit button
            LoadJobTitles();
            LoadDescriptions();
            LoadEmploymentTypes();
        }

        private void LoadJobTitles()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT JobTitle FROM JobTitles";  // Get existing job titles

                using (var command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        jobTitleComboBox.Items.Add(reader["JobTitle"].ToString());
                    }
                }
            }
        }

        private void LoadDescriptions()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Description FROM Descriptions";  // Get existing descriptions

                using (var command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        descriptionComboBox.Items.Add(reader["Description"].ToString());
                    }
                }
            }
        }

        private void LoadEmploymentTypes()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT EmploymentType FROM EmploymentTypes";  // Get existing employment types

                using (var command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        employmentTypeComboBox.Items.Add(reader["EmploymentType"].ToString());
                    }
                }
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string jobTitle = jobTitleComboBox.Text;
            string description = descriptionComboBox.Text;
            string employmentType = employmentTypeComboBox.SelectedItem?.ToString();  // Ensure something is selected

            if (string.IsNullOrEmpty(jobTitle) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(employmentType))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            // Check if job title exists in the database
            if (CheckIfExists("JobTitles", "JobTitle", jobTitle))
            {
                MessageBox.Show("This job title already exists.");
                return;
            }

            // Check if description exists in the database
            if (CheckIfExists("Descriptions", "Description", description))
            {
                MessageBox.Show("This description already exists.");
                return;
            }

          

            // Add the new job title, description, and employment type to the respective tables
            AddToDatabase("JobTitles", "JobTitle", jobTitle);
            AddToDatabase("Descriptions", "Description", description);

            // Add combination to the JobList table
            AddJobListToDatabase(jobTitle, description, employmentType);

            // Refresh ComboBoxes after adding a new entry
            RefreshComboBoxes();

            MessageBox.Show("Job added successfully.");
        }

        private bool CheckIfExists(string tableName, string columnName, string value)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT COUNT(*) FROM {tableName} WHERE {columnName} = @Value";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Value", value);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;  // Return true if it exists
                }
            }
        }

        private void AddToDatabase(string tableName, string columnName, string value)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = $"INSERT INTO {tableName} ({columnName}) VALUES (@Value)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Value", value);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void AddJobListToDatabase(string jobTitle, string description, string employmentType)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO JobList (JobTitle, Description, EmploymentType) VALUES (@JobTitle, @Description, @EmploymentType)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@JobTitle", jobTitle);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@EmploymentType", employmentType);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void RefreshComboBoxes()
        {
            jobTitleComboBox.Items.Clear();
            descriptionComboBox.Items.Clear();
            employmentTypeComboBox.Items.Clear();

            LoadJobTitles();
            LoadDescriptions();
            LoadEmploymentTypes();
        }
    }
}

