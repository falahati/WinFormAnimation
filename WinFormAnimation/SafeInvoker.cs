// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SafeInvoker.cs" company="Soroush Falahati (soroush@falahati.net)">
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
//   The safe invoker class for passing delegates and execute them in correct thread.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WinFormAnimation
{
    #region

    using System;
    using System.Reflection;
    using System.Threading;

    #endregion

    /// <summary>
    /// The safe invoker class for passing delegates and execute them in correct thread.
    /// </summary>
    public class SafeInvoker
    {
        #region Fields

        /// <summary>
        /// The underlying delegate.
        /// </summary>
        private readonly Delegate underlyingDelegate;

        /// <summary>
        /// The invoke method info
        /// </summary>
        private MethodInfo invokeMethod;

        /// <summary>
        /// The invoke required property info
        /// </summary>
        private PropertyInfo invokeRequiredProperty;

        /// <summary>
        /// The reference object.
        /// </summary>
        private object refObject;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SafeInvoker"/> class.
        /// </summary>
        /// <param name="del">
        /// The void delegate.
        /// </param>
        /// <param name="o">
        /// The responsible object.
        /// </param>
        public SafeInvoker(Callback del, object o = null)
        {
            this.underlyingDelegate = del;
            if (o != null)
            {
                this.SetObject(o);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SafeInvoker"/> class.
        /// </summary>
        /// <param name="del">
        /// The float setter delegate.
        /// </param>
        /// <param name="o">
        /// The responsible object.
        /// </param>
        public SafeInvoker(Setter del, object o = null)
        {
            this.underlyingDelegate = del;
            if (o != null)
            {
                this.SetObject(o);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SafeInvoker"/> class.
        /// </summary>
        /// <param name="del">
        /// The float2D setter delegate.
        /// </param>
        /// <param name="o">
        /// The responsible object.
        /// </param>
        public SafeInvoker(Setter2D del, object o = null)
        {
            this.underlyingDelegate = del;
            if (o != null)
            {
                this.SetObject(o);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SafeInvoker"/> class.
        /// </summary>
        /// <param name="del">
        /// The float3D setter delegate.
        /// </param>
        /// <param name="o">
        /// The responsible object.
        /// </param>
        public SafeInvoker(Setter3D del, object o = null)
        {
            this.underlyingDelegate = del;
            if (o != null)
            {
                this.SetObject(o);
            }
        }

        #endregion

        #region Delegates

        /// <summary>
        /// The void delegate
        /// </summary>
        public delegate void Callback();

        /// <summary>
        /// The 1D setter delegate
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public delegate void Setter(float value);

        /// <summary>
        /// The 2D setter delegate
        /// </summary>
        /// <param name="value">
        /// The 2D value.
        /// </param>
        public delegate void Setter2D(float2D value);

        /// <summary>
        /// The 3D setter delegate
        /// </summary>
        /// <param name="value">
        /// The 3D value.
        /// </param>
        public delegate void Setter3D(float3D value);

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The set object method. Used for setting reference object of the delegate.
        /// </summary>
        /// <param name="obj">
        /// The object
        /// </param>
        public void SetObject(object obj)
        {
            this.invokeRequiredProperty = obj.GetType()
                .GetProperty("InvokeRequired", BindingFlags.Instance | BindingFlags.Public);
            this.invokeMethod = obj.GetType()
                .GetMethod(
                    "Invoke", 
                    BindingFlags.Instance | BindingFlags.Public, 
                    Type.DefaultBinder, 
                    new[] { typeof(Delegate) }, 
                    null);
            if (this.invokeRequiredProperty != null && this.invokeMethod != null)
            {
                this.refObject = obj;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoke the delegate
        /// </summary>
        /// <param name="value">
        /// The float value
        /// </param>
        public void Invoke(float value)
        {
            this.Invoke((object)value);
        }

        /// <summary>
        /// Invoke the delegate
        /// </summary>
        /// <param name="value">
        /// The float2D value
        /// </param>
        public void Invoke(float2D value)
        {
            this.Invoke((object)value);
        }

        /// <summary>
        /// Invoke the delegate
        /// </summary>
        /// <param name="value">
        /// The float 3D value
        /// </param>
        public void Invoke(float3D value)
        {
            this.Invoke((object)value);
        }

        /// <summary>
        /// Invoke the delegate
        /// </summary>
        public void Invoke()
        {
            this.Invoke((object)null);
        }

        /// <summary>
        /// Invoke the delegate
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        private void Invoke(object value)
        {
            try
            {
                ThreadPool.QueueUserWorkItem(
                    state =>
                        {
                            if (this.refObject != null && (bool)this.invokeRequiredProperty.GetValue(this.refObject, null))
                            {
                                this.invokeMethod.Invoke(
                                    this.refObject, 
                                    new object[] { new Action(() => this.underlyingDelegate.DynamicInvoke(value != null ? new[] { value } : null)) });
                                return;
                            }

                            this.underlyingDelegate.DynamicInvoke(value != null ? new[] { value } : null);
                        });
            }
            catch (Exception)
            {
            }
        }

        #endregion
    }
}