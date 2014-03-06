// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Path2D.cs" company="Soroush Falahati (soroush@falahati.net)">
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
//   The 2D key frame/path class
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WinFormAnimation
{
    #region

    using System.Drawing;

    #endregion

    /// <summary>
    /// The 2D key frame/path class
    /// </summary>
    public class Path2D
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Path2D"/> class.
        /// </summary>
        /// <param name="startX">
        /// The starting value of X.
        /// </param>
        /// <param name="endX">
        /// The ending value of X.
        /// </param>
        /// <param name="startY">
        /// The starting value of Y.
        /// </param>
        /// <param name="endY">
        /// The ending value of y.
        /// </param>
        /// <param name="durationX">
        /// The duration of X changes.
        /// </param>
        /// <param name="durationY">
        /// The duration of Y changes.
        /// </param>
        /// <param name="delayX">
        /// The delay of X changes.
        /// </param>
        /// <param name="delayY">
        /// The delay of Y changes.
        /// </param>
        /// <param name="functionX">
        /// The animation function for X.
        /// </param>
        /// <param name="functionY">
        /// The animation function for Y.
        /// </param>
        public Path2D(
            float startX, 
            float endX, 
            float startY, 
            float endY, 
            float durationX, 
            float durationY, 
            float delayX = 0, 
            float delayY = 0, 
            Functions.Function functionX = null, 
            Functions.Function functionY = null)
            : this(
                new Path(startX, endX, durationX, delayX, functionX), 
                new Path(startY, endY, durationY, delayY, functionY))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Path2D"/> class.
        /// </summary>
        /// <param name="startX">
        /// The starting value of X.
        /// </param>
        /// <param name="endX">
        /// The ending value of X.
        /// </param>
        /// <param name="startY">
        /// The starting value of Y.
        /// </param>
        /// <param name="endY">
        /// The ending value of y.
        /// </param>
        /// <param name="duration">
        /// The duration of changes.
        /// </param>
        /// <param name="delay">
        /// The delay of changes.
        /// </param>
        /// <param name="function">
        /// The animation function.
        /// </param>
        // ReSharper disable once UnusedMember.Global
        public Path2D(
            float startX, 
            float endX, 
            float startY, 
            float endY, 
            float duration, 
            float delay = 0, 
            Functions.Function function = null)
            : this(new Path(startX, endX, duration, delay, function), new Path(startY, endY, duration, delay, function))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Path2D"/> class.
        /// </summary>
        /// <param name="start">
        /// The starting Size.
        /// </param>
        /// <param name="end">
        /// The ending Size.
        /// </param>
        /// <param name="duration">
        /// The duration of changes.
        /// </param>
        /// <param name="delay">
        /// The delay of changes.
        /// </param>
        /// <param name="function">
        /// The animation function.
        /// </param>
        // ReSharper disable once UnusedMember.Global
        public Path2D(Size start, Size end, float duration, float delay = 0, Functions.Function function = null)
            : this(
                new Path(start.Width, end.Width, duration, delay, function), 
                new Path(start.Height, end.Height, duration, delay, function))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Path2D"/> class.
        /// </summary>
        /// <param name="start">
        /// The starting Point/Location
        /// </param>
        /// <param name="end">
        /// The ending Point/Location
        /// </param>
        /// <param name="duration">
        /// The duration of changes.
        /// </param>
        /// <param name="delay">
        /// The delay of changes.
        /// </param>
        /// <param name="function">
        /// The animation function.
        /// </param>
        // ReSharper disable once UnusedMember.Global
        public Path2D(Point start, Point end, float duration, float delay = 0, Functions.Function function = null)
            : this(
                new Path(start.X, end.X, duration, delay, function), 
                new Path(start.Y, end.Y, duration, delay, function))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Path2D"/> class.
        /// </summary>
        /// <param name="x">
        /// The X path.
        /// </param>
        /// <param name="y">
        /// The Y path.
        /// </param>
        public Path2D(Path x, Path y)
        {
            this.HorizontalPath = x;
            this.VerticalPath = y;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the horizontal path.
        /// </summary>
        public Path HorizontalPath { get; private set; }

        /// <summary>
        /// Gets the vertical path.
        /// </summary>
        public Path VerticalPath { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The reverse.
        /// </summary>
        /// <returns>
        /// The <see cref="Path2D"/>.
        /// </returns>
        // ReSharper disable once UnusedMember.Global
        public Path2D Reverse()
        {
            return new Path2D(this.HorizontalPath.Reverse(), this.VerticalPath.Reverse());
        }

        #endregion
    }
}