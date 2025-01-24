namespace PayrollApp
{
    partial class AddEmployeeForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label departmentLabel;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Label dateOfEmploymentLabel;
        private System.Windows.Forms.DateTimePicker dateOfEmploymentPicker;
        private System.Windows.Forms.Button saveButton;

        // Payroll-related controls
        private System.Windows.Forms.Label basicSalaryLabel;
        private System.Windows.Forms.Label taxLabel;
        private System.Windows.Forms.TextBox taxTextBox;
        private System.Windows.Forms.Label payDateLabel;
        private System.Windows.Forms.DateTimePicker payDatePicker;

        private void InitializeComponent()
        {
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.departmentLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.dateOfEmploymentLabel = new System.Windows.Forms.Label();
            this.dateOfEmploymentPicker = new System.Windows.Forms.DateTimePicker();
            this.saveButton = new System.Windows.Forms.Button();
            this.basicSalaryLabel = new System.Windows.Forms.Label();
            this.taxLabel = new System.Windows.Forms.Label();
            this.taxTextBox = new System.Windows.Forms.TextBox();
            this.payDateLabel = new System.Windows.Forms.Label();
            this.payDatePicker = new System.Windows.Forms.DateTimePicker();
            this.cBoxAddEmpDep = new System.Windows.Forms.ComboBox();
            this.basicSalaryTextBox = new System.Windows.Forms.TextBox();
            this.lblAddEmpPosition = new System.Windows.Forms.Label();
            this.cBoxAddEmpPosition = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(30, 30);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(97, 32);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(120, 30);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(200, 38);
            this.nameTextBox.TabIndex = 1;
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(30, 70);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(158, 32);
            this.lastNameLabel.TabIndex = 2;
            this.lastNameLabel.Text = "Last Name:";
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(120, 70);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(200, 38);
            this.lastNameTextBox.TabIndex = 3;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(30, 110);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(94, 32);
            this.emailLabel.TabIndex = 4;
            this.emailLabel.Text = "Email:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(120, 110);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(200, 38);
            this.emailTextBox.TabIndex = 5;
            // 
            // departmentLabel
            // 
            this.departmentLabel.AutoSize = true;
            this.departmentLabel.Location = new System.Drawing.Point(30, 150);
            this.departmentLabel.Name = "departmentLabel";
            this.departmentLabel.Size = new System.Drawing.Size(170, 32);
            this.departmentLabel.TabIndex = 6;
            this.departmentLabel.Text = "Department:";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(30, 235);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(126, 32);
            this.addressLabel.TabIndex = 8;
            this.addressLabel.Text = "Address:";
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(120, 235);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(200, 38);
            this.addressTextBox.TabIndex = 9;
            // 
            // dateOfEmploymentLabel
            // 
            this.dateOfEmploymentLabel.AutoSize = true;
            this.dateOfEmploymentLabel.Location = new System.Drawing.Point(30, 275);
            this.dateOfEmploymentLabel.Name = "dateOfEmploymentLabel";
            this.dateOfEmploymentLabel.Size = new System.Drawing.Size(247, 32);
            this.dateOfEmploymentLabel.TabIndex = 10;
            this.dateOfEmploymentLabel.Text = "Employment Date:";
            // 
            // dateOfEmploymentPicker
            // 
            this.dateOfEmploymentPicker.Location = new System.Drawing.Point(120, 275);
            this.dateOfEmploymentPicker.Name = "dateOfEmploymentPicker";
            this.dateOfEmploymentPicker.Size = new System.Drawing.Size(200, 38);
            this.dateOfEmploymentPicker.TabIndex = 11;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(120, 448);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(200, 23);
            this.saveButton.TabIndex = 100;
            this.saveButton.Text = "Save Employee";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // basicSalaryLabel
            // 
            this.basicSalaryLabel.AutoSize = true;
            this.basicSalaryLabel.Location = new System.Drawing.Point(30, 315);
            this.basicSalaryLabel.Name = "basicSalaryLabel";
            this.basicSalaryLabel.Size = new System.Drawing.Size(180, 32);
            this.basicSalaryLabel.TabIndex = 12;
            this.basicSalaryLabel.Text = "Basic Salary:";
            // 
            // taxLabel
            // 
            this.taxLabel.AutoSize = true;
            this.taxLabel.Location = new System.Drawing.Point(30, 360);
            this.taxLabel.Name = "taxLabel";
            this.taxLabel.Size = new System.Drawing.Size(69, 32);
            this.taxLabel.TabIndex = 16;
            this.taxLabel.Text = "Tax:";
            // 
            // taxTextBox
            // 
            this.taxTextBox.Location = new System.Drawing.Point(120, 360);
            this.taxTextBox.Name = "taxTextBox";
            this.taxTextBox.Size = new System.Drawing.Size(200, 38);
            this.taxTextBox.TabIndex = 17;
            // 
            // payDateLabel
            // 
            this.payDateLabel.AutoSize = true;
            this.payDateLabel.Location = new System.Drawing.Point(30, 403);
            this.payDateLabel.Name = "payDateLabel";
            this.payDateLabel.Size = new System.Drawing.Size(138, 32);
            this.payDateLabel.TabIndex = 20;
            this.payDateLabel.Text = "Pay Date:";
            // 
            // payDatePicker
            // 
            this.payDatePicker.Location = new System.Drawing.Point(120, 403);
            this.payDatePicker.Name = "payDatePicker";
            this.payDatePicker.Size = new System.Drawing.Size(200, 38);
            this.payDatePicker.TabIndex = 21;
            // 
            // cBoxAddEmpDep
            // 
            this.cBoxAddEmpDep.FormattingEnabled = true;
            this.cBoxAddEmpDep.Location = new System.Drawing.Point(120, 150);
            this.cBoxAddEmpDep.Name = "cBoxAddEmpDep";
            this.cBoxAddEmpDep.Size = new System.Drawing.Size(200, 39);
            this.cBoxAddEmpDep.TabIndex = 101;
            this.cBoxAddEmpDep.SelectedIndexChanged += new System.EventHandler(this.cBoxAddEmpDep_SelectedIndexChanged);
            // 
            // basicSalaryTextBox
            // 
            this.basicSalaryTextBox.Location = new System.Drawing.Point(120, 315);
            this.basicSalaryTextBox.Name = "basicSalaryTextBox";
            this.basicSalaryTextBox.Size = new System.Drawing.Size(200, 38);
            this.basicSalaryTextBox.TabIndex = 13;
            // 
            // lblAddEmpPosition
            // 
            this.lblAddEmpPosition.AutoSize = true;
            this.lblAddEmpPosition.Location = new System.Drawing.Point(30, 192);
            this.lblAddEmpPosition.Name = "lblAddEmpPosition";
            this.lblAddEmpPosition.Size = new System.Drawing.Size(125, 32);
            this.lblAddEmpPosition.TabIndex = 102;
            this.lblAddEmpPosition.Text = "Position:";
            // 
            // cBoxAddEmpPosition
            // 
            this.cBoxAddEmpPosition.Enabled = false;
            this.cBoxAddEmpPosition.FormattingEnabled = true;
            this.cBoxAddEmpPosition.Location = new System.Drawing.Point(120, 192);
            this.cBoxAddEmpPosition.Name = "cBoxAddEmpPosition";
            this.cBoxAddEmpPosition.Size = new System.Drawing.Size(200, 39);
            this.cBoxAddEmpPosition.TabIndex = 103;
            this.cBoxAddEmpPosition.SelectedIndexChanged += new System.EventHandler(this.cBoxAddEmpPosition_SelectedIndexChanged);
            // 
            // AddEmployeeForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 515);
            this.Controls.Add(this.cBoxAddEmpPosition);
            this.Controls.Add(this.lblAddEmpPosition);
            this.Controls.Add(this.cBoxAddEmpDep);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.departmentLabel);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.dateOfEmploymentLabel);
            this.Controls.Add(this.dateOfEmploymentPicker);
            this.Controls.Add(this.basicSalaryLabel);
            this.Controls.Add(this.basicSalaryTextBox);
            this.Controls.Add(this.taxLabel);
            this.Controls.Add(this.taxTextBox);
            this.Controls.Add(this.payDateLabel);
            this.Controls.Add(this.payDatePicker);
            this.Controls.Add(this.saveButton);
            this.Name = "AddEmployeeForm";
            this.Text = "Add Employee";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private System.Windows.Forms.ComboBox cBoxAddEmpDep;
        private System.Windows.Forms.TextBox basicSalaryTextBox;
        private System.Windows.Forms.Label lblAddEmpPosition;
        private System.Windows.Forms.ComboBox cBoxAddEmpPosition;
    }
}
