namespace WinFormAnimation.Samples
{
    partial class Demo3
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
            this.btn_play = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_pause = new System.Windows.Forms.Button();
            this.btn_resume = new System.Windows.Forms.Button();
            this.p_color = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btn_play
            // 
            this.btn_play.Location = new System.Drawing.Point(36, 3);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(27, 24);
            this.btn_play.TabIndex = 5;
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
            this.btn_stop.TabIndex = 4;
            this.btn_stop.Text = "□";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.StopButton);
            // 
            // btn_pause
            // 
            this.btn_pause.Location = new System.Drawing.Point(3, 33);
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.Size = new System.Drawing.Size(27, 24);
            this.btn_pause.TabIndex = 6;
            this.btn_pause.Text = "| |";
            this.btn_pause.UseVisualStyleBackColor = true;
            this.btn_pause.Click += new System.EventHandler(this.PauseButton);
            // 
            // btn_resume
            // 
            this.btn_resume.Location = new System.Drawing.Point(36, 33);
            this.btn_resume.Name = "btn_resume";
            this.btn_resume.Size = new System.Drawing.Size(27, 24);
            this.btn_resume.TabIndex = 7;
            this.btn_resume.Text = ">";
            this.btn_resume.UseVisualStyleBackColor = true;
            this.btn_resume.Click += new System.EventHandler(this.ResumeButton);
            // 
            // p_color
            // 
            this.p_color.BackColor = System.Drawing.Color.Aqua;
            this.p_color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_color.Location = new System.Drawing.Point(70, 4);
            this.p_color.Name = "p_color";
            this.p_color.Size = new System.Drawing.Size(168, 53);
            this.p_color.TabIndex = 8;
            // 
            // Demo3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.p_color);
            this.Controls.Add(this.btn_play);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_pause);
            this.Controls.Add(this.btn_resume);
            this.DoubleBuffered = true;
            this.Name = "Demo3";
            this.Size = new System.Drawing.Size(241, 63);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_pause;
        private System.Windows.Forms.Button btn_resume;
        private System.Windows.Forms.Panel p_color;
    }
}
