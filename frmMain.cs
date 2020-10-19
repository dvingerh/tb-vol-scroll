using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Principal;

namespace TbVolScroll
{
    public partial class frmMain : Form
    {

        #region DLLImports
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(int hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(HandleRef hWnd, [In, Out] ref RECT rect);

        private static void ShowInactiveTopmost(Form frm)
        {
            frm.Invoke((MethodInvoker)delegate
            {
                ShowWindow(frm.Handle, 4);
                SetWindowPos(frm.Handle.ToInt32(), -1, frm.Left, frm.Top, frm.Width, frm.Height, 16u);
            });
        }
        public struct RECT
        {
            public int Left;

            public int Top;

            public int Right;

            public int Bottom;
        }

        public static bool IsTaskbarHidden()
        {
            return CheckTaskbarVisibility(null);
        }

        public static bool CheckTaskbarVisibility(Screen screen)
        {
            if (screen == null)
            {
                screen = Screen.PrimaryScreen;
            }
            RECT rect = new RECT();
            GetWindowRect(new HandleRef(null, GetForegroundWindow()), ref rect);
            return new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top).Contains(screen.Bounds);
        }

        public RECT TaskbarRect;
        public InputHandler inputHandler;
        public bool IsDisplayingVolume = false;

        #endregion

        public frmMain()
        {
            InitializeComponent();
            if (IsAdministrator())
                tsmTitleLabel.Text = $"TbVolScroll v{Properties.Settings.Default.AppVersion} (Admin)";
            else
                tsmTitleLabel.Text = $"TbVolScroll v{Properties.Settings.Default.AppVersion}";
        }

        public static bool IsAdministrator()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator);
        }

        public void DoVolumeChanges(int delta)
        {
            try
            {
                Invoke((MethodInvoker)delegate
                {
                    int CurrentVolume = (int)Math.Round(VolumeHandler.GetMasterVolume());
                    if (CursorInTaskbar() && !IsTaskbarHidden())
                    {
                        inputHandler.TimeOutHelper = 10;
                        if (delta < 0)
                        {
                            if (inputHandler.IsAltDown)
                            {
                                VolumeHandler.SetMasterVolume(CurrentVolume - 1);
                            }
                            else if (CurrentVolume <= Properties.Settings.Default.PreciseScrollThreshold)
                            {
                                VolumeHandler.SetMasterVolume(CurrentVolume - 1);
                            }
                            else
                            {
                                VolumeHandler.SetMasterVolume(CurrentVolume - Properties.Settings.Default.VolumeStep);
                            }
                        }
                        else
                        {
                            if (inputHandler.IsAltDown)
                            {
                                VolumeHandler.SetMasterVolume(CurrentVolume + 1);
                            }
                            else if (CurrentVolume < Properties.Settings.Default.PreciseScrollThreshold)
                            {
                                VolumeHandler.SetMasterVolume(CurrentVolume + 1);
                            }
                            else
                            {
                                VolumeHandler.SetMasterVolume(CurrentVolume + Properties.Settings.Default.VolumeStep);
                            }
                        }

                        CurrentVolume = (int)Math.Round(VolumeHandler.GetMasterVolume());
                        lblVolumeText.Text = CurrentVolume + "%";
                        trayIcon.Text = "TbVolScroll - " + CurrentVolume + "%";


                        Point CursorPosition = Cursor.Position;
                        Width = CurrentVolume + Properties.Settings.Default.BarWidth;
                        Left = CursorPosition.X - Width / 2;
                        Top = CursorPosition.Y - Height - 5;
                        Opacity = Properties.Settings.Default.BarOpacity;
                        if (Properties.Settings.Default.UseBarGradient)
                        {
                            lblVolumeText.BackColor = CalculateColor(CurrentVolume);

                        }
                        else
                        {
                            lblVolumeText.BackColor = Properties.Settings.Default.BarColor;
                        }
                        if (!IsDisplayingVolume)
                        {
                            IsDisplayingVolume = true;
                            Application.DoEvents();
                            AutoHideVolume();
                        }
                    }
                    else
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            Hide();
                        });
                        IsDisplayingVolume = false;
                    }
                });
            }
            catch { }
        }

        private static Color CalculateColor(double percentage)
        {
            double num = ((percentage > 50.0) ? (1.0 - 2.0 * (percentage - 50.0) / 100.0) : 1.0) * 255.0;
            double num2 = ((percentage > 50.0) ? 1.0 : (2.0 * percentage / 100.0)) * 255.0;
            double num3 = 0.0;
            return Color.FromArgb((int)num, (int)num2, (int)num3);
        }

        async Task PutTaskDelay()
        {
            await Task.Delay(100);
        }



        private async void AutoHideVolume()
        {
            ShowInactiveTopmost(this);

            while (inputHandler.TimeOutHelper != 0)
            {
                await PutTaskDelay();
                inputHandler.TimeOutHelper--;
            }

            Invoke((MethodInvoker)delegate
            {
                Hide();
                WindowState = FormWindowState.Minimized;
            });
            IsDisplayingVolume = false;
        }

        public bool CursorInTaskbar()
        {
            Point position = Cursor.Position;
            if (position.Y >= TaskbarRect.Top && position.Y <= TaskbarRect.Bottom)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void RestartAppNormal(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void ResetVolume(object sender, EventArgs e)
        {
            VolumeHandler.SetMasterVolume(0);
        }


        private void SetupProgramVars(object sender, EventArgs e)
        {
            MaximumSize = new Size(100 + Properties.Settings.Default.BarWidth, Properties.Settings.Default.BarHeight);
            MinimumSize = new Size(Properties.Settings.Default.BarWidth, Properties.Settings.Default.BarHeight);
            Width = 100 + Properties.Settings.Default.BarWidth;
            Height = Properties.Settings.Default.BarHeight;
            Hide();
            IntPtr hwnd = FindWindow("Shell_traywnd", "");
            GetWindowRect(hwnd, out TaskbarRect);
            inputHandler = new InputHandler(this);

            lblVolumeText.Font = Properties.Settings.Default.FontStyle;
            int CurrentVolume = (int)Math.Round(VolumeHandler.GetMasterVolume());
            lblVolumeText.Text = CurrentVolume + "%";
            trayIcon.Text = "TbVolScroll - " + CurrentVolume + "%";

        }

        private void ShowTrayMenuOnClick(object sender, EventArgs e)
        {
            System.Reflection.MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            mi.Invoke(trayIcon, null);
        }

        private void OpenSetVolumeStepDialog(object sender, EventArgs e)
        {
            new FrmSetVolumeStep().ShowDialog();
        }

        private void OpenSetPreciseScrollThreshold(object sender, EventArgs e)
        {
            new FrmSetPreciseThreshold().ShowDialog();
        }

        private void TsmSetVolumeBarDimensions_Click(object sender, EventArgs e)
        {
            new frmSetBarAppearance(this).ShowDialog();

        }

        private void RestartAppAsAdministrator(object sender, EventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = Application.ExecutablePath;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.Verb = "runas";
            proc.Start();
            Environment.Exit(0);
        }
    }
}
