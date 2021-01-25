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
        private int volumeBarHideTimeout = 10;
        private bool isDisplayingVolume = false;
        #endregion


        private void ShowInactiveTopmost(Form frm)
        {
            frm.Invoke((MethodInvoker)delegate
            {
                ShowWindow(frm.Handle, 4);
                SetWindowPos(frm.Handle.ToInt32(), -1, frm.Left, frm.Top, frm.Width, frm.Height, 16u);
            });
        }

        public MainForm(bool noTray = false)
        {
            InitializeComponent();
            if (IsAdministrator())
                TitleLabelMenuItem.Text = $"{Assembly.GetEntryAssembly().GetName().Name} v{Properties.Settings.Default.AppVersion} (Admin)";
            else
                TitleLabelMenuItem.Text = $"{Assembly.GetEntryAssembly().GetName().Name} v{Properties.Settings.Default.AppVersion}";

            if (noTray)
                TrayNotifyIcon.Visible = false;
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
                            if (inputHandler.isAltDown || currentVolume <= Properties.Settings.Default.PreciseScrollThreshold)
                                VolumeHandler.SetMasterVolume(currentVolume - 1);
                            else
                                VolumeHandler.SetMasterVolume(currentVolume - Properties.Settings.Default.VolumeStep);
                        }
                        else
                        {
                            if (inputHandler.isAltDown || currentVolume < Properties.Settings.Default.PreciseScrollThreshold)
                                VolumeHandler.SetMasterVolume(currentVolume + 1);
                            else
                                VolumeHandler.SetMasterVolume(currentVolume + Properties.Settings.Default.VolumeStep);
                        }

                        currentVolume = (int)Math.Round(VolumeHandler.GetMasterVolume());
                        VolumeTextLabel.Text = $"{currentVolume}% ";
                        TrayNotifyIcon.Text = $"{Assembly.GetEntryAssembly().GetName().Name} - {currentVolume}%";


                        Width = currentVolume + Properties.Settings.Default.BarWidth + 5;
                        SetVolumeBarPosition(TaskbarHelper.Position);
                        VolumeTextLabel.Top = 1;
                        VolumeTextLabel.Left = 1;
                        VolumeTextLabel.Height = Height - 2;
                        VolumeTextLabel.Width = Width - 2;
                        Refresh();

                        Opacity = Properties.Settings.Default.BarOpacity;
                        if (Properties.Settings.Default.UseBarGradient)
                            VolumeTextLabel.BackColor = CalculateColor(currentVolume);
                        else
                            VolumeTextLabel.BackColor = Properties.Settings.Default.BarColor;

                        if (!isDisplayingVolume)
                        {
                            isDisplayingVolume = true;
                            AutoHideVolume();
                        }
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

        private async Task PutTaskDelay()
        {
            await Task.Delay(100);
        }

        private async void AutoHideVolume()
        {
            ShowInactiveTopmost(this);

            while (volumeBarHideTimeout != 0)
            {
                await PutTaskDelay();
                volumeBarHideTimeout--;
            }

            Invoke((MethodInvoker)delegate
            {
                Hide();
            });
            volumeBarHideTimeout = 10;
            isDisplayingVolume = false;
        }

        private bool CursorInTaskbar()
        {
            Point cursorPosition = Cursor.Position;
            Rectangle taskbarBounds = TaskbarHelper.CurrentBounds;
            if (taskbarBounds.Contains(cursorPosition) && !TaskbarHelper.IsTaskbarHidden())
                return true;
            else
                return false;
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            TrayNotifyIcon.Dispose();
            Environment.Exit(0);
        }

        private void RestartAppNormal(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void LoadProgramSettings(object sender, EventArgs e)
        {
            int currentVolume = (int)Math.Round(VolumeHandler.GetMasterVolume());
            
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

        private void OpenSetVolumeStepDialog(object sender, EventArgs e)
        {
            new SetVolumeStepForm().ShowDialog();
        }

        private void OpenSetPreciseScrollThreshold(object sender, EventArgs e)
        {
            new SetPreciseThresholdForm().ShowDialog();
        }

        private void OpenSetAppearanceDialog(object sender, EventArgs e)
        {
            new SetAppearanceForm(this).ShowDialog();
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
    }
}
