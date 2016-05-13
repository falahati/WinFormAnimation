using System;
using System.Windows.Forms;

namespace WinFormAnimation.Samples
{
    public partial class Demo2 : UserControl
    {
        private readonly Animator2D ani = new Animator2D(Timer.FpsLimiter.Fps100);

        public Demo2()
        {
            InitializeComponent();
            ani.SetPaths(new Path2D(70, 320, 5, 115, 2000, 2000, 0, 0, Functions.CubicEaseOut, Functions.CubicEaseIn),
                new Path2D(320, 70, 115, 5, 2000, 1700, 300, 600, Functions.Liner, Functions.ExponentialEaseInOut));
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            ani.Play(pb_image, Animator2D.KnownProperties.Location);
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            ani.Stop();
        }

        private void btn_resume_Click(object sender, EventArgs e)
        {
            ani.Resume();
        }

        private void btn_pause_Click(object sender, EventArgs e)
        {
            ani.Pause();
        }
    }
}