// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Timer.cs" company="Soroush Falahati (soroush@falahati.net)">
//   This library is free software; you can redistribute it and/or
//   modify it under the terms of the GNU Lesser General Public
//   License as published by the Free Software Foundation; either
//   version 2.1 of the License, or (at your option) any later version.
//   
//   This library is distributed in the hope that it will be useful,
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//   Lesser General Public License for more details.
// </copyright>
// <summary>
//   The global timer class for all animator objects
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WinFormAnimation
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    #endregion

    /// <summary>
    /// The timer class, will execute your code in specific time frames
    /// </summary>
    public class Timer
    {
        #region Static Fields

        /// <summary>
        /// The time when this class first initialized
        /// </summary>
        private static readonly long StartTimeAsMs = DateTime.Now.Ticks;

        /// <summary>
        /// The list of all sub classes waiting for the timer tick
        /// </summary>
        private static readonly List<Timer> Subscribers = new List<Timer>();

        /// <summary>
        /// The thread which real timer works at
        /// </summary>
        private static Thread timerThread;

        #endregion

        #region Fields

        /// <summary>
        /// The callback delegate to run when a tick happens
        /// </summary>
        private readonly TickDelegate callback;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Timer"/> class.
        /// </summary>
        /// <param name="callback">
        /// The callback to execute at each tick
        /// </param>
        /// <param name="maxFps">
        /// The max tick per second
        /// </param>
        public Timer(TickDelegate callback, FpsLimiter maxFps = FpsLimiter.Fps30)
        {
            if (callback == null)
            {
                throw new ArgumentNullException("callback");
            }

            this.callback = callback;
            this.MaxFps = maxFps;
            if (timerThread != null)
                return;
            timerThread = new Thread(ThreadCycle) { IsBackground = true };
            timerThread.Start();
        }

        #endregion

        #region Delegates

        /// <summary>
        /// The tick delegate.
        /// </summary>
        /// <param name="millSinceBeginning">
        /// The mill since beginning.
        /// </param>
        public delegate void TickDelegate(int millSinceBeginning);

        #endregion

        #region Enums

        /// <summary>
        /// The fps limiter enumeration
        /// </summary>
        public enum FpsLimiter
        {
            /// <summary>
            /// 10 frames per second
            /// </summary>
            // ReSharper disable once UnusedMember.Global
            Fps10 = 10, 

            /// <summary>
            /// 20 frames per second
            /// </summary>
            // ReSharper disable once UnusedMember.Global
            Fps20 = 20, 

            /// <summary>
            /// 30 frames per second
            /// </summary>
            // ReSharper disable once UnusedMember.Global
            Fps30 = 30, 

            /// <summary>
            /// 60 frames per second
            /// </summary>
            // ReSharper disable once UnusedMember.Global
            Fps60 = 60, 

            /// <summary>
            /// 100 frames per second
            /// </summary>
            // ReSharper disable once UnusedMember.Global
            Fps100 = 100, 

            /// <summary>
            /// 200 frames per second
            /// </summary>
            // ReSharper disable once UnusedMember.Global
            Fps200 = 200, 

            /// <summary>
            /// The max frames possible
            /// </summary>
            // ReSharper disable once UnusedMember.Global
            Max = -1, 
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the last tick time.
        /// </summary>
        public long LastTick { get; private set; }

        /// <summary>
        /// Gets or sets the max fps.
        /// </summary>
        public FpsLimiter MaxFps { get; set; }

        /// <summary>
        /// Gets the start at time.
        /// </summary>
        public long StartAt { get; private set; }

        /// <summary>
        /// Gets the stop at time.
        /// </summary>
        public long StopAt { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The get time difference as milliseconds.
        /// </summary>
        /// <returns>
        /// The <see cref="long"/>.
        /// </returns>
        public static long GetTimeDifferenceAsMs()
        {
            return (DateTime.Now.Ticks - StartTimeAsMs) / 10000;
        }

        /// <summary>
        /// The timer thread main code
        /// </summary>
        public static void ThreadCycle()
        {
            while (true)
            {
                try
                {
                    bool hibernate;
                    lock (Subscribers)
                    {
                        hibernate = Subscribers.Count == 0;
                        if (!hibernate)
                        {
                            foreach (Timer t in Subscribers.ToList())
                            {
                                t.Tick();
                            }
                        }
                    }

                    Thread.Sleep(hibernate ? 50 : 1);
                }
                catch (Exception)
                {
                }
            }
            // ReSharper disable once FunctionNeverReturns
        }

        /// <summary>
        /// The reset clock method to reset StartAt variable
        /// </summary>
        public void ResetClock()
        {
            this.StartAt = GetTimeDifferenceAsMs();
        }

        /// <summary>
        /// The resume method to start timer again but with automatic calculated start at property.
        /// </summary>
        public void Resume()
        {
            lock (Subscribers)
                if (!Subscribers.Contains(this))
                {
                    this.StartAt += GetTimeDifferenceAsMs() - this.StopAt;
                    this.StopAt = 0;
                    Subscribers.Add(this);
                }
        }

        /// <summary>
        /// The start method to start timer generating new ticks.
        /// </summary>
        public void Start()
        {
            lock (Subscribers)
                if (!Subscribers.Contains(this))
                {
                    Subscribers.Add(this);
                    this.StartAt = GetTimeDifferenceAsMs();
                    this.StopAt = 0;
                }
        }

        /// <summary>
        /// The stop method to prevent timer from generate any new ticks.
        /// </summary>
        public void Stop()
        {
            lock (Subscribers)
                if (Subscribers.Contains(this))
                {
                    this.StopAt = GetTimeDifferenceAsMs();
                    Subscribers.Remove(this);
                }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The method which comes from main thread and we pass it here to the real delegate.
        /// </summary>
        private void Tick()
        {
            if ((1000 / (int)this.MaxFps) < (GetTimeDifferenceAsMs() - this.LastTick))
            {
                this.LastTick = GetTimeDifferenceAsMs();
                this.callback((int)(this.LastTick - this.StartAt));
            }
        }

        #endregion
    }
}