// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Functions.cs" company="Soroush Falahati (soroush@falahati.net)">
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
//   The functions gallery for animation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WinFormAnimation
{
    /// <summary>
    /// The functions gallery for animation
    /// </summary>
    public static class Functions
    {
        #region Delegates

        /// <summary>
        /// The function.
        /// </summary>
        /// <param name="time">
        /// The time.
        /// </param>
        /// <param name="beginningValue">
        /// The beginning value.
        /// </param>
        /// <param name="changeInValue">
        /// The change in value.
        /// </param>
        /// <param name="duration">
        /// The duration.
        /// </param>
        /// <returns>
        /// A float value indicating current value of animation depending on other parameters
        /// </returns>
        public delegate float Function(float time, float beginningValue, float changeInValue, float duration);

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The cubic ease in animation function.
        /// </summary>
        /// <param name="t">
        /// The time.
        /// </param>
        /// <param name="b">
        /// The starting value.
        /// </param>
        /// <param name="c">
        /// The change in value.
        /// </param>
        /// <param name="d">
        /// The duration.
        /// </param>
        /// <returns>
        /// A float value indicating current value of animation depending on other parameters
        /// </returns>
        public static float CubicEaseIn(float t, float b, float c, float d)
        {
            t /= d;
            return (c * t * t * t) + b;
        }

        /// <summary>
        /// The cubic ease in out animation function.
        /// </summary>
        /// <param name="t">
        /// The time.
        /// </param>
        /// <param name="b">
        /// The starting value.
        /// </param>
        /// <param name="c">
        /// The change in value.
        /// </param>
        /// <param name="d">
        /// The duration.
        /// </param>
        /// <returns>
        /// A float value indicating current value of animation depending on other parameters
        /// </returns>
        public static float CubicEaseInOut(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1)
            {
                return c / 2 * t * t * (t + b);
            }

            t -= 2;
            return (c / 2 * (t * t * (t + 2))) + b;
        }

        /// <summary>
        /// The cubic ease out animation function.
        /// </summary>
        /// <param name="t">
        /// The time.
        /// </param>
        /// <param name="b">
        /// The starting value.
        /// </param>
        /// <param name="c">
        /// The change in value.
        /// </param>
        /// <param name="d">
        /// The duration.
        /// </param>
        /// <returns>
        /// A float value indicating current value of animation depending on other parameters
        /// </returns>
        public static float CubicEaseOut(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return (c * ((t * t * t) + 1)) + b;
        }

        /// <summary>
        /// The liner animation function.
        /// </summary>
        /// <param name="t">
        /// The time.
        /// </param>
        /// <param name="b">
        /// The starting value.
        /// </param>
        /// <param name="c">
        /// The change in value.
        /// </param>
        /// <param name="d">
        /// The duration.
        /// </param>
        /// <returns>
        /// A float value indicating current value of animation depending on other parameters
        /// </returns>
        public static float Liner(float t, float b, float c, float d)
        {
            return (c * t / d) + b;
        }

        #endregion
    }
}