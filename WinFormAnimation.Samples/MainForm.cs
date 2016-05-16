using System;
using System.Windows.Forms;

namespace WinFormAnimation.Samples
{
    internal partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void FormShown(object sender, EventArgs e)
        {
            new Animator(new Path(0, 1, 400, 100)).Play(this, Animator.KnownProperties.Opacity);
        }
    }
}