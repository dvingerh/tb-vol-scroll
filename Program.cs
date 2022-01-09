using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using tbvolscroll.Classes;

namespace tbvolscroll
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 


        [STAThread]
        static void Main(string[] args)
        {


            bool noTrayArg = args.Any("no-tray".Contains);
            bool updateDoneArg = args.Any("update-done".Contains);
            bool adminArg = args.Any("admin".Contains);

            Globals.AppMutex = new Mutex(true, @"Global\" + Application.ProductName, out bool didCreate);



            if (!Globals.AppMutex.WaitOne(0, false) || !didCreate)
            {
                MessageBox.Show("Another instance is already running.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(1);
            }

            GC.KeepAlive(Globals.AppMutex);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(noTray: noTrayArg, attemptedAdmin: adminArg, updateDoneArg: updateDoneArg));
        }
    }
}