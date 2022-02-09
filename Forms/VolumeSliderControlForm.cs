using AudioSwitcher.AudioApi.Session;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
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

        public VolumeSliderControlForm()
        {
            InitializeComponent();
            Globals.VolumeSliderControlForm = this;
            Point position = Cursor.Position;
            Screen screen = Screen.FromPoint(position);
            Rectangle workingArea = screen.WorkingArea;
            PeakMeterPictureBox.BackColor = Globals.DefaultColor;

            switch (TaskbarHandler.Position)
            {
                case TaskbarHandler.TaskbarPosition.Bottom:
                    Location = new Point(workingArea.Right - Width - 10, workingArea.Bottom - Height - 10);
                    break;
                case TaskbarHandler.TaskbarPosition.Right:
                    Location = new Point(workingArea.Right - Width - 10, workingArea.Bottom - Height - 10);
                    break;
                case TaskbarHandler.TaskbarPosition.Left:
                    Location = new Point(workingArea.Left + 10, workingArea.Bottom - Height - 10);
                    break;
                case TaskbarHandler.TaskbarPosition.Top:
                    Location = new Point(workingArea.Right - Width - 10, workingArea.Top + 10);
                    break;

            }

            VolumeTrackBar.Value = AudioState.Volume;
            RefreshOnDeviceActivity(updateDeviceInfo: true);
            

        }

        public void RefreshOnDeviceActivity(bool updateDeviceInfo = false)
        {
            VolumeTrackBar.Value = AudioState.Volume;
            VolumeLabel.Text = $"{(AudioState.Muted ? ("Muted") : AudioState.Volume + "%")}";
            if (updateDeviceInfo)
            {
                AudioDeviceNameLabel.Text = AudioState.CoreAudioController.DefaultPlaybackDevice.Name;
                VolumeSliderTooltip.SetToolTip(AudioDeviceNameLabel, AudioState.CoreAudioController.DefaultPlaybackDevice.FullName);
                Utils.ExtractIconEx(AudioState.CoreAudioController.DefaultPlaybackDevice.IconPath.Split(',')[0], int.Parse(AudioState.CoreAudioController.DefaultPlaybackDevice.IconPath.Split(',')[1]), out IntPtr hIcon, IntPtr.Zero, 1);
                using (Icon tmpIcon = Icon.FromHandle(hIcon))
                {
                    Icon newIcon = (Icon)tmpIcon.Clone();
                    Utils.DestroyIcon(tmpIcon.Handle);
                    AudioDevicePictureBox.Image = newIcon.ToBitmap();
                }
            }
        }

        private void OnFormShown(object sender, EventArgs e)
        {
            Activate();
            Invalidate();
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
            if (updateVolumeQueue.Count < 100)
            {
                updatePeakValueQueue.Enqueue(peakValue);
                await ProcessPeakValueEventQueue();
            }
        }

        private async Task HandleVolumeUpdate(int volume)
        {
            if (AudioState.Volume != volume)
            {
                try
                {
                    if (AudioState.Volume == 0)
                        await Globals.AudioHandler.SetDeviceVolume(10);
                    await Globals.AudioHandler.SetDeviceVolume(volume);
                    if ((int)Math.Round(AudioState.CoreAudioController.DefaultPlaybackDevice.Volume) == 0 && AudioState.Muted == false)
                    {
                        await Globals.AudioHandler.SetDeviceMute(isMuted: true);
                        Invoke((MethodInvoker)delegate
                        {
                            PeakMeterPictureBox.BackColor = SystemColors.ControlLight;
                        });
                    }
                    else if ((int)Math.Round(AudioState.CoreAudioController.DefaultPlaybackDevice.Volume) > 0 && AudioState.Muted == true)
                        await Globals.AudioHandler.SetDeviceMute(isMuted: false);

                    Invoke((MethodInvoker)delegate
                   {
                       VolumeLabel.Text = $"{(AudioState.CoreAudioController.DefaultPlaybackDevice.IsMuted ? ("Muted") : (int)Math.Round(AudioState.CoreAudioController.DefaultPlaybackDevice.Volume) + "%")}";
                   });
                }
                catch { }
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
                    });
                }
                catch {
                  
                }
            });
        }


        public void CloseFormOnDeactivate(object sender, EventArgs e)
        {
            updatePeakValueQueue.Clear();
            updateVolumeQueue.Clear();
            currentPeakValueTask = null;
            currentUpdateVolumeTask = null;
            Close();
        }

        private async void UpdateVolumeFromTrackBar(object sender, EventArgs e)
        {
                if (updateVolumeQueue.Count < 10)
                {
                    updateVolumeQueue.Enqueue(VolumeTrackBar.Value);
                }
                await ProcessVolumeQueue();

            Utils.AvoidControlFocus(Handle);

        }

        private void PlaySound(object sender, MouseEventArgs e)
        {
            SystemSounds.Exclamation.Play();

        }

        private void AvoidControlFocus(object sender, EventArgs e)
        {
            Utils.AvoidControlFocus(Handle);
        }

        private void DrawVolumeSliderBorder(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Black, 2))
            {
                Rectangle rect = DisplayRectangle;
                e.Graphics.DrawRectangle(pen, rect);
            }
        }
    }
}
