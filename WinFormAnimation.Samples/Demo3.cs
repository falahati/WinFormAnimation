using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormAnimation.Samples
{
    public partial class Demo3 : UserControl
    {
        private readonly Animator3D ani = new Animator3D(Timer.FpsLimiter.Fps30);

        public Demo3()
        {
            InitializeComponent();
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            ani.Stop();
            ani.SetPaths(new Path3D(Color.Aqua, Color.FromArgb(255, 128, 0), 3000));
            ani.Play(p_color, Animator3D.KnownProperties.BackColor, new SafeInvoker(() =>
            {
                ani.SetPaths(new Path3D(Color.FromArgb(255, 128, 0), Color.Aqua, 1000, 1000));
                ani.Play(p_color, Animator3D.KnownProperties.BackColor);
            }));
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