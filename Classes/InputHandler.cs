using Indieteur.GlobalHooks;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        private GlobalKeyHook globalKeyHook;
        private GlobalMouseHook globalMouseHook;

        public bool IsAltDown { get => isAltDown; set => isAltDown = value; }
        public bool IsCtrlDown { get => isCtrlDown; set => isCtrlDown = value; }
        public bool IsShiftDown { get => isShiftDown; set => isShiftDown = value; }
        public GlobalKeyHook GlobalKeyHook { get => globalKeyHook; set => globalKeyHook = value; }
        public GlobalMouseHook GlobalMouseHook { get => globalMouseHook; set => globalMouseHook = value; }

        private readonly Queue<GlobalMouseEventArgs> mouseScrollQueue = new Queue<GlobalMouseEventArgs>();
        private Task currentMouseTask = null;

        public InputHandler()
        {
            globalKeyHook = new GlobalKeyHook();
            globalMouseHook = new GlobalMouseHook();

            globalKeyHook.OnKeyDown += EnableKeyActions;
            globalKeyHook.OnKeyUp += DisableKeyActions;

            globalMouseHook.OnMouseMove += UpdateBarPositionMouseMove;
            globalMouseHook.OnMouseWheelScroll += OnMouseScroll;
        }

        public void UpdateBarPositionMouseMove(object sender, GlobalMouseEventArgs e)
        {
            if (Globals.IsDisplayingVolumeBar)
            {
                if (TaskbarHelper.IsCursorInTaskbar())
                   Globals.MainForm.SetVolumeBarPosition();
                else
                    Globals.MainForm.HideVolumeBar();
            }
        }

        private void DisableKeyActions(object sender, GlobalKeyEventArgs e)
        {
            if (e.Alt == ModifierKeySide.None)
                isAltDown = false;
            if (e.Control == ModifierKeySide.None)
                isCtrlDown = false;
            if (e.Shift == ModifierKeySide.None)
                isShiftDown = false;
        }

        private void EnableKeyActions(object sender, GlobalKeyEventArgs e)
        {
            if (e.Alt != ModifierKeySide.None)
                isAltDown = true;
            if (e.Control != ModifierKeySide.None)
                isCtrlDown = true;
            if (e.Shift != ModifierKeySide.None)
                isShiftDown = true;
        }

        private async void OnMouseScroll(object sender, GlobalMouseEventArgs e)
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


        private async Task HandleMouseScrollAction(GlobalMouseEventArgs e)
        {
            if (TaskbarHelper.IsValidAction() && !Globals.IsDisplayingVolumeSliderControl && Globals.ProgramIsReady && !Globals.AudioHandler.AudioDisabled)
            {
                int delta = int.Parse(e.wheelRotation.ToString());
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
