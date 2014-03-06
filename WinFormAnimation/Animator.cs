// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Animator.cs" company="Soroush Falahati (soroush@falahati.net)">
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
//   The animator class
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WinFormAnimation
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;

    #endregion

    /// <summary>
    /// The animator class
    /// </summary>
    public class Animator
    {
        #region Fields

        /// <summary>
        /// The key frames / paths
        /// </summary>
        private readonly List<Path> paths = new List<Path>();

        /// <summary>
        /// The temporary variable for key frames / paths
        /// </summary>
        private readonly List<Path> tempPaths = new List<Path>();

        /// <summary>
        /// The timer object.
        /// </summary>
        private readonly Timer timer;

        /// <summary>
        /// The ending invoker.
        /// </summary>
        private SafeInvoker endInvoker;

        /// <summary>
        /// The frame tick invoker.
        /// </summary>
        private SafeInvoker frameInvoker;

        /// <summary>
        /// The are we in hold?.
        /// </summary>
        private bool holdEnded;

        /// <summary>
        /// The underlying object for setting property.
        /// </summary>
        private object underlyingObject;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Animator"/> class.
        /// </summary>
        /// <param name="maxFps">
        /// The max fps.
        /// </param>
        public Animator(Timer.FpsLimiter maxFps = Timer.FpsLimiter.Fps30)
            : this(new Path[] { }, maxFps)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Animator"/> class.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <param name="maxFps">
        /// The max fps.
        /// </param>
        // ReSharper disable once UnusedMember.Global
        public Animator(Path path, Timer.FpsLimiter maxFps = Timer.FpsLimiter.Fps30)
            : this(new[] { path }, maxFps)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Animator"/> class.
        /// </summary>
        /// <param name="paths">
        /// The paths.
        /// </param>
        /// <param name="maxFps">
        /// The max fps.
        /// </param>
        public Animator(Path[] paths, Timer.FpsLimiter maxFps = Timer.FpsLimiter.Fps30)
        {
            this.CurrentStatus = Status.Stopped;
            this.SetPaths(paths);
            this.timer = new Timer(this.Elapsed, maxFps);
        }

        #endregion

        #region Enums

        /// <summary>
        /// The known properties to set
        /// </summary>
        public enum KnownProperties
        {
            /// <summary>
            /// The value.
            /// </summary>
            // ReSharper disable once UnusedMember.Global
            Value, 

            /// <summary>
            /// The text.
            /// </summary>
            Text, 

            /// <summary>
            /// The caption.
            /// </summary>
            // ReSharper disable once UnusedMember.Global
            Caption, 

            /// <summary>
            /// The back color.
            /// </summary>
            // ReSharper disable once UnusedMember.Global
            BackColor, 

            /// <summary>
            /// The fore color.
            /// </summary>
            // ReSharper disable once UnusedMember.Global
            ForeColor, 

            /// <summary>
            /// The opacity.
            /// </summary>
            // ReSharper disable once UnusedMember.Global
            Opacity, 
        }

        /// <summary>
        /// The possible statuses
        /// </summary>
        public enum Status
        {
            /// <summary>
            /// The stopped.
            /// </summary>
            Stopped, 

            /// <summary>
            /// The playing.
            /// </summary>
            Playing, 

            /// <summary>
            /// The on hold.
            /// </summary>
            OnHold, 

            /// <summary>
            /// The paused.
            /// </summary>
            Paused, 
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the active path.
        /// </summary>
        public Path ActivePath { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether repeat the animation
        /// </summary>
        public bool Repeat { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether reverse repeating the animation
        /// </summary>
        public bool ReverseRepeat { get; set; }

        /// <summary>
        /// Gets the status.
        /// </summary>
        public Status CurrentStatus { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The pause method
        /// </summary>
        public void Pause()
        {
            if (this.CurrentStatus != Status.OnHold && this.CurrentStatus != Status.Playing)
                return;
            this.timer.Stop();
            this.CurrentStatus = Status.Paused;
        }

        /// <summary>
        /// The play method
        /// </summary>
        /// <param name="o">
        /// The object
        /// </param>
        /// <param name="property">
        /// The property of object
        /// </param>
        /// <param name="endCallback">
        /// The end callback
        /// </param>
        /// <typeparam name="T">
        /// Any object
        /// </typeparam>
        public void Play<T>(T o, KnownProperties property, SafeInvoker endCallback = null)
        {
            this.Play(o, property.ToString(), endCallback);
        }

        /// <summary>
        /// The play method
        /// </summary>
        /// <param name="o">
        /// The object
        /// </param>
        /// <param name="propertyName">
        /// The property name
        /// </param>
        /// <param name="endCallback">
        /// The end callback
        /// </param>
        /// <typeparam name="T">
        /// Any object
        /// </typeparam>
        public void Play<T>(T o, string propertyName, SafeInvoker endCallback = null)
        {
            this.underlyingObject = o;
            PropertyInfo prop = this.underlyingObject.GetType()
                .GetProperty(
                    propertyName,
                    BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty);
            if (prop == null) return;
            
            this.Play(
                new SafeInvoker(
                    (float value) => prop.SetValue(this.underlyingObject, Convert.ChangeType(value, prop.PropertyType), null), 
                    this.underlyingObject), 
                endCallback);
        }

        /// <summary>
        /// The play method
        /// </summary>
        /// <param name="o">
        /// The object.
        /// </param>
        /// <param name="propertySetter">
        /// The property setter expression
        /// </param>
        /// <param name="endCallback">
        /// The end callback
        /// </param>
        /// <typeparam name="T">
        /// Any object
        /// </typeparam>
        // ReSharper disable once UnusedMember.Global
        public void Play<T>(T o, Expression<Func<T, object>> propertySetter, SafeInvoker endCallback = null)
        {
            if (propertySetter == null)
                return;
            this.underlyingObject = o;
            MemberExpression expr;
            if (propertySetter.Body is MemberExpression)
            {
                expr = (MemberExpression)propertySetter.Body;
            }
            else
            {
                expr = (MemberExpression)((UnaryExpression)propertySetter.Body).Operand;
            }

            PropertyInfo prop = (PropertyInfo)expr.Member;
            this.Play(
                new SafeInvoker(
                    (float value) => prop.SetValue(this.underlyingObject, Convert.ChangeType(value, prop.PropertyType), null), 
                    this.underlyingObject), 
                endCallback);
        }

        /// <summary>
        /// The play method
        /// </summary>
        /// <param name="frameCallback">
        /// The frame callback.
        /// </param>
        /// <param name="endCallback">
        /// The end callback.
        /// </param>
        public void Play(SafeInvoker frameCallback, SafeInvoker endCallback = null)
        {
            this.Stop();
            this.frameInvoker = frameCallback;
            this.endInvoker = endCallback;
            this.timer.ResetClock();
            this.CurrentStatus = Status.Playing;
            lock (this.tempPaths) this.tempPaths.AddRange(this.paths);
            this.timer.Start();
        }

        /// <summary>
        /// The resume method
        /// </summary>
        public void Resume()
        {
            if (this.CurrentStatus == Status.Paused)
            {
                this.timer.Resume();
            }
        }

        /// <summary>
        /// The set new paths.
        /// </summary>
        /// <param name="newPaths">
        /// The new paths.
        /// </param>
        /// <exception cref="NotSupportedException">
        /// Animation is running
        /// </exception>
        public void SetPaths(params Path[] newPaths)
        {
            if (this.CurrentStatus == Status.Stopped)
            {
                this.paths.Clear();
                this.paths.AddRange(newPaths);
            }
            else
            {
                throw new NotSupportedException("Animation is running.");
            }
        }

        /// <summary>
        /// The stop method
        /// </summary>
        public void Stop()
        {
            this.timer.Stop();
            lock (this.tempPaths) this.tempPaths.Clear();
            this.ActivePath = null;
            this.CurrentStatus = Status.Stopped;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The tick method.
        /// </summary>
        /// <param name="millSinceBeginning">
        /// The milliseconds since beginning.
        /// </param>
        private void Elapsed(int millSinceBeginning)
        {
            lock (this.tempPaths)
            {
                if (this.tempPaths != null && this.ActivePath == null && this.tempPaths.Count > 0)
                {
                    while (this.ActivePath == null)
                    {
                        this.ActivePath = this.tempPaths[0];
                        this.tempPaths.RemoveAt(0);
                    }
                }

                if (this.ActivePath != null)
                {
                    if (!this.holdEnded)
                    {
                        if (this.ActivePath.Delay > 0)
                        {
                            if (millSinceBeginning > this.ActivePath.Delay)
                            {
                                this.holdEnded = true;
                                this.timer.ResetClock();
                                millSinceBeginning = 0;
                            }
                            else
                            {
                                this.CurrentStatus = Status.OnHold;
                            }
                        }
                        else
                        {
                            this.holdEnded = true;
                        }
                    }

                    if (this.holdEnded)
                    {
                        if (millSinceBeginning <= this.ActivePath.Duration)
                        {
                            this.CurrentStatus = Status.Playing;
                            float value = this.ActivePath.Function(
                                millSinceBeginning, 
                                this.ActivePath.Start, 
                                this.ActivePath.Change, 
                                this.ActivePath.Duration);
                            this.frameInvoker.Invoke(value);
                        }
                        else
                        {
                            this.holdEnded = false;
                            this.timer.ResetClock();
                            float end = this.ActivePath.End;
                            this.ActivePath = null;
                            this.frameInvoker.Invoke(end);
                        }
                    }
                }
                else if (this.Repeat)
                {
                    lock (this.tempPaths)
                    {
                        this.tempPaths.AddRange(this.paths);
                        if (this.ReverseRepeat)
                        {
                            this.tempPaths.Reverse();
                            for (int i = 0; i < this.tempPaths.Count; i++)
                            {
                                this.tempPaths[i] = this.tempPaths[i].Reverse();
                            }
                        }
                    }
                }
                else
                {
                    this.Stop();
                    if (this.endInvoker != null)
                    {
                        this.endInvoker.Invoke();
                    }
                }
            }
        }

        #endregion
    }
}