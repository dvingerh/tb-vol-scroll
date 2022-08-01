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
        public List<CoreAudioDevice> AudioDevices { get => AudioController.GetPlaybackDevicesAsync(DeviceState.Active).Result.ToList(); }

        public bool IsAudioAvailable()
        {
            if (AudioController == null)
                return false;
            else if (AudioController.DefaultPlaybackDevice == null)
                return false;
            else if (AudioController.DefaultPlaybackDevice.State != DeviceState.Active)
                return false;
            else
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
                    device.PeakValueTimer.PeakValueInterval = 100;
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
                        await Globals.AudioHandler.SetDeviceMute(Globals.AudioHandler.AudioController.DefaultPlaybackDevice, false);
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

            await SetDeviceVolume(audioController.DefaultPlaybackDevice, newVolume);
            if (newVolume == 0)
                await Globals.AudioHandler.SetDeviceMute(Globals.AudioHandler.AudioController.DefaultPlaybackDevice, true);
        }



        public async Task ChangePlaybackDevice(MouseWheelDirection direction)
        {
            if (AudioDevices.Count != 0)
            {
                int curDeviceIndex = AudioDevices.IndexOf(AudioController.DefaultPlaybackDevice);
                CoreAudioDevice newAudioDevice = null;
                switch (direction)
                {
                    case MouseWheelDirection.Up:
                        if (curDeviceIndex != AudioDevices.Count)
                            newAudioDevice = AudioDevices.ElementAt(curDeviceIndex + 1);
                        break;
                    case MouseWheelDirection.Down:
                        if (curDeviceIndex != 0)
                            newAudioDevice = AudioDevices.ElementAt(curDeviceIndex - 1);
                        break;
                }
                if(newAudioDevice != null)
                    await SetPlaybackDevice(newAudioDevice);
            }
        }

        public async void DeviceStateChanged(DeviceChangedArgs value)
        {
            Console.WriteLine($"{DateTime.Now.ToString("H:mm:ss.FFF")}: {value.Device.FullName} triggered {value.ChangedType}");
            CoreAudioDevice audioDevice = null;
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
                        if (!Globals.AudioAvailable && Globals.InputAvailable)
                            Globals.MainForm.SetAppAppearances(ActionTriggerType.AudioDisabled);

                        break;
                    case DeviceChangedType.DeviceAdded:
                        Console.WriteLine("State: " + value.Device.State);
                        audioDevice = audioController.GetDevice(value.Device.Id, DeviceState.All);
                        if (audioDevice != null && !audioDeviceSubscriptions.ContainsValue(audioDevice) && value.Device.State == DeviceState.Active)
                        {
                            audioDeviceSubscriptions.Add(audioDevice.PeakValueChanged.Subscribe(DeviceStateChanged), audioDevice);
                            audioDeviceSubscriptions.Add(audioDevice.VolumeChanged.Subscribe(DeviceStateChanged), audioDevice);
                            audioDeviceSubscriptions.Add(audioDevice.MuteChanged.Subscribe(DeviceStateChanged), audioDevice);
                            audioDevice.PeakValueTimer.PeakValueInterval = 100;
                        }
                         if (Globals.AudioAvailable && !Globals.InputAvailable)
                            Globals.MainForm.SetAppAppearances(ActionTriggerType.AudioEnabled);
                        break;
                    case DeviceChangedType.VolumeChanged:
                        Console.WriteLine("Volume: " + value.Device.Volume);

                        Globals.MainForm.SetAppAppearances(ActionTriggerType.InternalEvent);
                        if (Globals.VolumeSliderControlForm != null)
                            Globals.VolumeSliderControlForm.UpdateVolumeState();
                        break;
                    case DeviceChangedType.MuteChanged:
                        Console.WriteLine("Mute: " + value.Device.IsMuted);

                        Globals.MainForm.SetAppAppearances(ActionTriggerType.InternalEvent);
                        if (Globals.VolumeSliderControlForm != null)
                            Globals.VolumeSliderControlForm.UpdateVolumeState();
                        break;
                    case DeviceChangedType.DefaultChanged:
                        Console.WriteLine("Default: " + value.Device.IsPlaybackDevice);

                        if (Globals.AudioAvailable && Globals.InputAvailable)
                            Globals.MainForm.SetAppAppearances(ActionTriggerType.InternalEvent);
                        if (Globals.VolumeSliderControlForm != null)
                            Globals.VolumeSliderControlForm.UpdateDeviceState();
                        break;
                    case DeviceChangedType.PeakValueChanged:
                        Console.WriteLine("PeakValue: " + value.Device.PeakValue);
                        audioDevice = audioController.GetDevice(value.Device.Id, DeviceState.All);
                        if (Globals.VolumeSliderControlForm != null && !AudioController.DefaultPlaybackDevice.IsMuted)
                        {
                            audioDevice.PeakValueTimer.PeakValueInterval = 10;
                            DevicePeakValueChangedArgs peakVal = (DevicePeakValueChangedArgs)value;
                            double currentPeakValue = Math.Round(peakVal.PeakValue);
                            if (currentPeakValue < 0)
                                currentPeakValue = 0;
                            if (currentPeakValue > 1)
                                currentPeakValue = 1;

                            if (Globals.VolumeSliderControlForm != null)
                                Globals.VolumeSliderControlForm.UpdatePeakValue(peakVal.PeakValue);
                        }
                        else
                            audioDevice.PeakValueTimer.PeakValueInterval = 100;
                        break;
                    default:
                        break;
                }
                if (value.ChangedType != DeviceChangedType.PeakValueChanged && Globals.AudioPlaybackDevicesForm != null)
                    await Globals.AudioPlaybackDevicesForm.OnDeviceChanged();
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
