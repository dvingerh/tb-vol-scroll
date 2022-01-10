using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using tbvolscroll.Classes;
using tbvolscroll.Properties;

namespace tbvolscroll
{
    public class InputHandler
    {
        private bool isAltDown;
        private bool isCtrlDown;
        private bool isShiftDown;
        private bool isScrolling;

        private IKeyboardMouseEvents inputEvents;
        private Queue<MouseEventArgs> mouseScrollQueue = new Queue<MouseEventArgs>();
        private Task currentMouseTask = null;

        public bool IsAltDown { get => isAltDown; set => isAltDown = value; }
        public bool IsCtrlDown { get => isCtrlDown; set => isCtrlDown = value; }
        public bool IsShiftDown { get => isShiftDown; set => isShiftDown = value; }
        public IKeyboardMouseEvents InputEvents { get => inputEvents; set => inputEvents = value; }
        public bool IsScrolling { get => isScrolling; set => isScrolling = value; }
        public Queue<MouseEventArgs> MouseScrollQueue { get => mouseScrollQueue; set => mouseScrollQueue = value; }
        public Task CurrentMouseTask { get => currentMouseTask; set => currentMouseTask = value; }

        public InputHandler()
        {
            inputEvents = Hook.GlobalEvents();
            inputEvents.MouseWheel += OnMouseScroll;
            inputEvents.MouseMove += UpdateBarPositionMouseMove;
            inputEvents.KeyDown += EnableKeyActions;
            inputEvents.KeyUp += DisableKeyActions;
        }

        public void UpdateBarPositionMouseMove(object sender, MouseEventArgs e)
        {
            if (Globals.IsDisplayingVolumeBar)
            {
                if (TaskbarHandler.IsCursorInTaskbar())
                    Globals.MainForm.SetVolumeBarPosition();
                else
                {
                    Globals.MainForm.HideVolumeBar();
                    mouseScrollQueue.Clear();
                    currentMouseTask = null;
                }
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
            if (TaskbarHandler.IsCursorInTaskbar() && Globals.VolumeSliderControlForm == null && AudioState.AudioAvailable)
            {
                if (mouseScrollQueue.Count <= 5)
                    mouseScrollQueue.Enqueue(e);
                if ((currentMouseTask == null || currentMouseTask.IsCompleted) && mouseScrollQueue.Count > 0)
                    await ProcessMouseScrollActionQueue();
            }

        }

        private async Task ProcessMouseScrollActionQueue()
        {
            if (currentMouseTask == null || currentMouseTask.IsCompleted)
            {
                if (mouseScrollQueue.Count > 0)
                {
                    var refreshArgs = mouseScrollQueue.Dequeue();

                    currentMouseTask = HandleMouseScrollAction(refreshArgs);
                    await currentMouseTask;
                    if (mouseScrollQueue.Count > 0)
                        await ProcessMouseScrollActionQueue();
                }
            }
        }

        private async Task HandleMouseScrollAction(MouseEventArgs e)
        {
            int scrollDirection = e.Delta;
            if (Settings.Default.InvertScrollingDirection)
                if (scrollDirection < 0)
                    scrollDirection = 1;
                else
                    scrollDirection = -1;


            if (!isShiftDown && !isCtrlDown && !isScrolling)
            {
                isScrolling = true;
                await Task.Run(async () =>
                {
                    await Globals.AudioHandler.DoVolumeChanges(scrollDirection);
                    await Globals.MainForm.DoScrollUpdate(updateType: "volume");
                });
            }
            else if (isCtrlDown && Settings.Default.ToggleMuteShortcut && !isShiftDown && !isAltDown && !isScrolling)
            {
                isScrolling = true;
                await Task.Run(async () =>
                {
                    bool doMute = scrollDirection < 0;
                    if (!AudioState.Muted && doMute)
                        await Globals.AudioHandler.SetDeviceMute(doMute);
                    else if (AudioState.Muted && !doMute)
                        await Globals.AudioHandler.SetDeviceMute(doMute);
                    await Globals.MainForm.DoScrollUpdate(updateType: "mute");
                });
            }
            else if (isShiftDown && Settings.Default.SwitchDefaultPlaybackDeviceShortcut && !isCtrlDown && !isAltDown && !isScrolling)
            {
                isScrolling = true;
                await Task.Run(async () =>
                {
                    await Globals.AudioHandler.ToggleAudioPlaybackDevice(scrollDirection);
                    await Globals.MainForm.DoScrollUpdate(updateType: "device");
                });
            }
            isScrolling = false;
        }
    }
}