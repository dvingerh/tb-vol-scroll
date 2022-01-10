using AudioSwitcher.AudioApi.CoreAudio;
using AudioSwitcher.AudioApi.Session;

namespace tbvolscroll.Classes
{
    public static class AudioState
    {
        private static int volume = 0;
        private static int currentAudioDeviceIndex = -1;
        private static bool muted = true;
        private static bool audioAvailable = false;
        private static CoreAudioController coreAudioController;
        public static int Volume { get => volume; set => volume = value; }
        public static bool Muted { get => muted; set => muted = value; }
        public static bool AudioAvailable { get => audioAvailable; set => audioAvailable = value; }
        public static CoreAudioController CoreAudioController { get => coreAudioController; set => coreAudioController = value; }
        public static int CurrentAudioDeviceIndex { get => currentAudioDeviceIndex; set => currentAudioDeviceIndex = value; }
    }
}
