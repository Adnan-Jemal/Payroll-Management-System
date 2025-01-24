namespace PayrollApp
{
    partial class GeneratePaySlipForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label employeeDetailsLabel;
        private System.Windows.Forms.Label emailLabel; // Added label

        // Required designer variable.
        private void InitializeComponent()
        {
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.employeeDetailsLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(12, 25);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(200, 38);
            this.emailTextBox.TabIndex = 0;
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(12, 60);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 1;
            this.generateButton.Text = "Generate Pay Slip";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // employeeDetailsLabel
            // 
            this.employeeDetailsLabel.AutoSize = true;
            this.employeeDetailsLabel.Location = new System.Drawing.Point(12, 100);
            this.employeeDetailsLabel.Name = "employeeDetailsLabel";
            this.employeeDetailsLabel.Size = new System.Drawing.Size(236, 32);
            this.employeeDetailsLabel.TabIndex = 2;
            this.employeeDetailsLabel.Text = "Employee Details";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(12, 5);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(205, 32);
            this.emailLabel.TabIndex = 3;
            this.emailLabel.Text = "Email Address:";
            // 
            // GeneratePaySlipForm
            // 
            this.ClientSize = new System.Drawing.Size(483, 349);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.employeeDetailsLabel);
            this.Name = "GeneratePaySlipForm";
            this.Text = "Generate Pay Slip";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Clean up any resources being used.
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}