using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;
using AudioSwitcher.AudioApi.Observables;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using tbvolscroll.Classes;
using tbvolscroll.Properties;

namespace tbvolscroll
{
    public class AudioHandler
    {
        private static IEnumerable<CoreAudioDevice> audioDevices;
        private static CoreAudioController coreAudioController;
        private static int volume = 0;
        private static bool muted = false;
        private static bool audioDisabled = false;

        private bool isSubScribed = false;
        private readonly Queue<DeviceChangedArgs> deviceEventQueue = new Queue<DeviceChangedArgs>();
        private Task curentDeviceEventTask = null;

        public AudioHandler()
        {
            coreAudioController = new CoreAudioController();
            coreAudioController.AudioDeviceChanged.Subscribe(OnDeviceEvent);
            if (coreAudioController.DefaultPlaybackDevice != null && !isSubScribed)
            {
                isSubScribed = true;
                coreAudioController.DefaultPlaybackDevice.VolumeChanged.Subscribe(OnDeviceEvent);
                coreAudioController.DefaultPlaybackDevice.MuteChanged.Subscribe(OnDeviceEvent);
            }
        }

        private async Task ProcessDeviceEventQueue()
        {
            if ((curentDeviceEventTask == null) || (curentDeviceEventTask.IsCompleted))
            {
                if (deviceEventQueue.Count > 0)
                {
                    if (Utils.IsAudioServiceRunning())
                    {
                        var refreshArgs = deviceEventQueue.Dequeue();
                        curentDeviceEventTask = HandleDeviceEvent(refreshArgs);
                        await curentDeviceEventTask;

                        await ProcessDeviceEventQueue();
                    }
                    else
                    {
                        deviceEventQueue.Clear();
                        await UpdateAudioState();
                    }
                }
            }
        }

        public async Task HandleDeviceEvent(DeviceChangedArgs value)
        {
            if (coreAudioController.DefaultPlaybackDevice != null && !isSubScribed)
            {
                isSubScribed = true;
                coreAudioController.DefaultPlaybackDevice.VolumeChanged.Subscribe(OnDeviceEvent);
                coreAudioController.DefaultPlaybackDevice.MuteChanged.Subscribe(OnDeviceEvent);
            }


            switch (value.ChangedType)
            {
                case DeviceChangedType.DefaultChanged:
                        await RefreshPlaybackDevices();
                        await UpdateAudioState();
                        if (Globals.AudioPlaybackDevicesForm != null)
                            await Globals.AudioPlaybackDevicesForm.RefeshOnDeviceActivity();
                        break;
                    case DeviceChangedType.StateChanged:
                        await RefreshPlaybackDevices();
                        await UpdateAudioState();
                        if (Globals.AudioPlaybackDevicesForm != null)
                            await Globals.AudioPlaybackDevicesForm.RefeshOnDeviceActivity();
                        break;
                    case DeviceChangedType.DeviceAdded:
                        await RefreshPlaybackDevices();
                        await UpdateAudioState();
                        if (Globals.AudioPlaybackDevicesForm != null)
                            await Globals.AudioPlaybackDevicesForm.RefeshOnDeviceActivity();
                        break;
                    case DeviceChangedType.DeviceRemoved:
                        await RefreshPlaybackDevices();
                        await UpdateAudioState();
                        if (Globals.AudioPlaybackDevicesForm != null)
                            await Globals.AudioPlaybackDevicesForm.RefeshOnDeviceActivity();
                        break;
                    case DeviceChangedType.VolumeChanged:
                        await UpdateAudioState();
                        if (Globals.AudioPlaybackDevicesForm != null)
                            await Globals.AudioPlaybackDevicesForm.RefeshOnDeviceActivity();
                        break;
                    case DeviceChangedType.MuteChanged:
                        await UpdateAudioState();
                        break;
                    default:
                    break;
            }
        }


        public async void OnDeviceEvent(DeviceChangedArgs value)
        {
            deviceEventQueue.Enqueue(value);
            await ProcessDeviceEventQueue();
        }

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(
          IntPtr hWnd,
          int X,
          int Y,
          int nWidth,
          int nHeight,
          bool bRepaint);


