using System.Windows.Forms;

namespace PayrollApp
{
    partial class JobListForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox jobTitleComboBox;
        private System.Windows.Forms.ComboBox descriptionComboBox;
        private System.Windows.Forms.ComboBox employmentTypeComboBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label jobTitleLabel;  // Label for Job Title
        private System.Windows.Forms.Label descriptionLabel;  // Label for Description
        private System.Windows.Forms.Label employmentTypeLabel;  // Label for Employment Type

        private void InitializeComponent()
        {
            this.jobTitleComboBox = new System.Windows.Forms.ComboBox();
            this.descriptionComboBox = new System.Windows.Forms.ComboBox();
            this.employmentTypeComboBox = new System.Windows.Forms.ComboBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.jobTitleLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.employmentTypeLabel = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // JobTitle TextBox
            this.jobTitleComboBox.Location = new System.Drawing.Point(100, 30);
            this.jobTitleComboBox.Name = "jobTitleComboBox";
            this.jobTitleComboBox.Size = new System.Drawing.Size(200, 21);
            this.jobTitleComboBox.TabIndex = 0;

            // JobTitle Label
            this.jobTitleLabel.Location = new System.Drawing.Point(12, 30);
            this.jobTitleLabel.Name = "jobTitleLabel";
            this.jobTitleLabel.Size = new System.Drawing.Size(80, 20);
            this.jobTitleLabel.Text = "Job Title:";

            // Description TextBox
            this.descriptionComboBox.Location = new System.Drawing.Point(100, 60);
            this.descriptionComboBox.Name = "descriptionComboBox";
            this.descriptionComboBox.Size = new System.Drawing.Size(200, 21);
            this.descriptionComboBox.TabIndex = 1;

            // Description Label
            this.descriptionLabel.Location = new System.Drawing.Point(12, 60);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(80, 20);
            this.descriptionLabel.Text = "Description:";

            // Employment Type ComboBox
            this.employmentTypeComboBox.FormattingEnabled = true;
            this.employmentTypeComboBox.Location = new System.Drawing.Point(100, 90);
            this.employmentTypeComboBox.Name = "employmentTypeComboBox";
            this.employmentTypeComboBox.Size = new System.Drawing.Size(200, 21);
            this.employmentTypeComboBox.TabIndex = 2;
            this.employmentTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            // Employment Type Label
            this.employmentTypeLabel.Location = new System.Drawing.Point(12, 90);
            this.employmentTypeLabel.Name = "employmentTypeLabel";
            this.employmentTypeLabel.Size = new System.Drawing.Size(80, 20);
            this.employmentTypeLabel.Text = "Employment Type:";

            // Submit Button
            this.submitButton.Location = new System.Drawing.Point(150, 130);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(100, 30);
            this.submitButton.TabIndex = 3;
            this.submitButton.Text = "Add Job";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);

            // JobListForm
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.employmentTypeComboBox);
            this.Controls.Add(this.descriptionComboBox);
            this.Controls.Add(this.jobTitleComboBox);
            this.Controls.Add(this.jobTitleLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.employmentTypeLabel);
            this.Name = "JobListForm";
            this.Text = "Add Job";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
