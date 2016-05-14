namespace WinFormAnimation.Samples
{
    partial class Demo1
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
            this.lbl_res = new System.Windows.Forms.Label();
            this.btn_play = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_pause = new System.Windows.Forms.Button();
            this.btn_resume = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_res
            // 
            this.lbl_res.AutoSize = true;
            this.lbl_res.Location = new System.Drawing.Point(69, 10);
            this.lbl_res.Name = "lbl_res";
            this.lbl_res.Size = new System.Drawing.Size(13, 13);
            this.lbl_res.TabIndex = 4;
            this.lbl_res.Text = "0";
            // 
            // btn_play
            // 
            this.btn_play.Location = new System.Drawing.Point(36, 3);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(27, 24);
            this.btn_play.TabIndex = 1;
            this.btn_play.Text = ">";
            this.btn_play.UseVisualStyleBackColor = true;
            this.btn_play.Click += new System.EventHandler(this.PlayButton);
            // 
            // btn_stop
            // 
            this.btn_stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_stop.Location = new System.Drawing.Point(3, 3);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(27, 24);
            this.btn_stop.TabIndex = 0;
            this.btn_stop.Text = "□";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.StopButton);
            // 
            // btn_pause
            // 
            this.btn_pause.Location = new System.Drawing.Point(3, 33);
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.Size = new System.Drawing.Size(27, 24);
            this.btn_pause.TabIndex = 2;
            this.btn_pause.Text = "| |";
            this.btn_pause.UseVisualStyleBackColor = true;
            this.btn_pause.Click += new System.EventHandler(this.PauseButton);
            // 
            // btn_resume
            // 
            this.btn_resume.Location = new System.Drawing.Point(36, 33);
            this.btn_resume.Name = "btn_resume";
            this.btn_resume.Size = new System.Drawing.Size(27, 24);
            this.btn_resume.TabIndex = 3;
            this.btn_resume.Text = ">";
            this.btn_resume.UseVisualStyleBackColor = true;
            this.btn_resume.Click += new System.EventHandler(this.ResumeButton);
            // 
            // Demo1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_res);
            this.Controls.Add(this.btn_play);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_pause);
            this.Controls.Add(this.btn_resume);
            this.DoubleBuffered = true;
            this.Name = "Demo1";
            this.Size = new System.Drawing.Size(130, 66);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lbl_res;
        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_pause;
        private System.Windows.Forms.Button btn_resume;

    }
}
