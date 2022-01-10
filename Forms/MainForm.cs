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

namespace tbvolscroll
{
    public partial class MainForm : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                var Params = base.CreateParams;
                Params.ExStyle |= 0x80;

                return Params;
            }
        }


        private readonly Timer hideVolumeBarTimer = new Timer();


        public MainForm(bool noTray = false, bool attemptedAdmin = false, bool updateDoneArg = false)
        {
            InitializeComponent();
            hideVolumeBarTimer.Tick += (s, e) => HideVolumeBar();


            if (updateDoneArg)
            {
                TrayNotifyIcon.Visible = true;
                TrayNotifyIcon.ShowBalloonTip(2500, "Update complete", $"Successfully updated {Application.ProductName} to version {Application.ProductVersion}.", ToolTipIcon.Info);
            }

            if (noTray)
            {
                Globals.DisplayTrayIcon = false;
                TrayNotifyIcon.Visible = false;
            }


            bool isAdmin = Utils.IsAdministrator();

            TitleLabelMenuItem.Text = $"{Application.ProductName} v{Application.ProductVersion}" + (isAdmin ? " (Administrator)" : "");


            if (!attemptedAdmin && !isAdmin && Settings.Default.AutoRetryAdmin)
            {
                new Task( () =>
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
                InitialiseProgram().ConfigureAwait(false);
        }

        private async Task InitialiseProgram()
        {
            Globals.InputHandler = new InputHandler();
            await Task.Run(() =>
            {
                if (Settings.Default.UpdateSettings)
                {
                    Settings.Default.Upgrade();
                    Settings.Default.UpdateSettings = false;
                    Settings.Default.Save();
                }

                Globals.MainForm = this;

                Globals.VolumeBarAutoHideTimeout = Settings.Default.AutoHideTimeOut;

                Invoke((MethodInvoker)delegate
               {
                   VolumeTextLabel.Font = Settings.Default.VolumeBarFontStyle;
                   Size labelSize = Utils.CalculateLabelSize(VolumeTextLabel, "100%");
                   Size volumeBarMinSize = new Size(Settings.Default.BarWidthPadding + labelSize.Width, Settings.Default.BarHeightPadding + labelSize.Height + 5);
                   if (Settings.Default.DisplayTrayIconAsText)
                       TrayNotifyIcon.Icon = Utils.GenerateTrayIcon("T");
                   MinimumSize = volumeBarMinSize;
                   Height = volumeBarMinSize.Height;
                   Width = volumeBarMinSize.Width;
                   SetVolumeBarPosition();
                   Utils.ShowWindow(Handle, 4);
                   HideVolumeBar();
               });
                Globals.AudioHandler = new AudioHandler();
            });
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
            hideVolumeBarTimer.Interval = (Globals.VolumeBarAutoHideTimeout);
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

        private void ShowTrayMenuOnClick(object sender, EventArgs e)
        {
            MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
            mi.Invoke(TrayNotifyIcon, null);
        }

        private void OpenConfigureDialog(object sender, EventArgs e)
        {
            new ConfigurationForm().ShowDialog();
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
            e.Graphics.DrawRectangle(new Pen(Color.Black, 2), DisplayRectangle);
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
                    hideVolumeBarTimer.Stop();
                    SuspendLayout();
                    switch (updateType)
                    {
                        case "volume":
                            VolumeTextLabel.Text = $"{AudioState.Volume}%";
                            TrayNotifyIcon.Text = $"{AudioState.CoreAudioController.DefaultPlaybackDevice.Name}: {AudioState.Volume}%";
                            Width = Utils.CalculateLabelSize(VolumeTextLabel, "100%").Width + AudioState.Volume + Settings.Default.BarWidthPadding;
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
                    SetVolumeBarPosition();
                    if (!Settings.Default.DisplayVolumeBarScrolling && updateType == "volume")
                        return;
                    ResumeLayout();
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

        private void ShowVolumeSliderPopupForm(object sender, MouseEventArgs e)
        {
            if (AudioState.AudioAvailable && e.Button == MouseButtons.Middle)
            {
                TrayContextMenu.Hide();
                Globals.VolumeSliderControlForm = new VolumeSliderControlForm();
                Globals.VolumeSliderControlForm.ShowDialog();
                Globals.VolumeSliderControlForm = null;

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
    }
}