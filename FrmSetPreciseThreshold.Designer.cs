namespace TbVolScroll
{
    partial class FrmSetPreciseThreshold
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSetPreciseThreshold));
            this.numSetPreciseThreshold = new System.Windows.Forms.NumericUpDown();
            this.lblSetPreciseThreshold = new System.Windows.Forms.Label();
            this.btnSavePreciseThreshold = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numSetPreciseThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // numSetPreciseThreshold
            // 
            this.numSetPreciseThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numSetPreciseThreshold.Location = new System.Drawing.Point(77, 47);
            this.numSetPreciseThreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSetPreciseThreshold.Name = "numSetPreciseThreshold";
            this.numSetPreciseThreshold.Size = new System.Drawing.Size(49, 22);
            this.numSetPreciseThreshold.TabIndex = 0;
            this.numSetPreciseThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numSetPreciseThreshold.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblSetPreciseThreshold
            // 
            this.lblSetPreciseThreshold.AutoSize = true;
            this.lblSetPreciseThreshold.Location = new System.Drawing.Point(24, 9);
            this.lblSetPreciseThreshold.Name = "lblSetPreciseThreshold";
            this.lblSetPreciseThreshold.Size = new System.Drawing.Size(210, 26);
            this.lblSetPreciseThreshold.TabIndex = 1;
            this.lblSetPreciseThreshold.Text = "Change the threshold for when precise\r\nscrolling is enabled. Default value is 10." +
    "";
            this.lblSetPreciseThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSavePreciseThreshold
            // 
            this.btnSavePreciseThreshold.Location = new System.Drawing.Point(132, 47);
            this.btnSavePreciseThreshold.Name = "btnSavePreciseThreshold";
            this.btnSavePreciseThreshold.Size = new System.Drawing.Size(50, 23);
            this.btnSavePreciseThreshold.TabIndex = 2;
            this.btnSavePreciseThreshold.Text = "Save";
            this.btnSavePreciseThreshold.UseVisualStyleBackColor = true;
            this.btnSavePreciseThreshold.Click += new System.EventHandler(this.SavenewThreshold);
            // 
            // FrmSetPreciseThreshold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(259, 76);
            this.Controls.Add(this.btnSavePreciseThreshold);
            this.Controls.Add(this.lblSetPreciseThreshold);
            this.Controls.Add(this.numSetPreciseThreshold);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSetPreciseThreshold";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TbVolScroll - Set precise threshold";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LoadCurrentThreshold);
            ((System.ComponentModel.ISupportInitialize)(this.numSetPreciseThreshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numSetPreciseThreshold;
        private System.Windows.Forms.Label lblSetPreciseThreshold;
        private System.Windows.Forms.Button btnSavePreciseThreshold;
    }
}