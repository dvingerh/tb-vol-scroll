using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;
using AudioSwitcher.AudioApi.Observables;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;
using tbvolscroll.Classes;
using tbvolscroll.Properties;

namespace tbvolscroll
{
    public class AudioHandler
    {
        private IEnumerable<CoreAudioDevice> audioDevices;
        private CoreAudioController coreAudioController;
        private int volume = 0;
        private bool muted = false;
        private bool audioDisabled = false;

        private bool isSubScribed = false;
        private readonly Queue<DeviceChangedArgs> deviceStateEventQueue = new Queue<DeviceChangedArgs>();
        private Task currentDeviceStateEventTask = null;
        private ExtendedServiceController audioSrvStatusController;

        public IEnumerable<CoreAudioDevice> AudioDevices { get => audioDevices; set => audioDevices = value; }
        public CoreAudioController CoreAudioController { get => coreAudioController; set => coreAudioController = value; }
        public int Volume { get => volume; set => volume = value; }
        public bool Muted { get => muted; set => muted = value; }
        public bool AudioDisabled { get => audioDisabled; set => audioDisabled = value; }
        public ExtendedServiceController AudioSrvStatusController { get => audioSrvStatusController; set => audioSrvStatusController = value; }
        public bool IsSubScribed { get => isSubScribed; set => isSubScribed = value; }

        public AudioHandler()
        {
            audioSrvStatusController = new ExtendedServiceController("audiosrv");
            coreAudioController = new CoreAudioController();
            audioSrvStatusController.StatusChanged += AudioServiceStatusChanged;
            if (audioSrvStatusController.Status == ServiceControllerStatus.Running)
                coreAudioController.AudioDeviceChanged.Subscribe(DeviceStateChanged);
            else
            {
                Globals.MainForm.TrayNotifyIcon.Visible = true;
                Globals.MainForm.TrayNotifyIcon.ShowBalloonTip(2500, "Windows Audio service inactive", $"{Application.ProductName} will restart automatically when the service becomes available.", ToolTipIcon.Warning);
            }
            if (coreAudioController.DefaultPlaybackDevice != null && !isSubScribed)
            {
                isSubScribed = true;
                coreAudioController.DefaultPlaybackDevice.VolumeChanged.Subscribe(DeviceStateChanged);
                coreAudioController.DefaultPlaybackDevice.MuteChanged.Subscribe(DeviceStateChanged);
            }

            audioSrvStatusController.Refresh();
        }

        private async void AudioServiceStatusChanged(object sender, ServiceStatusEventArgs e)
        {

            if (Globals.IsAudioServiceRunning && e.Status != ServiceControllerStatus.Running)
            {
                Globals.IsAudioServiceRunning = false;
                Globals.MainForm.TrayNotifyIcon.Visible = true;
                Globals.MainForm.TrayNotifyIcon.ShowBalloonTip(2500, "Windows Audio service inactive", $"{Application.ProductName} will restart automatically when the service becomes available.", ToolTipIcon.Warning);
                deviceStateEventQueue.Clear();
                await UpdateAudioState();
                Globals.InputHandler.InputEvents.Dispose();
            }
            else
            {
                if (e.Status == ServiceControllerStatus.Running)
                {
                    Process proc = new Process();
                    proc.StartInfo.FileName = Application.ExecutablePath;
                    proc.StartInfo.UseShellExecute = true;
                    proc.StartInfo.Verb = "runas";
                    proc.StartInfo.Arguments = "audiosrv";
                    Globals.MainForm.HandleApplicationExit(proc, 0);
                }
            }
        }

