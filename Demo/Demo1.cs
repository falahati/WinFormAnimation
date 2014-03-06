using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormAnimation;

namespace Demo
{
    public partial class Demo1 : UserControl
    {
        Animator ani = new Animator();
        public Demo1()
        {
            InitializeComponent();
            ani.SetPaths(new Path(0, 100, 2000));
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            ani.Play(lbl_res, Animator.KnownProperties.Text);
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
