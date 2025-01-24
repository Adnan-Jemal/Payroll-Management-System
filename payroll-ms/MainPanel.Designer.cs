using System.Windows.Forms;
using System;
using System.Drawing;

namespace PayrollApp
{
    partial class MainPanelForm
    {
        private System.ComponentModel.IContainer components = null;

        // Navigation panel initialization
        private System.Windows.Forms.Panel navigationPanel;
        private System.Windows.Forms.Button dashboardButton;
        private System.Windows.Forms.Button employeeManagementButton;
        private System.Windows.Forms.Button deductionButton;
        private System.Windows.Forms.Button bonusButton;
        private System.Windows.Forms.Button payrollButton;
        private System.Windows.Forms.Button attendanceButton;
        private System.Windows.Forms.Button positionButton;
        private System.Windows.Forms.Button departmentButton;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel borderPanel;

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
            this.navigationPanel = new System.Windows.Forms.Panel();
            this.dashboardButton = new System.Windows.Forms.Button();
            this.employeeManagementButton = new System.Windows.Forms.Button();
            this.attendanceButton = new System.Windows.Forms.Button();
            this.payrollButton = new System.Windows.Forms.Button();
            this.positionButton = new System.Windows.Forms.Button();
            this.departmentButton = new System.Windows.Forms.Button();
            this.deductionButton = new System.Windows.Forms.Button();
            this.bonusButton = new System.Windows.Forms.Button();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.borderPanel = new System.Windows.Forms.Panel();
            this.navigationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigationPanel
            // 
            this.navigationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.navigationPanel.Controls.Add(this.dashboardButton);
            this.navigationPanel.Controls.Add(this.employeeManagementButton);
            this.navigationPanel.Controls.Add(this.attendanceButton);
            this.navigationPanel.Controls.Add(this.payrollButton);
            this.navigationPanel.Controls.Add(this.positionButton);
            this.navigationPanel.Controls.Add(this.departmentButton);
            this.navigationPanel.Controls.Add(this.deductionButton);
            this.navigationPanel.Controls.Add(this.bonusButton);
            this.navigationPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.navigationPanel.Location = new System.Drawing.Point(0, 0);
            this.navigationPanel.Name = "navigationPanel";
            this.navigationPanel.Size = new System.Drawing.Size(250, 504);
            this.navigationPanel.TabIndex = 1;
            // 
            // dashboardButton
            // 
            this.dashboardButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.dashboardButton.FlatAppearance.BorderSize = 0;
            this.dashboardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardButton.ForeColor = System.Drawing.Color.White;
            this.dashboardButton.Location = new System.Drawing.Point(10, 34);
            this.dashboardButton.Name = "dashboardButton";
            this.dashboardButton.Size = new System.Drawing.Size(230, 50);
            this.dashboardButton.TabIndex = 0;
            this.dashboardButton.Text = "Dashboard";
            this.dashboardButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashboardButton.UseVisualStyleBackColor = true;
            this.dashboardButton.Click += new System.EventHandler(this.dashboardButton_Click);
            // 
            // employeeManagementButton
            // 
            this.employeeManagementButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.employeeManagementButton.FlatAppearance.BorderSize = 0;
            this.employeeManagementButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.employeeManagementButton.ForeColor = System.Drawing.Color.White;
            this.employeeManagementButton.Location = new System.Drawing.Point(10, 90);
            this.employeeManagementButton.Name = "employeeManagementButton";
            this.employeeManagementButton.Size = new System.Drawing.Size(230, 50);
            this.employeeManagementButton.TabIndex = 1;
            this.employeeManagementButton.Text = "Employee Management";
            this.employeeManagementButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.employeeManagementButton.UseVisualStyleBackColor = true;
            this.employeeManagementButton.Click += new System.EventHandler(this.employeeManagementButton_Click);
            // 
            // attendanceButton
            // 
            this.attendanceButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.attendanceButton.FlatAppearance.BorderSize = 0;
            this.attendanceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.attendanceButton.ForeColor = System.Drawing.Color.White;
            this.attendanceButton.Location = new System.Drawing.Point(10, 426);
            this.attendanceButton.Name = "attendanceButton";
            this.attendanceButton.Size = new System.Drawing.Size(230, 50);
            this.attendanceButton.TabIndex = 2;
            this.attendanceButton.Text = "Attendance";
            this.attendanceButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.attendanceButton.UseVisualStyleBackColor = true;
            this.attendanceButton.Click += new System.EventHandler(this.attendanceButton_Click);
            // 
            // payrollButton
            // 
            this.payrollButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.payrollButton.FlatAppearance.BorderSize = 0;
            this.payrollButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.payrollButton.ForeColor = System.Drawing.Color.White;
            this.payrollButton.Location = new System.Drawing.Point(10, 370);
            this.payrollButton.Name = "payrollButton";
            this.payrollButton.Size = new System.Drawing.Size(230, 50);
            this.payrollButton.TabIndex = 3;
            this.payrollButton.Text = "Payments";
            this.payrollButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.payrollButton.UseVisualStyleBackColor = true;
            this.payrollButton.Click += new System.EventHandler(this.payrollButton_Click);
            // 
            // positionButton
            // 
            this.positionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.positionButton.FlatAppearance.BorderSize = 0;
            this.positionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.positionButton.ForeColor = System.Drawing.Color.White;
            this.positionButton.Location = new System.Drawing.Point(10, 258);
            this.positionButton.Name = "positionButton";
            this.positionButton.Size = new System.Drawing.Size(230, 50);
            this.positionButton.TabIndex = 4;
            this.positionButton.Text = "Position list";
            this.positionButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.positionButton.UseVisualStyleBackColor = true;
            this.positionButton.Click += new System.EventHandler(this.positionButton_Click);
            // 
            // departmentButton
            // 
            this.departmentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.departmentButton.FlatAppearance.BorderSize = 0;
            this.departmentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.departmentButton.ForeColor = System.Drawing.Color.White;
            this.departmentButton.Location = new System.Drawing.Point(10, 314);
            this.departmentButton.Name = "departmentButton";
            this.departmentButton.Size = new System.Drawing.Size(230, 50);
            this.departmentButton.TabIndex = 5;
            this.departmentButton.Text = "Department list";
            this.departmentButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.departmentButton.UseVisualStyleBackColor = true;
            this.departmentButton.Click += new System.EventHandler(this.departmentButton_Click);
            // 
            // deductionButton
            // 
            this.deductionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.deductionButton.FlatAppearance.BorderSize = 0;
            this.deductionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deductionButton.ForeColor = System.Drawing.Color.White;
            this.deductionButton.Location = new System.Drawing.Point(10, 146);
            this.deductionButton.Name = "deductionButton";
            this.deductionButton.Size = new System.Drawing.Size(230, 50);
            this.deductionButton.TabIndex = 6;
            this.deductionButton.Text = "Deductions";
            this.deductionButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deductionButton.UseVisualStyleBackColor = true;
            this.deductionButton.Click += new System.EventHandler(this.deductiblesButton_Click);
            // 
            // bonusButton
            // 
            this.bonusButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.bonusButton.FlatAppearance.BorderSize = 0;
            this.bonusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bonusButton.ForeColor = System.Drawing.Color.White;
            this.bonusButton.Location = new System.Drawing.Point(10, 202);
            this.bonusButton.Name = "bonusButton";
            this.bonusButton.Size = new System.Drawing.Size(230, 50);
            this.bonusButton.TabIndex = 7;
            this.bonusButton.Text = "Bonus";
            this.bonusButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bonusButton.UseVisualStyleBackColor = true;
            this.bonusButton.Click += new System.EventHandler(this.bonusButton_Click);
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(250, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(850, 504);
            this.contentPanel.TabIndex = 0;
            // 
            // borderPanel
            // 
            this.borderPanel.BackColor = System.Drawing.Color.Black;
            this.borderPanel.Location = new System.Drawing.Point(250, 0);
            this.borderPanel.Name = "borderPanel";
            this.borderPanel.Size = new System.Drawing.Size(10, 500);
            this.borderPanel.TabIndex = 2;
            // 
            // MainPanelForm
            // 
            this.ClientSize = new System.Drawing.Size(1100, 504);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.navigationPanel);
            this.Controls.Add(this.borderPanel);
            this.Name = "MainPanelForm";
            this.Text = "Payroll Managment System";
            this.navigationPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

    }
}


