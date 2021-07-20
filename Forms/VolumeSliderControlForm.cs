using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.Observables;
using System;
using System.Drawing;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using tbvolscroll.Classes;

namespace tbvolscroll.Forms
{
    public partial class VolumeSliderControlForm : Form
    {
        IDisposable deviceObserver;
        IDisposable deviceVolumeObserver;
        readonly MainForm callback;
        public VolumeSliderControlForm(MainForm callback)
        {
            InitializeComponent();
            this.callback = callback;
        }

        private async void OnFormShown(object sender, EventArgs e)
        {
            VolumeTrackBar.Value = Globals.AudioHandler.Volume;
            VolumeLabel.Text = $"{Globals.AudioHandler.Volume}%";
            AudioDeviceLabel.Text = Globals.AudioHandler.CoreAudioController.DefaultPlaybackDevice.Name;
            PeakMeterPictureBox.BackColor = Properties.Settings.Default.BarColor;


            Point position = Cursor.Position;
            Screen screen = Screen.FromPoint(position);
            Rectangle workingArea = screen.WorkingArea;

            switch (TaskbarHelper.Position)
            {
                case TaskbarPosition.Bottom:
                    Location = new Point(workingArea.Right - Width - 10, workingArea.Bottom - Height - 10);
                    break;
                case TaskbarPosition.Right:
                    Location = new Point(workingArea.Right - Width - 10, workingArea.Bottom - Height - 10);
                    break;
                case TaskbarPosition.Left:
                    Location = new Point(workingArea.Left + 10, workingArea.Bottom - Height - 10);
                    break;
                case TaskbarPosition.Top:
                    Location = new Point(workingArea.Right - Width - 10, workingArea.Top + 10);
                    break;

            }

            deviceObserver = Globals.AudioHandler.CoreAudioController.AudioDeviceChanged.Subscribe(async x => {
                await Task.Run(async () =>
                {
                    await StartPeakVolumeMeter();
                });
            });

            await Task.Run(async () =>
            {
                await StartPeakVolumeMeter();
            });
        }

        public async Task StartPeakVolumeMeter()
        {
            var device = await Globals.AudioHandler.CoreAudioController.GetDefaultDeviceAsync(DeviceType.Playback, Role.Multimedia);
            deviceVolumeObserver = device.PeakValueChanged.Subscribe(x =>
            {

                int value = (int)Math.Round((x.PeakValue / 100) * Globals.AudioHandler.Volume);
                Invoke((MethodInvoker)delegate
                {
                    if (Properties.Settings.Default.UseBarGradient)
                        PeakMeterPictureBox.BackColor = Utils.CalculateColor(100 - value);
                    PeakMeterPictureBox.Width = value * (PeakMeterPanel.Width / 100);
                    VolumeTrackBar.Value = Globals.AudioHandler.Volume;
                    VolumeLabel.Text = $"{Globals.AudioHandler.Volume}%";
                    AudioDeviceLabel.Text = Globals.AudioHandler.CoreAudioController.DefaultPlaybackDevice.Name;
                });
            });
        }

        private void UpdateVolume(object sender, EventArgs e)
        {
            Globals.AudioHandler.SetMasterVolume(VolumeTrackBar.Value);
            Globals.AudioHandler.UpdateAudioState();
            if (Globals.AudioHandler.Volume == 0 && Globals.AudioHandler.Muted == false)
                Globals.AudioHandler.SetMasterVolumeMute(isMuted: true);
            else if (Globals.AudioHandler.Volume > 0 && Globals.AudioHandler.Muted == true)
                Globals.AudioHandler.SetMasterVolumeMute(isMuted: false);
            Globals.AudioHandler.UpdateAudioState();
            VolumeLabel.Text = $"{Globals.AudioHandler.Volume}%";
            callback.TrayNotifyIcon.Text = $"{Application.ProductName} - {Globals.AudioHandler.Volume}%";
            callback.SetTrayIcon();
            SystemSounds.Exclamation.Play();
        }

        private void CloseFormOnDeacivate(object sender, EventArgs e)
        {
            deviceObserver.Dispose();
            deviceVolumeObserver.Dispose();
            Close();
        }
    }
}
