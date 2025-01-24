using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using payroll_ms;

namespace PayrollApp
{
    public partial class PositionForm : UserControl
    {
        private string connectionString = Program.connectionString;

        public PositionForm()
        {
            InitializeComponent();
            InitializeDataGridView();
            LoadInitialData();
            SetupEventHandlers();
        }

        private void InitializeDataGridView()
        {
            positionDataGridView.Dock = DockStyle.Fill;
            positionDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            positionDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            positionDataGridView.ReadOnly = true;
        }

        private void LoadInitialData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                LoadPositionList();
                LoadDepartmentComboBoxes();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void SetupEventHandlers()
        {
            searchDepartmentComboBox.SelectedIndexChanged += FilterPositions;
            positionDataGridView.CellDoubleClick += PositionDataGridView_CellDoubleClick;
            searchButton.Click += SearchButton_Click;
            submitButton.Click += SubmitButton_Click;
        }

        private void LoadPositionList(string searchText = "", int? departmentId = null)
        {
            try
            {
                const string query = @"
                    SELECT 
                        PositionId, 
                        PositionName, 
                        Positions.Description AS PositionDescription, 
                        BaseSalary, 
                        Departments.DepartmentId,
                        Departments.DepartmentName
                    FROM Positions
                    INNER JOIN Departments ON Positions.DepartmentId = Departments.DepartmentId
                    WHERE (PositionName LIKE @SearchText OR Positions.Description LIKE @SearchText)
                    AND (@DepartmentId IS NULL OR Departments.DepartmentId = @DepartmentId)
                    ORDER BY PositionName";

                using (var connection = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@SearchText", $"%{searchText}%");
                    cmd.Parameters.AddWithValue("@DepartmentId", departmentId ?? (object)DBNull.Value);

                    var dataAdapter = new SqlDataAdapter(cmd);
                    var positionTable = new DataTable();
                    dataAdapter.Fill(positionTable);

                    positionDataGridView.DataSource = positionTable;
                    ConfigureGridColumns();
                }
            }
            catch (Exception ex)
            {
                ShowError("Error loading positions", ex);
            }
        }

        private void ConfigureGridColumns()
        {
            if (positionDataGridView.Columns.Count > 0)
            {
                positionDataGridView.Columns["PositionId"].Visible = false;
                positionDataGridView.Columns["DepartmentId"].Visible = false;
                positionDataGridView.Columns["BaseSalary"].DefaultCellStyle.Format = "C2";
            }
        }

        private void LoadDepartmentComboBoxes()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("GetAllDepartments", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var dataAdapter = new SqlDataAdapter(cmd);
                        var departmentTable = new DataTable();
                        dataAdapter.Fill(departmentTable);

                        ConfigureComboBox(searchDepartmentComboBox, departmentTable);
                        ConfigureComboBox(departmentComboBox, departmentTable);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("Error loading departments", ex);
            }
        }

        private void ConfigureComboBox(ComboBox comboBox, DataTable data)
        {
            comboBox.DataSource = data;
            comboBox.DisplayMember = "DepartmentName";
            comboBox.ValueMember = "DepartmentId";
            comboBox.SelectedIndex = -1;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            var searchText = searchTextBox.Text.Trim();
            var departmentId = (int?)searchDepartmentComboBox.SelectedValue;
            LoadPositionList(searchText, departmentId);
        }

        private void FilterPositions(object sender, EventArgs e)
        {
            var departmentId = (int?)searchDepartmentComboBox.SelectedValue;
            LoadPositionList(searchTextBox.Text.Trim(), departmentId);
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidatePositionForm()) return;

                var positionName = positionTextbox.Text.Trim();
                var positionDescription = descriptionTextbox.Text.Trim();
                var baseSalary = decimal.Parse(baseSalaryTextbox.Text.Trim(),
                    NumberStyles.Currency, CultureInfo.InvariantCulture);
                var departmentId = (int)departmentComboBox.SelectedValue;

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("AddPosition", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PositionName", positionName);
                        cmd.Parameters.AddWithValue("@Description", positionDescription);
                        cmd.Parameters.AddWithValue("@BaseSalary", baseSalary);
                        cmd.Parameters.AddWithValue("@DepartmentId", departmentId);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Position added successfully!");
                LoadPositionList();
                ClearPositionForm();
            }
            catch (Exception ex)
            {
                ShowError("Error submitting position", ex);
            }
        }

        private bool ValidatePositionForm()
        {
            if (string.IsNullOrWhiteSpace(positionTextbox.Text))
            {
                MessageBox.Show("Please enter a position name.");
                return false;
            }

            if (!decimal.TryParse(baseSalaryTextbox.Text.Trim(),
                NumberStyles.Currency, CultureInfo.InvariantCulture, out var baseSalary) || baseSalary <= 0)
            {
                MessageBox.Show("Please enter a valid base salary.");
                return false;
            }

            if (departmentComboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select a department.");
                return false;
            }

            if (PositionExists(positionTextbox.Text.Trim()))
            {
                MessageBox.Show("Position already exists.");
                return false;
            }

            return true;
        }

        private bool PositionExists(string positionName)
        {
            try
            {
                const string query = "SELECT COUNT(*) FROM Positions WHERE PositionName = @PositionName";

                using (var connection = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PositionName", positionName);
                    connection.Open();
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
            catch (Exception ex)
            {
                ShowError("Error checking position existence", ex);
                return true; // Prevent duplicate submissions on error
            }
        }

        private void ClearPositionForm()
        {
            positionTextbox.Clear();
            descriptionTextbox.Clear();
            baseSalaryTextbox.Clear();
            departmentComboBox.SelectedIndex = -1;
        }

        private void PositionDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = positionDataGridView.Rows[e.RowIndex];
            var positionId = (int)row.Cells["PositionId"].Value;
            var positionName = row.Cells["PositionName"].Value.ToString();
            var description = row.Cells["PositionDescription"].Value.ToString();
            var baseSalary = (decimal)row.Cells["BaseSalary"].Value;
            var departmentId = (int)row.Cells["DepartmentId"].Value;

            using (var updateForm = new UpdatePositionForm(positionId, positionName, description, baseSalary, departmentId))
            {
                if (updateForm.ShowDialog() == DialogResult.OK)
                {
                    LoadPositionList();
                }
            }
        }

        private void ShowError(string message, Exception ex)
        {
            MessageBox.Show($"{message}: {ex.Message}\n\nTechnical details:\n{ex}",
                          "Error",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
        }
    }
}