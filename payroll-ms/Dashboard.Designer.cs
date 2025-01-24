using System.Windows.Forms;
using System;

namespace PayrollApp
{
    partial class Dashboard
    {
        private System.ComponentModel.IContainer components = null;
        private Label totalPayrollLabel;
        private Label numberOfEmployeesLabel;
        private ListBox upcomingPaymentsListBox;
        private Label employeeCountLabel;
        private Label averageSalaryLabel;
        private ListBox newHiresListBox;
        private Label recentPayrollRunLabel;
        private Button addEmployeeButton;
        private Button generatePaySlipButton;
        private Button processPayrollButton;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label label1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.totalPayrollLabel = new System.Windows.Forms.Label();
            this.numberOfEmployeesLabel = new System.Windows.Forms.Label();
            this.upcomingPaymentsListBox = new System.Windows.Forms.ListBox();
            this.employeeCountLabel = new System.Windows.Forms.Label();
            this.averageSalaryLabel = new System.Windows.Forms.Label();
            this.newHiresListBox = new System.Windows.Forms.ListBox();
            this.recentPayrollRunLabel = new System.Windows.Forms.Label();
            this.addEmployeeButton = new System.Windows.Forms.Button();
            this.generatePaySlipButton = new System.Windows.Forms.Button();
            this.processPayrollButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // totalPayrollLabel
            // 
            this.totalPayrollLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.totalPayrollLabel.ForeColor = System.Drawing.Color.White;
            this.totalPayrollLabel.Location = new System.Drawing.Point(20, 60);
            this.totalPayrollLabel.Name = "totalPayrollLabel";
            this.totalPayrollLabel.Size = new System.Drawing.Size(300, 25);
            this.totalPayrollLabel.TabIndex = 3;
            this.totalPayrollLabel.Text = "Total Payroll for the Month: $0";
            // 
            // numberOfEmployeesLabel
            // 
            this.numberOfEmployeesLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.numberOfEmployeesLabel.ForeColor = System.Drawing.Color.White;
            this.numberOfEmployeesLabel.Location = new System.Drawing.Point(20, 100);
            this.numberOfEmployeesLabel.Name = "numberOfEmployeesLabel";
            this.numberOfEmployeesLabel.Size = new System.Drawing.Size(300, 25);
            this.numberOfEmployeesLabel.TabIndex = 4;
            this.numberOfEmployeesLabel.Text = "Number of Employees: 0";
            // 
            // upcomingPaymentsListBox
            // 
            this.upcomingPaymentsListBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.upcomingPaymentsListBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.upcomingPaymentsListBox.ItemHeight = 23;
            this.upcomingPaymentsListBox.Location = new System.Drawing.Point(20, 140);
            this.upcomingPaymentsListBox.Name = "upcomingPaymentsListBox";
            this.upcomingPaymentsListBox.Size = new System.Drawing.Size(300, 119);
            this.upcomingPaymentsListBox.TabIndex = 5;
            // 
            // employeeCountLabel
            // 
            this.employeeCountLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.employeeCountLabel.ForeColor = System.Drawing.Color.White;
            this.employeeCountLabel.Location = new System.Drawing.Point(350, 60);
            this.employeeCountLabel.Name = "employeeCountLabel";
            this.employeeCountLabel.Size = new System.Drawing.Size(300, 25);
            this.employeeCountLabel.TabIndex = 6;
            this.employeeCountLabel.Text = "Employee Count: 0";
            // 
            // averageSalaryLabel
            // 
            this.averageSalaryLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.averageSalaryLabel.ForeColor = System.Drawing.Color.White;
            this.averageSalaryLabel.Location = new System.Drawing.Point(350, 100);
            this.averageSalaryLabel.Name = "averageSalaryLabel";
            this.averageSalaryLabel.Size = new System.Drawing.Size(300, 25);
            this.averageSalaryLabel.TabIndex = 7;
            this.averageSalaryLabel.Text = "Average Salary: $0";
            // 
            // newHiresListBox
            // 
            this.newHiresListBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.newHiresListBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.newHiresListBox.ItemHeight = 23;
            this.newHiresListBox.Location = new System.Drawing.Point(350, 140);
            this.newHiresListBox.Name = "newHiresListBox";
            this.newHiresListBox.Size = new System.Drawing.Size(300, 119);
            this.newHiresListBox.TabIndex = 8;
            // 
            // recentPayrollRunLabel
            // 
            this.recentPayrollRunLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.recentPayrollRunLabel.ForeColor = System.Drawing.Color.White;
            this.recentPayrollRunLabel.Location = new System.Drawing.Point(20, 280);
            this.recentPayrollRunLabel.Name = "recentPayrollRunLabel";
            this.recentPayrollRunLabel.Size = new System.Drawing.Size(300, 25);
            this.recentPayrollRunLabel.TabIndex = 9;
            this.recentPayrollRunLabel.Text = "Recent Payroll Run: -";
            // 
            // addEmployeeButton
            // 
            this.addEmployeeButton.BackColor = System.Drawing.Color.SteelBlue;
            this.addEmployeeButton.ForeColor = System.Drawing.Color.White;
            this.addEmployeeButton.Location = new System.Drawing.Point(20, 320);
            this.addEmployeeButton.Name = "addEmployeeButton";
            this.addEmployeeButton.Size = new System.Drawing.Size(160, 40);
            this.addEmployeeButton.TabIndex = 10;
            this.addEmployeeButton.Text = "Add New Employee";
            this.addEmployeeButton.UseVisualStyleBackColor = false;
            this.addEmployeeButton.Click += new System.EventHandler(this.addEmployeeButton_Click);
            // 
            // generatePaySlipButton
            // 
            this.generatePaySlipButton.BackColor = System.Drawing.Color.SteelBlue;
            this.generatePaySlipButton.ForeColor = System.Drawing.Color.White;
            this.generatePaySlipButton.Location = new System.Drawing.Point(200, 320);
            this.generatePaySlipButton.Name = "generatePaySlipButton";
            this.generatePaySlipButton.Size = new System.Drawing.Size(160, 40);
            this.generatePaySlipButton.TabIndex = 11;
            this.generatePaySlipButton.Text = "Generate Pay Slip";
            this.generatePaySlipButton.UseVisualStyleBackColor = false;
            this.generatePaySlipButton.Click += new System.EventHandler(this.generatePaySlipButton_Click);
            // 
            // processPayrollButton
            // 
            this.processPayrollButton.BackColor = System.Drawing.Color.SteelBlue;
            this.processPayrollButton.ForeColor = System.Drawing.Color.White;
            this.processPayrollButton.Location = new System.Drawing.Point(380, 320);
            this.processPayrollButton.Name = "processPayrollButton";
            this.processPayrollButton.Size = new System.Drawing.Size(160, 40);
            this.processPayrollButton.TabIndex = 12;
            this.processPayrollButton.Text = "Process Payroll";
            this.processPayrollButton.UseVisualStyleBackColor = false;
            this.processPayrollButton.Click += new System.EventHandler(this.ProcessPayrollButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1378, 52);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Payroll Dashboard";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1378, 10);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 824);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1378, 10);
            this.panel3.TabIndex = 2;
            // 
            // Dashboard
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.totalPayrollLabel);
            this.Controls.Add(this.numberOfEmployeesLabel);
            this.Controls.Add(this.upcomingPaymentsListBox);
            this.Controls.Add(this.employeeCountLabel);
            this.Controls.Add(this.averageSalaryLabel);
            this.Controls.Add(this.newHiresListBox);
            this.Controls.Add(this.recentPayrollRunLabel);
            this.Controls.Add(this.addEmployeeButton);
            this.Controls.Add(this.generatePaySlipButton);
            this.Controls.Add(this.processPayrollButton);
            this.Name = "Dashboard";
            this.Size = new System.Drawing.Size(1378, 834);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}