// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Path.cs" company="Soroush Falahati (soroush@falahati.net)">
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
//   The 1D key frame/path class
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WinFormAnimation
{
    #region

    using System;

    #endregion

    /// <summary>
    /// The path.
    /// </summary>
    public class Path
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Path"/> class.
        /// </summary>
        /// <param name="start">
        /// The starting value.
        /// </param>
        /// <param name="end">
        /// The ending value.
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
        /// <exception cref="ArgumentOutOfRangeException">
        /// Duration is less than zero
        /// </exception>
        public Path(float start, float end, float duration, float delay = 0, Functions.Function function = null)
        {
            this.Start = start;
            this.End = end;
            this.Change = this.End - this.Start;
            if (this.Duration < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.Duration = duration;
            this.Function = function;
            this.Delay = delay;
            if (this.Function == null)
            {
                this.Function = Functions.Liner;
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the start - end difference.
        /// </summary>
        public float Change { get; private set; }

        /// <summary>
        /// Gets the delay of changes.
        /// </summary>
        public float Delay { get; private set; }

        /// <summary>
        /// Gets the duration of changes.
        /// </summary>
        public float Duration { get; private set; }

        /// <summary>
        /// Gets the ending value.
        /// </summary>
        public float End { get; private set; }

        /// <summary>
        /// Gets the animation function.
        /// </summary>
        public Functions.Function Function { get; private set; }

        /// <summary>
        /// Gets the starting value.
        /// </summary>
        public float Start { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The reverse method.
        /// </summary>
        /// <returns>
        /// The <see cref="Path"/> which is the reverse of the current <see cref="Path"/>.
        /// </returns>
        public Path Reverse()
        {
            return new Path(this.End, this.Start, this.Duration, this.Delay, this.Function);
        }

        #endregion
    }
}