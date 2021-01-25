using Gma.System.MouseKeyHook;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tbvolscroll
{
    public sealed class InputHandler
    {
        public bool isAltDown;
        public bool isCtrlDown;
        public bool isScrolling;
        private readonly IKeyboardMouseEvents mouseEvents;
        private readonly MainForm callbackForm;

        public InputHandler(MainForm callbackForm)
        {
            this.callbackForm = callbackForm;
            mouseEvents = Hook.GlobalEvents();
            mouseEvents.MouseWheel += OnMouseScroll;
            mouseEvents.MouseMove += UpdateBarPositionMouseMove;
            mouseEvents.KeyDown += EnableKeyActions;
            mouseEvents.KeyUp += DisableKeyActions;
        }

        private void UpdateBarPositionMouseMove(object sender, MouseEventArgs e)
        {
            callbackForm.SetVolumeBarPosition(TaskbarHelper.Position);
        }

        private void DisableKeyActions(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.LMenu || e.KeyCode == Keys.RMenu)
                isAltDown = false;
            if (e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey)
                isCtrlDown = false;
        }

        private void EnableKeyActions(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.LMenu || e.KeyCode == Keys.RMenu)
                isAltDown = true;
            if (e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey)
                isCtrlDown = true;
        }

        private async void OnMouseScroll(object sender, MouseEventArgs e)
        {
            isScrolling = true;
            callbackForm.DoVolumeChanges(e.Delta);
            await Task.Delay(100);
            isScrolling = false;
        }
    }
}
