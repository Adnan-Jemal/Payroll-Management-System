using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using payroll_ms;

namespace PayrollApp
{
    public partial class DeductibleForm : UserControl
    {
        private string connectionString = Program.connectionString;

        public DeductibleForm()
        {
            InitializeComponent();
            LoadEmployeeDropdown();
            LoadDeductibles();
        }

        private void LoadEmployeeDropdown()
        {
            try
            {
                string query = "SELECT EmployeeId, FirstName, LastName FROM Employees ORDER BY FirstName";

                using (var connection = new SqlConnection(connectionString))
                using (var adapter = new SqlDataAdapter(query, connection))
                {
                    var employeeTable = new DataTable();
                    adapter.Fill(employeeTable);

                    employeeDropdown.DataSource = employeeTable;
                    employeeDropdown.DisplayMember = "FirstName";
                    employeeDropdown.ValueMember = "EmployeeId";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}");
            }
        }

        private void LoadDeductibles(string searchKeyword = "")
        {
            try
            {
                string query = @"
            SELECT D.DeductibleId, 
                   E.EmployeeId,
                   E.FirstName, 
                   E.LastName, 
                   D.Description, 
                   D.Amount, 
                   D.Date
            FROM Deductibles D
            JOIN Employees E ON D.EmployeeId = E.EmployeeId";

                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    query += @" 
                WHERE D.Description LIKE @SearchKeyword 
                OR E.FirstName LIKE @SearchKeyword 
                OR E.LastName LIKE @SearchKeyword";
                }

                query += " ORDER BY D.Date DESC";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection))
                {
                    if (!string.IsNullOrEmpty(searchKeyword))
                    {
                        dataAdapter.SelectCommand.Parameters.AddWithValue("@SearchKeyword", $"%{searchKeyword}%");
                    }

                    DataTable deductiblesTable = new DataTable();
                    dataAdapter.Fill(deductiblesTable);

                    deductiblesGrid.DataSource = deductiblesTable;
                    deductiblesGrid.Columns["EmployeeId"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading deductibles: {ex.Message}");
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (employeeDropdown.SelectedValue == null ||
                string.IsNullOrWhiteSpace(descriptionTextBox.Text) ||
                amountNumeric.Value <= 0)
            {
                MessageBox.Show("Please fill all required fields with valid data.");
                return;
            }

            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand("AddDeduction", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeId", employeeDropdown.SelectedValue);
                    cmd.Parameters.AddWithValue("@Description", descriptionTextBox.Text.Trim());
                    cmd.Parameters.AddWithValue("@Amount", amountNumeric.Value);
                    cmd.Parameters.AddWithValue("@DeductionDate", datePicker.Value);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }

                ClearForm();
                LoadDeductibles();
                MessageBox.Show("Deduction added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving deduction: {ex.Message}");
            }
        }

        private void ClearForm()
        {
            descriptionTextBox.Clear();
            amountNumeric.Value = 0;
            datePicker.Value = DateTime.Today;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            LoadDeductibles(searchTextBox.Text.Trim());
        }

        private void deductiblesGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = deductiblesGrid.Rows[e.RowIndex];
            try
            {
                var updateForm = new UpdateDeductibleForm(
                    deductibleId: Convert.ToInt32(row.Cells["DeductibleId"].Value),
                    employeeId: row.Cells["EmployeeId"].Value.ToString(), // Get from grid, not dropdown
                    description: row.Cells["Description"].Value.ToString(),
                    amount: Convert.ToDecimal(row.Cells["Amount"].Value),
                    date: Convert.ToDateTime(row.Cells["Date"].Value)
                );

                if (updateForm.ShowDialog() == DialogResult.OK)
                {
                    LoadDeductibles(searchTextBox.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening update form: {ex.Message}");
            }
        }
    }
}