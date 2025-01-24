namespace PayrollApp
{
    partial class UpdatePositionForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label positionLabel;
        private System.Windows.Forms.TextBox positionTextbox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox descriptionTextbox;
        private System.Windows.Forms.Label baseSalaryLabel;
        private System.Windows.Forms.TextBox baseSalaryTextbox;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label departmentLabel;
        private System.Windows.Forms.ComboBox departmentComboBox;

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
            this.positionLabel = new System.Windows.Forms.Label();
            this.positionTextbox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionTextbox = new System.Windows.Forms.TextBox();
            this.baseSalaryLabel = new System.Windows.Forms.Label();
            this.baseSalaryTextbox = new System.Windows.Forms.TextBox();
            this.updateButton = new System.Windows.Forms.Button();
            this.departmentLabel = new System.Windows.Forms.Label();
            this.departmentComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();

            // positionLabel
            this.positionLabel.AutoSize = true;
            this.positionLabel.Location = new System.Drawing.Point(20, 20);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(120, 16);
            this.positionLabel.TabIndex = 0;
            this.positionLabel.Text = "Position Name:";

            // positionTextbox
            this.positionTextbox.Location = new System.Drawing.Point(150, 20);
            this.positionTextbox.Name = "positionTextbox";
            this.positionTextbox.Size = new System.Drawing.Size(200, 22);
            this.positionTextbox.TabIndex = 1;

            // descriptionLabel
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(20, 60);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(83, 16);
            this.descriptionLabel.TabIndex = 2;
            this.descriptionLabel.Text = "Description:";

            // descriptionTextbox
            this.descriptionTextbox.Location = new System.Drawing.Point(150, 60);
            this.descriptionTextbox.Name = "descriptionTextbox";
            this.descriptionTextbox.Size = new System.Drawing.Size(200, 22);
            this.descriptionTextbox.TabIndex = 3;

            // baseSalaryLabel
            this.baseSalaryLabel.AutoSize = true;
            this.baseSalaryLabel.Location = new System.Drawing.Point(20, 100);
            this.baseSalaryLabel.Name = "baseSalaryLabel";
            this.baseSalaryLabel.Size = new System.Drawing.Size(86, 16);
            this.baseSalaryLabel.TabIndex = 4;
            this.baseSalaryLabel.Text = "Base Salary:";

            // baseSalaryTextbox
            this.baseSalaryTextbox.Location = new System.Drawing.Point(150, 100);
            this.baseSalaryTextbox.Name = "baseSalaryTextbox";
            this.baseSalaryTextbox.Size = new System.Drawing.Size(200, 22);
            this.baseSalaryTextbox.TabIndex = 5;

            // departmentLabel
            this.departmentLabel.AutoSize = true;
            this.departmentLabel.Location = new System.Drawing.Point(20, 140);
            this.departmentLabel.Name = "departmentLabel";
            this.departmentLabel.Size = new System.Drawing.Size(80, 16);
            this.departmentLabel.TabIndex = 6;
            this.departmentLabel.Text = "Department:";

            // departmentComboBox
            this.departmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.departmentComboBox.FormattingEnabled = true;
            this.departmentComboBox.Location = new System.Drawing.Point(150, 140);
            this.departmentComboBox.Name = "departmentComboBox";
            this.departmentComboBox.Size = new System.Drawing.Size(200, 24);
            this.departmentComboBox.TabIndex = 7;

            // updateButton
            this.updateButton.Location = new System.Drawing.Point(150, 180);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(120, 30);
            this.updateButton.TabIndex = 8;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);

            // UpdatePositionForm
            this.ClientSize = new System.Drawing.Size(400, 230);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.departmentComboBox);
            this.Controls.Add(this.departmentLabel);
            this.Controls.Add(this.baseSalaryTextbox);
            this.Controls.Add(this.baseSalaryLabel);
            this.Controls.Add(this.descriptionTextbox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.positionTextbox);
            this.Controls.Add(this.positionLabel);
            this.Name = "UpdatePositionForm";
            this.Text = "Update Position";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}