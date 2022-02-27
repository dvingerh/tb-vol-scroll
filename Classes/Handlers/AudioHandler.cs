using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;
using AudioSwitcher.AudioApi.Observables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tb_vol_scroll.Properties;
using static tb_vol_scroll.Classes.Helpers.Enums;

namespace tb_vol_scroll.Classes.Handlers
{
    public class AudioHandler
    {
        private CoreAudioController audioController = null;
        private readonly Dictionary<IDisposable, CoreAudioDevice> audioDeviceSubscriptions = new Dictionary<IDisposable, CoreAudioDevice>();
        public CoreAudioController AudioController { get => audioController; set => audioController = value; }
        public int FriendlyVolume { get => audioController.DefaultPlaybackDevice != null ? (int)Math.Round(audioController.DefaultPlaybackDevice.Volume) : -1; }
        public bool IsAudioAvailable()
        {
            if (AudioController == null)
                return false;
            if (AudioController.DefaultPlaybackDevice == null)
                return false;
            if (AudioController.DefaultPlaybackDevice.State != DeviceState.Active)
                return false;
            return true;
        }
        public AudioHandler()
        {
            audioController = new CoreAudioController();
            AudioController.AudioDeviceChanged.Subscribe(DeviceStateChanged);
            if (audioController.DefaultPlaybackDevice != null)
            {
                foreach (var device in audioController.GetPlaybackDevices(DeviceState.Active))
                {
                    audioDeviceSubscriptions.Add(device.PeakValueChanged.Subscribe(DeviceStateChanged), device);
                    audioDeviceSubscriptions.Add(device.VolumeChanged.Subscribe(DeviceStateChanged), device);
                    audioDeviceSubscriptions.Add(device.MuteChanged.Subscribe(DeviceStateChanged), device);
                    device.PeakValueTimer.PeakValueInterval = 10;
                }
            }
        }

        public async Task AdjustVolume(MouseWheelDirection direction, ActionTriggerType type)
        {
            int newVolume = FriendlyVolume;
            if (Settings.Default.InvertScrollingDirection)
                direction = direction == MouseWheelDirection.Up ? direction = MouseWheelDirection.Down : direction = MouseWheelDirection.Up;
            switch (direction)
            {
                case MouseWheelDirection.Up:
                    if (type == ActionTriggerType.RegularVolumeScroll)
                        newVolume += Settings.Default.NormalVolumeStep;
                    if (type == ActionTriggerType.PreciseVolumeScroll)
                        newVolume += Settings.Default.PreciseVolumeStep;
                    if (audioController.DefaultPlaybackDevice.IsMuted)
                        await Task.Run(() => Globals.AudioHandler.SetDeviceMute(Globals.AudioHandler.AudioController.DefaultPlaybackDevice, false));
                    break;
                case MouseWheelDirection.Down:
                    if (type == ActionTriggerType.RegularVolumeScroll)
                        newVolume -= Settings.Default.NormalVolumeStep;
                    if (type == ActionTriggerType.PreciseVolumeScroll)
                        newVolume -= Settings.Default.PreciseVolumeStep;
                    break;
            }

            if (newVolume > 100)
                newVolume = 100;
            if (newVolume < 0)
                newVolume = 0;

            await Task.Run(() => SetDeviceVolume(audioController.DefaultPlaybackDevice, newVolume));
            if (newVolume == 0)
                await Task.Run(() => Globals.AudioHandler.SetDeviceMute(Globals.AudioHandler.AudioController.DefaultPlaybackDevice, true));
        }



        public async Task ChangePlaybackDevice(MouseWheelDirection direction)
        {
            List<CoreAudioDevice> audioDevices = (await Task.Run(() => AudioController.GetPlaybackDevicesAsync(DeviceState.Active))).ToList();
            if (audioDevices.Count > 0)
            {
                int curDeviceIndex = audioDevices.IndexOf(AudioController.DefaultPlaybackDevice);
                CoreAudioDevice newAudioDevice = null;
                switch (direction)
                {
                    case MouseWheelDirection.Up:
                        if (curDeviceIndex != audioDevices.Count)
                            newAudioDevice = audioDevices.ElementAt(curDeviceIndex + 1);
                        break;
                    case MouseWheelDirection.Down:
                        if (curDeviceIndex != 0)
                            newAudioDevice = audioDevices.ElementAt(curDeviceIndex - 1);
                        break;
                }
                if(newAudioDevice != null)
                    await Task.Run(() => SetPlaybackDevice(newAudioDevice));
            }
        }

