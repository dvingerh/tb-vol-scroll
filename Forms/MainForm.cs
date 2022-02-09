using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using tbvolscroll.Properties;
using tbvolscroll.Forms;
using System.Media;
using System.IO;
using tbvolscroll.Classes;
using System.ServiceProcess;
using System.Drawing.Drawing2D;

namespace tbvolscroll
{
    public partial class MainForm : Form
    {
        private const int WS_EX_NOACTIVATE = 0x08000000;
        protected override CreateParams CreateParams
        {
            get
            {
                var createParams = base.CreateParams;

                createParams.ExStyle |= WS_EX_NOACTIVATE;
                return createParams;
            }
        }


        private readonly Timer hideVolumeBarTimer = new Timer();


        public MainForm(bool noTrayArg = false, bool adminArg = false, bool updateDoneArg = false)
        {
            InitializeComponent();
            Globals.MainForm = this;
            hideVolumeBarTimer.Tick += (s, e) => HideVolumeBar();

            if (updateDoneArg)
            {
                Settings.Default.UpdateSettings = true;
                TrayNotifyIcon.Visible = true;
                TrayNotifyIcon.ShowBalloonTip(2500, "Update complete", $"Successfully updated {Application.ProductName} to version {Application.ProductVersion}.", ToolTipIcon.Info);
            }

            if (Settings.Default.UpdateSettings)
            {
                Settings.Default.Upgrade();
                Settings.Default.UpdateSettings = false;
                Settings.Default.Save();
            }

            Globals.TextRenderingHintType = Settings.Default.TextRenderingHintType;

            if (!noTrayArg)
            {
                Globals.DisplayTrayIcon = true;
                TrayNotifyIcon.Visible = true;
            }

            if (Settings.Default.DisplayTrayIconAsText)
            {
                Icon newIcon = Utils.GenerateTrayIcon("T");
                if (newIcon != null)
                    TrayNotifyIcon.Icon = newIcon;
                Utils.DestroyIcon(newIcon.Handle);
            }

            bool isAdmin = Utils.IsAdministrator();

            TitleLabelMenuItem.Text = $"{Application.ProductName} {Application.ProductVersion}";

            if (isAdmin)
                TitleLabelMenuItem.Image = Utils.GetUacShield();

            if (!adminArg && !isAdmin && Settings.Default.AutoRetryAdmin)
            {
                new Task(() =>
               {
                   Process proc = new Process();
                   proc.StartInfo.FileName = Application.ExecutablePath;
                   proc.StartInfo.UseShellExecute = true;
                   proc.StartInfo.Verb = "runas";
                   proc.StartInfo.Arguments = "admin";
                   HandleApplicationExit(proc, 0);
               }).Start();
            }
            else
            {
                InitApplicationBackgroundWorker.RunWorkerAsync();

            }
        }
        public void SetVolumeBarPosition()
        {
            Point cursorPosition = Cursor.Position;
            switch (TaskbarHandler.Position)
            {
                case TaskbarHandler.TaskbarPosition.Bottom:
                    Left = cursorPosition.X - Width / 2;
                    Top = cursorPosition.Y - Height - 5;
                    break;
                case TaskbarHandler.TaskbarPosition.Left:
                    Left = cursorPosition.X + 25;
                    Top = cursorPosition.Y - 5;
                    break;
                case TaskbarHandler.TaskbarPosition.Top:
                    Left = cursorPosition.X - Width / 2;
                    Top = cursorPosition.Y + 25;
                    break;
                case TaskbarHandler.TaskbarPosition.Right:
                    Left = cursorPosition.X - Width - 25;
                    Top = cursorPosition.Y - 5;
                    break;
                case TaskbarHandler.TaskbarPosition.Unknown:
                    Left = cursorPosition.X - Width / 2;
                    Top = cursorPosition.Y - Height - 5;
                    break;
                default:
                    Left = cursorPosition.X - Width / 2;
                    Top = cursorPosition.Y - Height - 5;
                    break;

            }
        }

        private void ShowVolumeBar()
        {
            Opacity = Settings.Default.VolumeBarOpacity;
            Globals.IsDisplayingVolumeBar = true;
            Utils.ShowInactiveTopmost(this);
            hideVolumeBarTimer.Interval = Globals.VolumeBarAutoHideTimeout;
            hideVolumeBarTimer.Start();
        }

        public void HideVolumeBar()
        {
            Hide();
            hideVolumeBarTimer.Stop();
            Globals.IsDisplayingVolumeBar = false;
        }

        public void HandleApplicationExit(Process process, int code = 0)
        {
            if (Globals.InputHandler != null)
                Globals.InputHandler.InputEvents.Dispose();
            if (AudioState.CoreAudioController != null)
                AudioState.CoreAudioController.Dispose();

            TrayNotifyIcon.Visible = false;
            TrayNotifyIcon.Icon = null;
            TrayNotifyIcon.Dispose();
            Invoke((MethodInvoker)delegate
            {
                Globals.AppMutex.ReleaseMutex();
                Globals.AppMutex.Dispose();
            });

            if (process != null)
                process.Start();

            Environment.Exit(code);
        }
        public void ExitApplication(object sender, EventArgs e)
        {
            HandleApplicationExit(null, 0);
        }

