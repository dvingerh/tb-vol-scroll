using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tbvolscroll
{
    public static class AudioHandler
    {
        private static IEnumerable<CoreAudioDevice> audioDevices = null;
        private static CoreAudioController coreAudioController = new CoreAudioController();
        private static int volume = 0;
        private static bool muted = false;

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(
          IntPtr hWnd,
          int X,
          int Y,
          int nWidth,
          int nHeight,
          bool bRepaint);

        [DllImport("User32.dll")]
        internal static extern bool ClientToScreen(IntPtr hWnd, out Point point);

        [DllImport("User32.dll")]
        internal static extern bool GetClientRect(IntPtr hWnd, out WindowRect lpRect);

        public static int Volume
        {
            get => volume;
            set => volume = value;
        }

        public static bool Muted
        {
            get => muted;
            set => muted = value;
        }

        public static IEnumerable<CoreAudioDevice> AudioDevices
        {
            get => audioDevices;
            set => audioDevices = value;
        }

        public static CoreAudioController CoreAudioController
        {
            get => coreAudioController;
            set => coreAudioController = value;
        }

        public static void UpdateAudioState()
        {
            Volume = (int)CoreAudioController.DefaultPlaybackDevice.Volume;
            Muted = CoreAudioController.DefaultPlaybackDevice.IsMuted;
        }

        public static async Task RefreshPlaybackDevices()
        {
            if (coreAudioController == null)
                coreAudioController = new CoreAudioController();
            IEnumerable<CoreAudioDevice> coreAudioDevices = await coreAudioController.GetPlaybackDevicesAsync((DeviceState)1);
            audioDevices = coreAudioDevices;
        }

        public static double GetMasterVolume()
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

        public static void SetMasterVolume(int volume)
        {
            try
            {
                if (coreAudioController == null || coreAudioController.DefaultPlaybackDevice == null)
                    return;
                coreAudioController.DefaultPlaybackDevice.Volume = volume;
            }
            catch
            {
            }
        }

        public static void SetMasterVolumeMute(bool isMuted = false)
        {
            try
            {
                if (coreAudioController == null || coreAudioController.DefaultPlaybackDevice == null)
                    return;
                coreAudioController.DefaultPlaybackDevice.Mute(isMuted);
            }
            catch
            {
            }
        }

        public async static void OpenSndVol()
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
                await Task.Delay(10);
            }

            Screen screen = Screen.FromPoint(Cursor.Position);
            int sndvolWidth = 1000;
            int sndvolHeight = 500;
            int posX = screen.WorkingArea.Width / 2 - (sndvolWidth / 2);
            int posY = screen.WorkingArea.Height / 2 - (sndvolHeight / 2);
            MoveWindow(windowHandle, posX, posY, sndvolWidth, sndvolHeight, true);

        }

        public static Rectangle GetWindowClientRectangle(IntPtr handle)
        {
            GetClientRect(handle, out WindowRect lpRect);
            ClientToScreen(handle, out Point point);
            return lpRect.ToRectangleOffset(point);
        }

        public struct WindowRect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public Rectangle ToRectangleOffset(Point p) => Rectangle.FromLTRB(p.X, p.Y, Right + p.X, Bottom + p.Y);
        }
    }
}