        public int Volume
        {
            get => volume;
            set => volume = value;
        }

        public bool Muted
        {
            get => muted;
            set => muted = value;
        }

        public IEnumerable<CoreAudioDevice> AudioDevices
        {
            get => audioDevices;
            set => audioDevices = value;
        }

        public CoreAudioController CoreAudioController
        {
            get => coreAudioController;
            set => coreAudioController = value;
        }
        public bool AudioDisabled { get => audioDisabled; set => audioDisabled = value; }

        public async Task UpdateAudioState()
        {

            if (CoreAudioController.DefaultPlaybackDevice != null)
            {
                if (CoreAudioController.DefaultPlaybackDevice.State == DeviceState.Active)
                {
                        Volume = (int)CoreAudioController.DefaultPlaybackDevice.Volume;
                        Muted = CoreAudioController.DefaultPlaybackDevice.IsMuted;
                        AudioDisabled = false;
                    }
                }
                else
                {
                    Volume = 0;
                    Muted = true;
                    AudioDisabled = true;
                }
                await Task.Run(() =>
                {
                    Globals.MainForm.Invoke((MethodInvoker)delegate
                    {
                        Globals.MainForm.VolumeSliderControlMenuItem.Enabled = !AudioDisabled;
                        Globals.MainForm.AudioPlaybackDevicesMenuItem.Enabled = !AudioDisabled;
                        Globals.MainForm.SetTrayIcon();
                    });
                });
            }

        public List<CoreAudioDevice> GetAudioDevicesList()
        {
            List<CoreAudioDevice> audioDevicesList = new List<CoreAudioDevice>();
            audioDevicesList.AddRange(AudioDevices);
            return audioDevicesList;
        }

        public async Task RefreshPlaybackDevices()
        {
            if (Utils.IsAudioServiceRunning())
            {
                IEnumerable<CoreAudioDevice> coreAudioDevices = await coreAudioController.GetPlaybackDevicesAsync(DeviceState.Active);
                audioDevices = coreAudioDevices;
            }
            
        }

        public double GetMasterVolume()
        {
            try
            {
                return coreAudioController != null && coreAudioController.DefaultPlaybackDevice != null ? coreAudioController.DefaultPlaybackDevice.Volume : 0.0;
            }
            catch
            {
                return 0.0;
            }
        }

        public void SetMasterVolume(int volume)
        {
            try
            {
                if (coreAudioController == null || coreAudioController.DefaultPlaybackDevice == null)
                    return;
                Volume = volume;
                coreAudioController.DefaultPlaybackDevice.Volume = volume;
            }
            catch
            {
            }
        }

        public async Task SetMasterVolumeMute(bool isMuted = false)
        {
            await Task.Run(async () =>
            {
                try
                {
                    if (coreAudioController == null || coreAudioController.DefaultPlaybackDevice == null)
                        return;
                    await coreAudioController.DefaultPlaybackDevice.MuteAsync(isMuted);
                }
                catch
                {
                }
            });
        }

        public async Task OpenSndVol()
        {
            Process sndvolProc = new Process();
            sndvolProc.StartInfo.FileName = "sndvol.exe";
            sndvolProc.Start();

            bool hasWindow = false;
            IntPtr windowHandle = new IntPtr();
            while (!hasWindow)
            {
                Process[] processes = Process.GetProcessesByName("sndvol");

                foreach (Process p in processes)
                {
                    IntPtr tempHandle = p.MainWindowHandle;
                    if (tempHandle.ToInt32() != 0)
                    {
                        windowHandle = tempHandle;
                        hasWindow = true;
                    }
                }
                await Task.Delay(50);
            }

            int sndvolWidth = 1000;
            int sndvolHeight = 500;
            Point position = Cursor.Position;
            Screen screen = Screen.FromPoint(position);
            Point location = new Point();
            Rectangle workingArea = screen.WorkingArea;

            switch (TaskbarHelper.Position)
            {
                case TaskbarPosition.Bottom:
                    location = new Point(workingArea.Right - sndvolWidth, workingArea.Bottom - sndvolHeight);
                    break;
                case TaskbarPosition.Right:
                    location = new Point(workingArea.Right - sndvolWidth, workingArea.Bottom - sndvolHeight);
                    break;
                case TaskbarPosition.Left:
                    location = new Point(workingArea.Left, workingArea.Bottom - sndvolHeight);
                    break;
                case TaskbarPosition.Top:
                    location = new Point(workingArea.Right - sndvolWidth, workingArea.Top);
                    break;
            }
            MoveWindow(windowHandle, location.X, location.Y, sndvolWidth, sndvolHeight, true);

        }

