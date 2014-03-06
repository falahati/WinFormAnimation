// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Animator2D.cs" company="Soroush Falahati (soroush@falahati.net)">
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
//   The 2D animator class
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
    /// The 2D animator class
    /// </summary>
    public class Animator2D
    {
        #region Fields

        /// <summary>
        /// The key frames / paths
        /// </summary>
        private readonly List<Path2D> paths = new List<Path2D>();

        /// <summary>
        /// The X value.
        /// </summary>
        private float? x;

        /// <summary>
        /// The Y value.
        /// </summary>
        private float? y;

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
        /// Initializes a new instance of the <see cref="Animator2D"/> class.
        /// </summary>
        /// <param name="maxFps">
        /// The max fps.
        /// </param>
        public Animator2D(Timer.FpsLimiter maxFps = Timer.FpsLimiter.Fps30)
            : this(new Path2D[] { }, maxFps)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Animator2D"/> class.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <param name="maxFps">
        /// The max fps.
        /// </param>
        // ReSharper disable once UnusedMember.Global
        public Animator2D(Path2D path, Timer.FpsLimiter maxFps = Timer.FpsLimiter.Fps30)
            : this(new[] { path }, maxFps)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Animator2D"/> class.
        /// </summary>
        /// <param name="paths">
        /// The paths.
        /// </param>
        /// <param name="maxFps">
        /// The max fps.
        /// </param>
        public Animator2D(Path2D[] paths, Timer.FpsLimiter maxFps = Timer.FpsLimiter.Fps30)
        {
            this.HorizontalAnimator = new Animator(maxFps);
            this.VerticalAnimator = new Animator(maxFps);
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
            /// The size.
            /// </summary>
            // ReSharper disable once UnusedMember.Global
            Size, 

            /// <summary>
            /// The location.
            /// </summary>
            Location, 
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the active path.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public Path2D ActivePath
        {
            get
            {
                return new Path2D(this.HorizontalAnimator.ActivePath, this.VerticalAnimator.ActivePath);
            }
        }

        /// <summary>
        /// Gets the horizontal animator.
        /// </summary>
        public Animator HorizontalAnimator { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether repeat the animation
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public bool Repeat
        {
            get
            {
                return this.HorizontalAnimator.Repeat && this.VerticalAnimator.Repeat;
            }

            set
            {
                this.HorizontalAnimator.Repeat = this.VerticalAnimator.Repeat = value;
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
                return this.HorizontalAnimator.ReverseRepeat && this.VerticalAnimator.ReverseRepeat;
            }

            set
            {
                this.HorizontalAnimator.ReverseRepeat = this.VerticalAnimator.ReverseRepeat = value;
            }
        }

        /// <summary>
        /// Gets the status.
        /// </summary>
        public Animator.Status CurrentStatus
        {
            get
            {
                if (this.HorizontalAnimator.CurrentStatus == Animator.Status.Stopped
                    && this.VerticalAnimator.CurrentStatus == Animator.Status.Stopped)
                {
                    return Animator.Status.Stopped;
                }

                if (this.HorizontalAnimator.CurrentStatus == Animator.Status.Paused
                    && this.VerticalAnimator.CurrentStatus == Animator.Status.Paused)
                {
                    return Animator.Status.Paused;
                }

                if (this.HorizontalAnimator.CurrentStatus == Animator.Status.OnHold
                    && this.VerticalAnimator.CurrentStatus == Animator.Status.OnHold)
                {
                    return Animator.Status.OnHold;
                }

                return Animator.Status.Playing;
            }
        }

        /// <summary>
        /// Gets the vertical animator.
        /// </summary>
        public Animator VerticalAnimator { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The pause method
        /// </summary>
        public void Pause()
        {
            if (this.CurrentStatus == Animator.Status.OnHold || this.CurrentStatus == Animator.Status.Playing)
            {
                this.HorizontalAnimator.Pause();
                this.VerticalAnimator.Pause();
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
                    (float2D value) => prop.SetValue(this.underlyingObject, Convert.ChangeType(value, prop.PropertyType), null), 
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
                    (float2D value) => prop.SetValue(this.underlyingObject, Convert.ChangeType(value, prop.PropertyType), null), 
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
            this.HorizontalAnimator.Play(
                new SafeInvoker(
                    value =>
                        {
                            this.x = value;
                            this.InvokeSetter();
                        }), 
                new SafeInvoker(this.InvokeFinisher));
            this.VerticalAnimator.Play(
                new SafeInvoker(
                    value =>
                        {
                            this.y = value;
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
                this.HorizontalAnimator.Resume();
                this.VerticalAnimator.Resume();
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
        public void SetPaths(params Path2D[] newPaths)
        {
            if (this.CurrentStatus == Animator.Status.Stopped)
            {
                this.paths.Clear();
                this.paths.AddRange(newPaths);
                List<Path> pathsH = new List<Path>();
                List<Path> pathsV = new List<Path>();
                foreach (Path2D p in newPaths)
                {
                    pathsH.Add(p.HorizontalPath);
                    pathsV.Add(p.VerticalPath);
                }

                this.HorizontalAnimator.SetPaths(pathsH.ToArray());
                this.VerticalAnimator.SetPaths(pathsV.ToArray());
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
            this.HorizontalAnimator.Stop();
            this.VerticalAnimator.Stop();
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
            if (this.x != null && this.y != null)
            {
                this.frameInvoker.Invoke(new float2D(this.x.Value, this.y.Value));
            }
        }

        #endregion
    }
}