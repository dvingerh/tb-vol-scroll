using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using tb_vol_scroll.Classes;

namespace tb_vol_scroll
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Globals.AppArgs = new List<string>(args);
            Globals.AppMutex = new Mutex(true, @"Global\" + Application.ProductName, out bool didCreate);

            if (!Globals.AppMutex.WaitOne(0, false) || !didCreate)
            {
                MessageBox.Show("Another instance is already running.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(1);
            }
            GC.KeepAlive(Globals.AppMutex);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
