using System.Windows.Forms;
using System;

namespace PayrollApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.LinkLabel resetPasswordLinkLabel;

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
            this.loginButton = new System.Windows.Forms.Button();
            this.resetPasswordLinkLabel = new System.Windows.Forms.LinkLabel();
            this.RegisterLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.usernameLabel.Location = new System.Drawing.Point(50, 50);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(214, 46);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Username:";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.usernameTextBox.Location = new System.Drawing.Point(170, 50);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(250, 53);
            this.usernameTextBox.TabIndex = 1;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.passwordLabel.Location = new System.Drawing.Point(50, 100);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(207, 46);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.passwordTextBox.Location = new System.Drawing.Point(170, 100);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(250, 53);
            this.passwordTextBox.TabIndex = 3;
            // 
            // loginButton
            // 
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.loginButton.Location = new System.Drawing.Point(170, 150);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(120, 40);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // resetPasswordLinkLabel
            // 
            this.resetPasswordLinkLabel.AutoSize = true;
            this.resetPasswordLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline);
            this.resetPasswordLinkLabel.Location = new System.Drawing.Point(170, 210);
            this.resetPasswordLinkLabel.Name = "resetPasswordLinkLabel";
            this.resetPasswordLinkLabel.Size = new System.Drawing.Size(284, 39);
            this.resetPasswordLinkLabel.TabIndex = 5;
            this.resetPasswordLinkLabel.TabStop = true;
            this.resetPasswordLinkLabel.Text = "Reset Password?";
            this.resetPasswordLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ResetPasswordLinkLabel_LinkClicked);
            // 
            // RegisterLinkLabel
            // 
            this.RegisterLinkLabel.AutoSize = true;
            this.RegisterLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline);
            this.RegisterLinkLabel.Location = new System.Drawing.Point(12, 252);
            this.RegisterLinkLabel.Name = "RegisterLinkLabel";
            this.RegisterLinkLabel.Size = new System.Drawing.Size(517, 39);
            this.RegisterLinkLabel.TabIndex = 6;
            this.RegisterLinkLabel.TabStop = true;
            this.RegisterLinkLabel.Text = "Do\'nt have an account? Register.";
            this.RegisterLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RegisterLinkLabel_LinkClicked);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.RegisterLinkLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.resetPasswordLinkLabel);
            this.Name = "Form1";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private LinkLabel RegisterLinkLabel;
    }
}
