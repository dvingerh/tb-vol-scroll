using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Principal;
using System.Reflection;

namespace tbvolscroll
{
    public partial class MainForm : Form
    {

        #region DLLImports
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(int hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        #endregion

        #region Variables
        private InputHandler inputHandler;
        public int volumeBarAutoHideTimeout = 1000;
        private bool isDisplayingVolume = false;
        #endregion


        private void ShowInactiveTopmost()
        {
            Invoke((MethodInvoker)delegate
            {
                ShowWindow(Handle, 4);
                SetWindowPos(Handle.ToInt32(), -1, Left, Top, Width, Height, 16u);
            });
        }

        public MainForm(bool noTray = false, bool attemptedAdmin = false)
        {
            InitializeComponent();

            bool hasAdmin = IsAdministrator();

            TitleLabelMenuItem.Text = $"{Assembly.GetEntryAssembly().GetName().Name} v{Application.ProductVersion}" + (hasAdmin ? " (Administrator)" : "");

            if (noTray)
                TrayNotifyIcon.Visible = false;

            if (!attemptedAdmin && !hasAdmin && Properties.Settings.Default.AutoRetryAdmin)
            {
                Process proc = new Process();
                proc.StartInfo.FileName = Application.ExecutablePath;
                proc.StartInfo.UseShellExecute = true;
                proc.StartInfo.Verb = "runas";
                proc.StartInfo.Arguments = "admin";
                proc.Start();
                ExitMenuItem.PerformClick();
            }
            else
            {
                if (attemptedAdmin && !hasAdmin)
                    TrayNotifyIcon.ShowBalloonTip(1000, "Warning", "Could not obtain administrator rights, scrolling may not work in all cases.", ToolTipIcon.Warning);
            }
        }

        private bool IsAdministrator()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator);
        }

        public void DoVolumeChanges(int delta)
        {
            try
            {
                Invoke((MethodInvoker)delegate
                {
                    int currentVolume = (int)Math.Round(VolumeHandler.GetMasterVolume());
                    if (CursorInTaskbar())
                    {
                        if (delta < 0)
                        {
                            if (inputHandler.isCtrlDown)
                            {
                                VolumeHandler.SetMasterVolumeMute(isMuted: true);
                                VolumeTextLabel.Text = $"System Muted";
                            }
                            else
                            {
                                if (inputHandler.isAltDown || currentVolume <= Properties.Settings.Default.PreciseScrollThreshold)
                                    VolumeHandler.SetMasterVolume(currentVolume - 1);
                                else
                                    VolumeHandler.SetMasterVolume(currentVolume - Properties.Settings.Default.VolumeStep);
                            }
                        }
                        else
                        {
                            if (inputHandler.isCtrlDown)
                            {
                                VolumeHandler.SetMasterVolumeMute(isMuted: false);
                                VolumeTextLabel.Text = $"System Unmuted";
                            }
                            else
                            {
                                if (inputHandler.isAltDown || currentVolume < Properties.Settings.Default.PreciseScrollThreshold)
                                    VolumeHandler.SetMasterVolume(currentVolume + 1);
                                else
                                    VolumeHandler.SetMasterVolume(currentVolume + Properties.Settings.Default.VolumeStep);
                            }
                        }

                        if (!inputHandler.isCtrlDown)
                        {
                            currentVolume = (int)Math.Round(VolumeHandler.GetMasterVolume());
                            VolumeTextLabel.Text = $"{currentVolume}% ";
                            TrayNotifyIcon.Text = $"{Assembly.GetEntryAssembly().GetName().Name} - {currentVolume}%";

                            Width = currentVolume + Properties.Settings.Default.BarWidth + 5;
                            SetVolumeBarPosition(TaskbarHelper.Position);
                            Refresh();

                            Opacity = Properties.Settings.Default.BarOpacity;
                            if (Properties.Settings.Default.UseBarGradient)
                                VolumeTextLabel.BackColor = CalculateColor(currentVolume);
                            else
                                VolumeTextLabel.BackColor = Properties.Settings.Default.BarColor;
                        }
                        else
                        {
                            Width = 120;
                            VolumeTextLabel.BackColor = Color.SkyBlue;
                        }
                        if (!isDisplayingVolume)
                            AutoHideVolume();
                    }
                });
            }
            catch { }
        }

