using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using tb_vol_scroll.Classes.ControlsExt;
using tb_vol_scroll.Classes.Handlers;
using tb_vol_scroll.Classes.Helpers;
using tb_vol_scroll.Forms;

namespace tb_vol_scroll.Classes
{
    public static class Globals
    {
        private static MainForm mainForm;
        private static VolumeSliderControlForm volumeSliderControlForm;
        private static AudioPlaybackDevicesForm audioPlaybackDevicesForm;
        private static InputHandler inputHandler;
        private static AudioHandler audioHandler;
        private static ServiceControllerExt audioServiceController = new ServiceControllerExt("audiosrv");
        private static Mutex appMutex;
        private static List<string> appArgs;

        private static float dpiScale = Utils.GetDpiScale();
        private static readonly Color defaultColor = Color.SkyBlue;

        public static MainForm MainForm { get => mainForm; set => mainForm = value; }
        public static InputHandler InputHandler { get => inputHandler; set => inputHandler = value; }
        public static AudioHandler AudioHandler { get => audioHandler; set => audioHandler = value; }
        public static ServiceControllerExt AudioServiceController { get => audioServiceController; set => audioServiceController = value; }
        public static float DpiScale { get => dpiScale; set => dpiScale = value; }
        public static Mutex AppMutex { get => appMutex; set => appMutex = value; }
        public static bool AudioAvailable { get => AudioHandler != null && AudioHandler.IsAudioAvailable(); }
        public static bool InputAvailable { get => InputHandler.InputEnabled; }

        public static Color DefaultColor => defaultColor;

        public static VolumeSliderControlForm VolumeSliderControlForm { get => volumeSliderControlForm; set => volumeSliderControlForm = value; }
        public static List<string> AppArgs { get => appArgs; set => appArgs = value; }
        public static AudioPlaybackDevicesForm AudioPlaybackDevicesForm { get => audioPlaybackDevicesForm; set => audioPlaybackDevicesForm = value; }
    }
}
