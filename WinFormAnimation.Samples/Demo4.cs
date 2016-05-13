using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace WinFormAnimation.Samples
{
    public partial class Demo4 : UserControl
    {
        private readonly List<Animator> aniList = new List<Animator>();
        private readonly Process cp = Process.GetCurrentProcess();
        private int cpu;
        private int ends;
        private int hits;
        private readonly Stopwatch sw = new Stopwatch();

        public Demo4()
        {
            InitializeComponent();
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            Enabled = false;
            aniList.Clear();
            hits = 0;
            ends = 0;
            var rnd = new Random();
            for (var i = 0; i < nud_num.Value; i++)
            {
                aniList.Add(new Animator((Timer.FpsLimiter) nud_fps.Value));
                aniList.Last().SetPaths(new Path(rnd.Next(1000), rnd.Next(1000), (float) nud_dur.Value));
            }
            cpu = (int) cp.TotalProcessorTime.TotalMilliseconds;
            sw.Reset();
            sw.Start();
            aniList.ForEach((Animator a) => { a.Play(new SafeInvoker(Hit, this), new SafeInvoker(End, this)); });
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
                lbl_fps.Text = Round(hits/((sw.ElapsedMilliseconds/1000)*nud_num.Value)) + " fps";
                lbl_time.Text = sw.ElapsedMilliseconds + " ms";
                lbl_cpu.Text = Round((decimal) ((cp.TotalProcessorTime.TotalMilliseconds - cpu)/sw.ElapsedMilliseconds)*
                                     (100/Environment.ProcessorCount))
                               + " % - " + Environment.ProcessorCount + " Cores";
                Enabled = true;
            }
        }

        private float Round(decimal n)
        {
            return (float) Math.Round(n, 2);
        }
    }
}