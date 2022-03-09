
namespace tb_vol_scroll.Classes.ControlsEx
{
    partial class FontList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FontNameTextBox = new System.Windows.Forms.TextBox();
            this.FontListComponent = new System.Windows.Forms.ListView();
            this.FontColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FontListImageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // FontNameTextBox
            // 
            this.FontNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FontNameTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.FontNameTextBox.Location = new System.Drawing.Point(0, 0);
            this.FontNameTextBox.Name = "FontNameTextBox";
            this.FontNameTextBox.Size = new System.Drawing.Size(200, 22);
            this.FontNameTextBox.TabIndex = 1;
            this.FontNameTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextSizeTextBoxSelectAll);
            this.FontNameTextBox.TextChanged += new System.EventHandler(this.FontNameTextBox_TextChanged);
            // 
            // FontListComponent
            // 
            this.FontListComponent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FontListComponent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FontListComponent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FontColumnHeader});
            this.FontListComponent.FullRowSelect = true;
            this.FontListComponent.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.FontListComponent.HideSelection = false;
            this.FontListComponent.Location = new System.Drawing.Point(0, 21);
            this.FontListComponent.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.FontListComponent.MultiSelect = false;
            this.FontListComponent.Name = "FontListComponent";
            this.FontListComponent.ShowGroups = false;
            this.FontListComponent.Size = new System.Drawing.Size(200, 129);
            this.FontListComponent.SmallImageList = this.FontListImageList;
            this.FontListComponent.TabIndex = 2;
            this.FontListComponent.UseCompatibleStateImageBehavior = false;
            this.FontListComponent.View = System.Windows.Forms.View.Details;
            this.FontListComponent.SelectedIndexChanged += new System.EventHandler(this.FontListComponentSelectedIndexChanged);
            this.FontListComponent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FontListComponentKeyDown);
            // 
            // FontColumnHeader
            // 
            this.FontColumnHeader.Text = "Font";
            this.FontColumnHeader.Width = 150;
            // 
            // FontListImageList
            // 
            this.FontListImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.FontListImageList.ImageSize = new System.Drawing.Size(1, 25);
            this.FontListImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // FontList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.FontListComponent);
            this.Controls.Add(this.FontNameTextBox);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FontList";
            this.Size = new System.Drawing.Size(200, 150);
            this.Load += new System.EventHandler(this.FontListLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox FontNameTextBox;
        private System.Windows.Forms.ListView FontListComponent;
        private System.Windows.Forms.ColumnHeader FontColumnHeader;
        private System.Windows.Forms.ImageList FontListImageList;
    }
}
