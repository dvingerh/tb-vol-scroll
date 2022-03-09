using tb_vol_scroll.Classes.ControlsEx;

namespace tb_vol_scroll.Forms
{
    partial class FontDialogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FontDialogForm));
            this.FontLabel = new System.Windows.Forms.Label();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.FontBoldCheckBox = new System.Windows.Forms.CheckBox();
            this.FontItalicCheckBox = new System.Windows.Forms.CheckBox();
            this.FontStrikeoutCheckBox = new System.Windows.Forms.CheckBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.PreviewLabel = new System.Windows.Forms.Label();
            this.CancelDialogButton = new System.Windows.Forms.Button();
            this.FontSizePanel = new System.Windows.Forms.Panel();
            this.FontSizeListBox = new System.Windows.Forms.ListBox();
            this.FontSizeTextBox = new System.Windows.Forms.TextBox();
            this.PreviewTextLabel = new System.Windows.Forms.Label();
            this.FontList = new tb_vol_scroll.Classes.ControlsEx.FontList();
            this.FontSizePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // FontLabel
            // 
            this.FontLabel.AutoSize = true;
            this.FontLabel.Location = new System.Drawing.Point(12, 9);
            this.FontLabel.Name = "FontLabel";
            this.FontLabel.Size = new System.Drawing.Size(34, 13);
            this.FontLabel.TabIndex = 0;
            this.FontLabel.Text = "Font:";
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Location = new System.Drawing.Point(257, 9);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(30, 13);
            this.SizeLabel.TabIndex = 3;
            this.SizeLabel.Text = "Size:";
            // 
            // FontBoldCheckBox
            // 
            this.FontBoldCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.FontBoldCheckBox.Location = new System.Drawing.Point(318, 178);
            this.FontBoldCheckBox.Name = "FontBoldCheckBox";
            this.FontBoldCheckBox.Size = new System.Drawing.Size(79, 23);
            this.FontBoldCheckBox.TabIndex = 6;
            this.FontBoldCheckBox.Text = "Bold";
            this.FontBoldCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FontBoldCheckBox.UseVisualStyleBackColor = true;
            this.FontBoldCheckBox.CheckedChanged += new System.EventHandler(this.CheckBoxCheckedChanged);
            // 
            // FontItalicCheckBox
            // 
            this.FontItalicCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.FontItalicCheckBox.Location = new System.Drawing.Point(404, 178);
            this.FontItalicCheckBox.Name = "FontItalicCheckBox";
            this.FontItalicCheckBox.Size = new System.Drawing.Size(80, 23);
            this.FontItalicCheckBox.TabIndex = 7;
            this.FontItalicCheckBox.Text = "Italic";
            this.FontItalicCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FontItalicCheckBox.UseVisualStyleBackColor = true;
            this.FontItalicCheckBox.CheckedChanged += new System.EventHandler(this.CheckBoxCheckedChanged);
            // 
            // FontStrikeoutCheckBox
            // 
            this.FontStrikeoutCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.FontStrikeoutCheckBox.Location = new System.Drawing.Point(491, 178);
            this.FontStrikeoutCheckBox.Name = "FontStrikeoutCheckBox";
            this.FontStrikeoutCheckBox.Size = new System.Drawing.Size(79, 23);
            this.FontStrikeoutCheckBox.TabIndex = 8;
            this.FontStrikeoutCheckBox.Text = "Strikeout";
            this.FontStrikeoutCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FontStrikeoutCheckBox.UseVisualStyleBackColor = true;
            this.FontStrikeoutCheckBox.CheckedChanged += new System.EventHandler(this.CheckBoxCheckedChanged);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SaveButton.Location = new System.Drawing.Point(469, 273);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(100, 23);
            this.SaveButton.TabIndex = 11;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // PreviewLabel
            // 
            this.PreviewLabel.AutoSize = true;
            this.PreviewLabel.Location = new System.Drawing.Point(316, 9);
            this.PreviewLabel.Name = "PreviewLabel";
            this.PreviewLabel.Size = new System.Drawing.Size(49, 13);
            this.PreviewLabel.TabIndex = 14;
            this.PreviewLabel.Text = "Preview:";
            // 
            // CancelDialogButton
            // 
            this.CancelDialogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelDialogButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CancelDialogButton.Location = new System.Drawing.Point(360, 273);
            this.CancelDialogButton.Name = "CancelDialogButton";
            this.CancelDialogButton.Size = new System.Drawing.Size(100, 23);
            this.CancelDialogButton.TabIndex = 15;
            this.CancelDialogButton.Text = "Cancel";
            this.CancelDialogButton.UseVisualStyleBackColor = true;
            this.CancelDialogButton.Click += new System.EventHandler(this.CancelDialogButton_Click);
            // 
            // FontSizePanel
            // 
            this.FontSizePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FontSizePanel.Controls.Add(this.FontSizeListBox);
            this.FontSizePanel.Location = new System.Drawing.Point(259, 46);
            this.FontSizePanel.Name = "FontSizePanel";
            this.FontSizePanel.Size = new System.Drawing.Size(53, 250);
            this.FontSizePanel.TabIndex = 18;
            // 
            // FontSizeListBox
            // 
            this.FontSizeListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FontSizeListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FontSizeListBox.FormattingEnabled = true;
            this.FontSizeListBox.IntegralHeight = false;
            this.FontSizeListBox.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "36",
            "48",
            "72"});
            this.FontSizeListBox.Location = new System.Drawing.Point(0, 0);
            this.FontSizeListBox.Name = "FontSizeListBox";
            this.FontSizeListBox.Size = new System.Drawing.Size(51, 248);
            this.FontSizeListBox.TabIndex = 17;
            this.FontSizeListBox.SelectedIndexChanged += new System.EventHandler(this.FontSizeListSelectionChanged);
            // 
            // FontSizeTextBox
            // 
            this.FontSizeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FontSizeTextBox.Location = new System.Drawing.Point(259, 25);
            this.FontSizeTextBox.Name = "FontSizeTextBox";
            this.FontSizeTextBox.Size = new System.Drawing.Size(53, 22);
            this.FontSizeTextBox.TabIndex = 5;
            this.FontSizeTextBox.TextChanged += new System.EventHandler(this.FontSizeTextChanged);
            this.FontSizeTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FontSizeTextBoxKeyDown);
            // 
            // PreviewTextLabel
            // 
            this.PreviewTextLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PreviewTextLabel.AutoEllipsis = true;
            this.PreviewTextLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PreviewTextLabel.Location = new System.Drawing.Point(319, 25);
            this.PreviewTextLabel.Name = "PreviewTextLabel";
            this.PreviewTextLabel.Size = new System.Drawing.Size(250, 150);
            this.PreviewTextLabel.TabIndex = 19;
            this.PreviewTextLabel.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ\r\n1234567890 %";
            this.PreviewTextLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // FontList
            // 
            this.FontList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FontList.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FontList.Location = new System.Drawing.Point(15, 25);
            this.FontList.Name = "FontList";
            this.FontList.Size = new System.Drawing.Size(238, 270);
            this.FontList.TabIndex = 20;
            // 
            // FontDialogForm
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.CancelDialogButton;
            this.ClientSize = new System.Drawing.Size(584, 311);
            this.Controls.Add(this.FontList);
            this.Controls.Add(this.PreviewTextLabel);
            this.Controls.Add(this.FontSizeTextBox);
            this.Controls.Add(this.CancelDialogButton);
            this.Controls.Add(this.PreviewLabel);
            this.Controls.Add(this.FontStrikeoutCheckBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.FontBoldCheckBox);
            this.Controls.Add(this.FontItalicCheckBox);
            this.Controls.Add(this.SizeLabel);
            this.Controls.Add(this.FontLabel);
            this.Controls.Add(this.FontSizePanel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FontDialogForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Font (tb-vol-scroll)";
            this.Load += new System.EventHandler(this.FontDialogForm_Load);
            this.FontSizePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FontLabel;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.CheckBox FontBoldCheckBox;
        private System.Windows.Forms.CheckBox FontItalicCheckBox;
        private System.Windows.Forms.CheckBox FontStrikeoutCheckBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label PreviewLabel;
        private System.Windows.Forms.Button CancelDialogButton;
        private System.Windows.Forms.Panel FontSizePanel;
        private System.Windows.Forms.ListBox FontSizeListBox;
        private System.Windows.Forms.TextBox FontSizeTextBox;
        private System.Windows.Forms.Label PreviewTextLabel;
        private FontList FontList;
    }
}