        private async Task ProcessDeviceEventQueue()
        {
            if ((currentDeviceStateEventTask == null) || currentDeviceStateEventTask.IsCompleted)
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
            try
            {
                if (coreAudioController.DefaultPlaybackDevice != null && !isSubScribed)
                {
                    isSubScribed = true;
                    coreAudioController.DefaultPlaybackDevice.VolumeChanged.Subscribe(DeviceStateChanged);
                    coreAudioController.DefaultPlaybackDevice.MuteChanged.Subscribe(DeviceStateChanged);
                }


                switch (value.ChangedType)
                {
                    case DeviceChangedType.VolumeChanged:
                        await UpdateAudioState();
                        if (Globals.AudioPlaybackDevicesForm != null)
                            await Globals.AudioPlaybackDevicesForm.RefeshOnDeviceActivity();
                        break;
                    case DeviceChangedType.MuteChanged:
                        await UpdateAudioState();
                        break;
                    default:
                        await RefreshPlaybackDevices();
                        await UpdateAudioState();
                        if (Globals.AudioPlaybackDevicesForm != null)
                            await Globals.AudioPlaybackDevicesForm.RefeshOnDeviceActivity();
                        break;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }

        }


        public async void DeviceStateChanged(DeviceChangedArgs value)
        {
            deviceStateEventQueue.Enqueue(value);
            await ProcessDeviceEventQueue();
        }

        public async Task UpdateAudioState()
        {

            if (CoreAudioController.DefaultPlaybackDevice != null)
            {
                if (CoreAudioController.DefaultPlaybackDevice.State == DeviceState.Active)
                {
                    Volume = (int)CoreAudioController.DefaultPlaybackDevice.Volume;
                    Muted = CoreAudioController.DefaultPlaybackDevice.IsMuted;
                    AudioDisabled = false;

                    if (Volume < 0 || Volume > 100)
                    {
                        await UpdateAudioState();
                        return;
                    }
                }
                else
                {
                    await UpdateAudioState();
                    return;
                }
            }
            else
            {
                Volume = 0;
                Muted = true;
                AudioDisabled = true;
                IsSubScribed = false;
            }
            await Task.Run(() =>
            {
                Globals.MainForm.Invoke((MethodInvoker)delegate
                {
                    Globals.MainForm.VolumeSliderControlMenuItem.Enabled = !AudioDisabled;
                    Globals.MainForm.AudioPlaybackDevicesMenuItem.Enabled = !AudioDisabled;
                    Globals.MainForm.SystemVolumeMixerMenuItem.Enabled = !AudioDisabled;
                    Globals.MainForm.MoreOptionsMenuItem.Enabled = !AudioDisabled;
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
            IEnumerable<CoreAudioDevice> coreAudioDevices = await coreAudioController.GetPlaybackDevicesAsync(DeviceState.Active);
            audioDevices = coreAudioDevices;
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
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }

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
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }

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

            Screen screen = Screen.FromPoint(Cursor.Position);
            Point location = new Point();
            Rectangle workingArea = screen.WorkingArea;
            int sndWidth = Convert.ToInt32(Math.Round(0.75 * workingArea.Width));
            Size sndVolDimensions = Utils.GetSndVolSize(windowHandle);

            switch (TaskbarHelper.Position)
            {
                case TaskbarHelper.TaskbarPosition.Bottom:
                    location = new Point(workingArea.Right - sndWidth, workingArea.Bottom - sndVolDimensions.Height);
                    break;
                case TaskbarHelper.TaskbarPosition.Right:
                    location = new Point(workingArea.Right - sndWidth, workingArea.Bottom - sndVolDimensions.Height);
                    break;
                case TaskbarHelper.TaskbarPosition.Left:
                    location = new Point(workingArea.Left, workingArea.Bottom - sndVolDimensions.Height);
                    break;
                case TaskbarHelper.TaskbarPosition.Top:
                    location = new Point(workingArea.Right - sndWidth, workingArea.Top);
                    break;
            }
            Utils.MoveWindow(windowHandle, location.X, location.Y, sndWidth, sndVolDimensions.Height, true);
        }

        public async Task DoVolumeChanges(int delta)
        {

            await Task.Run(async () =>
            {
                if ((delta < 0 && Globals.AudioHandler.Volume != 0) || (delta > 0 && Globals.AudioHandler.Volume != 100))
                {
                    try
                    {

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

                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString());  }
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
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }

    }
}