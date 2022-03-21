using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;
using tb_vol_scroll.Classes;
using tb_vol_scroll.Classes.Helpers;

namespace tb_vol_scroll.Forms
{
    public partial class AudioPlaybackDevicesForm : Form
    {
        private bool isRefreshing = false;
        public AudioPlaybackDevicesForm()
        {
            InitializeComponent();

        }

        private async void AudioPlaybackDevicesForm_Shown(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Point position = Cursor.Position;
            Screen screen = Screen.FromPoint(position);
            Rectangle workingArea = screen.WorkingArea;
            switch (Taskbar.Position)
            {
                case Taskbar.TaskbarPosition.Bottom:
                    Location = new Point(workingArea.Right - Width - 10, workingArea.Bottom - Height - 10);
                    break;
                case Taskbar.TaskbarPosition.Right:
                    Location = new Point(workingArea.Right - Width - 10, workingArea.Bottom - Height - 10);
                    break;
                case Taskbar.TaskbarPosition.Left:
                    Location = new Point(workingArea.Left + 10, workingArea.Bottom - Height - 10);
                    break;
                case Taskbar.TaskbarPosition.Top:
                    Location = new Point(workingArea.Right - Width - 10, workingArea.Top + 10);
                    break;

            }
            await LoadAudioPlaybackDevicesList();
        }

        public async Task LoadAudioPlaybackDevicesList()
        {
            Utils.InvokeIfRequired(this, () =>
            {
                SuspendLayout();
                DevicesListView.Items.Clear();
                SetDefaultButton.Enabled = false;
                RefreshButton.Enabled = false;
            });

            List<ListViewItem> deviceListViewItem = new List<ListViewItem>();
            List<CoreAudioDevice> audioDevices = (await Task.Run(() => Globals.AudioHandler.AudioController.GetPlaybackDevicesAsync(DeviceState.Active))).ToList();
            if (audioDevices.Count != 0)
            {
                foreach (CoreAudioDevice d in audioDevices)
                {
                    Utils.ExtractIconEx(d.IconPath.Split(',')[0], int.Parse(d.IconPath.Split(',')[1]), out IntPtr hIcon, IntPtr.Zero, 1);
                    DevicesListViewImageList.Images.Add(Icon.FromHandle(hIcon));
                    ListViewItem deviceItem = new ListViewItem
                    {
                        ImageIndex = audioDevices.IndexOf(d),
                        Text = d.FullName
                    };
                    deviceItem.SubItems.Add($"{(int)Math.Round(d.Volume)}%");
                    deviceItem.SubItems.Add(d.IsDefaultDevice ? "Yes" : "No");
                    deviceItem.SubItems.Add(d.IsMuted ? "Yes" : "No");
                    deviceItem.BackColor = d.IsDefaultDevice ? Color.FromArgb(225, 255, 225) : Color.White;
                    deviceItem.Tag = d;
                    deviceListViewItem.Add(deviceItem);
                }
            }
            Utils.InvokeIfRequired(this, () =>
            {
                DevicesListView.Items.AddRange(deviceListViewItem.ToArray());
                RefreshButton.Enabled = true;
                bool hasScrollBars = DevicesListView.ClientSize.Height < (DevicesListView.Items.Count + 1) * DevicesListView.Items[0].Bounds.Height;
                DevicesListView.Columns[0].Width = DevicesListView.Width - (60 * 3) - (hasScrollBars ? 25 : 0);
                ResumeLayout();
            });
        }

        private async void SetDefaultButton_Click(object sender, EventArgs e)
        {
            if (DevicesListView.SelectedItems.Count == 0)
            {
                CoreAudioDevice newPlaybackDevice = (CoreAudioDevice)DevicesListView.SelectedItems[0].Tag;
                await newPlaybackDevice.SetAsDefaultAsync();
            }
            SetDefaultButton.Enabled = false;
        }

        public async Task RefreshOnDeviceActivity()
        {
            if (!isRefreshing)
            {
                isRefreshing = true;
                List<CoreAudioDevice> audioDevices = (await Task.Run(() => Globals.AudioHandler.AudioController.GetPlaybackDevicesAsync(DeviceState.Active))).ToList();
                Utils.InvokeIfRequired(this, () =>
                {
                    foreach (ListViewItem deviceItem in DevicesListView.Items)
                    {
                        if (audioDevices.Contains(deviceItem.Tag))
                        {
                            deviceItem.SubItems[1].Text = $"{(int)Math.Round(((CoreAudioDevice)deviceItem.Tag).Volume)}%";
                            deviceItem.SubItems[2].Text = ((CoreAudioDevice)deviceItem.Tag).IsDefaultDevice ? "Yes" : "No";
                            deviceItem.SubItems[3].Text = ((CoreAudioDevice)deviceItem.Tag).IsMuted ? "Yes" : "No";
                            deviceItem.BackColor = ((CoreAudioDevice)deviceItem.Tag).IsDefaultDevice ? Color.FromArgb(225, 255, 225) : Color.White;
                        }
                        else
                            deviceItem.Remove();
                        audioDevices.Remove((CoreAudioDevice)deviceItem.Tag);
                    }
                    if (audioDevices.Count != 0)
                    {
                        foreach (CoreAudioDevice device in audioDevices)
                        {
                            ListViewItem deviceItem = new ListViewItem
                            {
                                Text = device.FullName
                            };
                            deviceItem.SubItems.Add($"{(int)Math.Round(device.Volume)}%");
                            deviceItem.SubItems.Add(device.IsDefaultDevice ? "Yes" : "No");
                            deviceItem.SubItems.Add(device.IsMuted ? "Yes" : "No");
                            deviceItem.BackColor = device.IsDefaultDevice ? Color.FromArgb(230, 255, 230) : Color.White;
                            deviceItem.Tag = device;
                            DevicesListView.Items.Add(deviceItem);
                        }
                    }
                    DevicesListViewImageList.Images.Clear();
                    foreach (ListViewItem deviceItem in DevicesListView.Items)
                    {
                        CoreAudioDevice audioDevice = ((CoreAudioDevice)deviceItem.Tag);
                        Utils.ExtractIconEx(audioDevice.IconPath.Split(',')[0], int.Parse(audioDevice.IconPath.Split(',')[1]), out IntPtr hIcon, IntPtr.Zero, 1);
                        DevicesListViewImageList.Images.Add(Icon.FromHandle(hIcon));
                        deviceItem.ImageIndex = DevicesListView.Items.IndexOf(deviceItem);

                    }
                    bool hasScrollBars = DevicesListView.ClientSize.Height < (DevicesListView.Items.Count + 1) * DevicesListView.Items[0].Bounds.Height;
                    DevicesListView.Columns[0].Width = DevicesListView.Width - (60 * 3) - (hasScrollBars ? 25 : 0);

                });
                isRefreshing = false;
            }
        }


        private async void RefreshButton_Click(object sender, EventArgs e)
        {
            await RefreshOnDeviceActivity();
        }

        private void AudioPlaybackDevicesForm_Deactivate(object sender, EventArgs e)
        {
            if (!isRefreshing)
                Close();
        }

        private void DevicesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDefaultButton.Enabled = DevicesListView.SelectedItems.Count == 1;
        }

        private async void DevicesListView_DoubleClick(object sender, EventArgs e)
        {
            if (DevicesListView.SelectedItems.Count == 1)
            {
                CoreAudioDevice newPlaybackDevice = (CoreAudioDevice)DevicesListView.SelectedItems[0].Tag;
                await newPlaybackDevice.SetAsDefaultAsync();
                if (!isRefreshing)
                    Close();
            }
        }
    }
}
