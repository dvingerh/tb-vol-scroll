using System.Drawing;
using System.Threading;
using tbvolscroll.Forms;

namespace tbvolscroll.Classes
{
    public static class Globals
    {
        private static Color defaultColor = Color.FromArgb(31, 143, 255);
        private static int volumeBarAutoHideTimeout;
        private static float dpiScale = Utils.GetDpiScale();
        private static InputHandler inputHandler;
        private static AudioHandler audioHandler;
        private static bool isDisplayingVolumeBar = false;
        private static bool displayTrayIcon = true;
        private static MainForm mainForm;
        private static AudioPlaybackDevicesForm audioPlaybackDevicesForm;
        private static VolumeSliderControlForm volumeSliderControlForm;
        private static ConfigurationForm configurationForm;
        private static Mutex appMutex;
        private static int textRenderingHintType;
        public static int VolumeBarAutoHideTimeout { get => volumeBarAutoHideTimeout; set => volumeBarAutoHideTimeout = value; }
        public static InputHandler InputHandler { get => inputHandler; set => inputHandler = value; }
        public static AudioHandler AudioHandler { get => audioHandler; set => audioHandler = value; }
        public static bool IsDisplayingVolumeBar { get => isDisplayingVolumeBar; set => isDisplayingVolumeBar = value; }
        public static MainForm MainForm { get => mainForm; set => mainForm = value; }
        public static AudioPlaybackDevicesForm AudioPlaybackDevicesForm { get => audioPlaybackDevicesForm; set => audioPlaybackDevicesForm = value; }
        public static VolumeSliderControlForm VolumeSliderControlForm { get => volumeSliderControlForm; set => volumeSliderControlForm = value; }
        public static Mutex AppMutex { get => appMutex; set => appMutex = value; }
        public static bool DisplayTrayIcon { get => displayTrayIcon; set => displayTrayIcon = value; }
        public static float DpiScale { get => dpiScale; set => dpiScale = value; }
        public static int TextRenderingHintType { get => textRenderingHintType; set => textRenderingHintType = value; }
        public static Color DefaultColor { get => defaultColor; set => defaultColor = value; }
        public static ConfigurationForm ConfigurationForm { get => configurationForm; set => configurationForm = value; }
    }
}
