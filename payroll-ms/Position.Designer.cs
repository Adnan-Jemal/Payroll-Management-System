using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PayrollApp
{
    partial class PositionForm
    {
        private System.ComponentModel.IContainer components = null;

        private TabControl mainTabControl;
        private TabPage listTabPage;
        private TabPage addTabPage;
        private DataGridView positionDataGridView;
        private Panel searchPanel;
        private TextBox searchTextBox;
        private Button searchButton;
        private ComboBox searchDepartmentComboBox;
        private Label searchDepartmentLabel;
        private TableLayoutPanel addFormLayout;
        private TextBox positionTextbox;
        private TextBox descriptionTextbox;
        private TextBox baseSalaryTextbox;
        private ComboBox departmentComboBox;
        private Button submitButton;
        private Label positionLabel;
        private Label descriptionLabel;
        private Label baseSalaryLabel;
        private Label departmentLabel;

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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();

            // Main Controls
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.listTabPage = new System.Windows.Forms.TabPage();
            this.positionDataGridView = new System.Windows.Forms.DataGridView();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchDepartmentComboBox = new System.Windows.Forms.ComboBox();
            this.searchDepartmentLabel = new System.Windows.Forms.Label();
            this.addTabPage = new System.Windows.Forms.TabPage();
            this.addFormLayout = new System.Windows.Forms.TableLayoutPanel();
            this.positionLabel = new System.Windows.Forms.Label();
            this.positionTextbox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionTextbox = new System.Windows.Forms.TextBox();
            this.baseSalaryLabel = new System.Windows.Forms.Label();
            this.baseSalaryTextbox = new System.Windows.Forms.TextBox();
            this.departmentLabel = new System.Windows.Forms.Label();
            this.departmentComboBox = new System.Windows.Forms.ComboBox();
            this.submitButton = new System.Windows.Forms.Button();

            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.listTabPage);
            this.mainTabControl.Controls.Add(this.addTabPage);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.mainTabControl.ItemSize = new System.Drawing.Size(120, 30);
            this.mainTabControl.Location = new System.Drawing.Point(0, 0);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(900, 600);
            this.mainTabControl.TabIndex = 0;

            // 
            // listTabPage
            // 
            this.listTabPage.Controls.Add(this.positionDataGridView);
            this.listTabPage.Controls.Add(this.searchPanel);
            this.listTabPage.Location = new System.Drawing.Point(4, 34);
            this.listTabPage.Name = "listTabPage";
            this.listTabPage.Padding = new System.Windows.Forms.Padding(10);
            this.listTabPage.Size = new System.Drawing.Size(892, 562);
            this.listTabPage.TabIndex = 0;
            this.listTabPage.Text = "Position List";

            // 
            // positionDataGridView
            // 
            this.positionDataGridView.AllowUserToAddRows = false;
            this.positionDataGridView.AllowUserToDeleteRows = false;
            this.positionDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.positionDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.positionDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.positionDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(158)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.positionDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.positionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.positionDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.positionDataGridView.EnableHeadersVisualStyles = false;
            this.positionDataGridView.Location = new System.Drawing.Point(10, 60);
            this.positionDataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.positionDataGridView.Name = "positionDataGridView";
            this.positionDataGridView.ReadOnly = true;
            this.positionDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            this.positionDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.positionDataGridView.RowTemplate.Height = 30;
            this.positionDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.positionDataGridView.Size = new System.Drawing.Size(872, 492);
            this.positionDataGridView.TabIndex = 1;

            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.searchTextBox);
            this.searchPanel.Controls.Add(this.searchButton);
            this.searchPanel.Controls.Add(this.searchDepartmentComboBox);
            this.searchPanel.Controls.Add(this.searchDepartmentLabel);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanel.Location = new System.Drawing.Point(10, 10);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(872, 50);
            this.searchPanel.TabIndex = 0;

            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.searchTextBox.Location = new System.Drawing.Point(0, 10);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(0, 10, 10, 10);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(300, 30);
            this.searchTextBox.TabIndex = 0;

            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(158)))));
            this.searchButton.FlatAppearance.BorderSize = 0;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.searchButton.ForeColor = System.Drawing.Color.White;
            this.searchButton.Location = new System.Drawing.Point(320, 10);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(100, 30);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = false;

            // 
            // searchDepartmentComboBox
            // 
            this.searchDepartmentComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchDepartmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchDepartmentComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.searchDepartmentComboBox.FormattingEnabled = true;
            this.searchDepartmentComboBox.Location = new System.Drawing.Point(560, 10);
            this.searchDepartmentComboBox.Name = "searchDepartmentComboBox";
            this.searchDepartmentComboBox.Size = new System.Drawing.Size(200, 31);
            this.searchDepartmentComboBox.TabIndex = 2;

            // 
            // searchDepartmentLabel
            // 
            this.searchDepartmentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchDepartmentLabel.AutoSize = true;
            this.searchDepartmentLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.searchDepartmentLabel.Location = new System.Drawing.Point(430, 13);
            this.searchDepartmentLabel.Name = "searchDepartmentLabel";
            this.searchDepartmentLabel.Size = new System.Drawing.Size(124, 23);
            this.searchDepartmentLabel.TabIndex = 3;
            this.searchDepartmentLabel.Text = "Department:";

            // 
            // addTabPage
            // 
            this.addTabPage.Controls.Add(this.addFormLayout);
            this.addTabPage.Location = new System.Drawing.Point(4, 34);
            this.addTabPage.Name = "addTabPage";
            this.addTabPage.Padding = new System.Windows.Forms.Padding(20);
            this.addTabPage.Size = new System.Drawing.Size(892, 562);
            this.addTabPage.TabIndex = 1;
            this.addTabPage.Text = "Add Position";

            // 
            // addFormLayout
            // 
            this.addFormLayout.ColumnCount = 2;
            this.addFormLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.addFormLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.addFormLayout.Controls.Add(this.positionLabel, 0, 0);
            this.addFormLayout.Controls.Add(this.positionTextbox, 1, 0);
            this.addFormLayout.Controls.Add(this.descriptionLabel, 0, 1);
            this.addFormLayout.Controls.Add(this.descriptionTextbox, 1, 1);
            this.addFormLayout.Controls.Add(this.baseSalaryLabel, 0, 2);
            this.addFormLayout.Controls.Add(this.baseSalaryTextbox, 1, 2);
            this.addFormLayout.Controls.Add(this.departmentLabel, 0, 3);
            this.addFormLayout.Controls.Add(this.departmentComboBox, 1, 3);
            this.addFormLayout.Controls.Add(this.submitButton, 1, 4);
            this.addFormLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.addFormLayout.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.addFormLayout.Location = new System.Drawing.Point(20, 20);
            this.addFormLayout.Name = "addFormLayout";
            this.addFormLayout.RowCount = 5;
            this.addFormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.addFormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.addFormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.addFormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.addFormLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.addFormLayout.Size = new System.Drawing.Size(852, 260);
            this.addFormLayout.TabIndex = 0;

            // 
            // positionLabel
            // 
            this.positionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.positionLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.positionLabel.Text = "Position Name:";
            this.positionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // positionTextbox
            // 
            this.positionTextbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.positionTextbox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.positionTextbox.Location = new System.Drawing.Point(153, 10);
            this.positionTextbox.Margin = new System.Windows.Forms.Padding(3, 10, 20, 10);
            this.positionTextbox.Name = "positionTextbox";
            this.positionTextbox.Size = new System.Drawing.Size(679, 30);
            this.positionTextbox.TabIndex = 0;

            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.descriptionLabel.Text = "Description:";
            this.descriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // descriptionTextbox
            // 
            this.descriptionTextbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.descriptionTextbox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.descriptionTextbox.Location = new System.Drawing.Point(153, 60);
            this.descriptionTextbox.Margin = new System.Windows.Forms.Padding(3, 10, 20, 10);
            this.descriptionTextbox.Name = "descriptionTextbox";
            this.descriptionTextbox.Size = new System.Drawing.Size(679, 30);
            this.descriptionTextbox.TabIndex = 1;

            // 
            // baseSalaryLabel
            // 
            this.baseSalaryLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseSalaryLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.baseSalaryLabel.Text = "Base Salary:";
            this.baseSalaryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // baseSalaryTextbox
            // 
            this.baseSalaryTextbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.baseSalaryTextbox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.baseSalaryTextbox.Location = new System.Drawing.Point(153, 110);
            this.baseSalaryTextbox.Margin = new System.Windows.Forms.Padding(3, 10, 20, 10);
            this.baseSalaryTextbox.Name = "baseSalaryTextbox";
            this.baseSalaryTextbox.Size = new System.Drawing.Size(679, 30);
            this.baseSalaryTextbox.TabIndex = 2;

            // 
            // departmentLabel
            // 
            this.departmentLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.departmentLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.departmentLabel.Text = "Department:";
            this.departmentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // departmentComboBox
            // 
            this.departmentComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.departmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.departmentComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.departmentComboBox.FormattingEnabled = true;
            this.departmentComboBox.Location = new System.Drawing.Point(153, 160);
            this.departmentComboBox.Margin = new System.Windows.Forms.Padding(3, 10, 20, 10);
            this.departmentComboBox.Name = "departmentComboBox";
            this.departmentComboBox.Size = new System.Drawing.Size(679, 31);
            this.departmentComboBox.TabIndex = 3;

            // 
            // submitButton
            // 
            this.submitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.submitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(158)))));
            this.submitButton.FlatAppearance.BorderSize = 0;
            this.submitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.submitButton.ForeColor = System.Drawing.Color.White;
            this.submitButton.Location = new System.Drawing.Point(672, 210);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(160, 40);
            this.submitButton.TabIndex = 4;
            this.submitButton.Text = "Add Position";
            this.submitButton.UseVisualStyleBackColor = false;

            // 
            // PositionForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.mainTabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "PositionForm";
            this.Size = new System.Drawing.Size(900, 600);
            this.mainTabControl.ResumeLayout(false);
            this.listTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.positionDataGridView)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.addTabPage.ResumeLayout(false);
            this.addFormLayout.ResumeLayout(false);
            this.addFormLayout.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}