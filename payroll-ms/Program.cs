using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PayrollApp;

namespace payroll_ms
{
    internal static class Program
    {
        public static string connectionString = @"Server=ROG-zephyrus;Database=payroll;Integrated Security=True;";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
