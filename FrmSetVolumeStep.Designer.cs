namespace TbVolScroll
{
    partial class FrmSetVolumeStep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSetVolumeStep));
            this.numSetVolumeStep = new System.Windows.Forms.NumericUpDown();
            this.lblSetVolumeStep = new System.Windows.Forms.Label();
            this.btnSaveVolumeStep = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numSetVolumeStep)).BeginInit();
            this.SuspendLayout();
            // 
            // numSetVolumeStep
            // 
            this.numSetVolumeStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numSetVolumeStep.Location = new System.Drawing.Point(65, 47);
            this.numSetVolumeStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSetVolumeStep.Name = "numSetVolumeStep";
            this.numSetVolumeStep.Size = new System.Drawing.Size(49, 22);
            this.numSetVolumeStep.TabIndex = 0;
            this.numSetVolumeStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numSetVolumeStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblSetVolumeStep
            // 
            this.lblSetVolumeStep.AutoSize = true;
            this.lblSetVolumeStep.Location = new System.Drawing.Point(21, 9);
            this.lblSetVolumeStep.Name = "lblSetVolumeStep";
            this.lblSetVolumeStep.Size = new System.Drawing.Size(193, 26);
            this.lblSetVolumeStep.TabIndex = 1;
            this.lblSetVolumeStep.Text = "Change the volume step percentage\r\nfor each scroll. Default value is 5.";
            this.lblSetVolumeStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSaveVolumeStep
            // 
            this.btnSaveVolumeStep.Location = new System.Drawing.Point(120, 47);
            this.btnSaveVolumeStep.Name = "btnSaveVolumeStep";
            this.btnSaveVolumeStep.Size = new System.Drawing.Size(50, 23);
            this.btnSaveVolumeStep.TabIndex = 2;
            this.btnSaveVolumeStep.Text = "Save";
            this.btnSaveVolumeStep.UseVisualStyleBackColor = true;
            this.btnSaveVolumeStep.Click += new System.EventHandler(this.SaveNewVolumeStep);
            // 
            // FrmSetVolumeStep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(234, 76);
            this.Controls.Add(this.btnSaveVolumeStep);
            this.Controls.Add(this.lblSetVolumeStep);
            this.Controls.Add(this.numSetVolumeStep);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSetVolumeStep";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TbVolScroll - Set volume step";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LoadCurrentVolumeStep);
            ((System.ComponentModel.ISupportInitialize)(this.numSetVolumeStep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numSetVolumeStep;
        private System.Windows.Forms.Label lblSetVolumeStep;
        private System.Windows.Forms.Button btnSaveVolumeStep;
    }
}