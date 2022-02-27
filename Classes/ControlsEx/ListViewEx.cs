using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace tb_vol_scroll.Classes.ControlsExt
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(ListView))]
    public class ListViewExt : ListView
    {
        public ListViewExt()
        {
            this.DoubleBuffered = true;
        }
    }
}
