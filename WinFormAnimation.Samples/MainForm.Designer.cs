namespace WinFormAnimation.Samples
{
    partial class MainForm
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.demo41 = new WinFormAnimation.Samples.Demo4();
            this.demo31 = new WinFormAnimation.Samples.Demo3();
            this.demo21 = new WinFormAnimation.Samples.Demo2();
            this.demo11 = new WinFormAnimation.Samples.Demo1();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "1D Animation";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "3D Animation";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Benchmark";
            // 
            // demo41
            // 
            this.demo41.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.demo41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.demo41.Location = new System.Drawing.Point(12, 190);
            this.demo41.Name = "demo41";
            this.demo41.Size = new System.Drawing.Size(613, 82);
            this.demo41.TabIndex = 6;
            // 
            // demo31
            // 
            this.demo31.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.demo31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.demo31.Location = new System.Drawing.Point(12, 108);
            this.demo31.Name = "demo31";
            this.demo31.Size = new System.Drawing.Size(245, 63);
            this.demo31.TabIndex = 2;
            // 
            // demo21
            // 
            this.demo21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.demo21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.demo21.Location = new System.Drawing.Point(263, 12);
            this.demo21.Name = "demo21";
            this.demo21.Size = new System.Drawing.Size(362, 159);
            this.demo21.TabIndex = 1;
            // 
            // demo11
            // 
            this.demo11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.demo11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.demo11.Location = new System.Drawing.Point(12, 28);
            this.demo11.Name = "demo11";
            this.demo11.Size = new System.Drawing.Size(245, 61);
            this.demo11.TabIndex = 0;
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 283);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.demo41);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.demo31);
            this.Controls.Add(this.demo21);
            this.Controls.Add(this.demo11);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Main";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinForm Animation Library Samples";
            this.Shown += new System.EventHandler(this.FormShown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Demo1 demo11;
        private Demo2 demo21;
        private Demo3 demo31;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Demo4 demo41;
        private System.Windows.Forms.Label label4;


    }
}

