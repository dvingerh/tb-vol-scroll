using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace tbvolscroll
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool noTrayArg = args.Any("notray".Contains);
            bool updateDoneArg = args.Any("update-done".Contains);
            bool adminArg = args.Any("admin".Contains);

            if (updateDoneArg)
                MessageBox.Show($"Successfully updated tb-vol-scroll to version {Application.ProductVersion}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


            if (adminArg)
                Thread.Sleep(1000);
            Process[] processes = Process.GetProcesses();
            Process currentProc = Process.GetCurrentProcess();
            foreach (Process process in processes)
            {
                if (currentProc.ProcessName == process.ProcessName && currentProc.Id != process.Id)
                {
                    MessageBox.Show("Another instance is already running.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Environment.Exit(1);
                }
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(noTray: noTrayArg, attemptedAdmin: adminArg));
        }
    }
}
