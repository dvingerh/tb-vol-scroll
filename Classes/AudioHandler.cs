using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;
using AudioSwitcher.AudioApi.Observables;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;
using tbvolscroll.Classes;
using tbvolscroll.Properties;

namespace tbvolscroll
{
    public class AudioHandler
    {
        private Queue<DeviceChangedArgs> deviceStateEventQueue = new Queue<DeviceChangedArgs>();
        private Task currentDeviceStateEventTask = null;
        private AudioSrvPoller audioSrvPoller = new AudioSrvPoller("audiosrv");

        public Queue<DeviceChangedArgs> DeviceStateEventQueue { get => deviceStateEventQueue; set => deviceStateEventQueue = value; }
        public AudioSrvPoller AudioSrvPoller { get => audioSrvPoller; set => audioSrvPoller = value; }

        public AudioHandler()
        {
            audioSrvPoller.StatusChanged += AudioServiceStatusChanged;
            if (audioSrvPoller.Status == ServiceControllerStatus.Running)
            {
                InitialiseAudioController();
                AudioState.AudioAvailable = true;
            }
            else
                AudioState.AudioAvailable = false;
        }

        private void InitialiseAudioController(bool subscribeEvents = true)
        {
            AudioState.CoreAudioController = new CoreAudioController();
            AudioState.CoreAudioController.AudioDeviceChanged.Subscribe(DeviceStateChanged);
            if (subscribeEvents)
            {
                foreach (var device in AudioState.CoreAudioController.GetPlaybackDevices(DeviceState.Active))
                {
                    device.StateChanged.Subscribe(DeviceStateChanged);
                    device.VolumeChanged.Subscribe(DeviceStateChanged);
                    device.MuteChanged.Subscribe(DeviceStateChanged);
                    device.PeakValueChanged.Subscribe(DeviceStateChanged);
                    device.PeakValueTimer.PeakValueInterval = 75;
                }
            }
        }

        private async void AudioServiceStatusChanged(object sender, ServiceStatusEventArgs e)
        {
            if (e.Status == ServiceControllerStatus.Stopped)
            {
                AudioState.AudioAvailable = false;
                DeviceStateEventQueue.Clear();
                Globals.MainForm.TrayNotifyIcon.Visible = true;
                Globals.MainForm.TrayNotifyIcon.ShowBalloonTip(2500, "Windows Audio service not running", $"{Application.ProductName} will restart automatically when the service becomes available.", ToolTipIcon.Warning);
                await UpdateAudioState();
            }
            else
            {
                if (e.Status == ServiceControllerStatus.Running)
                {
                    Process proc = new Process();
                    proc.StartInfo.FileName = Application.ExecutablePath;
                    proc.StartInfo.UseShellExecute = true;
                    proc.StartInfo.Verb = "runas";
                    Globals.MainForm.HandleApplicationExit(proc, 0);
                }
            }
        }

        public async Task<List<CoreAudioDevice>> GetPlaybackDevices()
        {
            List<CoreAudioDevice> coreAudioDevices = new List<CoreAudioDevice>();
            try
            {
                if (AudioState.CoreAudioController != null)
                {
                    IEnumerable<CoreAudioDevice> ieDevices = await AudioState.CoreAudioController.GetPlaybackDevicesAsync(DeviceState.Active);
                    foreach (CoreAudioDevice device in ieDevices)
                        coreAudioDevices.Add(device);
                }
                return coreAudioDevices;
            }
            catch {
                coreAudioDevices.Clear();
                return coreAudioDevices;
            }
        }

        public async Task SetDefaultDevice(CoreAudioDevice coreAudioDevice)
        {
            if (AudioState.CoreAudioController != null)
                await coreAudioDevice.SetAsDefaultAsync();
        }



        private async Task ProcessDeviceEventQueue()
        {
            if (currentDeviceStateEventTask == null || currentDeviceStateEventTask.IsCompleted)
            {
                if (deviceStateEventQueue.Count > 0)
                {
                    var refreshArgs = deviceStateEventQueue.Dequeue();
                    currentDeviceStateEventTask = HandleDeviceEvent(refreshArgs);
                    await currentDeviceStateEventTask;

                    await ProcessDeviceEventQueue();
                }
            }
        }

        public async Task HandleDeviceEvent(DeviceChangedArgs value)
        {
            if (value != null)
            {
                Console.WriteLine(value.ChangedType);
                switch (value.ChangedType)
                {
                    case DeviceChangedType.VolumeChanged:
                    case DeviceChangedType.MuteChanged:
                    case DeviceChangedType.DefaultChanged:
                        if (value.ChangedType == DeviceChangedType.MuteChanged)
                            await UpdateAudioState();
                        if (!Globals.InputHandler.IsScrolling)
                            await UpdateAudioState();
                        if (Globals.AudioPlaybackDevicesForm != null)
                            await Globals.AudioPlaybackDevicesForm.RefreshOnDeviceActivity();
                        break;
                    case DeviceChangedType.PeakValueChanged:
                        if (Globals.VolumeSliderControlForm != null && !AudioState.Muted)
                        {
                            DevicePeakValueChangedArgs peakVal = (DevicePeakValueChangedArgs)value;
                            double currentPeakValue = Math.Round(peakVal.PeakValue);
                            if (currentPeakValue < 0)
                                currentPeakValue = 0;
                            if (currentPeakValue > 100)
                                currentPeakValue = 100;

                            Globals.VolumeSliderControlForm.UpdatePeakValue(currentPeakValue);
                        }
                        break;
                    default:
                        deviceStateEventQueue.Clear();
                        await UpdateAudioState();
                        break;
                }
            }
        }


