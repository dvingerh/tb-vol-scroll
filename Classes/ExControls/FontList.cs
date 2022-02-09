using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
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
                    if (f.Name != null || f.Name != "")
                        FontListComponent.Items.Add(new Font(f, 12));
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
                if (value == null) FontListComponent.ClearSelected();
                else
                {
                    FontListComponent.SelectedIndex = IndexOf(value);
                }

            }
        }

        public int IndexOf(FontFamily ff)
        {
            for (int i = 0; i < FontListComponent.Items.Count; i++)
            {
                Font f = (Font)FontListComponent.Items[i];
                if (f.FontFamily.Name == ff.Name)
                {
                    return i;
                }
            }

            return -1;
        }

        private void FontListComponent_DrawItem(object sender, DrawItemEventArgs e)
        {


            // Draw the background of the ListBox control for each item.
            e.DrawBackground();

            Font font = (Font)FontListComponent.Items[e.Index];
            e.Graphics.DrawString(font.Name, font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);

            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();





        }

        private void FontListComponent_SelectedIndexChanged(object sender, EventArgs e)
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

        private void TextSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!FontNameTextBox.Focused) return;

            for (int i = 0; i < FontListComponent.Items.Count; i++)
            {
                string str = ((Font)FontListComponent.Items[i]).Name;
                if (str.StartsWith(FontNameTextBox.Text, true, null))
                {
                    FontListComponent.SelectedIndex = i;

                    const uint WM_VSCROLL = 0x0115;
                    const uint SB_THUMBPOSITION = 4;

                    uint b = ((uint)(FontListComponent.SelectedIndex) << 16) | (SB_THUMBPOSITION & 0xffff);
                    SendMessage(FontListComponent.Handle, WM_VSCROLL, b, 0);

                    return;
                }
            }
        }

        private void TextSizeTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            FontNameTextBox.SelectAll();
        }


        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lParam);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FontListComponent_KeyDown(object sender, KeyEventArgs e)
        {
            // if you type alphanumeric characters while focus is on ListBox, it shifts the focus to TextBox.
            if (Char.IsLetterOrDigit((char)e.KeyValue))
            {
                FontNameTextBox.Focus();
                FontNameTextBox.Text = ((char)e.KeyValue).ToString();
                FontNameTextBox.SelectionStart = 1;
            }
        }

        // ensures that focus is FontListComponent control whenever the form is loaded
        private void FontList_Load(object sender, EventArgs e)
        {
            this.ActiveControl = FontListComponent;
        }


    }


}
