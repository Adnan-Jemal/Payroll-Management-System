using System;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using payroll_ms;

namespace PayrollApp
{
    public partial class GeneratePaySlipForm : Form
    {
        private string connectionString = Program.connectionString;

        public GeneratePaySlipForm()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            string email = emailTextBox.Text.Trim();

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            CheckUserAndGeneratePaySlip(email);
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase);
        }

        private void CheckUserAndGeneratePaySlip(string email)
        {
            if (!EmployeeExists(email))
            {
                MessageBox.Show("Employee email not found.");
                return;
            }
            string query = @"
                SELECT TOP 1 
                e.EmployeeId, 
                e.FirstName, 
                e.LastName, 
                d.DepartmentName AS Department,
                p.GrossSalary,
                p.Bonus, 
                p.Tax, 
                p.Deductions, 
                p.NetSalary, 
                p.PayDate
            FROM Employees e
            INNER JOIN Payroll p ON e.EmployeeId = p.EmployeeId
            INNER JOIN Departments d ON e.DepartmentId = d.DepartmentId
            WHERE e.Email = @Email COLLATE DATABASE_DEFAULT  -- Handle collation
            AND p.Status = 'Active'
            ORDER BY p.PayDate DESC;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string firstName = reader["FirstName"].ToString();
                                string lastName = reader["LastName"].ToString();
                                string department = reader["Department"].ToString();
                                decimal grossSalary = (decimal)reader["GrossSalary"];
                                decimal bonus = (decimal)reader["Bonus"];
                                decimal tax = (decimal)reader["Tax"];
                                decimal deductions = (decimal)reader["Deductions"];
                                decimal netSalary = (decimal)reader["NetSalary"];
                                DateTime payDate = (DateTime)reader["PayDate"];

                                employeeDetailsLabel.Text = $"Employee: {firstName} {lastName}\nDepartment: {department}";

                                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                                string paySlipsPath = Path.Combine(documentsPath, "PaySlips");
                                Directory.CreateDirectory(paySlipsPath);

                                GeneratePaySlipToTextFile(
                                    email, firstName, lastName, department,
                                    payDate, grossSalary, bonus, tax,
                                    deductions, netSalary, paySlipsPath
                                );
                            }
                            else
                            {
                                MessageBox.Show("No active payroll records found for this employee. Process payroll first to generate PaySlips");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\n\nTechnical Details:\n{ex}");
            }
        }
        // check emploee exists
        private bool EmployeeExists(string email)
        {
            string query = "SELECT COUNT(1) FROM Employees WHERE Email = @Email";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        private void GeneratePaySlipToTextFile(string email, string firstName, string lastName,
            string department, DateTime payDate, decimal grossSalary, decimal bonus,
            decimal tax, decimal deductions, decimal netSalary, string directoryPath)
        {
            try
            {
                string sanitizedEmail = Regex.Replace(email, "[^a-zA-Z0-9_]", "_");
                string fileName = $"{sanitizedEmail}_{payDate:yyyyMMdd}_PaySlip.txt";
                string filePath = Path.Combine(directoryPath, fileName);

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine($"PAY SLIP - {payDate:MMMM yyyy}");
                    writer.WriteLine(new string('=', 40));
                    writer.WriteLine($"Employee: {firstName} {lastName}");
                    writer.WriteLine($"Department: {department}");
                    writer.WriteLine($"Pay Date: {payDate:dd MMMM yyyy}");
                    writer.WriteLine(new string('-', 40));
                    writer.WriteLine("Earnings:");
                    writer.WriteLine($"{"Gross Salary:",-20}{grossSalary,15:C2}");
                    writer.WriteLine($"{"Bonus:",-20}{bonus,15:C2}");
                    writer.WriteLine(new string('-', 40));
                    writer.WriteLine("Deductions:");
                    writer.WriteLine($"{"Tax:",-20}{tax,15:C2}");
                    writer.WriteLine($"{"Other Deductions:",-20}{deductions,15:C2}");
                    writer.WriteLine(new string('=', 40));
                    writer.WriteLine($"{"NET SALARY:",-20}{netSalary,15:C2}");
                }

                MessageBox.Show($"Pay slip generated successfully!\n\nLocation: {filePath}",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating pay slip: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}