        public async void DeviceStateChanged(DeviceChangedArgs value)
        {
            if (AudioState.AudioAvailable)
            {
                deviceStateEventQueue.Enqueue(value);
                await ProcessDeviceEventQueue();
            }
        }

        public async Task UpdateAudioState()
        {
            if (AudioState.CoreAudioController != null)
            {
                CoreAudioDevice coreAudioDevice = AudioState.CoreAudioController.DefaultPlaybackDevice;
                if (coreAudioDevice != null)
                {
                    if (coreAudioDevice.State == DeviceState.Active)
                    {
                        AudioState.Volume = (int)AudioState.CoreAudioController.DefaultPlaybackDevice.Volume;
                        AudioState.Muted = AudioState.CoreAudioController.DefaultPlaybackDevice.IsMuted;
                        AudioState.AudioAvailable = true;
                    }
                    else
                        AudioState.AudioAvailable = false;
                }
                else
                {
                    AudioState.AudioAvailable = false;
                    Globals.InputHandler.MouseScrollQueue.Clear();
                    deviceStateEventQueue.Clear();
                }
            }


            await Task.Run(() =>
            {
                Globals.MainForm.Invoke((MethodInvoker)delegate
                {
                    Globals.MainForm.VolumeSliderControlMenuItem.Enabled = AudioState.AudioAvailable;
                    Globals.MainForm.AudioPlaybackDevicesMenuItem.Enabled = AudioState.AudioAvailable;
                    Globals.MainForm.SystemVolumeMixerMenuItem.Enabled = AudioState.AudioAvailable;
                    Globals.MainForm.MoreOptionsMenuItem.Enabled = AudioState.AudioAvailable;
                    Globals.MainForm.SetTrayIcon();
                });
            });
        }

        public async Task SetDeviceVolume(int volume)
        {
            if (AudioState.CoreAudioController.DefaultPlaybackDevice != null)
                await AudioState.CoreAudioController.DefaultPlaybackDevice.SetVolumeAsync(volume);
        }

        public async Task SetDeviceMute(bool isMuted = false)
        {
            if (AudioState.CoreAudioController.DefaultPlaybackDevice != null)
                await AudioState.CoreAudioController.DefaultPlaybackDevice.SetMuteAsync(isMuted);
        }

        public async Task DoVolumeChanges(int scrollDirection)
        {

            if ((scrollDirection < 0 && AudioState.Volume != 0) || (scrollDirection > 0 && AudioState.Volume != 100))
            {
                int newVolume = AudioState.Volume;

                if (scrollDirection < 0)
                {
                    if (Globals.InputHandler.IsAltDown && Settings.Default.ManualPreciseVolumeShortcut || AudioState.Volume <= Settings.Default.PreciseScrollThreshold)
                        newVolume -= 1;
                    else
                        newVolume -= Settings.Default.VolumeStep;
                    if (newVolume < 0)
                        newVolume = 0;
                    await SetDeviceVolume(newVolume);
                }
                else
                {
                    if (AudioState.Volume == 0)
                        await SetDeviceVolume(10); // Workaround for stuck at 0 bug in AudioSwitcher lib
                    if (Globals.InputHandler.IsAltDown && Settings.Default.ManualPreciseVolumeShortcut || AudioState.Volume < Settings.Default.PreciseScrollThreshold)
                        newVolume += 1;
                    else
                        newVolume += Settings.Default.VolumeStep;
                    if (newVolume > 100)
                        newVolume = 100;
                    if (newVolume > 0 && AudioState.Muted)
                    {
                        await SetDeviceVolume(newVolume);
                        await SetDeviceMute(isMuted: false);
                    }
                    else
                        await SetDeviceVolume(newVolume);
                }
            }
        }

        public async Task ToggleAudioPlaybackDevice(int delta)
        {
            List<CoreAudioDevice> audioDevicesList = await GetPlaybackDevices();
            if (audioDevicesList.Count != 0)
            {
                CoreAudioDevice curDevice = AudioState.CoreAudioController.DefaultPlaybackDevice;
                if (AudioState.CurrentAudioDeviceIndex == -1)
                    AudioState.CurrentAudioDeviceIndex = audioDevicesList.FindIndex(x => x.Id == curDevice.Id);
                int newDeviceIndex = AudioState.CurrentAudioDeviceIndex;

                if (delta < 0)
                {
                    if (AudioState.CurrentAudioDeviceIndex > 0)
                        --AudioState.CurrentAudioDeviceIndex;
                    else
                        AudioState.CurrentAudioDeviceIndex = 0;
                }
                else
                {
                    if (AudioState.CurrentAudioDeviceIndex < audioDevicesList.Count - 1)
                        ++AudioState.CurrentAudioDeviceIndex;
                    else
                        AudioState.CurrentAudioDeviceIndex = audioDevicesList.Count - 1;
                }
                CoreAudioDevice newPlaybackDevice = audioDevicesList[AudioState.CurrentAudioDeviceIndex];

                if (curDevice != newPlaybackDevice)
                {
                    deviceStateEventQueue.Clear();
                    await newPlaybackDevice.SetAsDefaultAsync();
                }
            }
        }
    }
}