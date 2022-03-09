using Gma.System.MouseKeyHook;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using tb_vol_scroll.Classes.Helpers;
using tb_vol_scroll.Properties;
using static tb_vol_scroll.Classes.Helpers.Enums;

namespace tb_vol_scroll.Classes.Handlers
{
    public class InputHandler
    {
        private readonly IKeyboardMouseEvents inputHook;
        private readonly Queue<MouseEventArgs> mouseScrollQueue;
        private Task mouseScrollTask = null;
        private bool isAltDown = false;
        private bool isCtrlDown = false;
        private bool isShiftDown = false;
        private bool inputEnabled = false;
        public bool InputEnabled { get => inputEnabled; set => inputEnabled = value; }

        public Queue<MouseEventArgs> MouseScrollQueue => mouseScrollQueue;

        public InputHandler()
        {
            inputHook = Hook.GlobalEvents();
            mouseScrollQueue = new Queue<MouseEventArgs>();
            
            inputHook.KeyDown += InputHook_KeyDown;
            inputHook.KeyUp += InputHook_KeyUp;
            inputHook.MouseMove += InputHook_MouseMove;
            inputHook.MouseWheel += InputHook_MouseWheel;

            
        }

        public void UnhookAll()
        {
            mouseScrollQueue.Clear();
            mouseScrollTask = null;

            inputHook.KeyDown -= InputHook_KeyDown;
            inputHook.KeyUp -= InputHook_KeyUp;
            inputHook.MouseMove -= InputHook_MouseMove;
            inputHook.MouseWheel -= InputHook_MouseWheel;

            inputHook.Dispose();
        }

        private async void InputHook_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Taskbar.IsCursorInTaskbar() && Globals.VolumeSliderControlForm == null && inputEnabled)
            {
                if (mouseScrollQueue.Count < 5)
                    mouseScrollQueue.Enqueue(e);

                await ProcessMouseWheelScrollActionQueue();
            }
        }

        private async Task ProcessMouseWheelScrollActionQueue()
        {
            if (mouseScrollTask == null || mouseScrollTask.IsCompleted)
            {
                if (mouseScrollQueue.Count != 0)
                {
                    var wheelArgs = mouseScrollQueue.Dequeue();
                    MouseWheelDirection direction = wheelArgs.Delta > 0 ? MouseWheelDirection.Up : MouseWheelDirection.Down;
                    mouseScrollTask = HandleMouseWheelScroll(direction);
                    if (Settings.Default.DisplayStatusBarScrollActions)
                        await mouseScrollTask.ContinueWith(result => Globals.MainForm.SetBarVisibility(true));
                    if (mouseScrollQueue.Count != 0)
                        await ProcessMouseWheelScrollActionQueue();
                }
            }
        }


        private async Task HandleMouseWheelScroll(MouseWheelDirection direction)
        {
            Task task = null;

            if (!isAltDown && !isCtrlDown && !isShiftDown)
            {
                // Regular volume
                bool reachedThreshold = Globals.AudioHandler.FriendlyVolume < Settings.Default.PreciseVolumeThreshold;
                task = Globals.AudioHandler.AdjustVolume(direction, reachedThreshold ? ActionTriggerType.PreciseVolumeScroll : ActionTriggerType.RegularVolumeScroll);
                await task.ContinueWith(result => Globals.MainForm.SetAppAppearances(reachedThreshold ? ActionTriggerType.PreciseVolumeScroll : ActionTriggerType.RegularVolumeScroll));
            }
            else if (isAltDown)
            {
                // Precise Volume
                if (Settings.Default.AltHotkeyEnabled)
                {
                    task = Globals.AudioHandler.AdjustVolume(direction, ActionTriggerType.PreciseVolumeScroll);
                    await task.ContinueWith(result => Globals.MainForm.SetAppAppearances(ActionTriggerType.PreciseVolumeScroll));
                }
                else
                {
                    bool reachedThreshold = Globals.AudioHandler.FriendlyVolume < Settings.Default.PreciseVolumeThreshold;
                    task = Globals.AudioHandler.AdjustVolume(direction, reachedThreshold ? ActionTriggerType.PreciseVolumeScroll : ActionTriggerType.RegularVolumeScroll);
                    await task.ContinueWith(result => Globals.MainForm.SetAppAppearances(reachedThreshold ? ActionTriggerType.PreciseVolumeScroll : ActionTriggerType.RegularVolumeScroll));
                }
            }
            else if (isCtrlDown)
            {
                // Mute toggle
                if (Settings.Default.CtrlHotkeyEnabled)
                {
                    bool doMute = direction == MouseWheelDirection.Down;
                    task = Globals.AudioHandler.SetDeviceMute(Globals.AudioHandler.AudioController.DefaultPlaybackDevice, doMute);
                    await task.ContinueWith(result => Globals.MainForm.SetAppAppearances(ActionTriggerType.MuteToggleScroll));
                }
                else
                {
                    bool reachedThreshold = Globals.AudioHandler.FriendlyVolume < Settings.Default.PreciseVolumeThreshold;
                    task = Globals.AudioHandler.AdjustVolume(direction, reachedThreshold ? ActionTriggerType.PreciseVolumeScroll : ActionTriggerType.RegularVolumeScroll);
                    await task.ContinueWith(result => Globals.MainForm.SetAppAppearances(reachedThreshold ? ActionTriggerType.PreciseVolumeScroll : ActionTriggerType.RegularVolumeScroll));
                }
            }
            else if (isShiftDown)
            {
                // Device switch
                if (Settings.Default.ShiftHotkeyEnabled)
                {
                    task = Globals.AudioHandler.ChangePlaybackDevice(direction);
                    await task.ContinueWith(result => Globals.MainForm.SetAppAppearances(ActionTriggerType.DeviceSwitchScroll));
                }
                else
                {
                    bool reachedThreshold = Globals.AudioHandler.FriendlyVolume < Settings.Default.PreciseVolumeThreshold;
                    task = Globals.AudioHandler.AdjustVolume(direction, reachedThreshold ? ActionTriggerType.PreciseVolumeScroll : ActionTriggerType.RegularVolumeScroll);
                    await task.ContinueWith(result => Globals.MainForm.SetAppAppearances(reachedThreshold ? ActionTriggerType.PreciseVolumeScroll : ActionTriggerType.RegularVolumeScroll));
                }
            }
            else
            {
                // Invalid option
            }
        }

        private void InputHook_MouseMove(object sender, MouseEventArgs e)
        {
            if(Taskbar.IsCursorInTaskbar() && Globals.MainForm.Visible && inputEnabled)
                Globals.MainForm.SetBarPosition();
            else
                Globals.MainForm.SetBarVisibility(false);
        }

        private void InputHook_KeyUp(object sender, KeyEventArgs e)
        {
            if (inputEnabled)
            {
                if (e.KeyCode == Keys.LMenu)
                    isAltDown = false;
                if (e.KeyCode == Keys.LControlKey)
                    isCtrlDown = false;
                if (e.KeyCode == Keys.LShiftKey)
                    isShiftDown = false;
            }
        }
         
        private void InputHook_KeyDown(object sender, KeyEventArgs e)
        {
            if (inputEnabled)
            {
                if (e.KeyCode == Keys.LMenu)
                    isAltDown = true;
                if (e.KeyCode == Keys.LControlKey)
                    isCtrlDown = true;
                if (e.KeyCode == Keys.LShiftKey)
                    isShiftDown = true;
            }
        }
    }
}