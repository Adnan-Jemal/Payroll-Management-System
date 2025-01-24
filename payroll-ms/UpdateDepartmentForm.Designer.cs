namespace PayrollApp
{
    partial class UpdateDepartmentForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label departmentLabel;
        private System.Windows.Forms.TextBox departmentTextbox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox descriptionTextbox;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ComboBox statusComboBox;

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
            this.departmentLabel = new System.Windows.Forms.Label();
            this.departmentTextbox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionTextbox = new System.Windows.Forms.TextBox();
            this.updateButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();

            // departmentLabel
            this.departmentLabel.AutoSize = true;
            this.departmentLabel.Location = new System.Drawing.Point(20, 20);
            this.departmentLabel.Name = "departmentLabel";
            this.departmentLabel.Size = new System.Drawing.Size(120, 16);
            this.departmentLabel.TabIndex = 0;
            this.departmentLabel.Text = "Department Name:";

            // departmentTextbox
            this.departmentTextbox.Location = new System.Drawing.Point(150, 20);
            this.departmentTextbox.Name = "departmentTextbox";
            this.departmentTextbox.Size = new System.Drawing.Size(200, 22);
            this.departmentTextbox.TabIndex = 1;

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

            // statusLabel
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(20, 100);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(50, 16);
            this.statusLabel.TabIndex = 4;
            this.statusLabel.Text = "Status:";

            // statusComboBox
            this.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Items.AddRange(new object[] { "Active", "Inactive" });
            this.statusComboBox.Location = new System.Drawing.Point(150, 100);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(200, 24);
            this.statusComboBox.TabIndex = 5;

            // updateButton
            this.updateButton.Location = new System.Drawing.Point(150, 140);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(120, 30);
            this.updateButton.TabIndex = 6;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);

            // UpdateDepartmentForm
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.statusComboBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.descriptionTextbox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.departmentTextbox);
            this.Controls.Add(this.departmentLabel);
            this.Name = "UpdateDepartmentForm";
            this.Text = "Update Department";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}