        public async Task DoVolumeChanges(int delta)
        {

            await Task.Run(async() =>
            {
                if ((delta < 0 && Globals.AudioHandler.Volume != 0) || (delta > 0 && Globals.AudioHandler.Volume != 100))
                {
                    try
                    {

                        await Globals.AudioHandler.UpdateAudioState();
                        int newVolume = Globals.AudioHandler.Volume;

                        if (delta < 0)
                        {
                            if (Globals.InputHandler.IsAltDown && Settings.Default.ManualPreciseVolumeShortcut || Globals.AudioHandler.Volume <= Settings.Default.PreciseScrollThreshold)
                                newVolume -= 1;
                            else
                                newVolume -= Settings.Default.VolumeStep;
                            if (newVolume <= 0 && Globals.AudioHandler.Muted == false)
                            {
                                newVolume = 0;
                                Globals.AudioHandler.SetMasterVolume(newVolume);
                                await Globals.AudioHandler.SetMasterVolumeMute(isMuted: true);
                            }
                            else
                                Globals.AudioHandler.SetMasterVolume(newVolume);
                        }
                        else
                        {
                            if (Globals.InputHandler.IsAltDown && Settings.Default.ManualPreciseVolumeShortcut || Globals.AudioHandler.Volume < Settings.Default.PreciseScrollThreshold)
                                newVolume += 1;
                            else
                                newVolume += Settings.Default.VolumeStep;
                            if (newVolume > 0 && Globals.AudioHandler.Muted == true)
                                await Globals.AudioHandler.SetMasterVolumeMute(isMuted: false);
                            if (newVolume > 100)
                                newVolume = 100;
                            Globals.AudioHandler.SetMasterVolume(newVolume);

                        }                    }
                    catch { }
                }
            });
        }

        public async Task ToggleAudioPlaybackDevice(int delta)
        {
            try
            {
                List<CoreAudioDevice> audioDevicesList = new List<CoreAudioDevice>();
                audioDevicesList.AddRange(Globals.AudioHandler.AudioDevices);
                CoreAudioDevice curDevice = Globals.AudioHandler.CoreAudioController.DefaultPlaybackDevice;
                if (Globals.CurrentAudioDeviceIndex == -1)
                    Globals.CurrentAudioDeviceIndex = audioDevicesList.FindIndex(x => x.Id == curDevice.Id);
                int newDeviceIndex = Globals.CurrentAudioDeviceIndex;

                if (delta < 0)
                {
                    if (Globals.CurrentAudioDeviceIndex > 0)
                        --Globals.CurrentAudioDeviceIndex;
                    else
                        Globals.CurrentAudioDeviceIndex = 0;
                }
                else
                {
                    if (Globals.CurrentAudioDeviceIndex < audioDevicesList.Count - 1)
                        ++Globals.CurrentAudioDeviceIndex;
                    else
                        Globals.CurrentAudioDeviceIndex = audioDevicesList.Count - 1;
                }

                if (newDeviceIndex != Globals.CurrentAudioDeviceIndex)
                {
                    CoreAudioDevice newPlaybackDevice = audioDevicesList[Globals.CurrentAudioDeviceIndex];
                    await newPlaybackDevice.SetAsDefaultAsync();
                }
            }
            catch { }
        }

    }
}