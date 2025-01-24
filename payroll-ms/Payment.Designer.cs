using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System;

namespace PayrollApp
{
    public partial class PayrollForm : UserControl
    {
        private Panel panelSearch;
        private Panel panelTableContainer;
        private ComboBox comboBoxMonth;
        private ComboBox comboBoxYear;
        private Button buttonGeneratePayroll;
        private TableLayoutPanel gridLayout;
        private TableLayoutPanel searchLayout;

        private void InitializeComponent()
        {
            // Initialize components
            this.panelSearch = new Panel();
            this.searchLayout = new TableLayoutPanel();
            this.panelTableContainer = new Panel();
            this.comboBoxMonth = new ComboBox();
            this.comboBoxYear = new ComboBox();
            this.buttonGeneratePayroll = new Button();
            this.gridLayout = new TableLayoutPanel();

            // Main UserControl setup
            this.BackColor = Color.White;
            this.Size = new Size(1200, 600);
            this.DoubleBuffered = true;

            // Panel Search Setup
            this.panelSearch.Dock = DockStyle.Top;
            this.panelSearch.Height = 80;
            this.panelSearch.Padding = new Padding(20);
            this.panelSearch.BackColor = Color.FromArgb(245, 245, 245);
            this.panelSearch.Controls.Add(this.searchLayout);

            // Search Layout (TableLayoutPanel)
            this.searchLayout.Dock = DockStyle.Fill;
            this.searchLayout.ColumnCount = 5;
            this.searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            this.searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            this.searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            this.searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            this.searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.searchLayout.RowCount = 1;
            this.searchLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // Month Label
            var lblMonth = CreateLabel("Month:");
            lblMonth.Anchor = AnchorStyles.Left;
            this.searchLayout.Controls.Add(lblMonth, 0, 0);

            // ComboBox for Month
            this.comboBoxMonth.Font = new Font("Segoe UI", 10F);
            this.comboBoxMonth.Width = 160;
            this.comboBoxMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxMonth.Anchor = AnchorStyles.Left;
            this.comboBoxMonth.Items.AddRange(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames
                .Where(m => !string.IsNullOrEmpty(m)).ToArray());
            this.searchLayout.Controls.Add(this.comboBoxMonth, 1, 0);

            // Year Label
            var lblYear = CreateLabel("Year:");
            lblYear.Anchor = AnchorStyles.Left;
            lblYear.Margin = new Padding(20, 0, 0, 0);
            this.searchLayout.Controls.Add(lblYear, 2, 0);

            // ComboBox for Year
            this.comboBoxYear.Font = new Font("Segoe UI", 10F);
            this.comboBoxYear.Width = 100;
            this.comboBoxYear.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxYear.Anchor = AnchorStyles.Left;
            int currentYear = DateTime.Now.Year;
            for (int i = currentYear - 10; i <= currentYear; i++) this.comboBoxYear.Items.Add(i);
            this.searchLayout.Controls.Add(this.comboBoxYear, 3, 0);

            // Generate Payroll Button
            this.buttonGeneratePayroll.Text = "Generate Payroll";
            this.buttonGeneratePayroll.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.buttonGeneratePayroll.BackColor = Color.FromArgb(0, 138, 158);
            this.buttonGeneratePayroll.ForeColor = Color.White;
            this.buttonGeneratePayroll.FlatStyle = FlatStyle.Flat;
            this.buttonGeneratePayroll.FlatAppearance.BorderSize = 0;
            this.buttonGeneratePayroll.Size = new Size(180, 40);
            this.buttonGeneratePayroll.Anchor = AnchorStyles.Right;
            this.buttonGeneratePayroll.Cursor = Cursors.Hand;
            this.buttonGeneratePayroll.Margin = new Padding(20, 0, 0, 0);
            this.buttonGeneratePayroll.Click += new EventHandler(ButtonGeneratePayroll_Click);

            // Button hover effects
            this.buttonGeneratePayroll.MouseEnter += (s, e) =>
            {
                buttonGeneratePayroll.BackColor = Color.FromArgb(0, 118, 138);
            };
            this.buttonGeneratePayroll.MouseLeave += (s, e) =>
            {
                buttonGeneratePayroll.BackColor = Color.FromArgb(0, 138, 158);
            };

            this.searchLayout.Controls.Add(this.buttonGeneratePayroll, 4, 0);

            // Panel Table Container
            this.panelTableContainer.Dock = DockStyle.Fill;
            this.panelTableContainer.BackColor = Color.White;
            this.panelTableContainer.Padding = new Padding(20, 10, 20, 20);
            this.panelTableContainer.AutoScroll = true;
            this.panelTableContainer.Controls.Add(this.gridLayout);

            // TableLayoutPanel Setup
            this.gridLayout.AutoSize = true;
            this.gridLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.gridLayout.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            this.gridLayout.BackColor = Color.White;
            this.gridLayout.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.gridLayout.Font = new Font("Segoe UI", 9F);

            // Add panels to the UserControl
            this.Controls.Add(this.panelTableContainer);
            this.Controls.Add(this.panelSearch);

            // Set default selections
            comboBoxMonth.SelectedIndex = DateTime.Now.Month - 1;
            comboBoxYear.SelectedItem = DateTime.Now.Year;

            // Setup accessibility
            this.comboBoxMonth.TabIndex = 0;
            this.comboBoxYear.TabIndex = 1;
            this.buttonGeneratePayroll.TabIndex = 2;
        }

        private Label CreateLabel(string text)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                AutoSize = true,
                Margin = new Padding(0, 5, 10, 5)
            };
        }
    }
}