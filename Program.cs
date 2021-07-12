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
        /// 

        private static Mutex _mutex;

        [STAThread]
        static void Main(string[] args)
        {
            bool noTrayArg = args.Any("notray".Contains);
            bool updateDoneArg = args.Any("update-done".Contains);
            bool restartArg = args.Any("restart".Contains);
            bool adminArg = args.Any("admin".Contains);

            if (adminArg || updateDoneArg || noTrayArg || restartArg)
                Thread.Sleep(250);


            _mutex = new Mutex(true, @"Global\" + Application.ProductName, out bool isNewInstance);
            GC.KeepAlive(_mutex);

            if (!isNewInstance)
            {
                MessageBox.Show("Another instance is already running.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(1);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(noTray: noTrayArg, attemptedAdmin: adminArg, updateDoneArg));
        }
    }
}