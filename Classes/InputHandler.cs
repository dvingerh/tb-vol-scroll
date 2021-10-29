using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using tbvolscroll.Classes;
using tbvolscroll.Properties;

namespace tbvolscroll
{
    public sealed class InputHandler
    {
        private bool isAltDown;
        private bool isCtrlDown;
        private bool isShiftDown;
        private bool isScrolling;
        private IKeyboardMouseEvents inputEvents;
        
        public bool IsAltDown { get => isAltDown; set => isAltDown = value; }
        public bool IsCtrlDown { get => isCtrlDown; set => isCtrlDown = value; }
        public bool IsShiftDown { get => isShiftDown; set => isShiftDown = value; }
        public IKeyboardMouseEvents InputEvents { get => inputEvents; set => inputEvents = value; }
        
        private readonly Queue<MouseEventArgs> mouseScrollQueue = new Queue<MouseEventArgs>();
        private Task currentMouseTask = null;

        public InputHandler()
        {
            inputEvents = Hook.GlobalEvents();
            inputEvents.MouseWheel += OnMouseScroll;
            inputEvents.MouseMove += UpdateBarPositionMouseMove;
            inputEvents.KeyDown += EnableKeyActions;
            inputEvents.KeyUp += DisableKeyActions;
        }

        private void UpdateBarPositionMouseMove(object sender, MouseEventArgs e)
        {
            if (Globals.IsDisplayingVolumeBar)
            {
                if (TaskbarHelper.IsCursorInTaskbar())
                   Globals.MainForm.SetVolumeBarPosition();
                else
                    Globals.MainForm.HideVolumeBar();
            }
        }

        private void DisableKeyActions(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.LMenu || e.KeyCode == Keys.RMenu)
                isAltDown = false;
            if (e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey)
                isCtrlDown = false;
            if (e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey)
                isShiftDown = false;
        }

        private void EnableKeyActions(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.LMenu || e.KeyCode == Keys.RMenu)
                isAltDown = true;
            if (e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey)
                isCtrlDown = true;
            if (e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey)
                isShiftDown = true;
        }

        private async void OnMouseScroll(object sender, MouseEventArgs e)
        {
            mouseScrollQueue.Enqueue(e);
            await ProcessMouseScrollActionQueue();
        }


        private async Task ProcessMouseScrollActionQueue()
        {
            if ((currentMouseTask == null) || (currentMouseTask.IsCompleted))
            {
                if (mouseScrollQueue.Count > 0)
                {
                    var refreshArgs = mouseScrollQueue.Dequeue();

                    currentMouseTask = HandleMouseScrollAction(refreshArgs);
                    await currentMouseTask;

                    await ProcessMouseScrollActionQueue();
                }
            }
        }


        private async Task HandleMouseScrollAction(MouseEventArgs e)
        {
            if (TaskbarHelper.IsValidAction() && !Globals.IsDisplayingVolumeSliderControl && Globals.ProgramIsReady && !Globals.AudioHandler.AudioDisabled)
            {
                int delta = e.Delta;
                if (Settings.Default.ReverseScrollingDirection)
                    if (delta < 0)
                        delta = 1;
                    else
                        delta = -1;


                if (!isShiftDown && !isCtrlDown && !isScrolling)
                {
                    isScrolling = true;
                    await Task.Run(async () =>
                    {
                        await Globals.AudioHandler.DoVolumeChanges(delta);
                        await Globals.MainForm.DoScrollUpdate(updateType: "volume");
                    });
                }
                else if (isCtrlDown && Settings.Default.ToggleMuteShortcut && !isShiftDown && !isAltDown)
                {
                    await Task.Run(async () =>
                    {
                        bool isMuted = delta < 0;
                        await Globals.AudioHandler.SetMasterVolumeMute(isMuted);
                        await Globals.MainForm.DoScrollUpdate(updateType: "mute");
                    });
                }
                else if (isShiftDown && Settings.Default.SwitchDefaultPlaybackDeviceShortcut && !isCtrlDown && !isAltDown)
                {
                    await Task.Run(async () =>
                    {
                        await Globals.AudioHandler.ToggleAudioPlaybackDevice(delta);
                        await Globals.MainForm.DoScrollUpdate(updateType: "device");
                    });
                }
                isScrolling = false;
            }
        }
    }
}
