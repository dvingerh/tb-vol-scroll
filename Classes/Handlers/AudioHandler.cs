using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;
using AudioSwitcher.AudioApi.Observables;
using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;
using tbvolscroll.Classes;
using tbvolscroll.Properties;

namespace tbvolscroll
{
    public class AudioHandler
    {
        private bool isUpdatingPeakValue = false;
        private Queue<DeviceChangedArgs> deviceStateEventQueue = new Queue<DeviceChangedArgs>();
        private Task currentDeviceStateEventTask = null;
        private WinServicePoller servicePoller = new WinServicePoller("audiosrv");
        private readonly List<IDisposable> deviceEventDisposables = new List<IDisposable>();

        public Queue<DeviceChangedArgs> DeviceStateEventQueue { get => deviceStateEventQueue; set => deviceStateEventQueue = value; }
        public WinServicePoller ServicePoller { get => servicePoller; set => servicePoller = value; }

        public AudioHandler()
        {
            servicePoller.StatusChanged += AudioServiceStatusChanged;
            if (servicePoller.Status == ServiceControllerStatus.Running)
                InitialiseAudioController();
        }

        private void InitialiseAudioController(bool subscribeEvents = true)
        {

            AudioState.CoreAudioController = new CoreAudioController();
            //disposables.Add(AudioState.CoreAudioController.AudioDeviceChanged.Subscribe(DeviceStateChanged));
            if (subscribeEvents)
            {
                foreach (var device in AudioState.CoreAudioController.GetPlaybackDevices(DeviceState.Active))
                {
                    deviceEventDisposables.Add(device.PeakValueChanged.Subscribe(DeviceStateChanged));
                    deviceEventDisposables.Add(device.DefaultChanged.Subscribe(DeviceStateChanged));
                    deviceEventDisposables.Add(device.StateChanged.Subscribe(DeviceStateChanged));
                    deviceEventDisposables.Add(device.VolumeChanged.Subscribe(DeviceStateChanged));
                    deviceEventDisposables.Add(device.MuteChanged.Subscribe(DeviceStateChanged));
                }
            }
            Task.Run(async () => { await UpdateAudioState(); });
        }

        private async void AudioServiceStatusChanged(object sender, ServiceStatusEventArgs e)
        {
            if (e.Status == ServiceControllerStatus.Stopped)
            {
                deviceEventDisposables.ForEach(x => x.Dispose());
                deviceEventDisposables.Clear();
                Globals.MainForm.TrayNotifyIcon.Visible = true;
                Globals.MainForm.TrayNotifyIcon.ShowBalloonTip(2500, "Windows Audio service not running", $"{Application.ProductName} will restart automatically when the service becomes available.", ToolTipIcon.Warning);
                await UpdateAudioState();
            }
            else
            {
                if (e.Status == ServiceControllerStatus.Running)
                    Globals.MainForm.RestartNormalMenuItem.PerformClick();
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
            catch
            {
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
                    if (deviceStateEventQueue.Count > 0)
                        await ProcessDeviceEventQueue();
                }
            }
        }

        public async Task HandleDeviceEvent(DeviceChangedArgs value)
        {
            if (value != null)
            {
                switch (value.ChangedType)
                {
                    case DeviceChangedType.VolumeChanged:
                        if (!Globals.InputHandler.IsScrolling)
                            await UpdateAudioState();
                        break;
                    case DeviceChangedType.MuteChanged:
                        await UpdateAudioState();
                        break;
                    case DeviceChangedType.DefaultChanged:
                        if (value.Device.IsDefaultDevice)
                            await UpdateAudioState();
                        break;
                    case DeviceChangedType.PeakValueChanged:
                        if (Globals.VolumeSliderControlForm != null && !AudioState.Muted && !isUpdatingPeakValue)
                        {
                            isUpdatingPeakValue = true;
                            DevicePeakValueChangedArgs peakVal = (DevicePeakValueChangedArgs)value;
                            double currentPeakValue = Math.Round(peakVal.PeakValue);
                            if (currentPeakValue < 0)
                                currentPeakValue = 0;
                            if (currentPeakValue > 100)
                                currentPeakValue = 100;

                            Globals.VolumeSliderControlForm.UpdatePeakValue(currentPeakValue);
                            isUpdatingPeakValue = false;
                        }
                        break;
                    default:
                        await ProcessDeviceEventQueue();
                        break;
                }
                if (Globals.AudioPlaybackDevicesForm != null && value.ChangedType != DeviceChangedType.PeakValueChanged)
                {
                    await Task.Run(() =>
                    {
                        Globals.AudioPlaybackDevicesForm.Invoke((MethodInvoker)async delegate
                        {
                            await Globals.AudioPlaybackDevicesForm.RefreshOnDeviceActivity();
                        });
                    });
                }
                if (Globals.VolumeSliderControlForm != null && value.ChangedType != DeviceChangedType.PeakValueChanged)
                {
                    await Task.Run(() =>
                    {
                        Globals.VolumeSliderControlForm.Invoke((MethodInvoker)delegate
                        {
                            Globals.VolumeSliderControlForm.RefreshOnDeviceActivity(updateDeviceInfo: value.ChangedType == DeviceChangedType.DefaultChanged);
                        });
                    });
                }
            }
        }

        public async void DeviceStateChanged(DeviceChangedArgs value)
        {
            if (deviceStateEventQueue.Count <= 5)
                deviceStateEventQueue.Enqueue(value);
            if (deviceStateEventQueue.Count > 0)
                await ProcessDeviceEventQueue();
        }

        public async Task UpdateAudioState()
        {
            await Task.Run(() =>
            {
                if (AudioState.CoreAudioController.DefaultPlaybackDevice != null)
                {
                    if (AudioState.CoreAudioController.DefaultPlaybackDevice.State == DeviceState.Active)
                    {
                        AudioState.Volume = (int)Math.Round(AudioState.CoreAudioController.DefaultPlaybackDevice.Volume);
                        AudioState.Muted = AudioState.CoreAudioController.DefaultPlaybackDevice.IsMuted;
                        AudioState.AudioAvailable = true;
                    }
                    else
                        AudioState.AudioAvailable = false;
                }
                else
                    AudioState.AudioAvailable = false;

                if (!AudioState.AudioAvailable)
                {
                    Globals.InputHandler.MouseScrollQueue.Clear();
                    Globals.InputHandler.CurrentMouseTask = null;
                    DeviceStateEventQueue.Clear();
                    currentDeviceStateEventTask = null;
                }
                Globals.MainForm.BeginInvoke((MethodInvoker)delegate
                {
                    Globals.MainForm.VolumeSliderControlMenuItem.Enabled = AudioState.AudioAvailable;
                    Globals.MainForm.AudioPlaybackDevicesMenuItem.Enabled = AudioState.AudioAvailable;
                    Globals.MainForm.SystemVolumeMixerMenuItem.Enabled = AudioState.AudioAvailable;
                    Globals.MainForm.OptionsMenuItem.Enabled = AudioState.AudioAvailable;
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
                    if (newVolume > 0 && AudioState.Muted)
                        await SetDeviceMute(isMuted: false);
                    else if (newVolume == 0)
                        await SetDeviceMute(isMuted: true);
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
                await Globals.AudioHandler.UpdateAudioState();
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