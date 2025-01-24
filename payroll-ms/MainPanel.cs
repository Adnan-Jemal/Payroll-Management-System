using System;
using System.Drawing;
using System.Windows.Forms;


namespace PayrollApp
{
    public partial class MainPanelForm : Form
    {
        public MainPanelForm()
        {
            InitializeComponent();
        }

        private void dashboardButton_Click(object sender, EventArgs e)
        {
            // Show the Dashboard section
            ShowSection(new Dashboard());
        }

        private void employeeManagementButton_Click(object sender, EventArgs e)
        {
            // Show the Employee Management section
            ShowSection(new EmployeeManagement());
        }
        
        private void deductiblesButton_Click(object sender, EventArgs e)
        {
            // Show the Deductibles section
            ShowSection(new DeductibleForm());
        }

        private void bonusButton_Click(object sender, EventArgs e)
        {
            // Show the Bonus section
            ShowSection(new BonusForm()); // Make sure you have a BonusForm or similar
        }

        private void departmentButton_Click(object sender, EventArgs e)
        {
            // Show the Department section
            ShowSection(new DepartmentForm());
        }

        private void positionButton_Click(object sender, EventArgs e)
        {
            // Show the Positions section
            ShowSection(new PositionForm()); // Assuming you have a PositionsForm or similar
        }

        private void attendanceButton_Click(object sender, EventArgs e)
        {
            // Show the Positions section
            ShowSection(new AttendanceForm()); // Assuming you have a PositionsForm or similar
        }

        private void payrollButton_Click(object sender, EventArgs e)
        {
            // Show the Dashboard section
            ShowSection(new PayrollForm());
        }



        // Method to load the selected section into the content panel
        private void ShowSection(Control section)
        {
            contentPanel.Controls.Clear();  // Clear existing content
            section.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(section);  // Add new section to content panel
        }
    }
}