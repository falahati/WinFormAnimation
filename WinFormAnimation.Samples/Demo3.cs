using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormAnimation.Samples
{
    internal partial class Demo3 : UserControl
    {
        private readonly Animator3D _animator = new Animator3D();

        public Demo3()
        {
            InitializeComponent();
        }

        private void PlayButton(object sender, EventArgs e)
        {
            _animator.Stop();
            _animator.Paths =
                new Path3D(Color.Aqua.ToFloat3D(), Color.FromArgb(255, 128, 0).ToFloat3D(), 3000).ToArray();
            _animator.Play(p_color, Animator3D.KnownProperties.BackColor, new SafeInvoker(() =>
            {
                _animator.Paths = _animator.Paths.Last().Reverse().ToArray();
                _animator.Play(p_color, Animator3D.KnownProperties.BackColor);
            }));
        }

        private void StopButton(object sender, EventArgs e)
        {
            _animator.Stop();
        }

        private void ResumeButton(object sender, EventArgs e)
        {
            _animator.Resume();
        }

        private void PauseButton(object sender, EventArgs e)
        {
            _animator.Pause();
        }
    }
}