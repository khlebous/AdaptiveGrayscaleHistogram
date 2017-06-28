namespace histogram
{
    partial class histogram
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBarBottom = new System.Windows.Forms.TrackBar();
            this.trackBarTop = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTop)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bottom Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Top Value";
            // 
            // trackBarBottom
            // 
            this.trackBarBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.trackBarBottom.Location = new System.Drawing.Point(0, 13);
            this.trackBarBottom.Maximum = 255;
            this.trackBarBottom.Name = "trackBarBottom";
            this.trackBarBottom.Size = new System.Drawing.Size(308, 42);
            this.trackBarBottom.TabIndex = 2;
            this.trackBarBottom.ValueChanged += new System.EventHandler(this.trackBarBottom_ValueChanged);
            // 
            // trackBarTop
            // 
            this.trackBarTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.trackBarTop.Location = new System.Drawing.Point(0, 55);
            this.trackBarTop.Maximum = 255;
            this.trackBarTop.Name = "trackBarTop";
            this.trackBarTop.Size = new System.Drawing.Size(308, 42);
            this.trackBarTop.TabIndex = 3;
            this.trackBarTop.Value = 255;
            this.trackBarTop.ValueChanged += new System.EventHandler(this.trackBarTop_ValueChanged);
            // 
            // histogram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 112);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBarTop);
            this.Controls.Add(this.trackBarBottom);
            this.Controls.Add(this.label1);
            this.Name = "histogram";
            this.Text = "histogram";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBarBottom;
        private System.Windows.Forms.TrackBar trackBarTop;
    }
}