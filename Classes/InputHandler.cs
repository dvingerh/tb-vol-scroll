using Gma.System.MouseKeyHook;
using System.Drawing;
using System.Windows.Forms;

namespace tbvolscroll
{
    public sealed class InputHandler
    {
        public bool isAltDown;
        private readonly IKeyboardMouseEvents mouseEvents;
        private readonly MainForm callbackForm;

        public InputHandler(MainForm callbackForm)
        {
            this.callbackForm = callbackForm;
            mouseEvents = Hook.GlobalEvents();
            mouseEvents.MouseWheel += OnMouseScroll;
            mouseEvents.MouseMove += UpdateBarPositionMouseMove;
            mouseEvents.KeyDown += EnableAltDown;
            mouseEvents.KeyUp += DisableAltDown;
        }

        private void UpdateBarPositionMouseMove(object sender, MouseEventArgs e)
        {
            callbackForm.SetVolumeBarPosition(TaskbarHelper.Position);
        }

        private void DisableAltDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.LMenu)
                isAltDown = false;
        }

        private void EnableAltDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.LMenu)
                isAltDown = true;
        }

        private void OnMouseScroll(object sender, MouseEventArgs e)
        {
            callbackForm.DoVolumeChanges(e.Delta);
        }
    }
}