        public void SetVolumeBarPosition(TaskbarPosition taskbarPosition)
        {
            Point cursorPosition = Cursor.Position;
            switch (taskbarPosition)
            {
                case TaskbarPosition.Bottom:
                    Left = cursorPosition.X - Width / 2;
                    Top = cursorPosition.Y - Height - 5;
                    break;
                case TaskbarPosition.Left:
                    Left = cursorPosition.X + 25;
                    Top = cursorPosition.Y - 5;
                    break;
                case TaskbarPosition.Top:
                    Left = cursorPosition.X - Width / 2;
                    Top = cursorPosition.Y + 25;
                    break;
                case TaskbarPosition.Right:
                    Left = cursorPosition.X - Width - 25;
                    Top = cursorPosition.Y - 5;
                    break;
            }
        }

        private Color CalculateColor(double percentage)
        {
            double num = ((percentage > 50.0) ? (1.0 - 2.0 * (percentage - 50.0) / 100.0) : 1.0) * 255.0;
            double num2 = ((percentage > 50.0) ? 1.0 : (2.0 * percentage / 100.0)) * 255.0;
            double num3 = 0.0;
            return Color.FromArgb((int)num, (int)num2, (int)num3);
        }


        private async void AutoHideVolume()
        {
            isDisplayingVolume = true;
            volumeBarAutoHideTimeout = Properties.Settings.Default.AutoHideTimeOut;
            ShowInactiveTopmost();

            while (volumeBarAutoHideTimeout >= 10)
            {
                await Task.Delay(10);
                volumeBarAutoHideTimeout -= 10;
            }

            if (!inputHandler.isScrolling)
            {
                Invoke((MethodInvoker)delegate
                {
                    Hide();
                    volumeBarAutoHideTimeout = Properties.Settings.Default.AutoHideTimeOut;
                    isDisplayingVolume = false;
                });
            }
            else
                AutoHideVolume();
        }

        private bool CursorInTaskbar()
        {
            Point cursorPosition = Cursor.Position;
            Rectangle taskbarBounds = TaskbarHelper.CurrentBounds;
            bool cursorInTaskBar = taskbarBounds.Contains(cursorPosition);
            bool taskBarHidden = TaskbarHelper.IsTaskbarHidden();
            if (cursorInTaskBar && !taskBarHidden)
                return true;
            else
                return false;
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            inputHandler.inputEvents.Dispose();
            TrayNotifyIcon.Dispose();
            Environment.Exit(0);
        }

        private void RestartAppNormal(object sender, EventArgs e)
        {
            inputHandler.inputEvents.Dispose();
            TrayNotifyIcon.Dispose();
            Application.Restart();
        }

        private void LoadProgramSettings(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.UpdateSettings)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpdateSettings = false;
                Properties.Settings.Default.Save();
            }

            int currentVolume = (int)Math.Round(VolumeHandler.GetMasterVolume());
            volumeBarAutoHideTimeout = Properties.Settings.Default.AutoHideTimeOut;
            VolumeTextLabel.Font = Properties.Settings.Default.FontStyle;
            VolumeTextLabel.Text = $"{currentVolume}%";
            TrayNotifyIcon.Text = $"{Assembly.GetEntryAssembly().GetName().Name} - {currentVolume}%";

            MaximumSize = new Size(100 + Properties.Settings.Default.BarWidth, Properties.Settings.Default.BarHeight);
            MinimumSize = new Size(Properties.Settings.Default.BarWidth, Properties.Settings.Default.BarHeight);
            WindowState = FormWindowState.Normal;
            Hide();

            inputHandler = new InputHandler(this);
        }

        private void ShowTrayMenuOnClick(object sender, EventArgs e)
        {
            MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
            mi.Invoke(TrayNotifyIcon, null);
        }

        private void OpenSettingsDialog(object sender, EventArgs e)
        {
            new SettingsForm(this).ShowDialog();
        }

        private void RestartAppAsAdministrator(object sender, EventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = Application.ExecutablePath;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.Verb = "runas";
            proc.Start();
            ExitMenuItem.PerformClick();
        }

        private void UpdateTrayIconText(object sender, MouseEventArgs e)
        {
            int currentVolume = (int)Math.Round(VolumeHandler.GetMasterVolume());
            TrayNotifyIcon.Text = $"{Assembly.GetEntryAssembly().GetName().Name} - {currentVolume}%";
        }

        private void DrawVolumeBarBorder(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.Black, 2), DisplayRectangle);
        }

        private void OpenStartupFolder(object sender, EventArgs e)
        {
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Startup));
        }
    }
}
