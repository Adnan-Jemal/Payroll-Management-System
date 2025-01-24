using System.Windows.Forms;

namespace PayrollApp
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.LinkLabel loginLinkLabel;

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
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.loginLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();

            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.usernameLabel.Location = new System.Drawing.Point(50, 50);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(91, 20);
            this.usernameLabel.Text = "Username:";

            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.usernameTextBox.Location = new System.Drawing.Point(170, 50);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(250, 26);

            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.passwordLabel.Location = new System.Drawing.Point(50, 100);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(86, 20);
            this.passwordLabel.Text = "Password:";

            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.passwordTextBox.Location = new System.Drawing.Point(170, 100);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(250, 26);

            // 
            // registerButton
            // 
            this.registerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.registerButton.Location = new System.Drawing.Point(170, 150);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(120, 40);
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);

            // 
            // loginLinkLabel
            // 
            this.loginLinkLabel.AutoSize = true;
            this.loginLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline);
            this.loginLinkLabel.Location = new System.Drawing.Point(170, 210);
            this.loginLinkLabel.Name = "loginLinkLabel";
            this.loginLinkLabel.Size = new System.Drawing.Size(150, 17);
            this.loginLinkLabel.TabIndex = 5;
            this.loginLinkLabel.TabStop = true;
            this.loginLinkLabel.Text = "Already have an account? Login";
            this.loginLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.loginLinkLabel_LinkClicked);

            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.loginLinkLabel);
            this.Name = "Form2";
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}