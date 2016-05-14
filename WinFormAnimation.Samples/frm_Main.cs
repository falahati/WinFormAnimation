using System;
using System.Windows.Forms;

namespace WinFormAnimation.Samples
{
    public partial class frm_Main : Form
    {
        private readonly Animator _opacityAnimator = new Animator(new Path(0, 1, 400, 100));

        public frm_Main()
        {
            InitializeComponent();
        }

        private void FormShown(object sender, EventArgs e)
        {
            _opacityAnimator.Play(this, Animator.KnownProperties.Opacity);
        }
    }
}