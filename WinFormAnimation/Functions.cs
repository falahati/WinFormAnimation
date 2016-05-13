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
                return c/2*t*t*t + b;
            }

            t -= 2;
            return (c/2*(t*t*t + 2)) + b;
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
        public static float CircularEaseInOut(float t, float b, float c, float d)
        {
            t /= d/2;
            if (t < 1)
            {
                return (float) (-c/2*(Math.Sqrt(1 - t*t) - 1) + b);
            }
            t -= 2;
            return (float) (c/2*(Math.Sqrt(1 - t*t) + 1) + b);
        }


        public static float QuadraticEaseIn(float t, float b, float c, float d)
        {
            t /= d;
            return c*t*t + b;
        }


        public static float QuadraticEaseOut(float t, float b, float c, float d)
        {
            t /= d;
            return -c*t*(t - 2) + b;
        }


        public static float QuadraticEaseInOut(float t, float b, float c, float d)
        {
            t /= d/2;
            if (t < 1) return c/2*t*t + b;
            t--;
            return -c/2*(t*(t - 2) - 1) + b;
        }


        public static float QuarticEaseIn(float t, float b, float c, float d)
        {
            t /= d;
            return c*t*t*t*t + b;
        }


        public static float QuarticEaseOut(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return -c*(t*t*t*t - 1) + b;
        }


        public static float QuarticEaseInOut(float t, float b, float c, float d)
        {
            t /= d/2;
            if (t < 1) return c/2*t*t*t*t + b;
            t -= 2;
            return -c/2*(t*t*t*t - 2) + b;
        }


        public static float QuinticEaseIn(float t, float b, float c, float d)
        {
            t /= d;
            return c*t*t*t*t*t + b;
        }


        public static float QuinticEaseOut(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return c*(t*t*t*t*t + 1) + b;
        }


        public static float SinusoidalEaseIn(float t, float b, float c, float d)
        {
            return (float) (-c*Math.Cos(t/d*(Math.PI/2)) + c + b);
        }


        public static float SinusoidalEaseOut(float t, float b, float c, float d)
        {
            return (float) (c*Math.Sin(t/d*(Math.PI/2)) + b);
        }


        public static float SinusoidalEaseInOut(float t, float b, float c, float d)
        {
            return (float) (-c/2*(Math.Cos(Math.PI*t/d) - 1) + b);
        }


        public static float ExponentialEaseIn(float t, float b, float c, float d)
        {
            return (float) (c*Math.Pow(2, 10*(t/d - 1)) + b);
        }

        public static float ExponentialEaseOut(float t, float b, float c, float d)
        {
            return (float) (c*(-Math.Pow(2, -10*t/d) + 1) + b);
        }


        public static float ExponentialEaseInOut(float t, float b, float c, float d)
        {
            t /= d/2;
            if (t < 1)
            {
                return (float) (c/2*Math.Pow(2, 10*(t - 1)) + b);
            }
            t--;
            return (float) (c/2*(-Math.Pow(2, -10*t) + 2) + b);
        }


        public static float CircularEaseIn(float t, float b, float c, float d)
        {
            t /= d;
            return (float) (-c*(Math.Sqrt(1 - t*t) - 1) + b);
        }

        #endregion

        public static float CircularEaseOut(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return (float) (c*Math.Sqrt(1 - t*t) + b);
        }


        public static float QuinticEaseInOut(float t, float b, float c, float d)
        {
            t /= d/2;
            if (t < 1) return c/2*t*t*t*t*t + b;
            t -= 2;
            return c/2*(t*t*t*t*t + 2) + b;
        }
    }
}