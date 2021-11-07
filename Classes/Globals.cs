using System.ServiceProcess;
using System.Threading;
using tbvolscroll.Forms;

namespace tbvolscroll.Classes
{
    public static class Globals
    {
        private static int currentAudioDeviceIndex = -1;
        private static int volumeBarAutoHideTimeout = 1000;
        private static InputHandler inputHandler;
        private static AudioHandler audioHandler;
        private static bool programIsReady = false;
        private static bool isDisplayingVolumeBar = false;
        private static MainForm mainForm;
        private static AudioPlaybackDevicesForm audioPlaybackDevicesForm;
        private static VolumeSliderControlForm volumeSliderControlForm;
        private static bool isAudioServiceRunning = true;
        private static Mutex appMutex;
        private static bool displayTrayIcon = true;

        public static int CurrentAudioDeviceIndex { get => currentAudioDeviceIndex; set => currentAudioDeviceIndex = value; }
        public static int VolumeBarAutoHideTimeout { get => volumeBarAutoHideTimeout; set => volumeBarAutoHideTimeout = value; }
        public static InputHandler InputHandler { get => inputHandler; set => inputHandler = value; }
        public static AudioHandler AudioHandler { get => audioHandler; set => audioHandler = value; }
        public static bool ProgramIsReady { get => programIsReady; set => programIsReady = value; }
        public static bool IsDisplayingVolumeBar { get => isDisplayingVolumeBar; set => isDisplayingVolumeBar = value; }
        public static MainForm MainForm { get => mainForm; set => mainForm = value; }
        public static AudioPlaybackDevicesForm AudioPlaybackDevicesForm { get => audioPlaybackDevicesForm; set => audioPlaybackDevicesForm = value; }
        public static VolumeSliderControlForm VolumeSliderControlForm { get => volumeSliderControlForm; set => volumeSliderControlForm = value; }
        public static bool IsAudioServiceRunning { get => isAudioServiceRunning; set => isAudioServiceRunning = value; }
        public static Mutex AppMutex { get => appMutex; set => appMutex = value; }
        public static bool DisplayTrayIcon { get => displayTrayIcon; set => displayTrayIcon = value; }
    }
}
