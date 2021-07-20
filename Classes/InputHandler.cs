using Gma.System.MouseKeyHook;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using tbvolscroll.Classes;

namespace tbvolscroll
{
    public sealed class InputHandler
    {
        private bool isAltDown;
        private bool isCtrlDown;
        private bool isShiftDown;
        private bool isScrolling;
        private bool isSubscribed = false;
        private IKeyboardMouseEvents inputEvents;
        
        private readonly MainForm callbackForm;

        public bool IsSubscribed { get => isSubscribed; set => isSubscribed = value; }
        public bool IsScrolling { get => isScrolling; set => isScrolling = value; }
        public bool IsAltDown { get => isAltDown; set => isAltDown = value; }
        public bool IsCtrlDown { get => isCtrlDown; set => isCtrlDown = value; }
        public bool IsShiftDown { get => isShiftDown; set => isShiftDown = value; }
        public IKeyboardMouseEvents InputEvents { get => inputEvents; set => inputEvents = value; }

        public InputHandler(MainForm callbackForm)
        {
            this.callbackForm = callbackForm;
            SubscribeMouse();

        }

        public void SubscribeMouse()
        {
            isSubscribed = true;
            inputEvents = Hook.GlobalEvents();
            inputEvents.MouseWheel += OnMouseScroll;
            inputEvents.MouseMove += UpdateBarPositionMouseMove;
            inputEvents.KeyDown += EnableKeyActions;
            inputEvents.KeyUp += DisableKeyActions;
        }

        public void UnsubscribeMouse()
        {
            isSubscribed = false;
            inputEvents.MouseWheel -= OnMouseScroll;
            inputEvents.MouseMove -= UpdateBarPositionMouseMove;
            inputEvents.KeyDown -= EnableKeyActions;
            inputEvents.KeyUp -= DisableKeyActions;
            inputEvents.Dispose();
        }

        private void UpdateBarPositionMouseMove(object sender, MouseEventArgs e)
        {
            if (Globals.IsDisplayingVolumeBar)
            {
                if (TaskbarHelper.IsCursorInTaskbar())
                   callbackForm.SetVolumeBarPosition();
                else
                    callbackForm.HideVolumeBar();

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
            if (TaskbarHelper.IsValidAction() && !Globals.IsDisplayingVolumeSliderControl && Globals.ProgramIsReady && !Globals.AudioHandler.AudioDisabled)
            {
                isScrolling = true;
                if (!isShiftDown && !isCtrlDown)
                {
                    await Task.Run(async () =>
                    {
                        await Globals.AudioHandler.DoVolumeChanges(e.Delta);
                        await callbackForm.DoAppearanceUpdate(updateType: "volume");
                    });
                }
                else if (isCtrlDown && Properties.Settings.Default.ToggleMuteShortcut && !isShiftDown && !isAltDown)
                {
                    callbackForm.SetMuteStatus(e.Delta);
                    await Task.Run(async () =>
                    {
                        await callbackForm.DoAppearanceUpdate(updateType: "mute");
                    });
                }
                else if (isShiftDown && Properties.Settings.Default.SwitchDefaultPlaybackDeviceShortcut && !isCtrlDown && !isAltDown)
                {
                    await Task.Run(async () =>
                    {
                        await Globals.AudioHandler.ToggleAudioPlaybackDevice(e.Delta);
                        await callbackForm.DoAppearanceUpdate(updateType: "device");
                    });
                }
                isScrolling = false;
            }
        }
    }
}
