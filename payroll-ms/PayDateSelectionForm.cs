using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace payroll_ms
{
    public partial class PayDateSelectionForm : Form
    {
        public DateTime SelectedDate { get; private set; }
        public PayDateSelectionForm()
        {
            InitializeComponent();
            monthCalendar1.MaxSelectionCount = 1;
            SelectedDate = DateTime.Today;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectedDate = monthCalendar1.SelectionStart;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
