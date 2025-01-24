using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using payroll_ms;

namespace PayrollApp
{
    public partial class BonusForm : UserControl
    {
        private string connectionString = Program.connectionString;

        public BonusForm()
        {
            InitializeComponent();
            LoadEmployeeDropdown();
            LoadBonuses();
            WireEvents();
            ConfigureGridStyle();
        }

        private void WireEvents()
        {
            submitButton.Click += submitButton_Click;
            searchButton.Click += searchButton_Click;
            employeeDropdown.SelectedIndexChanged += employeeDropdown_SelectedIndexChanged;
            

            // Hover effects
            submitButton.MouseEnter += (s, e) => submitButton.BackColor = System.Drawing.Color.FromArgb(65, 65, 90);
            submitButton.MouseLeave += (s, e) => submitButton.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);
            searchButton.MouseEnter += (s, e) => searchButton.BackColor = System.Drawing.Color.FromArgb(65, 65, 90);
            searchButton.MouseLeave += (s, e) => searchButton.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);
        }

        private void ConfigureGridStyle()
        {
            bonusesGrid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.FromArgb(51, 51, 76),
                ForeColor = System.Drawing.Color.White,
                Font = new Font("Segoe UI", 9.75F, FontStyle.Bold)
            };
            bonusesGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
        }
        private void LoadEmployeeDropdown()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var adapter = new SqlDataAdapter(
                    "SELECT EmployeeId, FirstName, LastName FROM Employees ORDER BY FirstName", connection))
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
                MessageBox.Show($"Error loading employees: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBonuses(string searchKeyword = "")
        {
            try
            {
                // Modified query to include EmployeeId for filtering
                string query = @"
            SELECT B.BonusId, E.EmployeeId, 
                   E.FirstName, E.LastName, 
                   B.Amount, B.BonusDate, B.Description
            FROM Bonuses B
            JOIN Employees E ON B.EmployeeId = E.EmployeeId";

                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    query += @" WHERE E.FirstName LIKE @SearchKeyword 
                      OR E.LastName LIKE @SearchKeyword
                      OR B.Description LIKE @SearchKeyword";
                }

                query += " ORDER BY B.BonusDate DESC"; // Added DESC for reverse chronological order

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(searchKeyword))
                    {
                        cmd.Parameters.AddWithValue("@SearchKeyword", $"%{searchKeyword}%");
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable bonusesTable = new DataTable();
                    adapter.Fill(bonusesTable);

                    // Bind to grid and hide IDs
                    bonusesGrid.DataSource = bonusesTable;
                    bonusesGrid.Columns["BonusId"].Visible = false;
                    bonusesGrid.Columns["EmployeeId"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bonuses: {ex.Message}", "Database Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (employeeDropdown.SelectedValue == null ||
                amountNumeric.Value <= 0 ||
                string.IsNullOrWhiteSpace(descriptionTextBox.Text))
            {
                MessageBox.Show("Please fill all required fields with valid data.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand("AddBonus", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@EmployeeId", SqlDbType.NVarChar).Value =
                        employeeDropdown.SelectedValue;
                    cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value =
                        amountNumeric.Value;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 255).Value =
                        descriptionTextBox.Text.Trim();
                    cmd.Parameters.Add("@BonusDate", SqlDbType.DateTime).Value =
                        datePicker.Value;

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }

                ClearForm();
                LoadBonuses();
                MessageBox.Show("Bonus added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving bonus: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            LoadBonuses(searchTextBox.Text.Trim());
        }

        private void employeeDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (employeeDropdown.SelectedValue == null) return;

            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand(
                    @"SELECT B.BonusId, E.FirstName, E.LastName, 
                            B.Amount, B.BonusDate, B.Description
                     FROM Bonuses B
                     JOIN Employees E ON B.EmployeeId = E.EmployeeId
                     WHERE B.EmployeeId = @EmployeeId
                     ORDER BY B.BonusDate DESC", connection))
                {
                    cmd.Parameters.Add("@EmployeeId", SqlDbType.NVarChar).Value =
                        employeeDropdown.SelectedValue;

                    var adapter = new SqlDataAdapter(cmd);
                    var bonusesTable = new DataTable();
                    adapter.Fill(bonusesTable);

                    bonusesGrid.DataSource = bonusesTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bonuses: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}