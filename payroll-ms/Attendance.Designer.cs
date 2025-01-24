namespace PayrollApp
{
    partial class AttendanceForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelMonth;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Panel panelTableContainer;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.ComboBox comboBoxYear;
        private System.Windows.Forms.Button buttonGenerateGrid;
        private System.Windows.Forms.TableLayoutPanel gridLayout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.panelSearch = new System.Windows.Forms.Panel();
            this.labelMonth = new System.Windows.Forms.Label();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.labelYear = new System.Windows.Forms.Label();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.buttonGenerateGrid = new System.Windows.Forms.Button();
            this.panelTableContainer = new System.Windows.Forms.Panel();
            this.gridLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panelSearch.SuspendLayout();
            this.panelTableContainer.SuspendLayout();
            this.SuspendLayout();

            // panelSearch
            this.panelSearch.BackColor = System.Drawing.Color.White;
            this.panelSearch.Controls.Add(this.labelMonth);
            this.panelSearch.Controls.Add(this.comboBoxMonth);
            this.panelSearch.Controls.Add(this.labelYear);
            this.panelSearch.Controls.Add(this.comboBoxYear);
            this.panelSearch.Controls.Add(this.buttonGenerateGrid);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(1200, 80);
            this.panelSearch.TabIndex = 1;

            // labelMonth
            this.labelMonth.AutoSize = true;
            this.labelMonth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMonth.Location = new System.Drawing.Point(30, 20);
            this.labelMonth.Name = "labelMonth";
            this.labelMonth.Size = new System.Drawing.Size(75, 21);
            this.labelMonth.TabIndex = 0;
            this.labelMonth.Text = "Month:";

            // comboBoxMonth
            this.comboBoxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMonth.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Location = new System.Drawing.Point(110, 16);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(150, 29);
            this.comboBoxMonth.TabIndex = 1;

            // labelYear
            this.labelYear.AutoSize = true;
            this.labelYear.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelYear.Location = new System.Drawing.Point(290, 20);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(47, 21);
            this.labelYear.TabIndex = 2;
            this.labelYear.Text = "Year:";

            // comboBoxYear
            this.comboBoxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxYear.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Location = new System.Drawing.Point(343, 16);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(100, 29);
            this.comboBoxYear.TabIndex = 3;

            // buttonGenerateGrid
            this.buttonGenerateGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.buttonGenerateGrid.FlatAppearance.BorderSize = 0;
            this.buttonGenerateGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenerateGrid.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.buttonGenerateGrid.ForeColor = System.Drawing.Color.White;
            this.buttonGenerateGrid.Location = new System.Drawing.Point(470, 16);
            this.buttonGenerateGrid.Name = "buttonGenerateGrid";
            this.buttonGenerateGrid.Size = new System.Drawing.Size(180, 36);
            this.buttonGenerateGrid.TabIndex = 4;
            this.buttonGenerateGrid.Text = "Show Attendance";
            this.buttonGenerateGrid.UseVisualStyleBackColor = false;

            // panelTableContainer
            this.panelTableContainer.AutoScroll = true;
            this.panelTableContainer.BackColor = System.Drawing.Color.White;
            this.panelTableContainer.Controls.Add(this.gridLayout);
            this.panelTableContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTableContainer.Location = new System.Drawing.Point(0, 80);
            this.panelTableContainer.Name = "panelTableContainer";
            this.panelTableContainer.Padding = new System.Windows.Forms.Padding(20);
            this.panelTableContainer.Size = new System.Drawing.Size(1200, 520);
            this.panelTableContainer.TabIndex = 0;

            // gridLayout
            this.gridLayout.AutoSize = true;
            this.gridLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gridLayout.BackColor = System.Drawing.Color.White;
            this.gridLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.gridLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.gridLayout.Location = new System.Drawing.Point(20, 20);
            this.gridLayout.Name = "gridLayout";
            this.gridLayout.RowCount = 1;
            this.gridLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.gridLayout.Size = new System.Drawing.Size(150, 0);
            this.gridLayout.TabIndex = 0;

            // AttendanceForm
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelTableContainer);
            this.Controls.Add(this.panelSearch);
            this.Name = "AttendanceForm";
            this.Size = new System.Drawing.Size(1200, 600);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelTableContainer.ResumeLayout(false);
            this.panelTableContainer.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}