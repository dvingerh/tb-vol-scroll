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
        private double currentPeakValue = 100;
        public VolumeSliderControlForm()
        {
            InitializeComponent();
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
            deviceVolumeObserver = device.PeakValueChanged.Subscribe(UpdatePeakValue);
            await Task.Delay(100);
            if (currentPeakValue == 100)
                UpdatePeakValue(new DevicePeakValueChangedArgs(null, 100));
        }

        private void UpdatePeakValue(DevicePeakValueChangedArgs peakValue)
        {
            currentPeakValue = Math.Round(peakValue.PeakValue);
            double value = Math.Round(peakValue.PeakValue / 100 * Globals.AudioHandler.Volume, 2);
            Invoke((MethodInvoker)delegate
            {
                PeakMeterPictureBox.BackColor = Utils.CalculateColor(100 - value);
                double widthPerc = Math.Round((double)PeakMeterPanel.Width / 100, 2);
                PeakMeterPictureBox.Width = (int)Math.Round(value * widthPerc);
                VolumeTrackBar.Value = Globals.AudioHandler.Volume;
                VolumeLabel.Text = $"{Globals.AudioHandler.Volume}%";
                AudioDeviceLabel.Text = Globals.AudioHandler.CoreAudioController.DefaultPlaybackDevice.Name;
            });
        }

        private async void UpdateVolume(object sender, EventArgs e)
        {
            Globals.AudioHandler.SetMasterVolume(VolumeTrackBar.Value);
            if (Globals.AudioHandler.Volume == 0 && Globals.AudioHandler.Muted == false)
                await Globals.AudioHandler.SetMasterVolumeMute(isMuted: true);
            else if (Globals.AudioHandler.Volume > 0 && Globals.AudioHandler.Muted == true)
                await Globals.AudioHandler.SetMasterVolumeMute(isMuted: false);
            VolumeLabel.Text = $"{Globals.AudioHandler.Volume}%";
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
