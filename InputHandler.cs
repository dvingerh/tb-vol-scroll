using Gma.System.MouseKeyHook;
using System.Drawing;
using System.Windows.Forms;

namespace TbVolScroll
{
    public sealed class InputHandler
    {
        private static InputHandler instance = null;
        private static readonly object padlock = new object();
        public bool IsAltDown;
        public int TimeOutHelper;
        private IKeyboardMouseEvents MouseKeyEvents;
        private frmMain callbackForm;

        public InputHandler(frmMain callbackForm)
        {
            this.callbackForm = callbackForm;
            MouseKeyEvents = Hook.GlobalEvents();
            MouseKeyEvents.MouseWheel += OnMouseScroll;
            MouseKeyEvents.MouseMove += UpdateBarPositionMouseMove;
            MouseKeyEvents.KeyDown += EnableAltDown;
            MouseKeyEvents.KeyUp += DisableAltDown;
        }

        private void UpdateBarPositionMouseMove(object sender, MouseEventArgs e)
        {
            if (callbackForm.IsDisplayingVolume)
            {
                Point CursorPosition = Cursor.Position;
                callbackForm.Left = CursorPosition.X - callbackForm.Width / 2;
                callbackForm.Top = CursorPosition.Y - 20;
            }
        }

        private void DisableAltDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.LMenu)
            {
                IsAltDown = false;
            }
        }

        private void EnableAltDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.LMenu)
            {
                IsAltDown = true;
            }
        }

        public void OnMouseScroll(object sender, MouseEventArgs e)
        {
                TimeOutHelper = 10;
                callbackForm.DoVolumeChanges(e.Delta);
        }

        public bool CursorInTaskbar()
        {
            Point position = Cursor.Position;
            callbackForm.Opacity = 1;
            return position.Y >= callbackForm.TaskbarRect.Top && position.Y <= callbackForm.TaskbarRect.Bottom;
        }

        public static InputHandler Instance
        {
            get
            {
                lock (padlock)
                {
                    return instance;
                }
            }
        }
    }
}
