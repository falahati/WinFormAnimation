namespace WinFormAnimation.Samples
{
    partial class Demo2
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
            this.pb_image = new System.Windows.Forms.PictureBox();
            this.cb_repeat = new System.Windows.Forms.CheckBox();
            this.cb_reverse = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_image)).BeginInit();
            this.SuspendLayout();
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
            // pb_image
            // 
            this.pb_image.Image = global::WinFormAnimation.Samples.Properties.Resources.star_32;
            this.pb_image.Location = new System.Drawing.Point(69, 3);
            this.pb_image.Name = "pb_image";
            this.pb_image.Size = new System.Drawing.Size(32, 32);
            this.pb_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pb_image.TabIndex = 5;
            this.pb_image.TabStop = false;
            // 
            // cb_repeat
            // 
            this.cb_repeat.AutoSize = true;
            this.cb_repeat.Location = new System.Drawing.Point(3, 63);
            this.cb_repeat.Name = "cb_repeat";
            this.cb_repeat.Size = new System.Drawing.Size(61, 17);
            this.cb_repeat.TabIndex = 6;
            this.cb_repeat.Text = "Repeat";
            this.cb_repeat.UseVisualStyleBackColor = true;
            this.cb_repeat.CheckedChanged += new System.EventHandler(this.RepeatChecked);
            // 
            // cb_reverse
            // 
            this.cb_reverse.AutoSize = true;
            this.cb_reverse.Enabled = false;
            this.cb_reverse.Location = new System.Drawing.Point(3, 86);
            this.cb_reverse.Name = "cb_reverse";
            this.cb_reverse.Size = new System.Drawing.Size(66, 17);
            this.cb_reverse.TabIndex = 7;
            this.cb_reverse.Text = "Reverse";
            this.cb_reverse.UseVisualStyleBackColor = true;
            this.cb_reverse.CheckedChanged += new System.EventHandler(this.ReverseChecked);
            // 
            // Demo2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cb_reverse);
            this.Controls.Add(this.cb_repeat);
            this.Controls.Add(this.pb_image);
            this.Controls.Add(this.btn_play);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_pause);
            this.Controls.Add(this.btn_resume);
            this.DoubleBuffered = true;
            this.Name = "Demo2";
            this.Size = new System.Drawing.Size(362, 159);
            ((System.ComponentModel.ISupportInitialize)(this.pb_image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_pause;
        private System.Windows.Forms.Button btn_resume;
        private System.Windows.Forms.PictureBox pb_image;
        private System.Windows.Forms.CheckBox cb_repeat;
        private System.Windows.Forms.CheckBox cb_reverse;
    }
}
