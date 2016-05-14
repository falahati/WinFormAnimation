using System;
using System.Windows.Forms;

namespace WinFormAnimation.Samples
{
    internal partial class Demo1 : UserControl
    {
        private readonly Animator _animator = new Animator();

        public Demo1()
        {
            InitializeComponent();
            _animator.Paths = new Path(0, 100, 5000).ToArray();
        }

        private void PlayButton(object sender, EventArgs e)
        {
            _animator.Play(lbl_res, Animator.KnownProperties.Text);
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