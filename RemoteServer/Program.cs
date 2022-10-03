using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace RemoteServer
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                MessageBox.Show("You can't run this program twice at the same time.", "Warning");
                return;
            }

            Application.Run(new ControlForm());
        }
    }
}
