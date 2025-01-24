namespace PayrollApp
{
    partial class BonusForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabNewBonus = new System.Windows.Forms.TabPage();
            this.formPanel = new System.Windows.Forms.Panel();
            this.employeeSelectLabel = new System.Windows.Forms.Label();
            this.employeeDropdown = new System.Windows.Forms.ComboBox();
            this.amountLabel = new System.Windows.Forms.Label();
            this.amountNumeric = new System.Windows.Forms.NumericUpDown();
            this.dateLabel = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.tabViewBonuses = new System.Windows.Forms.TabPage();
            this.bonusesGrid = new System.Windows.Forms.DataGridView();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabNewBonus.SuspendLayout();
            this.formPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountNumeric)).BeginInit();
            this.tabViewBonuses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bonusesGrid)).BeginInit();
            this.searchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabNewBonus);
            this.tabControl.Controls.Add(this.tabViewBonuses);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.ItemSize = new System.Drawing.Size(120, 40);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(600, 400);
            this.tabControl.TabIndex = 0;
            // 
            // tabNewBonus
            // 
            this.tabNewBonus.BackColor = System.Drawing.Color.White;
            this.tabNewBonus.Controls.Add(this.formPanel);
            this.tabNewBonus.Location = new System.Drawing.Point(4, 44);
            this.tabNewBonus.Name = "tabNewBonus";
            this.tabNewBonus.Padding = new System.Windows.Forms.Padding(3);
            this.tabNewBonus.Size = new System.Drawing.Size(592, 352);
            this.tabNewBonus.TabIndex = 0;
            this.tabNewBonus.Text = "New Bonus";
            // 
            // formPanel
            // 
            this.formPanel.BackColor = System.Drawing.Color.White;
            this.formPanel.Controls.Add(this.employeeSelectLabel);
            this.formPanel.Controls.Add(this.employeeDropdown);
            this.formPanel.Controls.Add(this.amountLabel);
            this.formPanel.Controls.Add(this.amountNumeric);
            this.formPanel.Controls.Add(this.dateLabel);
            this.formPanel.Controls.Add(this.datePicker);
            this.formPanel.Controls.Add(this.descriptionLabel);
            this.formPanel.Controls.Add(this.descriptionTextBox);
            this.formPanel.Controls.Add(this.submitButton);
            this.formPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.formPanel.Location = new System.Drawing.Point(3, 3);
            this.formPanel.Name = "formPanel";
            this.formPanel.Padding = new System.Windows.Forms.Padding(20);
            this.formPanel.Size = new System.Drawing.Size(586, 320);
            this.formPanel.TabIndex = 0;
            // 
            // employeeSelectLabel
            // 
            this.employeeSelectLabel.AutoSize = true;
            this.employeeSelectLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.employeeSelectLabel.Location = new System.Drawing.Point(20, 20);
            this.employeeSelectLabel.Name = "employeeSelectLabel";
            this.employeeSelectLabel.Size = new System.Drawing.Size(104, 17);
            this.employeeSelectLabel.TabIndex = 0;
            this.employeeSelectLabel.Text = "Select Employee:";
            // 
            // employeeDropdown
            // 
            this.employeeDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.employeeDropdown.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.employeeDropdown.FormattingEnabled = true;
            this.employeeDropdown.Location = new System.Drawing.Point(140, 17);
            this.employeeDropdown.Name = "employeeDropdown";
            this.employeeDropdown.Size = new System.Drawing.Size(300, 25);
            this.employeeDropdown.TabIndex = 1;
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.amountLabel.Location = new System.Drawing.Point(20, 60);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(93, 17);
            this.amountLabel.TabIndex = 2;
            this.amountLabel.Text = "Bonus Amount:";
            // 
            // amountNumeric
            // 
            this.amountNumeric.DecimalPlaces = 2;
            this.amountNumeric.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.amountNumeric.Location = new System.Drawing.Point(140, 58);
            this.amountNumeric.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.amountNumeric.Name = "amountNumeric";
            this.amountNumeric.Size = new System.Drawing.Size(300, 25);
            this.amountNumeric.TabIndex = 3;
            this.amountNumeric.ThousandsSeparator = true;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dateLabel.Location = new System.Drawing.Point(20, 140);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(37, 17);
            this.dateLabel.TabIndex = 4;
            this.dateLabel.Text = "Date:";
            // 
            // datePicker
            // 
            this.datePicker.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker.Location = new System.Drawing.Point(140, 134);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(300, 25);
            this.datePicker.TabIndex = 5;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.descriptionLabel.Location = new System.Drawing.Point(20, 100);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(76, 17);
            this.descriptionLabel.TabIndex = 6;
            this.descriptionLabel.Text = "Description:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.descriptionTextBox.Location = new System.Drawing.Point(140, 97);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(300, 25);
            this.descriptionTextBox.TabIndex = 7;
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);
            this.submitButton.FlatAppearance.BorderSize = 0;
            this.submitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.submitButton.ForeColor = System.Drawing.Color.White;
            this.submitButton.Location = new System.Drawing.Point(140, 180);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(100, 30);
            this.submitButton.TabIndex = 8;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = false;
            // 
            // tabViewBonuses
            // 
            this.tabViewBonuses.Controls.Add(this.bonusesGrid);
            this.tabViewBonuses.Controls.Add(this.searchPanel);
            this.tabViewBonuses.Location = new System.Drawing.Point(4, 44);
            this.tabViewBonuses.Name = "tabViewBonuses";
            this.tabViewBonuses.Padding = new System.Windows.Forms.Padding(3);
            this.tabViewBonuses.Size = new System.Drawing.Size(592, 352);
            this.tabViewBonuses.TabIndex = 1;
            this.tabViewBonuses.Text = "View Bonuses";
            // 
            // bonusesGrid
            // 
            this.bonusesGrid.AllowUserToAddRows = false;
            this.bonusesGrid.AllowUserToDeleteRows = false;
            this.bonusesGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bonusesGrid.BackgroundColor = System.Drawing.Color.White;
            this.bonusesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bonusesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bonusesGrid.Location = new System.Drawing.Point(3, 63);
            this.bonusesGrid.Name = "bonusesGrid";
            this.bonusesGrid.ReadOnly = true;
            this.bonusesGrid.RowHeadersVisible = false;
            this.bonusesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bonusesGrid.Size = new System.Drawing.Size(586, 286);
            this.bonusesGrid.TabIndex = 1;
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.searchTextBox);
            this.searchPanel.Controls.Add(this.searchButton);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanel.Location = new System.Drawing.Point(3, 3);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(586, 60);
            this.searchPanel.TabIndex = 0;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.searchTextBox.Location = new System.Drawing.Point(12, 12);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(200, 25);
            this.searchTextBox.TabIndex = 0;
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);
            this.searchButton.FlatAppearance.BorderSize = 0;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.searchButton.ForeColor = System.Drawing.Color.White;
            this.searchButton.Location = new System.Drawing.Point(222, 10);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(100, 30);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = false;
            // 
            // BonusForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControl);
            this.Name = "BonusForm";
            this.Size = new System.Drawing.Size(600, 400);
            this.tabControl.ResumeLayout(false);
            this.tabNewBonus.ResumeLayout(false);
            this.formPanel.ResumeLayout(false);
            this.formPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountNumeric)).EndInit();
            this.tabViewBonuses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bonusesGrid)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabNewBonus;
        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.Label employeeSelectLabel;
        private System.Windows.Forms.ComboBox employeeDropdown;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.NumericUpDown amountNumeric;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.TabPage tabViewBonuses;
        private System.Windows.Forms.DataGridView bonusesGrid;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
    }
}