using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormAnimation;
using System.Diagnostics;
namespace Demo
{
    public partial class Demo4 : UserControl
    {
        List<Animator> aniList = new List<Animator>();
        Process cp = Process.GetCurrentProcess();
        Stopwatch sw = new Stopwatch();
        int hits = 0;
        int ends = 0;
        int cpu = 0;
        
        public Demo4()
        {
            InitializeComponent();
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            aniList.Clear();
            hits = 0;
            ends = 0;
            Random rnd = new Random();
            for (int i = 0; i < nud_num.Value; i++)
            {
                aniList.Add(new Animator((WinFormAnimation.Timer.FpsLimiter)nud_fps.Value));
                aniList.Last().SetPaths(new Path(rnd.Next(1000), rnd.Next(1000), (float)nud_dur.Value));
            }
            cpu = (int)cp.TotalProcessorTime.TotalMilliseconds;
            sw.Reset();
            sw.Start();
            aniList.ForEach((Animator a) =>
            {
                a.Play(new SafeInvoker(Hit, this), new SafeInvoker(End, this));
            });
        }

        private void Hit(float value)   
        {
            hits += 1;
        }

        private void End()
        {
            ends += 1;
            if (ends == nud_num.Value)
            {
                sw.Stop();
                lbl_fps.Text = Round(hits / ((sw.ElapsedMilliseconds / 1000) * nud_num.Value)).ToString() + " fps";
                lbl_time.Text = sw.ElapsedMilliseconds.ToString() + " ms";
                lbl_cpu.Text = Round((decimal)((cp.TotalProcessorTime.TotalMilliseconds - cpu) / sw.ElapsedMilliseconds) * (100 / Environment.ProcessorCount))
                    + " % - " + Environment.ProcessorCount.ToString() + " Cores";
                this.Enabled = true;
            }
        }

        private float Round(decimal n)
        {
            return (float)Math.Round(n, 2);
        }
    }
}
