using System;
using System.Windows.Forms;

namespace WinFormAnimation.Samples
{
    internal partial class Demo2 : UserControl
    {
        private readonly Animator2D _animator = new Animator2D();

        public Demo2()
        {
            InitializeComponent();
            _animator.Paths = new Path2D(
                new Path(70, 320, 2000, AnimationFunctions.CubicEaseOut),
                new Path(5, 100, 2000, AnimationFunctions.CubicEaseIn))
                .ContinueTo(new Path2D(
                    new Path(320, 70, 2000, 300, AnimationFunctions.ExponentialEaseInOut),
                    new Path(100, 5, 1700, 600, AnimationFunctions.Liner)));
        }

        private void PlayButton(object sender, EventArgs e)
        {
            _animator.Play(pb_image, Animator2D.KnownProperties.Location);
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

        private void RepeatChecked(object sender, EventArgs e)
        {
            _animator.Repeat = cb_repeat.Checked;
            cb_reverse.Enabled = cb_repeat.Checked;
        }

        private void ReverseChecked(object sender, EventArgs e)
        {
            _animator.ReverseRepeat = cb_reverse.Checked;
        }
    }
}