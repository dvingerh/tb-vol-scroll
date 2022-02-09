using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tbvolscroll.Classes.ExControls
{
    public class TransparentPanel : Panel
    {
        protected override void OnPaint(PaintEventArgs e)
        {

        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {

        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT

                return cp;
            }
        }
    }
}
