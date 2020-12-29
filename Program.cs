using System;
using System.Windows.Forms;
using tbvolscroll;
using TbVolScrollNet5.Forms;

namespace TbVolScrollNet5
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();
            bool noTrayArg = args.Length > 1 && args[1] == "notray";
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(noTray: noTrayArg));
        }
    }
}
