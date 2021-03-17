using Gma.System.MouseKeyHook;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tbvolscroll
{
    public sealed class InputHandler
    {
        public bool isAltDown;
        public bool isCtrlDown;
        public bool isShiftDown;
        public bool isScrolling;
        public readonly IKeyboardMouseEvents inputEvents;
        
        private readonly MainForm callbackForm;

        public InputHandler(MainForm callbackForm)
        {
            this.callbackForm = callbackForm;
            inputEvents = Hook.GlobalEvents();
            inputEvents.MouseWheel += OnMouseScroll;
            inputEvents.MouseMove += UpdateBarPositionMouseMove;
            inputEvents.KeyDown += EnableKeyActions;
            inputEvents.KeyUp += DisableKeyActions;
        }

        private void UpdateBarPositionMouseMove(object sender, MouseEventArgs e)
        {
            callbackForm.SetVolumeBarPosition();
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
            if (TaskbarHelper.IsValidAction())
            {
                isScrolling = true;
                if (!isShiftDown && !isCtrlDown)
                    callbackForm.DoVolumeChanges(e.Delta);
                else if (isCtrlDown && Properties.Settings.Default.ToggleMuteShortcut && !isShiftDown && !isAltDown)
                    callbackForm.SetMuteStatus(e.Delta);
                else if (isShiftDown && Properties.Settings.Default.SwitchDefaultPlaybackDeviceShortcut && !isCtrlDown && !isAltDown)
                    await callbackForm.ToggleAudioPlaybackDevice(e.Delta);
                await Task.Delay(100);
                isScrolling = false;
            }
        }
    }
}
