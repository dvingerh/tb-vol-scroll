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
            try
            {
                VolumeTrackBar.Value = AudioState.Volume;
                VolumeLabel.Text = $"{(AudioState.Muted ? ("Muted") : AudioState.Volume + "%")}";
                if (updateDeviceInfo)
                {
                    updateVolumeQueue.Clear();
                    currentUpdateVolumeTask = null;
                    updatePeakValueQueue.Clear();
                    currentPeakValueTask = null;

                    AudioDeviceNameLabel.Text = AudioState.CoreAudioController.DefaultPlaybackDevice.Name;
                    VolumeSliderTooltip.SetToolTip(AudioDeviceNameLabel, AudioState.CoreAudioController.DefaultPlaybackDevice.FullName);
                    Utils.ExtractIconEx(AudioState.CoreAudioController.DefaultPlaybackDevice.IconPath.Split(',')[0], int.Parse(AudioState.CoreAudioController.DefaultPlaybackDevice.IconPath.Split(',')[1]), out IntPtr hIcon, IntPtr.Zero, 1);
                    using (Icon tmpIcon = Icon.FromHandle(hIcon))
                    {
                        Icon newIcon = (Icon)tmpIcon.Clone();
                        Utils.DestroyIcon(tmpIcon.Handle);
                        AudioDevicePictureBox.Image = newIcon.ToBitmap();
                    }
                    UpdatePeakValue(AudioState.CoreAudioController.DefaultPlaybackDevice.PeakValue * 100);
                }
            }
            catch { }

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
                    if (updatePeakValueQueue.Count > 0)
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
                    if (updateVolumeQueue.Count > 0)
                        await ProcessVolumeQueue();
                }
            }
        }



        public async void UpdatePeakValue(double peakValue)
        {
            if (updatePeakValueQueue.Count < 5)
            {
                updatePeakValueQueue.Enqueue(peakValue);
                if (updatePeakValueQueue.Count > 0)
                    await ProcessPeakValueEventQueue();
            }
        }

        private async Task HandleVolumeUpdate(int volume)
        {
            if (AudioState.Volume != volume)
            {
                if (AudioState.Volume == 0)
                    await Globals.AudioHandler.SetDeviceVolume(10);
                await Globals.AudioHandler.SetDeviceVolume(volume);
                int curVolume = (int)Math.Round(AudioState.CoreAudioController.DefaultPlaybackDevice.Volume);
                if (curVolume == 0 && AudioState.Muted == false)
                {
                    await Globals.AudioHandler.SetDeviceMute(isMuted: true);
                    if (InvokeRequired)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            PeakMeterPictureBox.BackColor = SystemColors.ControlLight;
                        });
                    }else
                        PeakMeterPictureBox.BackColor = SystemColors.ControlLight;

                }
                else if (curVolume > 0 && AudioState.Muted == true)
                    await Globals.AudioHandler.SetDeviceMute(isMuted: false);

                if (InvokeRequired)
                {
                    Invoke((MethodInvoker)delegate
                   {
                       VolumeLabel.Text = $"{(AudioState.CoreAudioController.DefaultPlaybackDevice.IsMuted ? ("Muted") : curVolume + "%")}";
                   });
                }else
                    VolumeLabel.Text = $"{(AudioState.CoreAudioController.DefaultPlaybackDevice.IsMuted ? ("Muted") : curVolume + "%")}";

            }
        }

        private async Task HandlePeakValueUpdate(double peakValue)
        {
            await Task.Run(() =>
            {
                try
                {
                    double curValue = Math.Round(peakValue / 100 * AudioState.Volume, 2);
                    double widthPerc = Math.Round((double)PeakMeterPanel.Width / 100, 2);
                    double maxValue = Math.Round(peakValue / 100 * 100, 2);
                    if (InvokeRequired)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            PeakMeterPictureBox.BackColor = Utils.CalculateColor(100 - curValue);
                            PeakMeterPictureBox.Width = (int)Math.Round(curValue * widthPerc);
                            pictureBox1.BackColor = Color.FromArgb(25, 0, 0, 0);
                            pictureBox1.Width = (int)Math.Round(maxValue * widthPerc);
                            PeakMeterPanel.Refresh();

                        });
                    }
                    else
                    {
                        PeakMeterPictureBox.BackColor = Utils.CalculateColor(100 - curValue);
                        PeakMeterPictureBox.Width = (int)Math.Round(curValue * widthPerc);
                        pictureBox1.BackColor = Color.FromArgb(25, 0, 0, 0);
                        pictureBox1.Width = (int)Math.Round(maxValue * widthPerc);
                        PeakMeterPanel.Refresh();
                    }
                }
                catch { }
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
            if (updateVolumeQueue.Count < 50)
                updateVolumeQueue.Enqueue(VolumeTrackBar.Value);
            if (updateVolumeQueue.Count > 0)
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
