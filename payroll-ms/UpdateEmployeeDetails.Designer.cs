namespace PayrollApp
{
    partial class UpdateEmployeeDetails
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.Label departmentLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label positionLabel;
        private System.Windows.Forms.Label baseSalaryLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.ComboBox departmentComboBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.ComboBox positionComboBox;
        private System.Windows.Forms.TextBox baseSalaryTextBox;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;

        private void InitializeComponent()
        {
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.departmentLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.positionLabel = new System.Windows.Forms.Label();
            this.baseSalaryLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.departmentComboBox = new System.Windows.Forms.ComboBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.positionComboBox = new System.Windows.Forms.ComboBox();
            this.baseSalaryTextBox = new System.Windows.Forms.TextBox();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // FirstName Label
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(30, 30);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(60, 13);
            this.firstNameLabel.Text = "First Name";

            // FirstName TextBox
            this.firstNameTextBox.Location = new System.Drawing.Point(150, 27);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(250, 20);

            // LastName Label
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(30, 70);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(61, 13);
            this.lastNameLabel.Text = "Last Name";

            // LastName TextBox
            this.lastNameTextBox.Location = new System.Drawing.Point(150, 67);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(250, 20);

            // Department Label
            this.departmentLabel.AutoSize = true;
            this.departmentLabel.Location = new System.Drawing.Point(30, 110);
            this.departmentLabel.Name = "departmentLabel";
            this.departmentLabel.Size = new System.Drawing.Size(65, 13);
            this.departmentLabel.Text = "Department";

            // Department ComboBox
            this.departmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.departmentComboBox.FormattingEnabled = true;
            this.departmentComboBox.Location = new System.Drawing.Point(150, 107);
            this.departmentComboBox.Name = "departmentComboBox";
            this.departmentComboBox.Size = new System.Drawing.Size(250, 21);

            // Email Label
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(30, 150);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(32, 13);
            this.emailLabel.Text = "Email";

            // Email TextBox
            this.emailTextBox.Location = new System.Drawing.Point(150, 147);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(250, 20);

            // Address Label
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(30, 190);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(45, 13);
            this.addressLabel.Text = "Address";

            // Address TextBox
            this.addressTextBox.Location = new System.Drawing.Point(150, 187);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(250, 20);

            // Position Label
            this.positionLabel.AutoSize = true;
            this.positionLabel.Location = new System.Drawing.Point(30, 230);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(44, 13);
            this.positionLabel.Text = "Position";

            // Position ComboBox
            this.positionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.positionComboBox.FormattingEnabled = true;
            this.positionComboBox.Location = new System.Drawing.Point(150, 227);
            this.positionComboBox.Name = "positionComboBox";
            this.positionComboBox.Size = new System.Drawing.Size(250, 21);

            // BaseSalary Label
            this.baseSalaryLabel.AutoSize = true;
            this.baseSalaryLabel.Location = new System.Drawing.Point(30, 270);
            this.baseSalaryLabel.Name = "baseSalaryLabel";
            this.baseSalaryLabel.Size = new System.Drawing.Size(65, 13);
            this.baseSalaryLabel.Text = "Base Salary";

            // BaseSalary TextBox
            this.baseSalaryTextBox.Location = new System.Drawing.Point(150, 267);
            this.baseSalaryTextBox.Name = "baseSalaryTextBox";
            this.baseSalaryTextBox.Size = new System.Drawing.Size(250, 20);

            // Status Label
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(30, 310);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(37, 13);
            this.statusLabel.Text = "Status";

            // Status ComboBox
            this.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Items.AddRange(new object[] { "Active", "Inactive" });
            this.statusComboBox.Location = new System.Drawing.Point(150, 307);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(250, 21);

            // Save Button
            this.saveButton.Location = new System.Drawing.Point(150, 350);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 30);
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);

            // Cancel Button
            this.cancelButton.Location = new System.Drawing.Point(300, 350);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 30);
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);

            // UpdateEmployeeDetails Form
            this.ClientSize = new System.Drawing.Size(450, 400);
            this.Controls.Add(this.firstNameLabel);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.departmentLabel);
            this.Controls.Add(this.departmentComboBox);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.positionLabel);
            this.Controls.Add(this.positionComboBox);
            this.Controls.Add(this.baseSalaryLabel);
            this.Controls.Add(this.baseSalaryTextBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.statusComboBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "UpdateEmployeeDetails";
            this.Text = "Update Employee Details";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}