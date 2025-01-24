namespace PayrollApp
{
    partial class UpdateDeductibleForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.TextBox descriptionTextbox;
        private System.Windows.Forms.NumericUpDown amountTextbox;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button cancelButton;

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
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.amountLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.descriptionTextbox = new System.Windows.Forms.TextBox();
            this.amountTextbox = new System.Windows.Forms.NumericUpDown();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.updateButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.amountTextbox)).BeginInit();
            this.SuspendLayout();

            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Location = new System.Drawing.Point(20, 20);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(120, 23);
            this.descriptionLabel.TabIndex = 0;
            this.descriptionLabel.Text = "Description:";

            // 
            // amountLabel
            // 
            this.amountLabel.Location = new System.Drawing.Point(20, 60);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(120, 23);
            this.amountLabel.TabIndex = 1;
            this.amountLabel.Text = "Amount:";

            // 
            // dateLabel
            // 
            this.dateLabel.Location = new System.Drawing.Point(20, 100);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(120, 23);
            this.dateLabel.TabIndex = 2;
            this.dateLabel.Text = "Date:";

            // 
            // descriptionTextbox
            // 
            this.descriptionTextbox.Location = new System.Drawing.Point(140, 20);
            this.descriptionTextbox.Name = "descriptionTextbox";
            this.descriptionTextbox.Size = new System.Drawing.Size(200, 26);
            this.descriptionTextbox.TabIndex = 3;

            // 
            // amountTextbox
            // 
            this.amountTextbox.Location = new System.Drawing.Point(140, 60);
            this.amountTextbox.Name = "amountTextbox";
            this.amountTextbox.Size = new System.Drawing.Size(200, 26);
            this.amountTextbox.TabIndex = 4;

            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(140, 100);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(200, 26);
            this.datePicker.TabIndex = 5;

            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(140, 140);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(100, 30);
            this.updateButton.TabIndex = 6;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);

            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(260, 140);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 30);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);

            // 
            // UpdateDeductibleForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.amountLabel);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.descriptionTextbox);
            this.Controls.Add(this.amountTextbox);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "UpdateDeductibleForm";
            this.Text = "Update Deductible";
            ((System.ComponentModel.ISupportInitialize)(this.amountTextbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}