using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using payroll_ms;

namespace PayrollApp
{
    public partial class UpdateDeductibleForm : Form
    {
        private string connectionString = Program.connectionString;
        private int deductibleId;

        public UpdateDeductibleForm(int deductibleId, string employeeId, string description, decimal amount, DateTime date)
        {
            InitializeComponent();
            this.deductibleId = deductibleId;

            // Populate form fields with existing data
            descriptionTextbox.Text = description;
            amountTextbox.Value = amount;
            datePicker.Value = date;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                string description = descriptionTextbox.Text.Trim();
                decimal amount = amountTextbox.Value;
                DateTime date = datePicker.Value;

                // Validate inputs
                if (string.IsNullOrEmpty(description) || amount <= 0)
                {
                    MessageBox.Show("Please fill all fields with valid data.");
                    return;
                }

                // Use the UpdateDeduction stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("UpdateDeduction", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        cmd.Parameters.AddWithValue("@DeductibleId", deductibleId);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@Amount", amount);
                        cmd.Parameters.AddWithValue("@Date", date);

                        // Execute the command
                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                }

                // Show a success message
                MessageBox.Show("Deductible updated successfully!");

                // Close the form
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating the deductible: " + ex.Message);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();  // Close the form without saving changes
        }
    }
}