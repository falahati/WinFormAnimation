// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Animator3D.cs" company="Soroush Falahati (soroush@falahati.net)">
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
//   The 3D animator class
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
    /// The 3D animator class
    /// </summary>
    public class Animator3D
    {
        #region Fields

        /// <summary>
        /// The key frames / paths
        /// </summary>
        private readonly List<Path3D> paths = new List<Path3D>();

        /// <summary>
        /// The X value.
        /// </summary>
        private float? x;

        /// <summary>
        /// The Y value.
        /// </summary>
        private float? y;

        /// <summary>
        /// The Z value.
        /// </summary>
        private float? z;

        /// <summary>
        /// Is animation ended?
        /// </summary>
        private bool ended;

        /// <summary>
        /// The ending invoker.
        /// </summary>
        private SafeInvoker endInvoker;

        /// <summary>
        /// The frame tick invoker.
        /// </summary>
        private SafeInvoker frameInvoker;

        /// <summary>
        /// The underlying object for setting property.
        /// </summary>
        private object underlyingObject;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Animator3D"/> class.
        /// </summary>
        /// <param name="maxFps">
        /// The max fps.
        /// </param>
        public Animator3D(Timer.FpsLimiter maxFps = Timer.FpsLimiter.Fps30)
            : this(new Path3D[] { }, maxFps)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Animator3D"/> class.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <param name="maxFps">
        /// The max fps.
        /// </param>
        // ReSharper disable once UnusedMember.Global
        public Animator3D(Path3D path, Timer.FpsLimiter maxFps = Timer.FpsLimiter.Fps30)
            : this(new[] { path }, maxFps)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Animator3D"/> class.
        /// </summary>
        /// <param name="paths">
        /// The paths.
        /// </param>
        /// <param name="maxFps">
        /// The max fps.
        /// </param>
        public Animator3D(Path3D[] paths, Timer.FpsLimiter maxFps = Timer.FpsLimiter.Fps30)
        {
            this.XAxisAnimator = new Animator(maxFps);
            this.YAxisAnimator = new Animator(maxFps);
            this.ZAxisAnimator = new Animator(maxFps);
            this.SetPaths(paths);
        }

        #endregion

        #region Enums

        /// <summary>
        /// The known properties to set
        /// </summary>
        public enum KnownProperties
        {
            /// <summary>
            /// The back color.
            /// </summary>
            BackColor, 

            /// <summary>
            /// The fore color.
            /// </summary>
            // ReSharper disable once UnusedMember.Global
            ForeColor, 
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the active path.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public Path3D ActivePath
        {
            get
            {
                return new Path3D(
                    this.XAxisAnimator.ActivePath, 
                    this.YAxisAnimator.ActivePath, 
                    this.ZAxisAnimator.ActivePath);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether repeat the animation
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public bool Repeat
        {
            get
            {
                return this.XAxisAnimator.Repeat && this.YAxisAnimator.Repeat && this.ZAxisAnimator.Repeat;
            }

            set
            {
                this.XAxisAnimator.Repeat = this.YAxisAnimator.Repeat = this.ZAxisAnimator.Repeat = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether reverse repeating the animation
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public bool ReverseRepeat
        {
            get
            {
                return this.XAxisAnimator.ReverseRepeat && this.YAxisAnimator.ReverseRepeat
                       && this.ZAxisAnimator.ReverseRepeat;
            }

            set
            {
                this.XAxisAnimator.ReverseRepeat =
                    this.YAxisAnimator.ReverseRepeat = this.ZAxisAnimator.ReverseRepeat = value;
            }
        }

        /// <summary>
        /// Gets the status.
        /// </summary>
        public Animator.Status CurrentStatus
        {
            get
            {
                if (this.XAxisAnimator.CurrentStatus == Animator.Status.Stopped
                    && this.YAxisAnimator.CurrentStatus == Animator.Status.Stopped
                    && this.ZAxisAnimator.CurrentStatus == Animator.Status.Stopped)
                {
                    return Animator.Status.Stopped;
                }

                if (this.XAxisAnimator.CurrentStatus == Animator.Status.Paused
                    && this.YAxisAnimator.CurrentStatus == Animator.Status.Paused
                    && this.ZAxisAnimator.CurrentStatus == Animator.Status.Paused)
                {
                    return Animator.Status.Paused;
                }

                if (this.XAxisAnimator.CurrentStatus == Animator.Status.OnHold
                    && this.YAxisAnimator.CurrentStatus == Animator.Status.OnHold
                    && this.ZAxisAnimator.CurrentStatus == Animator.Status.OnHold)
                {
                    return Animator.Status.OnHold;
                }

                return Animator.Status.Playing;
            }
        }

        /// <summary>
        /// Gets the X axis animator.
        /// </summary>
        public Animator XAxisAnimator { get; private set; }

        /// <summary>
        /// Gets the Y axis animator.
        /// </summary>
        public Animator YAxisAnimator { get; private set; }

        /// <summary>
        /// Gets the Z axis animator.
        /// </summary>
        public Animator ZAxisAnimator { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The pause method
        /// </summary>
        public void Pause()
        {
            if (this.CurrentStatus == Animator.Status.OnHold || this.CurrentStatus == Animator.Status.Playing)
            {
                this.XAxisAnimator.Pause();
                this.YAxisAnimator.Pause();
                this.ZAxisAnimator.Pause();
            }
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
                    (float3D value) => prop.SetValue(this.underlyingObject, Convert.ChangeType(value, prop.PropertyType), null), 
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
                    (float3D value) => prop.SetValue(this.underlyingObject, Convert.ChangeType(value, prop.PropertyType), null), 
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
            this.ended = false;
            this.XAxisAnimator.Play(
                new SafeInvoker(
                    value =>
                        {
                            this.x = value;
                            this.InvokeSetter();
                        }), 
                new SafeInvoker(this.InvokeFinisher));
            this.YAxisAnimator.Play(
                new SafeInvoker(
                    value =>
                        {
                            this.y = value;
                            this.InvokeSetter();
                        }), 
                new SafeInvoker(this.InvokeFinisher));
            this.ZAxisAnimator.Play(
                new SafeInvoker(
                    value =>
                        {
                            this.z = value;
                            this.InvokeSetter();
                        }), 
                new SafeInvoker(this.InvokeFinisher));
        }

        /// <summary>
        /// The resume method
        /// </summary>
        public void Resume()
        {
            if (this.CurrentStatus == Animator.Status.Paused)
            {
                this.XAxisAnimator.Resume();
                this.YAxisAnimator.Resume();
                this.ZAxisAnimator.Resume();
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
        public void SetPaths(params Path3D[] newPaths)
        {
            if (this.CurrentStatus == Animator.Status.Stopped)
            {
                this.paths.Clear();
                this.paths.AddRange(newPaths);
                List<Path> pathsX = new List<Path>();
                List<Path> pathsY = new List<Path>();
                List<Path> pathsZ = new List<Path>();
                foreach (Path3D p in newPaths)
                {
                    pathsX.Add(p.XAxis);
                    pathsY.Add(p.YAxis);
                    pathsZ.Add(p.ZAxis);
                }

                this.XAxisAnimator.SetPaths(pathsX.ToArray());
                this.YAxisAnimator.SetPaths(pathsY.ToArray());
                this.ZAxisAnimator.SetPaths(pathsZ.ToArray());
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
            this.XAxisAnimator.Stop();
            this.YAxisAnimator.Stop();
            this.ZAxisAnimator.Stop();
            this.x = this.y = null;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The invoke finish callback
        /// </summary>
        private void InvokeFinisher()
        {
            if (this.endInvoker != null && !this.ended)
            {
                lock (this.endInvoker)
                    if (this.CurrentStatus == Animator.Status.Stopped && (this.ended = true))
                    {
                        this.endInvoker.Invoke();
                    }
            }
        }

        /// <summary>
        /// The invoke frame callback
        /// </summary>
        private void InvokeSetter()
        {
            if (this.x != null && this.y != null && this.z != null)
            {
                this.frameInvoker.Invoke(new float3D(this.x.Value, this.y.Value, this.z.Value));
            }
        }

        #endregion
    }
}