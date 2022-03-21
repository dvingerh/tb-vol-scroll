using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using tb_vol_scroll.Classes.Helpers;

namespace tb_vol_scroll.Classes.ControlsEx
{
    public partial class FontList : UserControl
    {

        public event EventHandler SelectedFontFamilyChanged;
        public FontList()
        {
            InitializeComponent();
            Task.Run(() =>
            {
                foreach (FontFamily f in FontFamily.Families)
                {
                    try
                {
                    if (!string.IsNullOrWhiteSpace(f.Name))
                    {
                        ListViewItem listViewItem = new ListViewItem
                        {
                            Text = f.Name,
                            Font = new Font(f, 10),
                            ForeColor = Color.Black,
                            Tag = new Font(f, 10)
                        };
                        FontListComponent.Items.Add(listViewItem);
                    }
                    }
                    catch { }
                }
            }).ConfigureAwait(false);
        }


        public FontFamily SelectedFontFamily
        {
            get
            {
                if (FontListComponent.SelectedItems.Count != 0)
                    return ((Font)FontListComponent.SelectedItems[0].Tag).FontFamily;
                else
                    return null;
            }
            set
            {
                if (value == null || IndexOf(value) == -1)
                    FontListComponent.SelectedItems.Clear();
                else
                    FontListComponent.Items[IndexOf(value)].Selected = true;
            }
        }

        public int IndexOf(FontFamily ff)
        {
            for (int i = 0; i < FontListComponent.Items.Count; i++)
            {
                Font f = (Font)FontListComponent.Items[i].Tag;
                if (f.FontFamily.Name == ff.Name)
                    return i;
            }

            return -1;
        }

        private void FontListComponentSelectedIndexChanged(object sender, EventArgs e)
        {

            if (FontListComponent.SelectedItems.Count != 0)
            {
                if (!FontNameTextBox.Focused)
                {
                    Font f = (Font)FontListComponent.SelectedItems[0].Tag;
                    FontNameTextBox.Text = f.Name;
                }
                SelectedFontFamilyChanged(FontListComponent, new EventArgs());
            }
        }

        private void FontNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!FontNameTextBox.Focused)
                return;

            for (int i = 0; i < FontListComponent.Items.Count; i++)
            {
                string str = ((Font)FontListComponent.Items[i].Tag).Name.ToLower();
                if (str.Contains(FontNameTextBox.Text.ToLower()))
                {
                    FontListComponent.Items[i].Selected = true;
                    FontListComponent.Items[i].EnsureVisible();
                    FontListComponent.TopItem = FontListComponent.Items[i];
                    int top = i - (int)Math.Round((FontListComponent.DisplayRectangle.Height / 25F) / 2) + 1;
                    if (top < 0)
                        top = 0;
                    if (top > FontListComponent.Items.Count)
                        top = FontListComponent.Items.Count;
                    FontListComponent.TopItem = FontListComponent.Items[top];
                    FontListComponent.TopItem.EnsureVisible();

                    return;
                }
            }
        }

        private void TextSizeTextBoxSelectAll(object sender, MouseEventArgs e)
        {
            FontNameTextBox.SelectAll();
        }


        private void FontListComponentKeyDown(object sender, KeyEventArgs e)
        {
            if (char.IsLetterOrDigit((char)e.KeyValue))
            {
                FontNameTextBox.Focus();
                FontNameTextBox.Text = ((char)e.KeyValue).ToString();
                FontNameTextBox.SelectionStart = 1;
            }
        }

        private void FontListLoad(object sender, EventArgs e)
        {
            ActiveControl = FontListComponent;
            FontListComponent.Columns[0].Width = FontListComponent.ClientSize.Width;
        }
    }


}