        public void RestartAppNormal(object sender, EventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = Application.ExecutablePath;
            proc.StartInfo.UseShellExecute = true;
            HandleApplicationExit(proc, 0);
        }

        private void OpenConfigureDialog(object sender, EventArgs e)
        {
            Globals.ConfigurationForm.ShowDialog();
        }

        private void RestartAppAsAdministrator(object sender, EventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = Application.ExecutablePath;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.Verb = "runas";
            proc.StartInfo.Arguments = "admin";
            HandleApplicationExit(proc, 0);
        }

        private void DrawVolumeBarBorder(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Black, 2))
            {
                Rectangle rect = VolumeTextLabel.DisplayRectangle;
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        private void OpenStartupFolder(object sender, EventArgs e)
        {
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Startup));
        }


        private async void VolumeMixerMenuItemClick(object sender, EventArgs e)
        {
            await Utils.OpenSndVol();
        }

        private void AudioDevicesMenuItemClick(object sender, EventArgs e)
        {
            new AudioPlaybackDevicesForm().ShowDialog();
            Globals.AudioPlaybackDevicesForm = null;
        }

        public async Task DoScrollUpdate(string updateType)
        {
            await Task.Run(() =>
            {
                Invoke((MethodInvoker)delegate
                {
                    Console.WriteLine(Height);

                    hideVolumeBarTimer.Stop();
                    SuspendLayout();
                    switch (updateType)
                    {
                        case "volume":
                            VolumeTextLabel.Text = $"{AudioState.Volume}%";
                            TrayNotifyIcon.Text = $"{AudioState.CoreAudioController.DefaultPlaybackDevice.Name}: {AudioState.Volume}%";
                            Width = MinimumSize.Width + AudioState.Volume + Settings.Default.BarWidthPadding;
                            if (Settings.Default.VolumeBarUseGradientColor)
                                VolumeTextLabel.BackColor = Utils.CalculateColor(AudioState.Volume);
                            else
                                VolumeTextLabel.BackColor = Settings.Default.VolumeBarSolidColor;
                            break;
                        case "device":
                            VolumeTextLabel.Text = $"({AudioState.CurrentAudioDeviceIndex + 1}/{Globals.AudioHandler.GetPlaybackDevices().Result.Count}) {AudioState.CoreAudioController.DefaultPlaybackDevice.Name}";
                            Width = Settings.Default.BarWidthPadding + Utils.CalculateLabelSize(VolumeTextLabel, VolumeTextLabel.Text).Width + (MinimumSize.Width / 2);
                            VolumeTextLabel.BackColor = Color.SkyBlue;
                            break;
                        case "mute":
                            if (AudioState.Muted)
                            {
                                VolumeTextLabel.Text = $"{AudioState.CoreAudioController.DefaultPlaybackDevice.Name}: Muted";
                                TrayNotifyIcon.Text = $"{AudioState.CoreAudioController.DefaultPlaybackDevice.Name}: Muted";
                            }
                            else
                            {
                                VolumeTextLabel.Text = $"{AudioState.CoreAudioController.DefaultPlaybackDevice.Name}: Unmuted";
                                TrayNotifyIcon.Text = $"{AudioState.CoreAudioController.DefaultPlaybackDevice.Name}: {AudioState.Volume}%";
                            }
                            Width = Settings.Default.BarWidthPadding + Utils.CalculateLabelSize(VolumeTextLabel, VolumeTextLabel.Text).Width + (MinimumSize.Width / 2);
                            VolumeTextLabel.BackColor = Color.SkyBlue;
                            break;
                    }
                    ResumeLayout();
                    SetVolumeBarPosition();
                    if (!Settings.Default.DisplayVolumeBarScrolling && updateType == "volume")
                        return;
                    ShowVolumeBar();

                });
            });
        }

        public void SetTrayIcon()
        {
            if (!AudioState.AudioAvailable)
            {
                Globals.AudioHandler.ServicePoller.Refresh();
                if (Globals.AudioHandler.ServicePoller.Status == ServiceControllerStatus.Running)
                    TrayNotifyIcon.Text = "No playback device available";
                else
                    TrayNotifyIcon.Text = "Windows Audio service not running";
                if (!Settings.Default.DisplayTrayIconAsText)
                    TrayNotifyIcon.Icon = Resources.voldisabled;
                else
                    TrayNotifyIcon.Icon = Utils.GenerateTrayIcon("X");
            }
            else if (AudioState.Muted)
            {
                TrayNotifyIcon.Text = $"{AudioState.CoreAudioController.DefaultPlaybackDevice.Name}: Muted";
                if (!Settings.Default.DisplayTrayIconAsText)
                    TrayNotifyIcon.Icon = Resources.volmute;
                else
                    TrayNotifyIcon.Icon = Utils.GenerateTrayIcon("M");
            }
            else
            {
                TrayNotifyIcon.Text = $"{AudioState.CoreAudioController.DefaultPlaybackDevice.Name}: {AudioState.Volume}%";
                if (!Settings.Default.DisplayTrayIconAsText)
                {
                    if (Settings.Default.VolumeBarUseGradientColor)
                    {
                        if (AudioState.Volume >= 90)
                            TrayNotifyIcon.Icon = Resources.vol100;
                        if (AudioState.Volume >= 80 && AudioState.Volume < 90)
                            TrayNotifyIcon.Icon = Resources.vol90;
                        if (AudioState.Volume >= 70 && AudioState.Volume < 80)
                            TrayNotifyIcon.Icon = Resources.vol80;
                        if (AudioState.Volume >= 60 && AudioState.Volume < 70)
                            TrayNotifyIcon.Icon = Resources.vol70;
                        if (AudioState.Volume >= 50 && AudioState.Volume < 60)
                            TrayNotifyIcon.Icon = Resources.vol60;
                        if (AudioState.Volume >= 40 && AudioState.Volume < 50)
                            TrayNotifyIcon.Icon = Resources.vol50;
                        if (AudioState.Volume >= 30 && AudioState.Volume < 40)
                            TrayNotifyIcon.Icon = Resources.vol40;
                        if (AudioState.Volume >= 20 && AudioState.Volume < 30)
                            TrayNotifyIcon.Icon = Resources.vol30;
                        if (AudioState.Volume >= 10 && AudioState.Volume < 20)
                            TrayNotifyIcon.Icon = Resources.vol20;
                        if (AudioState.Volume >= 0 && AudioState.Volume < 10)
                            TrayNotifyIcon.Icon = Resources.vol10;
                    }
                    else
                        TrayNotifyIcon.Icon = Resources.voltray;
                }
                else
                    TrayNotifyIcon.Icon = Utils.GenerateTrayIcon(AudioState.Volume.ToString());
            }
        }

        private void PlaySystemSoundTrayMenu(object sender, MouseEventArgs e)
        {
            if (TitleLabelMenuItem.ContentRectangle.Contains(e.Location))
                SystemSounds.Exclamation.Play();
        }

        private async void ShowVolumeSliderPopupForm(object sender, MouseEventArgs e)
        {
            if (AudioState.AudioAvailable && e.Button == MouseButtons.Left)
            {
                if (Globals.VolumeSliderControlForm != null)
                    Globals.VolumeSliderControlForm.CloseFormOnDeactivate(null, null);
                else
                {
                    Globals.VolumeSliderControlForm = new VolumeSliderControlForm();
                    Globals.VolumeSliderControlForm.ShowDialog();
                }
                Globals.VolumeSliderControlForm = null;
            }
            else if (AudioState.AudioAvailable && e.Button == MouseButtons.Middle)
                await Globals.AudioHandler.SetDeviceMute(!AudioState.Muted);
            else
            {
                MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                mi.Invoke(TrayNotifyIcon, null);
            }
        }

        private void VolumeSliderPopupMenuItemClick(object sender, EventArgs e)
        {
            if (AudioState.AudioAvailable)
            {
                Globals.VolumeSliderControlForm = new VolumeSliderControlForm();
                Globals.VolumeSliderControlForm.ShowDialog();
                Globals.VolumeSliderControlForm = null;
            }
        }
        private void OpenCheckForUpdatesForm(object sender, EventArgs e)
        {
            new CheckForUpdatesForm().ShowDialog();
        }

        private void OpenCurrentLocation(object sender, EventArgs e)
        {
            Process.Start(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        private void HandleBalloonTipHide(object sender, EventArgs e)
        {
            if (!Globals.DisplayTrayIcon)
                TrayNotifyIcon.Visible = false;
        }

        private void PreventTitleFromClosingContextMenu(object sender, ToolStripDropDownClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == ToolStripDropDownCloseReason.ItemClicked;
        }

        private void DoInitApplication(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Globals.VolumeBarAutoHideTimeout = Settings.Default.AutoHideTimeOut;
            Globals.ConfigurationForm = new ConfigurationForm();
            Globals.AudioHandler = new AudioHandler();
        }

        private void FinaliseInitApplication(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

            Font = Settings.Default.VolumeBarFontStyle;
            Size labelSize = Utils.CalculateLabelSize(VolumeTextLabel, "100%");

            Size volumeBarMinSize = new Size(Settings.Default.BarWidthPadding + labelSize.Width, Settings.Default.BarHeightPadding + labelSize.Height + 5);
            MinimumSize = volumeBarMinSize;
            Height = volumeBarMinSize.Height;
            Width = volumeBarMinSize.Width;

            Globals.InputHandler = new InputHandler();
        }

        private void SetFormInvisibleOnStart(object sender, EventArgs e)
        {
            Visible = false;

        }
    }
}