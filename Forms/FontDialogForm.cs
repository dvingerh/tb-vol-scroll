using System;
using System.Drawing;
using System.Windows.Forms;

namespace tb_vol_scroll.Forms
{
    public partial class FontDialogForm : Form
    {
        public FontDialogForm()
        {
            InitializeComponent();

            FontList.SelectedFontFamily = FontFamily.GenericSansSerif;
            FontList.SelectedFontFamilyChanged += SelectedFontChanged;
            FontSizeTextBox.Text = Convert.ToString(10);
            DialogResult = DialogResult.Cancel;
            
        }

        public Font SelectedFont
        {
            get
            {
                return PreviewTextLabel.Font;
            }
            set
            {
                FontList.SelectedFontFamily = value.FontFamily;
                FontSizeTextBox.Text = value.Size.ToString();
                FontBoldCheckBox.Checked = value.Bold;
                FontItalicCheckBox.Checked = value.Italic;
                FontStrikeoutCheckBox.Checked = value.Strikeout;
            }
        }


        private void SelectedFontChanged(object sender, EventArgs e)
        {
            UpdatePreviewText();
        }

        private void FontSizeListSelectionChanged(object sender, EventArgs e)
        {
            if (FontSizeListBox.SelectedItem != null)
                FontSizeTextBox.Text = FontSizeListBox.SelectedItem.ToString();
        }

        private void FontSizeTextChanged(object sender, EventArgs e)
        {
            if (FontSizeListBox.Items.Contains(FontSizeTextBox.Text))
                FontSizeListBox.SelectedItem = FontSizeTextBox.Text;
            else
                FontSizeListBox.ClearSelected();
            UpdatePreviewText();
        }


        private void FontSizeTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.D0:
                case Keys.D1:
                case Keys.D2:
                case Keys.D3:
                case Keys.D4:
                case Keys.D5:
                case Keys.D6:
                case Keys.D7:
                case Keys.D8:
                case Keys.D9:
                case Keys.End:
                case Keys.Enter:
                case Keys.Home:
                case Keys.Back:
                case Keys.Delete:
                case Keys.Escape:
                case Keys.Left:
                case Keys.Right:
                    break;
                case Keys.Decimal:
                case (Keys)190: //decimal point
                    if (FontSizeTextBox.Text.Contains("."))
                    {
                        e.SuppressKeyPress = true;
                        e.Handled = true;
                    }
                    break;
                default:
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    break;
            }

        }

        private void UpdatePreviewText()
        {
            if (FontList.SelectedFontFamily != null)
            {
                float size = FontSizeTextBox.Text != "" ? float.Parse(FontSizeTextBox.Text) : 8;
                FontStyle style = FontBoldCheckBox.Checked ? FontStyle.Bold : FontStyle.Regular;
                if (FontItalicCheckBox.Checked)
                    style |= FontStyle.Italic;
                if (FontStrikeoutCheckBox.Checked)
                    style |= FontStyle.Strikeout;
                PreviewTextLabel.Font = new Font(FontList.SelectedFontFamily, size, style);
            }
        }

    
        private void CheckBoxCheckedChanged(object sender, EventArgs e)
        {
            UpdatePreviewText();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelDialogButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FontDialogForm_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }
    }
}
