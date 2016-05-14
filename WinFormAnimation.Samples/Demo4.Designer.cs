namespace WinFormAnimation.Samples
{
    partial class Demo4
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
            this.components = new System.ComponentModel.Container();
            this.nud_fps = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nud_num = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nud_dur = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_fps = new System.Windows.Forms.Label();
            this.lbl_cpu = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_run = new System.Windows.Forms.Button();
            this.lbl_time = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cpu_timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nud_fps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_dur)).BeginInit();
            this.SuspendLayout();
            // 
            // nud_fps
            // 
            this.nud_fps.Location = new System.Drawing.Point(69, 3);
            this.nud_fps.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_fps.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_fps.Name = "nud_fps";
            this.nud_fps.Size = new System.Drawing.Size(120, 20);
            this.nud_fps.TabIndex = 1;
            this.nud_fps.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "FPS Limiter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Animations";
            // 
            // nud_num
            // 
            this.nud_num.Location = new System.Drawing.Point(69, 29);
            this.nud_num.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nud_num.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_num.Name = "nud_num";
            this.nud_num.Size = new System.Drawing.Size(120, 20);
            this.nud_num.TabIndex = 3;
            this.nud_num.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Duration";
            // 
            // nud_dur
            // 
            this.nud_dur.Location = new System.Drawing.Point(69, 55);
            this.nud_dur.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nud_dur.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_dur.Name = "nud_dur";
            this.nud_dur.Size = new System.Drawing.Size(120, 20);
            this.nud_dur.TabIndex = 5;
            this.nud_dur.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(279, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Average FPS:";
            // 
            // lbl_fps
            // 
            this.lbl_fps.AutoSize = true;
            this.lbl_fps.Location = new System.Drawing.Point(358, 5);
            this.lbl_fps.Name = "lbl_fps";
            this.lbl_fps.Size = new System.Drawing.Size(10, 13);
            this.lbl_fps.TabIndex = 7;
            this.lbl_fps.Text = "-";
            // 
            // lbl_cpu
            // 
            this.lbl_cpu.AutoSize = true;
            this.lbl_cpu.Location = new System.Drawing.Point(358, 31);
            this.lbl_cpu.Name = "lbl_cpu";
            this.lbl_cpu.Size = new System.Drawing.Size(10, 13);
            this.lbl_cpu.TabIndex = 9;
            this.lbl_cpu.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(279, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Average CPU:";
            // 
            // btn_run
            // 
            this.btn_run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_run.Location = new System.Drawing.Point(464, 51);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(160, 24);
            this.btn_run.TabIndex = 10;
            this.btn_run.Text = "RUN";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.RunButton);
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.Location = new System.Drawing.Point(358, 57);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(10, 13);
            this.lbl_time.TabIndex = 12;
            this.lbl_time.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(279, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Time:";
            // 
            // Demo4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_time);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.lbl_cpu);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbl_fps);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nud_dur);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nud_num);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nud_fps);
            this.Name = "Demo4";
            this.Size = new System.Drawing.Size(627, 89);
            ((System.ComponentModel.ISupportInitialize)(this.nud_fps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_dur)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.NumericUpDown nud_fps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nud_num;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nud_dur;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_fps;
        private System.Windows.Forms.Label lbl_cpu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer cpu_timer;
    }
}
