using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using payroll_ms;

namespace PayrollApp
{
    public partial class AttendanceForm : UserControl
    {
        private string connectionString = Program.connectionString;
        private int currentMonth;
        private int currentYear;
        private ToolTip statusToolTip;
        public AttendanceForm()
        {
            InitializeComponent();
            InitializeComboBoxes();
            WireEvents();
            ConfigureToolTips();
        }
        private void ConfigureToolTips()
        {
            statusToolTip = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 300,
                ReshowDelay = 500
            };

            // Set tooltip text for all comboboxes
            statusToolTip.SetToolTip(buttonGenerateGrid, "Generate attendance grid for selected month/year");
            statusToolTip.SetToolTip(comboBoxMonth, "Select month for attendance records");
            statusToolTip.SetToolTip(comboBoxYear, "Select year for attendance records");
        }

        private void InitializeComboBoxes()
        {
            // Initialize months
            comboBoxMonth.Items.AddRange(CultureInfo.CurrentCulture.DateTimeFormat.MonthNames
                .Where(m => !string.IsNullOrEmpty(m)).ToArray());
            comboBoxMonth.SelectedIndex = DateTime.Now.Month - 1;

            // Initialize years
            comboBoxYear.Items.AddRange(Enumerable.Range(2000, DateTime.Now.Year - 1999)
                .Select(y => y.ToString()).Reverse().ToArray());
            comboBoxYear.SelectedItem = DateTime.Now.Year.ToString();
        }

        private void WireEvents()
        {
            buttonGenerateGrid.Click += ButtonGenerateGrid_Click;
        }

        private void ButtonGenerateGrid_Click(object sender, EventArgs e)
        {
            if (comboBoxMonth.SelectedItem == null || comboBoxYear.SelectedItem == null)
            {
                MessageBox.Show("Please select a valid month and year.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            currentMonth = Array.FindIndex(CultureInfo.CurrentCulture.DateTimeFormat.MonthNames,
                m => m == comboBoxMonth.SelectedItem.ToString()) + 1;
            currentYear = int.Parse(comboBoxYear.SelectedItem.ToString());

            if (new DateTime(currentYear, currentMonth, 1) > DateTime.Now)
            {
                MessageBox.Show("Cannot generate attendance for future months.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PopulateAttendanceGrid();
        }

        private void PopulateAttendanceGrid()
        {
            gridLayout.Controls.Clear();
            gridLayout.ColumnStyles.Clear();
            gridLayout.RowStyles.Clear();

            int daysInMonth = DateTime.DaysInMonth(currentYear, currentMonth);

            // Configure columns
            gridLayout.ColumnCount = daysInMonth + 1;
            gridLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150)); // Employee ID column
            for (int i = 1; i <= daysInMonth; i++)
            {
                gridLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));
            }

            // Add header row
            AddHeaderRow(daysInMonth);

            // Load data
            var employees = LoadEmployeesFromDatabase();
            var attendanceData = LoadAttendanceFromDatabase();

            // Add employee rows
            for (int row = 0; row < employees.Count; row++)
            {
                AddEmployeeRow(row + 1, employees[row],
                    attendanceData.ContainsKey(employees[row]) ? attendanceData[employees[row]] : null);
            }

            gridLayout.Size = gridLayout.PreferredSize;
        }

        private List<string> LoadEmployeesFromDatabase()
        {
            var employees = new List<string>();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("SELECT EmployeeId FROM Employees", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) employees.Add(reader["EmployeeId"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return employees;
        }

        private Dictionary<string, Dictionary<int, string>> LoadAttendanceFromDatabase()
        {
            var data = new Dictionary<string, Dictionary<int, string>>();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("GetAttendanceByMonthYear", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Month", currentMonth);
                        cmd.Parameters.AddWithValue("@Year", currentYear);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var empId = reader["EmployeeId"].ToString();
                                var day = Convert.ToInt32(reader["Day"]);
                                var status = reader["AttendanceStatus"].ToString();

                                if (!data.ContainsKey(empId)) data[empId] = new Dictionary<int, string>();
                                data[empId][day] = status;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading attendance: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return data;
        }

        private void AddHeaderRow(int days)
        {
            var legendLabel = new Label
            {
                Text = "Attendance Legend: √=Present, X=Absent, L=Leave",
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                ForeColor = Color.Gray,
                Dock = DockStyle.Bottom
            };

            panelSearch.Controls.Add(legendLabel);
            legendLabel.BringToFront();

            // Rest of your existing header code...
       
            gridLayout.RowCount = 1;
            gridLayout.Controls.Add(new Label
            {
                Text = "Employee ID",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            }, 0, 0);

            for (int day = 1; day <= days; day++)
            {
                gridLayout.Controls.Add(new Label
                {
                    Text = day.ToString(),
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                }, day, 0);
            }
        }

        private void AddEmployeeRow(int rowIndex, string employeeId, Dictionary<int, string> attendance)
        {
            gridLayout.RowCount++;
            gridLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));

            // Employee ID
            gridLayout.Controls.Add(new Label
            {
                Text = employeeId,
                Font = new Font("Segoe UI", 10),
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill
            }, 0, rowIndex);

            // Day cells
            for (int day = 1; day <= gridLayout.ColumnCount - 1; day++)
            {
                var cb = new ComboBox
                {
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Font = new Font("Segoe UI", 9),
                    Dock = DockStyle.Fill,
                    Tag = new { EmployeeId = employeeId, Day = day }
                };

                cb.Items.AddRange(new[] { "√", "X", "L" });
                cb.SelectedIndex = attendance != null && attendance.ContainsKey(day) ?
                    Array.IndexOf(new[] { "√", "X", "L" }, attendance[day]) : 0;

                // Add tooltip to the combobox
                statusToolTip.SetToolTip(cb,
                    "Attendance Status Legend:\n" +
                    "√ - Present\n" +
                    "X - Absent\n" +
                    "L - Leave");

                cb.SelectedIndexChanged += (s, e) => SaveAttendance(cb);
                gridLayout.Controls.Add(cb, day, rowIndex);
            }
        }

        private void SaveAttendance(ComboBox cb)
        {
            var tag = (dynamic)cb.Tag;
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("SaveAttendance", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeeId", tag.EmployeeId);
                        cmd.Parameters.AddWithValue("@Date", new DateTime(currentYear, currentMonth, tag.Day));
                        cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 1).Value = cb.SelectedItem.ToString();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving attendance: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}