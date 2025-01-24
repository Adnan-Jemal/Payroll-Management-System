using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using payroll_ms;

namespace PayrollApp
{
    public partial class DepartmentForm : UserControl
    {
        private string connectionString = Program.connectionString;

        // Constructor
        public DepartmentForm()
        {
            InitializeComponent();
            LoadDepartmentList();

            // Ensure the DataGridView resizes with the panel
            departmentDataGridView.Dock = DockStyle.Fill;
            departmentDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Add event handlers
            submitButton.Click += submitButton_Click;
            searchButton.Click += searchButton_Click;
            departmentDataGridView.CellDoubleClick += departmentDataGridView_CellDoubleClick; // Enable double-click to edit
        }

        // Method to load departments into the DataGridView with optional filtering
        private void LoadDepartmentList(string filterQuery = "")
        {
            try
            {
                // Default query (if no filter is provided)
                string query = "SELECT DepartmentId, DepartmentName, Description, Status FROM Departments ORDER BY DepartmentName";

                // Apply search filter if any
                if (!string.IsNullOrEmpty(filterQuery))
                {
                    query = $"SELECT DepartmentId, DepartmentName, Description, Status FROM Departments WHERE DepartmentName LIKE @FilterQuery OR Description LIKE @FilterQuery ORDER BY DepartmentName";
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Add parameter to prevent SQL injection
                        if (!string.IsNullOrEmpty(filterQuery))
                        {
                            cmd.Parameters.AddWithValue("@FilterQuery", "%" + filterQuery + "%");
                        }

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                        DataTable departmentTable = new DataTable();
                        dataAdapter.Fill(departmentTable);
                        departmentDataGridView.DataSource = departmentTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading department data: " + ex.Message);
            }
        }

        // Event handler for the search button click
        private void searchButton_Click(object sender, EventArgs e)
        {
            string searchQuery = searchTextbox.Text.Trim();
            LoadDepartmentList(searchQuery); // Pass the search query to filter the departments
        }

        // Insert a new department into the database using the AddDepartment stored procedure
        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                string departmentName = departmentTextbox.Text.Trim();
                string description = descriptionTextbox.Text.Trim();

                if (string.IsNullOrEmpty(departmentName))
                {
                    MessageBox.Show("Please enter a valid department name.");
                    return;
                }

                if (DoesDepartmentExist(departmentName))
                {
                    MessageBox.Show("Department already exists in the database.");
                    return;
                }

                // Use the AddDepartment stored procedure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("AddDepartment", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DepartmentName", departmentName);
                        cmd.Parameters.AddWithValue("@Description", description);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Department added successfully!");
                LoadDepartmentList(); // Reload the department list after adding a new department
                departmentTextbox.Clear();
                descriptionTextbox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while submitting the department: " + ex.Message);
            }
        }

        // Check if the department already exists
        private bool DoesDepartmentExist(string departmentName)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Departments WHERE DepartmentName = @DepartmentName";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@DepartmentName", departmentName);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking department existence: " + ex.Message);
                return false;
            }
        }

        // Event handler for double-clicking a row in the DataGridView to edit a department
        private void departmentDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked
            {
                DataGridViewRow row = departmentDataGridView.Rows[e.RowIndex];

                // Open the UpdateDepartmentForm with the selected department's details
                int departmentId = Convert.ToInt32(row.Cells["DepartmentId"].Value);
                string departmentName = row.Cells["DepartmentName"].Value.ToString();
                string description = row.Cells["Description"].Value.ToString();
                string status = row.Cells["Status"].Value.ToString();

                UpdateDepartmentForm updateForm = new UpdateDepartmentForm(departmentId, departmentName, description, status);
                updateForm.ShowDialog();

                // Refresh the department list after updating
                LoadDepartmentList();
            }
        }
    }
}