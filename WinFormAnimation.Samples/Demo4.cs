using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace WinFormAnimation.Samples
{
    internal partial class Demo4 : UserControl
    {
        private readonly List<Animator> _animators = new List<Animator>();
        private readonly Process _currentProcess = Process.GetCurrentProcess();
        private readonly Stopwatch _stopWatch = new Stopwatch();
        private int _cpuUsage;
        private int _endedAnimations;
        private int _frameHits;

        public Demo4()
        {
            InitializeComponent();
        }

        private void RunButton(object sender, EventArgs e)
        {
            Enabled = false;
            _animators.Clear();
            _frameHits = 0;
            _endedAnimations = 0;
            var rnd = new Random();
            for (var i = 0; i < nud_num.Value; i++)
            {
                _animators.Add(new Animator((FPSLimiterKnownValues) nud_fps.Value)
                {
                    Paths = new[] {new Path(rnd.Next(1000), rnd.Next(1000), (ulong) nud_dur.Value)}
                });
            }
            _cpuUsage = (int) _currentProcess.TotalProcessorTime.TotalMilliseconds;
            _stopWatch.Reset();
            _stopWatch.Start();
            _animators.ForEach(a => { a.Play(new SafeInvoker<float>(Hit, this), new SafeInvoker(End, this)); });
        }

        private void Hit(float value)
        {
            _frameHits += 1;
        }

        private void End()
        {
            _endedAnimations += 1;
            if (_endedAnimations == nud_num.Value)
            {
                _stopWatch.Stop();
                lbl_fps.Text =
                    $"{Round((decimal) (_frameHits/((_stopWatch.ElapsedMilliseconds/1000f)*(double) nud_num.Value)))} fps";
                lbl_time.Text = $"{_stopWatch.ElapsedMilliseconds} ms";
                lbl_cpu.Text =
                    $"{Round((decimal) ((_currentProcess.TotalProcessorTime.TotalMilliseconds - _cpuUsage)/_stopWatch.ElapsedMilliseconds)*(decimal) (100f/Environment.ProcessorCount))} % - {Environment.ProcessorCount} Cores";
                Enabled = true;
            }
        }


        private float Round(decimal n)
        {
            return (float) Math.Round(n, 2);
        }
    }
}