        public async void DeviceStateChanged(DeviceChangedArgs value)
        {
            if (value.Device.InterfaceName != "Unknown" && value.Device.IsPlaybackDevice)
            {

                switch (value.ChangedType)
                {
                    case DeviceChangedType.DeviceRemoved:
                        foreach (var item in audioDeviceSubscriptions.Where(x => x.Value.Id == value.Device.Id).ToList())
                        {
                            audioDeviceSubscriptions.Remove(item.Key);
                            item.Key.Dispose();
                        }
                        break;
                    case DeviceChangedType.DeviceAdded:
                        CoreAudioDevice audioDevice = audioController.GetDevice(value.Device.Id, DeviceState.Active);
                        if (audioDevice != null && !audioDeviceSubscriptions.ContainsValue(audioDevice))
                        {
                            audioDeviceSubscriptions.Add(audioDevice.PeakValueChanged.Subscribe(DeviceStateChanged), audioDevice);
                            audioDeviceSubscriptions.Add(audioDevice.VolumeChanged.Subscribe(DeviceStateChanged), audioDevice);
                            audioDeviceSubscriptions.Add(audioDevice.MuteChanged.Subscribe(DeviceStateChanged), audioDevice);
                            audioDevice.PeakValueTimer.PeakValueInterval = 10;
                        }
                        break;
                    case DeviceChangedType.VolumeChanged:
                        Globals.MainForm.SetAppAppearances(ActionTriggerType.InternalEvent);
                        if (Globals.VolumeSliderControlForm != null)
                            await Globals.VolumeSliderControlForm.UpdateVolumeState();
                        break;
                    case DeviceChangedType.MuteChanged:
                        Globals.MainForm.SetAppAppearances(ActionTriggerType.InternalEvent);
                        if (Globals.VolumeSliderControlForm != null)
                            await Globals.VolumeSliderControlForm.UpdateVolumeState();
                        break;
                    case DeviceChangedType.DefaultChanged:
                        if (Globals.AudioAvailable && Globals.InputAvailable)
                            Globals.MainForm.SetAppAppearances(ActionTriggerType.InternalEvent);
                        else if (Globals.AudioAvailable && !Globals.InputAvailable)
                            Globals.MainForm.SetAppAppearances(ActionTriggerType.AudioEnabled);
                        else if (!Globals.AudioAvailable && Globals.InputAvailable)
                            Globals.MainForm.SetAppAppearances(ActionTriggerType.AudioDisabled);
                        if (Globals.VolumeSliderControlForm != null)
                            Globals.VolumeSliderControlForm.UpdateDeviceState();
                        break;
                    case DeviceChangedType.PeakValueChanged:
                        if (Globals.VolumeSliderControlForm != null && !AudioController.DefaultPlaybackDevice.IsMuted)
                        {
                            DevicePeakValueChangedArgs peakVal = (DevicePeakValueChangedArgs)value;
                            double currentPeakValue = Math.Round(peakVal.PeakValue);
                            if (currentPeakValue < 0)
                                currentPeakValue = 0;
                            if (currentPeakValue > 1)
                                currentPeakValue = 1;

                            Globals.VolumeSliderControlForm.UpdatePeakValue(peakVal.PeakValue);
                        }
                        break;
                    default:
                        break;
                }
                if (value.ChangedType != DeviceChangedType.PeakValueChanged && Globals.AudioPlaybackDevicesForm != null)
                   await Globals.AudioPlaybackDevicesForm.RefreshOnDeviceActivity();
            }
        }

        public async Task SetDeviceVolume(CoreAudioDevice device, double volume)
        {
            if (device != null && device.Volume != volume)
            {
                Task task = device.SetVolumeAsync(volume);
                await task;
            }
        }

        public async Task SetDeviceMute(CoreAudioDevice device, bool isMuted = false)
        {
            if (device != null)
            {
                Task task = device.SetMuteAsync(isMuted);
                await task;
            }
        }

        public async Task SetPlaybackDevice(CoreAudioDevice device)
        {
            if (device != null)
            {
                Task task = device.SetAsDefaultAsync();
                await task;
            }
        }


    }
}
