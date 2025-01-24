using System.Windows.Forms;
using System.Drawing;

namespace PayrollApp
{
    partial class DeductibleForm
    {
        private System.ComponentModel.IContainer components = null;

        private TabControl tabControl;
        private TabPage tabNewDeductible;
        private TabPage tabViewDeductibles;
        private ComboBox employeeDropdown;
        private TextBox descriptionTextBox;
        private NumericUpDown amountNumeric;
        private DateTimePicker datePicker;
        private Button submitButton;
        private DataGridView deductiblesGrid;
        private Label employeeSelectLabel;
        private Label descriptionLabel;
        private Label amountLabel;
        private Label dateLabel;
        private Panel formPanel;
        private Panel searchPanel;
        private TextBox searchTextBox;
        private Button searchButton;

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
            this.tabNewDeductible = new System.Windows.Forms.TabPage();
            this.formPanel = new System.Windows.Forms.Panel();
            this.employeeSelectLabel = new System.Windows.Forms.Label();
            this.employeeDropdown = new System.Windows.Forms.ComboBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.amountLabel = new System.Windows.Forms.Label();
            this.amountNumeric = new System.Windows.Forms.NumericUpDown();
            this.dateLabel = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.submitButton = new System.Windows.Forms.Button();
            this.tabViewDeductibles = new System.Windows.Forms.TabPage();
            this.deductiblesGrid = new System.Windows.Forms.DataGridView();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabNewDeductible.SuspendLayout();
            this.formPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountNumeric)).BeginInit();
            this.tabViewDeductibles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deductiblesGrid)).BeginInit();
            this.searchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabNewDeductible);
            this.tabControl.Controls.Add(this.tabViewDeductibles);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(600, 400);
            this.tabControl.TabIndex = 0;
            // 
            // tabNewDeductible
            // 
            this.tabNewDeductible.Controls.Add(this.formPanel);
            this.tabNewDeductible.Location = new System.Drawing.Point(10, 48);
            this.tabNewDeductible.Name = "tabNewDeductible";
            this.tabNewDeductible.Padding = new System.Windows.Forms.Padding(3);
            this.tabNewDeductible.Size = new System.Drawing.Size(580, 342);
            this.tabNewDeductible.TabIndex = 0;
            this.tabNewDeductible.Text = "New Deductible";
            this.tabNewDeductible.UseVisualStyleBackColor = true;
            // 
            // formPanel
            // 
            this.formPanel.Controls.Add(this.employeeSelectLabel);
            this.formPanel.Controls.Add(this.employeeDropdown);
            this.formPanel.Controls.Add(this.descriptionLabel);
            this.formPanel.Controls.Add(this.descriptionTextBox);
            this.formPanel.Controls.Add(this.amountLabel);
            this.formPanel.Controls.Add(this.amountNumeric);
            this.formPanel.Controls.Add(this.dateLabel);
            this.formPanel.Controls.Add(this.datePicker);
            this.formPanel.Controls.Add(this.submitButton);
            this.formPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.formPanel.Location = new System.Drawing.Point(3, 3);
            this.formPanel.Name = "formPanel";
            this.formPanel.Padding = new System.Windows.Forms.Padding(20);
            this.formPanel.Size = new System.Drawing.Size(574, 300);
            this.formPanel.TabIndex = 0;
            // 
            // employeeSelectLabel
            // 
            this.employeeSelectLabel.AutoSize = true;
            this.employeeSelectLabel.Location = new System.Drawing.Point(20, 20);
            this.employeeSelectLabel.Name = "employeeSelectLabel";
            this.employeeSelectLabel.Size = new System.Drawing.Size(236, 32);
            this.employeeSelectLabel.TabIndex = 0;
            this.employeeSelectLabel.Text = "Select Employee:";
            this.employeeSelectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // employeeDropdown
            // 
            this.employeeDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.employeeDropdown.FormattingEnabled = true;
            this.employeeDropdown.Location = new System.Drawing.Point(160, 17);
            this.employeeDropdown.Name = "employeeDropdown";
            this.employeeDropdown.Size = new System.Drawing.Size(300, 39);
            this.employeeDropdown.TabIndex = 1;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(20, 60);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(165, 32);
            this.descriptionLabel.TabIndex = 2;
            this.descriptionLabel.Text = "Description:";
            this.descriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(160, 57);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(300, 38);
            this.descriptionTextBox.TabIndex = 3;
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(20, 100);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(120, 32);
            this.amountLabel.TabIndex = 4;
            this.amountLabel.Text = "Amount:";
            this.amountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // amountNumeric
            // 
            this.amountNumeric.DecimalPlaces = 2;
            this.amountNumeric.Location = new System.Drawing.Point(160, 97);
            this.amountNumeric.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.amountNumeric.Name = "amountNumeric";
            this.amountNumeric.Size = new System.Drawing.Size(300, 38);
            this.amountNumeric.TabIndex = 5;
            this.amountNumeric.ThousandsSeparator = true;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(20, 140);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(82, 32);
            this.dateLabel.TabIndex = 6;
            this.dateLabel.Text = "Date:";
            this.dateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(160, 137);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(300, 38);
            this.datePicker.TabIndex = 7;
            // 
            // submitButton
            // 
            this.submitButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.submitButton.Location = new System.Drawing.Point(160, 180);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(288, 35);
            this.submitButton.TabIndex = 8;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // tabViewDeductibles
            // 
            this.tabViewDeductibles.Controls.Add(this.deductiblesGrid);
            this.tabViewDeductibles.Controls.Add(this.searchPanel);
            this.tabViewDeductibles.Location = new System.Drawing.Point(10, 48);
            this.tabViewDeductibles.Name = "tabViewDeductibles";
            this.tabViewDeductibles.Padding = new System.Windows.Forms.Padding(3);
            this.tabViewDeductibles.Size = new System.Drawing.Size(580, 342);
            this.tabViewDeductibles.TabIndex = 1;
            this.tabViewDeductibles.Text = "View Deductibles";
            this.tabViewDeductibles.UseVisualStyleBackColor = true;
            // 
            // deductiblesGrid
            // 
            this.deductiblesGrid.AllowUserToAddRows = false;
            this.deductiblesGrid.AllowUserToDeleteRows = false;
            this.deductiblesGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.deductiblesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.deductiblesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deductiblesGrid.Location = new System.Drawing.Point(3, 63);
            this.deductiblesGrid.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.deductiblesGrid.Name = "deductiblesGrid";
            this.deductiblesGrid.ReadOnly = true;
            this.deductiblesGrid.RowHeadersWidth = 51;
            this.deductiblesGrid.RowTemplate.Height = 24;
            this.deductiblesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.deductiblesGrid.Size = new System.Drawing.Size(574, 276);
            this.deductiblesGrid.TabIndex = 1;
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.searchTextBox);
            this.searchPanel.Controls.Add(this.searchButton);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanel.Location = new System.Drawing.Point(3, 3);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Padding = new System.Windows.Forms.Padding(10);
            this.searchPanel.Size = new System.Drawing.Size(574, 60);
            this.searchPanel.TabIndex = 0;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.Location = new System.Drawing.Point(10, 15);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(388, 38);
            this.searchTextBox.TabIndex = 0;
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Location = new System.Drawing.Point(408, 12);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(100, 32);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // DeductibleForm
            // 
            this.Controls.Add(this.tabControl);
            this.Name = "DeductibleForm";
            this.Size = new System.Drawing.Size(600, 400);
            this.tabControl.ResumeLayout(false);
            this.tabNewDeductible.ResumeLayout(false);
            this.formPanel.ResumeLayout(false);
            this.formPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountNumeric)).EndInit();
            this.tabViewDeductibles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deductiblesGrid)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}