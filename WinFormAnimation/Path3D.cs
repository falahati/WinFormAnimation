// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Path3D.cs" company="Soroush Falahati (soroush@falahati.net)">
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
//   The 3D key frame/path class
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WinFormAnimation
{
    #region

    using System.Drawing;

    #endregion

    /// <summary>
    /// The 3D key frame/path class
    /// </summary>
    public class Path3D
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Path3D"/> class.
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
        /// The ending value of Y.
        /// </param>
        /// <param name="startZ">
        /// The starting value of Z.
        /// </param>
        /// <param name="endZ">
        /// The ending value of Z.
        /// </param>
        /// <param name="durationX">
        /// The duration of X changes.
        /// </param>
        /// <param name="durationY">
        /// The duration of Y changes.
        /// </param>
        /// <param name="durationZ">
        /// The duration of Z changes.
        /// </param>
        /// <param name="delayX">
        /// The delay of X changes.
        /// </param>
        /// <param name="delayY">
        /// The delay of Y changes.
        /// </param>
        /// <param name="delayZ">
        /// The delay of Z changes.
        /// </param>
        /// <param name="functionX">
        /// The animation function of X.
        /// </param>
        /// <param name="functionY">
        /// The animation function of Y.
        /// </param>
        /// <param name="functionZ">
        /// The animation function of Z.
        /// </param>
        // ReSharper disable once UnusedMember.Global
        public Path3D(
            float startX, 
            float endX, 
            float startY, 
            float endY, 
            float startZ, 
            float endZ, 
            float durationX, 
            float durationY, 
            float durationZ, 
            float delayX = 0, 
            float delayY = 0, 
            float delayZ = 0, 
            Functions.Function functionX = null, 
            Functions.Function functionY = null, 
            Functions.Function functionZ = null)
            : this(
                new Path(startX, endX, durationX, delayX, functionX), 
                new Path(startY, endY, durationY, delayY, functionY), 
                new Path(startZ, endZ, durationZ, delayZ, functionZ))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Path3D"/> class.
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
        /// The ending value of Y.
        /// </param>
        /// <param name="startZ">
        /// The starting value of Z.
        /// </param>
        /// <param name="endZ">
        /// The ending value of Z.
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
        public Path3D(
            float startX, 
            float endX, 
            float startY, 
            float endY, 
            float startZ, 
            float endZ, 
            float duration, 
            float delay = 0, 
            Functions.Function function = null)
            : this(
                new Path(startX, endX, duration, delay, function), 
                new Path(startY, endY, duration, delay, function), 
                new Path(startZ, endZ, duration, delay, function))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Path3D"/> class.
        /// </summary>
        /// <param name="start">
        /// The start color
        /// </param>
        /// <param name="end">
        /// The end color
        /// </param>
        /// <param name="duration">
        /// The duration of changes
        /// </param>
        /// <param name="delay">
        /// The delay of changes.
        /// </param>
        /// <param name="function">
        /// The animation function.
        /// </param>
        public Path3D(Color start, Color end, float duration, float delay = 0, Functions.Function function = null)
            : this(
                new Path(start.R, end.R, duration, delay, function), 
                new Path(start.G, end.G, duration, delay, function), 
                new Path(start.B, end.B, duration, delay, function))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Path3D"/> class.
        /// </summary>
        /// <param name="x">
        /// The X path
        /// </param>
        /// <param name="y">
        /// The Y path
        /// </param>
        /// <param name="z">
        /// The Z path
        /// </param>
        public Path3D(Path x, Path y, Path z)
        {
            this.XAxis = x;
            this.YAxis = y;
            this.ZAxis = z;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the x axis.
        /// </summary>
        public Path XAxis { get; private set; }

        /// <summary>
        /// Gets the y axis.
        /// </summary>
        public Path YAxis { get; private set; }

        /// <summary>
        /// Gets the z axis.
        /// </summary>
        public Path ZAxis { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The reverse.
        /// </summary>
        /// <returns>
        /// The <see cref="Path3D"/>.
        /// </returns>
        // ReSharper disable once UnusedMember.Global
        public Path3D Reverse()
        {
            return new Path3D(this.XAxis.Reverse(), this.YAxis.Reverse(), this.ZAxis.Reverse());
        }

        #endregion
    }
}