using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;
using AudioSwitcher.AudioApi.Observables;
using System;
using System.Collections.Generic;
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
        private double currentPeakValue = 0;

        private readonly Queue<DevicePeakValueChangedArgs> updatePeakValueQueue = new Queue<DevicePeakValueChangedArgs>();
        private Task currentPeakValueTask = null;

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
            try
            {
                var device = await Globals.AudioHandler.CoreAudioController.GetDefaultDeviceAsync(DeviceType.Playback, Role.Multimedia);
                if (device != null)
                {
                    deviceVolumeObserver = device.PeakValueChanged.Subscribe(UpdatePeakValue);
                    if (currentPeakValue == 0)
                        UpdatePeakValue(new DevicePeakValueChangedArgs(null, 0));
                }
                else
                    CloseFormOnDeacivate(null, null);
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }

        private async Task ProcessPeakValueEventQueue()
        {
            if ((currentPeakValueTask == null) || currentPeakValueTask.IsCompleted)
            {
                if (updatePeakValueQueue.Count > 0)
                {
                    var peakValueArgs = updatePeakValueQueue.Dequeue();
                    currentPeakValueTask = HandlePeakValueUpdate(peakValueArgs);
                    await currentPeakValueTask;

                    await ProcessPeakValueEventQueue();
                }
            }
        }


        private async void UpdatePeakValue(DevicePeakValueChangedArgs peakValue)
        {
            updatePeakValueQueue.Enqueue(peakValue);
            await ProcessPeakValueEventQueue();
        }

        private async Task HandlePeakValueUpdate(DevicePeakValueChangedArgs peakValue)
        {
            currentPeakValue = Math.Round(peakValue.PeakValue);
            if (currentPeakValue < 0)
                currentPeakValue = 0;
            if (currentPeakValue > 100)
                currentPeakValue = 100;

            await Globals.AudioHandler.UpdateAudioState();

            double value = Math.Round(peakValue.PeakValue / 100 * Globals.AudioHandler.Volume, 2);
            await Task.Run(() =>
            {
                Invoke((MethodInvoker)delegate
                {
                    PeakMeterPictureBox.BackColor = Utils.CalculateColor(100 - value);
                    double widthPerc = Math.Round((double)PeakMeterPanel.Width / 100, 2);
                    PeakMeterPictureBox.Width = (int)Math.Round(value * widthPerc);
                    VolumeTrackBar.Value = Globals.AudioHandler.Volume;
                    VolumeLabel.Text = $"{Globals.AudioHandler.Volume}%";
                    AudioDeviceLabel.Text = Globals.AudioHandler.CoreAudioController.DefaultPlaybackDevice.Name;
                });
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
            Globals.VolumeSliderControlForm = null;
            Close();
        }
    }
}
