namespace PayrollApp
{
    partial class DepartmentForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage departmentListTab;
        private System.Windows.Forms.TabPage addDepartmentTab;
        private System.Windows.Forms.DataGridView departmentDataGridView;
        private System.Windows.Forms.TextBox departmentTextbox;
        private System.Windows.Forms.TextBox descriptionTextbox;
        private System.Windows.Forms.Label departmentLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.TextBox searchTextbox;
        private System.Windows.Forms.Button searchButton;

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.departmentListTab = new System.Windows.Forms.TabPage();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.departmentDataGridView = new System.Windows.Forms.DataGridView();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.searchTextbox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.addDepartmentTab = new System.Windows.Forms.TabPage();
            this.departmentLabel = new System.Windows.Forms.Label();
            this.departmentTextbox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionTextbox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.departmentListTab.SuspendLayout();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.departmentDataGridView)).BeginInit();
            this.searchPanel.SuspendLayout();
            this.addDepartmentTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.addDepartmentTab);
            this.tabControl.Controls.Add(this.departmentListTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 450);
            this.tabControl.TabIndex = 0;
            // 
            // departmentListTab
            // 
            this.departmentListTab.Controls.Add(this.mainPanel);
            this.departmentListTab.Location = new System.Drawing.Point(4, 29);
            this.departmentListTab.Name = "departmentListTab";
            this.departmentListTab.Padding = new System.Windows.Forms.Padding(3);
            this.departmentListTab.Size = new System.Drawing.Size(792, 417);
            this.departmentListTab.TabIndex = 0;
            this.departmentListTab.Text = "Department List";
            this.departmentListTab.UseVisualStyleBackColor = true;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.departmentDataGridView);
            this.mainPanel.Controls.Add(this.searchPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(3, 3);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(786, 411);
            this.mainPanel.TabIndex = 0;
            // 
            // departmentDataGridView
            // 
            this.departmentDataGridView.AllowUserToAddRows = false;
            this.departmentDataGridView.AllowUserToDeleteRows = false;
            this.departmentDataGridView.AllowUserToOrderColumns = true;
            this.departmentDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.departmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.departmentDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.departmentDataGridView.Location = new System.Drawing.Point(0, 55);
            this.departmentDataGridView.Name = "departmentDataGridView";
            this.departmentDataGridView.ReadOnly = true;
            this.departmentDataGridView.RowHeadersWidth = 51;
            this.departmentDataGridView.RowTemplate.Height = 24;
            this.departmentDataGridView.Size = new System.Drawing.Size(786, 356);
            this.departmentDataGridView.TabIndex = 0;
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.searchTextbox);
            this.searchPanel.Controls.Add(this.searchButton);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanel.Location = new System.Drawing.Point(0, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Padding = new System.Windows.Forms.Padding(10);
            this.searchPanel.Size = new System.Drawing.Size(786, 55);
            this.searchPanel.TabIndex = 1;
            // 
            // searchTextbox
            // 
            this.searchTextbox.Location = new System.Drawing.Point(12, 12);
            this.searchTextbox.Name = "searchTextbox";
            this.searchTextbox.Size = new System.Drawing.Size(200, 26);
            this.searchTextbox.TabIndex = 1;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(220, 12);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // addDepartmentTab
            // 
            this.addDepartmentTab.Controls.Add(this.departmentLabel);
            this.addDepartmentTab.Controls.Add(this.departmentTextbox);
            this.addDepartmentTab.Controls.Add(this.descriptionLabel);
            this.addDepartmentTab.Controls.Add(this.descriptionTextbox);
            this.addDepartmentTab.Controls.Add(this.submitButton);
            this.addDepartmentTab.Location = new System.Drawing.Point(4, 29);
            this.addDepartmentTab.Name = "addDepartmentTab";
            this.addDepartmentTab.Padding = new System.Windows.Forms.Padding(3);
            this.addDepartmentTab.Size = new System.Drawing.Size(192, 67);
            this.addDepartmentTab.TabIndex = 1;
            this.addDepartmentTab.Text = "Add New Department";
            this.addDepartmentTab.UseVisualStyleBackColor = true;
            // 
            // departmentLabel
            // 
            this.departmentLabel.Location = new System.Drawing.Point(6, 20);
            this.departmentLabel.Name = "departmentLabel";
            this.departmentLabel.Size = new System.Drawing.Size(120, 23);
            this.departmentLabel.TabIndex = 4;
            this.departmentLabel.Text = "Department Name:";
            // 
            // departmentTextbox
            // 
            this.departmentTextbox.Location = new System.Drawing.Point(140, 20);
            this.departmentTextbox.Name = "departmentTextbox";
            this.departmentTextbox.Size = new System.Drawing.Size(200, 26);
            this.departmentTextbox.TabIndex = 5;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Location = new System.Drawing.Point(6, 60);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(120, 23);
            this.descriptionLabel.TabIndex = 6;
            this.descriptionLabel.Text = "Description:";
            // 
            // descriptionTextbox
            // 
            this.descriptionTextbox.Location = new System.Drawing.Point(140, 60);
            this.descriptionTextbox.Name = "descriptionTextbox";
            this.descriptionTextbox.Size = new System.Drawing.Size(200, 26);
            this.descriptionTextbox.TabIndex = 7;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(140, 120);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(120, 23);
            this.submitButton.TabIndex = 2;
            this.submitButton.Text = "Add Department";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // DepartmentForm
            // 
            this.Controls.Add(this.tabControl);
            this.Name = "DepartmentForm";
            this.Size = new System.Drawing.Size(800, 450);
            this.tabControl.ResumeLayout(false);
            this.departmentListTab.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.departmentDataGridView)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.addDepartmentTab.ResumeLayout(false);
            this.addDepartmentTab.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}

