using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace tbvolscroll.Classes.ExControls
{
    public partial class FontList : UserControl
    {

        public event EventHandler SelectedFontFamilyChanged;

        public FontList()
        {
            InitializeComponent();
            foreach (FontFamily f in FontFamily.Families)
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(f.Name))
                        FontListComponent.Items.Add(new Font(f, 10));
                }
                catch { }
            }
        }


        public FontFamily SelectedFontFamily
        {
            get
            {
                if (FontListComponent.SelectedItem != null)
                    return ((Font)FontListComponent.SelectedItem).FontFamily;
                else
                    return null;
            }
            set
            {
                if (value == null)
                    FontListComponent.ClearSelected();
                else
                    FontListComponent.SelectedIndex = IndexOf(value);

            }
        }

        public int IndexOf(FontFamily ff)
        {
            for (int i = 0; i < FontListComponent.Items.Count; i++)
            {
                Font f = (Font)FontListComponent.Items[i];
                if (f.FontFamily.Name == ff.Name)
                    return i;
            }

            return -1;
        }

        private void FontListComponentDrawItem(object sender, DrawItemEventArgs e)
        {
            Font font = (Font)FontListComponent.Items[e.Index];
            e.DrawBackground();
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            StringFormat format = new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.EllipsisWord
            };
            if (e.State.HasFlag(DrawItemState.Selected))
                e.Graphics.DrawString(font.Name, font, Brushes.White, e.Bounds, format);
            else
                e.Graphics.DrawString(font.Name, font, Brushes.Black, e.Bounds, format);
        }

        private void FontListComponentSelectedIndexChanged(object sender, EventArgs e)
        {

            if (FontListComponent.SelectedItem != null)
            {
                if (!FontNameTextBox.Focused)
                {
                    Font f = (Font)FontListComponent.SelectedItem;
                    FontNameTextBox.Text = f.Name;
                }
                SelectedFontFamilyChanged(FontListComponent, new EventArgs());
            }
        }

        private void TextSizeTextBoxTextChanged(object sender, EventArgs e)
        {
            if (!FontNameTextBox.Focused) 
                return;

            for (int i = 0; i < FontListComponent.Items.Count; i++)
            {
                string str = ((Font)FontListComponent.Items[i]).Name.ToLower();
                if (str.Contains(FontNameTextBox.Text.ToLower()))
                {
                    FontListComponent.SelectedIndex = i;
                    FontListComponent.TopIndex = FontListComponent.SelectedIndex - (FontListComponent.ClientSize.Height / 25) / 2;
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
            if (Char.IsLetterOrDigit((char)e.KeyValue))
            {
                FontNameTextBox.Focus();
                FontNameTextBox.Text = ((char)e.KeyValue).ToString();
                FontNameTextBox.SelectionStart = 1;
            }
        }

        private void FontListLoad(object sender, EventArgs e)
        {
            this.ActiveControl = FontListComponent;
        }


    }


}
