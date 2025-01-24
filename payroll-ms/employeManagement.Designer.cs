using System;

namespace PayrollApp
{
    partial class EmployeeManagement
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView employeeDataGridView;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button addEmployeeButton; // New button for adding employees

        private void InitializeComponent()
        {
            this.employeeDataGridView = new System.Windows.Forms.DataGridView();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.updateButton = new System.Windows.Forms.Button();
            this.addEmployeeButton = new System.Windows.Forms.Button(); // Initialize the New Employee button

            ((System.ComponentModel.ISupportInitialize)(this.employeeDataGridView)).BeginInit();
            this.SuspendLayout();

            // Search Panel
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanel.Padding = new System.Windows.Forms.Padding(10);
            this.searchPanel.Controls.Add(this.searchTextBox);
            this.searchPanel.Controls.Add(this.searchButton);
            this.searchPanel.Controls.Add(this.updateButton);
            this.searchPanel.Controls.Add(this.addEmployeeButton); // Add the New Employee button to the search panel
            this.searchPanel.Height = 90;

            // Update Button
            this.updateButton.Location = new System.Drawing.Point(320, 12);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(100, 23);
            this.updateButton.TabIndex = 3;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);

            // Add Employee Button
            this.addEmployeeButton.Location = new System.Drawing.Point(430, 12);
            this.addEmployeeButton.Name = "addEmployeeButton";
            this.addEmployeeButton.Size = new System.Drawing.Size(120, 23);
            this.addEmployeeButton.TabIndex = 4;
            this.addEmployeeButton.Text = "Add New Employee";
            this.addEmployeeButton.UseVisualStyleBackColor = true;
            this.addEmployeeButton.Click += new System.EventHandler(this.addEmployeeButton_Click);

            // Search TextBox
            this.searchTextBox.Location = new System.Drawing.Point(12, 12);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(200, 20);
            this.searchTextBox.TabIndex = 1;

            // Search Button
            this.searchButton.Location = new System.Drawing.Point(220, 12);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);

            // Main Panel (Holding both the DataGridView and the Search Panel)
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Controls.Add(this.employeeDataGridView);
            this.mainPanel.Controls.Add(this.searchPanel);

            // Employee DataGridView
            this.employeeDataGridView.AllowUserToAddRows = false;
            this.employeeDataGridView.AllowUserToDeleteRows = false;
            this.employeeDataGridView.AllowUserToOrderColumns = true;
            this.employeeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.employeeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeeDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeeDataGridView.Location = new System.Drawing.Point(0, 50);
            this.employeeDataGridView.Name = "employeeDataGridView";
            this.employeeDataGridView.ReadOnly = true;
            this.employeeDataGridView.RowHeadersWidth = 51;
            this.employeeDataGridView.RowTemplate.Height = 24;
            this.employeeDataGridView.Size = new System.Drawing.Size(800, 370);
            this.employeeDataGridView.TabIndex = 0;

            // EmployeeManagement
            this.Controls.Add(this.mainPanel);
            this.Name = "EmployeeManagement";
            this.Size = new System.Drawing.Size(800, 450);

            ((System.ComponentModel.ISupportInitialize)(this.employeeDataGridView)).EndInit();
            this.ResumeLayout(false);
        }

      
    }
}

