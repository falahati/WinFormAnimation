// --------------------------------------------------------------------------------------------------------------------
// <copyright file="float3D.cs" company="Soroush Falahati (soroush@falahati.net)">
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
//   The 3D float class
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WinFormAnimation
{
    #region

    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;

    #endregion

    /// <summary>
    /// The 3D float class
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Reviewed. Suppression is OK here.")]
    // ReSharper disable once InconsistentNaming
    public class float3D : IConvertible
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="float3D"/> class.
        /// </summary>
        /// <param name="x">
        /// The X value.
        /// </param>
        /// <param name="y">
        /// The Y value.
        /// </param>
        /// <param name="z">
        /// The Z value.
        /// </param>
        public float3D(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the X value
        /// </summary>
        public float X { get; private set; }

        /// <summary>
        /// Gets the Y value
        /// </summary>
        public float Y { get; private set; }

        /// <summary>
        /// Gets the Z value
        /// </summary>
        public float Z { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The convert to Color method
        /// </summary>
        /// <param name="x">
        /// The float3D.
        /// </param>
        /// <returns>
        /// </returns>
        public static implicit operator Color(float3D x)
        {
            return Color.FromArgb((int)x.X, (int)x.Y, (int)x.Z);
        }

        /// <summary>
        /// The get type code.
        /// </summary>
        /// <returns>
        /// The <see cref="TypeCode"/>.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// This operation is not supported
        /// </exception>
        public TypeCode GetTypeCode()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Convert to the selected type
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// This operation is not supported
        /// </exception>
        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Convert to the selected type
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <returns>
        /// The <see cref="byte"/>.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// This operation is not supported
        /// </exception>
        public byte ToByte(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Convert to the selected type
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <returns>
        /// The <see cref="char"/>.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// This operation is not supported
        /// </exception>
        public char ToChar(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Convert to the selected type
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <returns>
        /// The <see cref="DateTime"/>.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// This operation is not supported
        /// </exception>
        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Convert to the selected type
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <returns>
        /// The <see cref="decimal"/>.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// This operation is not supported
        /// </exception>
        public decimal ToDecimal(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Convert to the selected type
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// This operation is not supported
        /// </exception>
        public double ToDouble(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Convert to the selected type
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <returns>
        /// The <see cref="short"/>.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// This operation is not supported
        /// </exception>
        public short ToInt16(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Convert to the selected type
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// This operation is not supported
        /// </exception>
        public int ToInt32(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Convert to the selected type
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <returns>
        /// The <see cref="long"/>.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// This operation is not supported
        /// </exception>
        public long ToInt64(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Convert to the selected type
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <returns>
        /// The <see cref="sbyte"/>.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// This operation is not supported
        /// </exception>
        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Convert to the selected type
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <returns>
        /// The <see cref="float"/>.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// This operation is not supported
        /// </exception>
        public float ToSingle(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Convert to the selected type
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// This operation is not supported
        /// </exception>
        public string ToString(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Convert to the selected type
        /// </summary>
        /// <param name="conversionType">
        /// The conversion type.
        /// </param>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// When type is not supported
        /// </exception>
        public object ToType(Type conversionType, IFormatProvider provider)
        {
            if (conversionType == typeof(Color))
            {
                return (Color)this;
            }

            throw new NotSupportedException();
        }

        /// <summary>
        /// Convert to the selected type
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <returns>
        /// The <see cref="ushort"/>.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// This operation is not supported
        /// </exception>
        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Convert to the selected type
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <returns>
        /// The <see cref="uint"/>.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// This operation is not supported
        /// </exception>
        public uint ToUInt32(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Convert to the selected type
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <returns>
        /// The <see cref="ulong"/>.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// This operation is not supported
        /// </exception>
        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}