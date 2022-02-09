
namespace tbvolscroll.Classes.ExControls
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
            this.FontListComponent = new System.Windows.Forms.ListBox();
            this.FontNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FontListComponent
            // 
            this.FontListComponent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FontListComponent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FontListComponent.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.FontListComponent.IntegralHeight = false;
            this.FontListComponent.ItemHeight = 20;
            this.FontListComponent.Location = new System.Drawing.Point(0, 22);
            this.FontListComponent.Name = "FontListComponent";
            this.FontListComponent.Size = new System.Drawing.Size(220, 284);
            this.FontListComponent.TabIndex = 0;
            this.FontListComponent.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.FontListComponent_DrawItem);
            this.FontListComponent.SelectedIndexChanged += new System.EventHandler(this.FontListComponent_SelectedIndexChanged);
            this.FontListComponent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FontListComponent_KeyDown);
            // 
            // FontNameTextBox
            // 
            this.FontNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FontNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FontNameTextBox.Location = new System.Drawing.Point(0, 0);
            this.FontNameTextBox.Name = "FontNameTextBox";
            this.FontNameTextBox.Size = new System.Drawing.Size(220, 22);
            this.FontNameTextBox.TabIndex = 1;
            this.FontNameTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextSizeTextBox_MouseClick);
            this.FontNameTextBox.TextChanged += new System.EventHandler(this.TextSizeTextBox_TextChanged);
            // 
            // FontList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.FontNameTextBox);
            this.Controls.Add(this.FontListComponent);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FontList";
            this.Size = new System.Drawing.Size(220, 307);
            this.Load += new System.EventHandler(this.FontList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox FontListComponent;
        private System.Windows.Forms.TextBox FontNameTextBox;
    }
}
