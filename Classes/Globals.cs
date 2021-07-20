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
        private static bool isDisplayingVolumeSliderControl = false;

        public static int CurrentAudioDeviceIndex { get => currentAudioDeviceIndex; set => currentAudioDeviceIndex = value; }
        public static int VolumeBarAutoHideTimeout { get => volumeBarAutoHideTimeout; set => volumeBarAutoHideTimeout = value; }
        public static InputHandler InputHandler { get => inputHandler; set => inputHandler = value; }
        public static AudioHandler AudioHandler { get => audioHandler; set => audioHandler = value; }
        public static bool ProgramIsReady { get => programIsReady; set => programIsReady = value; }
        public static bool IsDisplayingVolumeBar { get => isDisplayingVolumeBar; set => isDisplayingVolumeBar = value; }
        public static bool IsDisplayingVolumeSliderControl { get => isDisplayingVolumeSliderControl; set => isDisplayingVolumeSliderControl = value; }
    }
}
