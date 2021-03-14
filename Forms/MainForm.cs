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
using AudioSwitcher.AudioApi;
using tbvolscroll.Properties;
using tbvolscroll.Forms;

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
        private int curDeviceIndex = -1;
        private InputHandler inputHandler;
        private int volumeBarAutoHideTimeout = 1000;
        private bool isDisplayingVolume = false;
        #endregion


        private void SetPositionTopmost()
        {
            Invoke((MethodInvoker)delegate
            {
                SetWindowPos(Handle.ToInt32(), -1, Left, Top, Width, Height, 16u);
            });
        }

        private void ShowInactiveTopmost()
        {
            Invoke((MethodInvoker)delegate
            {
                ShowWindow(Handle, 4);
            });
        }

        public MainForm(bool noTray = false, bool attemptedAdmin = false)
        {
            InitializeComponent();
            bool hasAdmin = IsAdministrator();

            TitleLabelMenuItem.Text = $"{Assembly.GetEntryAssembly().GetName().Name} v{Application.ProductVersion}" + (hasAdmin ? " (Administrator)" : "");

            if (noTray)
                TrayNotifyIcon.Visible = false;

            if (!attemptedAdmin && !hasAdmin && Settings.Default.AutoRetryAdmin)
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

            LoadProgramSettings();
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
                    int currentVolume = (int)Math.Round(AudioHandler.GetMasterVolume());
                    if (delta < 0)
                    {
                        if (inputHandler.isCtrlDown)
                        {
                            AudioHandler.SetMasterVolumeMute(isMuted: true);
                            VolumeTextLabel.Text = $"System Muted";
                        }
                        else
                        {
                            if (inputHandler.isAltDown || currentVolume <= Settings.Default.PreciseScrollThreshold)
                                AudioHandler.SetMasterVolume(currentVolume - 1);
                            else
                                AudioHandler.SetMasterVolume(currentVolume - Settings.Default.VolumeStep);
                        }
                    }
                    else
                    {
                        if (inputHandler.isCtrlDown)
                        {
                            AudioHandler.SetMasterVolumeMute(isMuted: false);
                            VolumeTextLabel.Text = $"System Unmuted";
                        }
                        else
                        {
                            if (inputHandler.isAltDown || currentVolume < Settings.Default.PreciseScrollThreshold)
                                AudioHandler.SetMasterVolume(currentVolume + 1);
                            else
                                AudioHandler.SetMasterVolume(currentVolume + Settings.Default.VolumeStep);
                        }
                    }

                    if (!inputHandler.isCtrlDown)
                    {
                        currentVolume = (int)Math.Round(AudioHandler.GetMasterVolume());
                        if (currentVolume == 0)
                            AudioHandler.SetMasterVolumeMute(isMuted: true);
                        else
                            AudioHandler.SetMasterVolumeMute(isMuted: false);
                        VolumeTextLabel.Text = $"{currentVolume}% ";
                        TrayNotifyIcon.Text = $"{Assembly.GetEntryAssembly().GetName().Name} - {currentVolume}%";

                        Width = currentVolume + Settings.Default.BarWidth + 5;
                        Opacity = Settings.Default.BarOpacity;
                        if (Settings.Default.UseBarGradient)
                            VolumeTextLabel.BackColor = CalculateColor(currentVolume);
                        else
                            VolumeTextLabel.BackColor = Settings.Default.BarColor;
                    }
                    else
                    {
                        Width = Settings.Default.BarWidth + 100;
                        VolumeTextLabel.BackColor = Color.SkyBlue;
                    }
                    SetVolumeBarPosition();
                    SetPositionTopmost();
                    if (!isDisplayingVolume)
                        AutoHideVolume();
                });
            }
            catch { }
        }

        public void SetVolumeBarPosition()
        {
            Point cursorPosition = Cursor.Position;
            switch (TaskbarHelper.Position)
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
                case TaskbarPosition.Unknown:
                    Left = cursorPosition.X - Width / 2;
                    Top = cursorPosition.Y - Height - 5;
                    break;
                default:
                    Left = cursorPosition.X - Width / 2;
                    Top = cursorPosition.Y - Height - 5;
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
            volumeBarAutoHideTimeout = Settings.Default.AutoHideTimeOut;
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
                    volumeBarAutoHideTimeout = Settings.Default.AutoHideTimeOut;
                    isDisplayingVolume = false;
                });
            }
            else
                AutoHideVolume();
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            if (inputHandler != null)
                inputHandler.inputEvents.Dispose();
            TrayNotifyIcon.Dispose();
            Environment.Exit(0);
        }

        private void RestartAppNormal(object sender, EventArgs e)
        {
            if (inputHandler != null)
                inputHandler.inputEvents.Dispose();
            TrayNotifyIcon.Dispose();
            Application.Restart();
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
            int currentVolume = (int)Math.Round(AudioHandler.GetMasterVolume());
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

        private void LoadProgramSettings()
        {
            if (Settings.Default.UpdateSettings)
            {
                Settings.Default.Upgrade();
                Settings.Default.UpdateSettings = false;
                Settings.Default.Save();
            }

            int currentVolume = (int)Math.Round(AudioHandler.GetMasterVolume());
            volumeBarAutoHideTimeout = Settings.Default.AutoHideTimeOut;
            VolumeTextLabel.Font = Settings.Default.FontStyle;
            VolumeTextLabel.Text = $"{currentVolume}%";
            TrayNotifyIcon.Text = $"{Application.ProductName} - {currentVolume}%";

            MaximumSize = new Size(100 + Settings.Default.BarWidth, Settings.Default.BarHeight);
            MinimumSize = new Size(Settings.Default.BarWidth, Settings.Default.BarHeight);

            inputHandler = new InputHandler(this);
            AudioHandler.UpdateAudioState();
            SetTrayIcon();
        }


        private void VolumeMixerMenuItemClick(object sender, EventArgs e)
        {
            AudioHandler.OpenSndVol();
        }

        private void AudioDevicesMenuItem_Click(object sender, EventArgs e)
        {
            SetPlaybackAudioDeviceForm audioDevicesForm = new SetPlaybackAudioDeviceForm();
            audioDevicesForm.ShowDialog();
            AudioHandler.UpdateAudioState();
            SetTrayIcon();
        }

        private void DoAppearanceUpdate()
        {
            AudioHandler.UpdateAudioState();
            SetTrayIcon();
            SetVolumeBarPosition();
            SetPositionTopmost();
            if (isDisplayingVolume)
                return;
            AutoHideVolume();
        }

        private void SetTrayIcon()
        {
            if (AudioHandler.Muted)
            {
                TrayNotifyIcon.Text = "System is muted";
                TrayNotifyIcon.Icon = Resources.volmute;
            }
            else
            {
                if (AudioHandler.Volume >= 90)
                    TrayNotifyIcon.Icon = Resources.vol100;
                if (AudioHandler.Volume >= 80 && AudioHandler.Volume < 90)
                    TrayNotifyIcon.Icon = Resources.vol90;
                if (AudioHandler.Volume >= 70 && AudioHandler.Volume < 80)
                    TrayNotifyIcon.Icon = Resources.vol80;
                if (AudioHandler.Volume >= 60 && AudioHandler.Volume < 70)
                    TrayNotifyIcon.Icon = Resources.vol70;
                if (AudioHandler.Volume >= 50 && AudioHandler.Volume < 60)
                    TrayNotifyIcon.Icon = Resources.vol60;
                if (AudioHandler.Volume >= 40 && AudioHandler.Volume < 50)
                    TrayNotifyIcon.Icon = Resources.vol50;
                if (AudioHandler.Volume >= 30 && AudioHandler.Volume < 40)
                    TrayNotifyIcon.Icon = Resources.vol40;
                if (AudioHandler.Volume >= 20 && AudioHandler.Volume < 30)
                    TrayNotifyIcon.Icon = Resources.vol30;
                if (AudioHandler.Volume >= 10 && AudioHandler.Volume < 20)
                    TrayNotifyIcon.Icon = Resources.vol20;
                if (AudioHandler.Volume > 0 && AudioHandler.Volume < 10)
                    TrayNotifyIcon.Icon = Resources.vol10;
            }
        }

        public void SetAudioVolume(int delta)
        {
            try
            {
                Invoke((MethodInvoker)delegate
                 {
                     AudioHandler.Volume = (int)Math.Round(AudioHandler.GetMasterVolume());
                     if (delta < 0)
                     {
                         if (inputHandler.isAltDown || AudioHandler.Volume <= Settings.Default.PreciseScrollThreshold)
                             AudioHandler.SetMasterVolume(AudioHandler.Volume - 1);
                         else
                             AudioHandler.SetMasterVolume(AudioHandler.Volume - Settings.Default.VolumeStep);
                     }
                     else if (inputHandler.isAltDown || AudioHandler.Volume < Settings.Default.PreciseScrollThreshold)
                         AudioHandler.SetMasterVolume(AudioHandler.Volume + 1);
                     else
                         AudioHandler.SetMasterVolume(AudioHandler.Volume + Settings.Default.VolumeStep);
                     AudioHandler.Volume = (int)Math.Round(AudioHandler.GetMasterVolume());
                     AudioHandler.Muted = AudioHandler.CoreAudioController.DefaultPlaybackDevice.IsMuted;
                     if (AudioHandler.Volume > 0 && AudioHandler.Muted)
                         AudioHandler.SetMasterVolumeMute();
                     else if (AudioHandler.Volume == 0 && !AudioHandler.Muted)
                         AudioHandler.SetMasterVolumeMute(true);
                     AudioHandler.Muted = AudioHandler.CoreAudioController.DefaultPlaybackDevice.IsMuted;
                     Width = AudioHandler.Volume + Settings.Default.BarWidth + 5;
                     Refresh();
                     VolumeTextLabel.Text = $"{AudioHandler.Volume}%";
                     TrayNotifyIcon.Text = $"Volume: {AudioHandler.Volume}%1";
                     Opacity = Settings.Default.BarOpacity;
                     if (Settings.Default.UseBarGradient)
                         VolumeTextLabel.BackColor = CalculateColor(AudioHandler.Volume);
                     else
                         VolumeTextLabel.BackColor = Settings.Default.BarColor;
                 });
                DoAppearanceUpdate();
            }
            catch
            {
            }
        }

        public void SetMuteStatus(int delta)
        {
            bool isMuted = delta < 0;
            AudioHandler.SetMasterVolumeMute(isMuted);
            if (isMuted)
            {
                VolumeTextLabel.Text = "System Muted";
                TrayNotifyIcon.Text = "System is muted";
            }
            else
            {
                VolumeTextLabel.Text = "System Unmuted";
                TrayNotifyIcon.Text = string.Format("Volume: {0}%", (object)AudioHandler.Volume);
            }
            AudioHandler.Muted = isMuted;
            Width = Settings.Default.BarWidth + 100;
            VolumeTextLabel.BackColor = Color.SkyBlue;
            DoAppearanceUpdate();
        }

        public async Task ToggleAudioPlaybackDevice()
        {
            List<CoreAudioDevice> audioDevicesList = new List<CoreAudioDevice>();
            await AudioHandler.RefreshPlaybackDevices();
            audioDevicesList.AddRange(AudioHandler.AudioDevices);
            CoreAudioDevice curDevice = AudioHandler.CoreAudioController.DefaultPlaybackDevice;
            if (curDeviceIndex == -1)
                curDeviceIndex = audioDevicesList.FindIndex(x => x.Id == curDevice.Id);
            if (curDeviceIndex < audioDevicesList.Count - 1)
                ++curDeviceIndex;
            else
                curDeviceIndex = 0;
            CoreAudioDevice newPlaybackDevice = audioDevicesList[curDeviceIndex];
            await newPlaybackDevice.SetAsDefaultAsync();
            VolumeTextLabel.Text = AudioHandler.CoreAudioController.DefaultPlaybackDevice.Name;
            Width = Settings.Default.BarWidth + 100;
            VolumeTextLabel.BackColor = Color.SkyBlue;
            DoAppearanceUpdate();
        }
    }
}