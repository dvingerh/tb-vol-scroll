using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Principal;
using System.Reflection;
using AudioSwitcher.AudioApi.CoreAudio;
using System.Collections.Generic;
using tbvolscroll.Properties;
using tbvolscroll.Forms;
using System.Media;
using System.Threading;
using System.IO;
using tbvolscroll.Classes;
using System.ServiceProcess;

namespace tbvolscroll.Classes
{
    public static class Utils
    {
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(int hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static Color CalculateColor(double percentage)
        {
            if (percentage > 100)
                percentage = 100;
            if (percentage < 0)
                percentage = 0;

            double num = ((percentage > 50.0) ? (1.0 - 2.0 * (percentage - 50.0) / 100.0) : 1.0) * 255.0;
            double num2 = ((percentage > 50.0) ? 1.0 : (2.0 * percentage / 100.0)) * 255.0;
            double num3 = 0.0;

            if (num < 0)
                num = 0;
            if (num2 < 0)
                num2 = 0;
            if (num > 255)
                num = 255;
            if (num2 > 255)
                num2 = 255;

            return Color.FromArgb((int)num, (int)num2, (int)num3);
        }

        public static bool IsAdministrator()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static void ShowInactiveTopmost(MainForm mainForm)
        {
            mainForm.Invoke((MethodInvoker)delegate
            {
                SetWindowPos(mainForm.Handle.ToInt32(), -1, mainForm.Left, mainForm.Top, mainForm.Width, mainForm.Height, 16u);
                ShowWindow(mainForm.Handle, 4);
            });
        }


        public static bool IsAudioServiceRunning()
        {
            Globals.ServiceController.Refresh();
            return Globals.ServiceController.Status == ServiceControllerStatus.Running;
        }

    }
}
