﻿using System;
using System.Collections;
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

        private Queue updateDeviceTaskQueue = new Queue();
        private Task updateDeviceTask = null;


        public AudioPlaybackDevicesForm()
        {
            InitializeComponent();
            //Utils.SetWindowTheme(DevicesListView.Handle, "Explorer", null);

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

        private async Task ProcessUpdateDeviceQueue()
        {
            if ((updateDeviceTask == null) || updateDeviceTask.IsCompleted)
            {
                if (updateDeviceTaskQueue.Count != 0)
                {
                    updateDeviceTaskQueue.Dequeue();
                    updateDeviceTask = RefreshOnDeviceActivity();
                    await updateDeviceTask;
                    if (updateDeviceTaskQueue.Count != 0)
                        await ProcessUpdateDeviceQueue();
                }
            }
        }

        public async Task LoadAudioPlaybackDevicesList()
        {
            List<ListViewItem> deviceListViewItem = new List<ListViewItem>();
            List<CoreAudioDevice> audioDevices = (await Globals.AudioHandler.AudioController.GetPlaybackDevicesAsync(DeviceState.Active)).ToList();
            if (audioDevices.Count != 0)
            {
                foreach (CoreAudioDevice d in audioDevices)
                {
                    Icon iconImg = Utils.GetIconFromResource(d.IconPath);
                    DevicesListViewImageList.Images.Add(iconImg);
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
                bool hasScrollBars = DevicesListView.ClientSize.Height < (DevicesListView.Items.Count + 1) * DevicesListView.Items[0].Bounds.Height;
                DevicesListView.Columns[0].Width = DevicesListView.Width - (60 * 3) - (hasScrollBars ? 25 : 0);
                RefreshButton.Enabled = true;
            });
        }

        private async void SetDefaultButton_Click(object sender, EventArgs e)
        {
            if (DevicesListView.SelectedItems.Count == 1)
            {
                CoreAudioDevice newPlaybackDevice = (CoreAudioDevice)DevicesListView.SelectedItems[0].Tag;
                DevicesListView.SelectedItems.Clear();
                await newPlaybackDevice.SetAsDefaultAsync();
            }
            MakeDefaultButton.Enabled = false;
        }

        public async Task RefreshOnDeviceActivity()
        {
            List<CoreAudioDevice> audioDevices = (await Globals.AudioHandler.AudioController.GetPlaybackDevicesAsync(DeviceState.Active)).ToList();
            Utils.InvokeIfRequired(this, () =>
            {
                RefreshButton.Enabled = false;
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
                    CoreAudioDevice audioDevice = (CoreAudioDevice)deviceItem.Tag;
                    Icon iconImg = Utils.GetIconFromResource(audioDevice.IconPath);
                    DevicesListViewImageList.Images.Add(iconImg);
                    deviceItem.ImageIndex = DevicesListView.Items.IndexOf(deviceItem);

                    bool hasScrollBars = DevicesListView.ClientSize.Height < (DevicesListView.Items.Count + 1) * DevicesListView.Items[0].Bounds.Height;
                    DevicesListView.Columns[0].Width = DevicesListView.Width - (60 * 3) - (hasScrollBars ? 25 : 0);
                    RefreshButton.Enabled = true;

                }
            });
        }

        public async Task OnDeviceChanged()
        {
            if (updateDeviceTaskQueue.Count == 0)
                updateDeviceTaskQueue.Enqueue(null);
            if (updateDeviceTaskQueue.Count != 0)
                await ProcessUpdateDeviceQueue();


        }


        private async void RefreshButton_Click(object sender, EventArgs e)
        {
            await OnDeviceChanged();
        }

        private void AudioPlaybackDevicesForm_Deactivate(object sender, EventArgs e)
        {
                Close();
        }

        private void DevicesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            MakeDefaultButton.Enabled = DevicesListView.SelectedItems.Count == 1;
            Utils.AvoidControlFocus(DevicesListView.Handle);
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

        private void AudioPlaybackDevicesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateDeviceTaskQueue.Clear();
            updateDeviceTask = null;
        }
    }
}
