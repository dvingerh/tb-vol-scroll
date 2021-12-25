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
        private readonly Queue<int> updateVolumeQueue = new Queue<int>();
        private Task currentUpdateVolumeTask = null;
        private readonly Queue<double> updatePeakValueQueue = new Queue<double>();
        private Task currentPeakValueTask = null;
        private int lastTrackBarValue = 0;

        public VolumeSliderControlForm()
        {
            InitializeComponent();
            Globals.VolumeSliderControlForm = this;
        }

        private void OnFormShown(object sender, EventArgs e)
        {
            lastTrackBarValue = (int)AudioState.CoreAudioController.DefaultPlaybackDevice.Volume;
            VolumeTrackBar.Value = (int)AudioState.CoreAudioController.DefaultPlaybackDevice.Volume;
            VolumeLabel.Text = $"{(int)AudioState.CoreAudioController.DefaultPlaybackDevice.Volume}%";
            AudioDeviceLabel.Text = AudioState.CoreAudioController.DefaultPlaybackDevice.Name;
            PeakMeterPictureBox.BackColor = Properties.Settings.Default.VolumeBarSolidColor;


            Point position = Cursor.Position;
            Screen screen = Screen.FromPoint(position);
            Rectangle workingArea = screen.WorkingArea;

            switch (TaskbarHelper.Position)
            {
                case TaskbarHelper.TaskbarPosition.Bottom:
                    Location = new Point(workingArea.Right - Width - 10, workingArea.Bottom - Height - 10);
                    break;
                case TaskbarHelper.TaskbarPosition.Right:
                    Location = new Point(workingArea.Right - Width - 10, workingArea.Bottom - Height - 10);
                    break;
                case TaskbarHelper.TaskbarPosition.Left:
                    Location = new Point(workingArea.Left + 10, workingArea.Bottom - Height - 10);
                    break;
                case TaskbarHelper.TaskbarPosition.Top:
                    Location = new Point(workingArea.Right - Width - 10, workingArea.Top + 10);
                    break;

            }
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

        private async Task ProcessVolumeQueue()
        {
            if ((currentUpdateVolumeTask == null) || currentUpdateVolumeTask.IsCompleted)
            {
                if (updateVolumeQueue.Count > 0)
                {
                    var volumeArgs = updateVolumeQueue.Dequeue();
                    currentUpdateVolumeTask = HandleVolumeUpdate(volumeArgs);
                    await currentUpdateVolumeTask;

                    await ProcessVolumeQueue();
                }
            }
        }



        public async void UpdatePeakValue(double peakValue)
        {
            updatePeakValueQueue.Enqueue(peakValue);
            await ProcessPeakValueEventQueue();
        }

        private async Task HandleVolumeUpdate(int volume)
        {
            if (AudioState.Volume != volume)
            {
                await Task.Run(() =>
                {
                    try
                    {
                        Invoke((MethodInvoker)async delegate
                        {
                            if (AudioState.Volume == 0)
                                await Globals.AudioHandler.SetDeviceVolume(10);
                            await Globals.AudioHandler.SetDeviceVolume(volume);
                            if (AudioState.CoreAudioController.DefaultPlaybackDevice.Volume == 0 && AudioState.Muted == false)
                                await Globals.AudioHandler.SetDeviceMute(isMuted: true);
                            else if (AudioState.CoreAudioController.DefaultPlaybackDevice.Volume > 0 && AudioState.Muted == true)
                                await Globals.AudioHandler.SetDeviceMute(isMuted: false);

                            VolumeLabel.Text = $"{VolumeTrackBar.Value}%";
                            SystemSounds.Exclamation.Play();
                        });
                    }
                    catch { }
                });
            }
        }

        private async Task HandlePeakValueUpdate(double peakValue)
        {
            await Task.Run(() =>
            {
                try
                {
                    Invoke((MethodInvoker)delegate
                    {
                        double value = Math.Round(peakValue / 100 * AudioState.Volume, 2);
                        PeakMeterPictureBox.BackColor = Utils.CalculateColor(100 - value);
                        double widthPerc = Math.Round((double)PeakMeterPanel.Width / 100, 2);
                        PeakMeterPictureBox.Width = (int)Math.Round(value * widthPerc);
                        AudioDeviceLabel.Text = AudioState.CoreAudioController.DefaultPlaybackDevice.Name;
                    });
                }
                catch (Exception ex){
                    Console.WriteLine(ex.ToString());
                }
            });
        }


        private void CloseFormOnDeactivate(object sender, EventArgs e)
        {
            updatePeakValueQueue.Clear();
            updateVolumeQueue.Clear();
            currentPeakValueTask = null;
            currentUpdateVolumeTask = null;
            Globals.VolumeSliderControlForm = null;
            Close();
        }

        private async void UpdateVolumeFromTrackBar(object sender, EventArgs e)
        {
            if (lastTrackBarValue != VolumeTrackBar.Value)
            {
                lastTrackBarValue = VolumeTrackBar.Value;
                updateVolumeQueue.Enqueue(VolumeTrackBar.Value);
                await ProcessVolumeQueue();
            }
        }
    }
}
