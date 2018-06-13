// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExtendedBitConverter.cs">
//   Copyright (c) 2013 Alexander Logger. All rights reserved.
//   Copyright (c) 2018 Nivloc Enterprises Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
#if !NETCF
using System.Runtime.CompilerServices;
#endif

namespace BigMath.Utils
	{
	/// <summary>
	///     Bit converter methods which support explicit endian.
	/// </summary>
	public static class ExtendedBitConverter
		{
		/// <summary>
		///     Indicates the byte order ("endianness") in which data is stored in this computer architecture.
		/// </summary>
		public static readonly bool IsLittleEndian = BitConverter.IsLittleEndian;

		#region Int16

#if NETCF
		/// <summary>
		///     Converts <see cref="short" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static byte[] ToBytes (this short value)
			{
			return ToBytes (value, (bool?)null);
			}

		/// <summary>
		///     Converts <see cref="short" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="asLittleEndian">Convert to little endian.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static byte[] ToBytes (this short value, bool? asLittleEndian)
#else
	/// <summary>
	///     Converts <see cref="short" /> to array of bytes.
	/// </summary>
	/// <param name="value">Value.</param>
	/// <param name="asLittleEndian">Convert to little endian.</param>
	/// <returns>Array of bytes.</returns>
#if !NETCF
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static byte[] ToBytes(this short value, bool? asLittleEndian = null)
#endif
			{
			var buffer = new byte[2];
			value.ToBytes (buffer, 0, asLittleEndian);
			return buffer;
			}

#if NETCF
		/// <summary>
		///     Converts <see cref="short" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">Buffer at least 2 bytes.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static void ToBytes (this short value, byte[] buffer)
			{
			ToBytes (value, buffer, 0, null);
			}
		/// <summary>
		///     Converts <see cref="short" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">Buffer at least 2 bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static void ToBytes (this short value, byte[] buffer, int offset)
			{
			ToBytes (value, buffer, offset, null);
			}
		/// <summary>
		///     Converts <see cref="short" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">Buffer at least 2 bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
		/// <param name="asLittleEndian">Convert to little endian.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static void ToBytes (this short value, byte[] buffer, int offset, bool? asLittleEndian)
#else
		/// <summary>
		///     Converts <see cref="short" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">Buffer at least 2 bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
		/// <param name="asLittleEndian">Convert to little endian.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static void ToBytes (this short value, byte[] buffer, int offset = 0, bool? asLittleEndian = null)
#endif
			{
			if (buffer == null)
				throw new ArgumentNullException ("buffer");

			if (asLittleEndian.HasValue ? asLittleEndian.Value : IsLittleEndian)
				{
				buffer[offset] = (byte)value;
				buffer[offset + 1] = (byte)(value >> 8);
				}
			else
				{
				buffer[offset] = (byte)(value >> 8);
				buffer[offset + 1] = (byte)(value);
				}
			}

#if NETCF
		/// <summary>
		///     Converts array of bytes to <see cref="short" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <returns><see cref="short" /> value.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static short ToInt16 (this byte[] bytes)
			{
			return ToInt16 (bytes, 0, null);
			}
		/// <summary>
		///     Converts array of bytes to <see cref="short" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <returns><see cref="short" /> value.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static short ToInt16 (this byte[] bytes, int offset)
			{
			return ToInt16 (bytes, offset, null);
			}
		/// <summary>
		///     Converts array of bytes to <see cref="short" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <returns><see cref="short" /> value.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static short ToInt16 (this byte[] bytes, int offset, bool? asLittleEndian)
#else
		/// <summary>
		///     Converts array of bytes to <see cref="short" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <returns><see cref="short" /> value.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static short ToInt16 (this byte[] bytes, int offset = 0, bool? asLittleEndian = null)
#endif
			{
			if (bytes == null)
				throw new ArgumentNullException ("bytes");
			if (bytes.Length == 0)
				return 0;
			if (bytes.Length <= offset)
				throw new InvalidOperationException ("Array length must be greater than offset.");
			bool ale = GetIsLittleEndian (asLittleEndian);
			EnsureLength (ref bytes, 2, offset, ale);

			return (short)(ale ? bytes[offset] | bytes[offset + 1] << 8 : bytes[offset] << 8 | bytes[offset + 1]);
			}

		#endregion

		#region UInt16

#if NETCF
		/// <summary>
		///     Converts <see cref="ushort" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static byte[] ToBytes (this ushort value)
			{
			return ToBytes (value, (bool?)null);
			}
		/// <summary>
		///     Converts <see cref="ushort" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="asLittleEndian">Convert to little endian.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static byte[] ToBytes (this ushort value, bool? asLittleEndian)
#else
		/// <summary>
		///     Converts <see cref="ushort" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="asLittleEndian">Convert to little endian.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static byte[] ToBytes (this ushort value, bool? asLittleEndian = null)
#endif
			{
			return unchecked((short)value).ToBytes (asLittleEndian);
			}

#if NETCF
		/// <summary>
		///     Converts <see cref="ushort" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">Buffer at least 2 bytes.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static void ToBytes (this ushort value, byte[] buffer)
			{
			ToBytes (value, buffer, 0, null);
			}
		/// <summary>
		///     Converts <see cref="ushort" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">Buffer at least 2 bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static void ToBytes (this ushort value, byte[] buffer, int offset)
			{
			ToBytes (value, buffer, offset, null);
			}
		/// <summary>
		///     Converts <see cref="ushort" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">Buffer at least 2 bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
		/// <param name="asLittleEndian">Convert to little endian.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static void ToBytes (this ushort value, byte[] buffer, int offset, bool? asLittleEndian)
#else
		/// <summary>
		///     Converts <see cref="ushort" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">Buffer at least 2 bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
		/// <param name="asLittleEndian">Convert to little endian.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static void ToBytes (this ushort value, byte[] buffer, int offset = 0, bool? asLittleEndian = null)
#endif
			{
			unchecked((short)value).ToBytes (buffer, offset, asLittleEndian);
			}

#if NETCF
		/// <summary>
		///     Converts array of bytes to <see cref="ushort" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <returns><see cref="ushort" /> value.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static ushort ToUInt16 (this byte[] bytes)
			{
			return ToUInt16 (bytes, 0, null);
			}
		/// <summary>
		///     Converts array of bytes to <see cref="ushort" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <returns><see cref="ushort" /> value.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static ushort ToUInt16 (this byte[] bytes, int offset)
			{
			return ToUInt16 (bytes, offset, null);
			}
		/// <summary>
		///     Converts array of bytes to <see cref="ushort" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <returns><see cref="ushort" /> value.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static ushort ToUInt16 (this byte[] bytes, int offset, bool? asLittleEndian)
#else
		/// <summary>
		///     Converts array of bytes to <see cref="ushort" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <returns><see cref="ushort" /> value.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static ushort ToUInt16 (this byte[] bytes, int offset = 0, bool? asLittleEndian = null)
#endif
			{
			return (ushort)bytes.ToInt16 (offset, asLittleEndian);
			}

		#endregion

		#region Int32

#if NETCF
		/// <summary>
		///     Converts <see cref="int" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static byte[] ToBytes (this int value)
			{
			return ToBytes (value, (bool?)null);
			}
		/// <summary>
		///     Converts <see cref="int" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="asLittleEndian">Convert to little endian.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static byte[] ToBytes (this int value, bool? asLittleEndian)
#else
		/// <summary>
		///     Converts <see cref="int" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="asLittleEndian">Convert to little endian.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static byte[] ToBytes (this int value, bool? asLittleEndian = null)
#endif
			{
			var buffer = new byte[4];
			value.ToBytes (buffer, 0, asLittleEndian);
			return buffer;
			}

#if NETCF
		/// <summary>
		///     Converts <see cref="int" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">Buffer at least 4 bytes.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static void ToBytes (this int value, byte[] buffer)
			{
			ToBytes (value, buffer, 0, null);
			}
		/// <summary>
		///     Converts <see cref="int" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">Buffer at least 4 bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static void ToBytes (this int value, byte[] buffer, int offset)
			{
			ToBytes (value, buffer, offset, null);
			}
		/// <summary>
		///     Converts <see cref="int" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">Buffer at least 4 bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
		/// <param name="asLittleEndian">Convert to little endian.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static void ToBytes (this int value, byte[] buffer, int offset, bool? asLittleEndian)
#else
		/// <summary>
		///     Converts <see cref="int" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">Buffer at least 4 bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
		/// <param name="asLittleEndian">Convert to little endian.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static void ToBytes (this int value, byte[] buffer, int offset = 0, bool? asLittleEndian = null)
#endif
			{
			if (buffer == null)
				throw new ArgumentNullException ("buffer");

			if (asLittleEndian.HasValue ? asLittleEndian.Value : IsLittleEndian)
				{
				buffer[offset] = (byte)value;
				buffer[offset + 1] = (byte)(value >> 8);
				buffer[offset + 2] = (byte)(value >> 16);
				buffer[offset + 3] = (byte)(value >> 24);
				}
			else
				{
				buffer[offset] = (byte)(value >> 24);
				buffer[offset + 1] = (byte)(value >> 16);
				buffer[offset + 2] = (byte)(value >> 8);
				buffer[offset + 3] = (byte)value;
				}
			}

#if NETCF
		/// <summary>
		///     Converts array of bytes to <see cref="int" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <returns><see cref="int" /> value.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static int ToInt32 (this byte[] bytes)
			{
			return ToInt32 (bytes, 0, null);
			}
		/// <summary>
		///     Converts array of bytes to <see cref="int" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <returns><see cref="int" /> value.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static int ToInt32 (this byte[] bytes, int offset)
			{
			return ToInt32 (bytes, offset, null);
			}
		/// <summary>
		///     Converts array of bytes to <see cref="int" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <returns><see cref="int" /> value.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static int ToInt32 (this byte[] bytes, int offset, bool? asLittleEndian)
#else
		/// <summary>
		///     Converts array of bytes to <see cref="int" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <returns><see cref="int" /> value.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static int ToInt32 (this byte[] bytes, int offset = 0, bool? asLittleEndian = null)
#endif
			{
			if (bytes == null)
				throw new ArgumentNullException ("bytes");
			if (bytes.Length == 0)
				return 0;
			if (bytes.Length <= offset)
				throw new InvalidOperationException ("Array length must be greater than offset.");
			bool ale = GetIsLittleEndian (asLittleEndian);
			EnsureLength (ref bytes, 4, offset, ale);

			return (ale)
						? bytes[offset] | bytes[offset + 1] << 8 | bytes[offset + 2] << 16 | bytes[offset + 3] << 24
						: bytes[offset] << 24 | bytes[offset + 1] << 16 | bytes[offset + 2] << 8 | bytes[offset + 3];
			}

		#endregion

		private static void EnsureLength (ref byte[] bytes, int minLength, int offset, bool ale)
			{
			int bytesLength = bytes.Length - offset;
			if (bytesLength < minLength)
				{
				var b = new byte[minLength];
				Buffer.BlockCopy (bytes, offset, b, ale ? 0 : minLength - bytesLength, bytesLength);
				bytes = b;
				}
			}

		private static bool GetIsLittleEndian (bool? asLittleEndian)
			{
			return asLittleEndian.HasValue ? asLittleEndian.Value : IsLittleEndian;
			}

		#region UInt32

#if NETCF
		/// <summary>
		///     Converts <see cref="uint" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static byte[] ToBytes (this uint value)
			{
			return ToBytes (value, (bool?)null);
			}
		/// <summary>
		///     Converts <see cref="uint" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="asLittleEndian">Convert to little endian.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static byte[] ToBytes (this uint value, bool? asLittleEndian)
#else
		/// <summary>
		///     Converts <see cref="uint" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="asLittleEndian">Convert to little endian.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static byte[] ToBytes (this uint value, bool? asLittleEndian = null)
#endif
			{
			return unchecked((int)value).ToBytes (asLittleEndian);
			}

#if NETCF
		/// <summary>
		///     Converts <see cref="uint" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">Buffer at least 4 bytes.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static void ToBytes (this uint value, byte[] buffer)
			{
			ToBytes (value, buffer, 0, null);
			}
		/// <summary>
		///     Converts <see cref="uint" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">Buffer at least 4 bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static void ToBytes (this uint value, byte[] buffer, int offset)
			{
			ToBytes (value, buffer, offset, null);
			}
		/// <summary>
		///     Converts <see cref="uint" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">Buffer at least 4 bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
		/// <param name="asLittleEndian">Convert to little endian.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static void ToBytes (this uint value, byte[] buffer, int offset, bool? asLittleEndian)
#else
		/// <summary>
		///     Converts <see cref="uint" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">Buffer at least 4 bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
		/// <param name="asLittleEndian">Convert to little endian.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static void ToBytes (this uint value, byte[] buffer, int offset = 0, bool? asLittleEndian = null)
#endif
			{
			unchecked((int)value).ToBytes (buffer, offset, asLittleEndian);
			}

#if NETCF
		/// <summary>
		///     Converts array of bytes to <see cref="uint" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <returns><see cref="uint" /> value.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static uint ToUInt32 (this byte[] bytes)
			{
			return ToUInt32 (bytes, 0, null);
			}
		/// <summary>
		///     Converts array of bytes to <see cref="uint" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <returns><see cref="uint" /> value.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static uint ToUInt32 (this byte[] bytes, int offset)
			{
			return ToUInt32 (bytes, offset, null);
			}
		/// <summary>
		///     Converts array of bytes to <see cref="uint" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <returns><see cref="uint" /> value.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static uint ToUInt32 (this byte[] bytes, int offset, bool? asLittleEndian)
#else
		/// <summary>
		///     Converts array of bytes to <see cref="uint" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <returns><see cref="uint" /> value.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static uint ToUInt32 (this byte[] bytes, int offset = 0, bool? asLittleEndian = null)
#endif
			{
			return (uint)bytes.ToInt32 (offset, asLittleEndian);
			}

		#endregion

		#region Int64

#if NETCF
		/// <summary>
		///     Converts <see cref="long" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static byte[] ToBytes (this long value)
			{
			return ToBytes (value, (bool?)null);
			}
		/// <summary>
		///     Converts <see cref="long" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="asLittleEndian">Convert to little endian.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static byte[] ToBytes (this long value, bool? asLittleEndian)
#else
		/// <summary>
		///     Converts <see cref="long" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="asLittleEndian">Convert to little endian.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static byte[] ToBytes (this long value, bool? asLittleEndian = null)
#endif
			{
			var buffer = new byte[8];
			value.ToBytes (buffer, 0, asLittleEndian);
			return buffer;
			}

#if NETCF
		/// <summary>
		///     Converts <see cref="long" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">Buffer at least 8 bytes.</param>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static void ToBytes (this long value, byte[] buffer)
			{
			ToBytes (value, buffer, 0, null);
			}
		/// <summary>
		///     Converts <see cref="long" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">Buffer at least 8 bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static void ToBytes (this long value, byte[] buffer, int offset)
			{
			ToBytes (value, buffer, offset, null);
			}
		/// <summary>
		///     Converts <see cref="long" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">Buffer at least 8 bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
		/// <param name="asLittleEndian">Convert to little endian.</param>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static void ToBytes (this long value, byte[] buffer, int offset, bool? asLittleEndian)
#else
		/// <summary>
		///     Converts <see cref="long" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">Buffer at least 8 bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
		/// <param name="asLittleEndian">Convert to little endian.</param>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static void ToBytes (this long value, byte[] buffer, int offset = 0, bool? asLittleEndian = null)
#endif
			{
			if (asLittleEndian.HasValue ? asLittleEndian.Value : IsLittleEndian)
				{
				buffer[offset] = (byte)value;
				buffer[offset + 1] = (byte)(value >> 8);
				buffer[offset + 2] = (byte)(value >> 16);
				buffer[offset + 3] = (byte)(value >> 24);
				buffer[offset + 4] = (byte)(value >> 32);
				buffer[offset + 5] = (byte)(value >> 40);
				buffer[offset + 6] = (byte)(value >> 48);
				buffer[offset + 7] = (byte)(value >> 56);
				}
			else
				{
				buffer[offset] = (byte)(value >> 56);
				buffer[offset + 1] = (byte)(value >> 48);
				buffer[offset + 2] = (byte)(value >> 40);
				buffer[offset + 3] = (byte)(value >> 32);
				buffer[offset + 4] = (byte)(value >> 24);
				buffer[offset + 5] = (byte)(value >> 16);
				buffer[offset + 6] = (byte)(value >> 8);
				buffer[offset + 7] = (byte)value;
				}
			}

#if NETCF
		/// <summary>
		///     Converts array of bytes to <see cref="long" />.
		/// </summary>
		/// <param name="bytes">An array of bytes. </param>
		/// <returns><see cref="long" /> value.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static long ToInt64 (this byte[] bytes)
			{
			return ToInt64 (bytes, 0, null);
			}
		/// <summary>
		///     Converts array of bytes to <see cref="long" />.
		/// </summary>
		/// <param name="bytes">An array of bytes. </param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <returns><see cref="long" /> value.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static long ToInt64 (this byte[] bytes, int offset)
			{
			return ToInt64 (bytes, offset, null);
			}
		/// <summary>
		///     Converts array of bytes to <see cref="long" />.
		/// </summary>
		/// <param name="bytes">An array of bytes. </param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <returns><see cref="long" /> value.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static long ToInt64 (this byte[] bytes, int offset, bool? asLittleEndian)
#else
		/// <summary>
		///     Converts array of bytes to <see cref="long" />.
		/// </summary>
		/// <param name="bytes">An array of bytes. </param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <returns><see cref="long" /> value.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static long ToInt64 (this byte[] bytes, int offset = 0, bool? asLittleEndian = null)
#endif
			{
			if (bytes == null)
				throw new ArgumentNullException ("bytes");
			if (bytes.Length == 0)
				return 0;
			if (bytes.Length <= offset)
				throw new InvalidOperationException ("Array length must be greater than offset.");
			bool ale = GetIsLittleEndian (asLittleEndian);
			EnsureLength (ref bytes, 8, offset, ale);

			return ale
						? bytes[offset] | (long)bytes[offset + 1] << 8 | (long)bytes[offset + 2] << 16 | (long)bytes[offset + 3] << 24 | (long)bytes[offset + 4] << 32
							| (long)bytes[offset + 5] << 40 | (long)bytes[offset + 6] << 48 | (long)bytes[offset + 7] << 56
						: (long)bytes[offset] << 56 | (long)bytes[offset + 1] << 48 | (long)bytes[offset + 2] << 40 | (long)bytes[offset + 3] << 32
							| (long)bytes[offset + 4] << 24 | (long)bytes[offset + 5] << 16 | (long)bytes[offset + 6] << 8 | bytes[offset + 7];
			}

		#endregion

		#region UInt64

#if NETCF
		/// <summary>
		///     Converts <see cref="ulong" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static byte[] ToBytes (this ulong value)
			{
			return ToBytes (value, (bool?)null);
			}
		/// <summary>
		///     Converts <see cref="ulong" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="asLittleEndian">Convert to little endian.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static byte[] ToBytes (this ulong value, bool? asLittleEndian)
#else
		/// <summary>
		///     Converts <see cref="ulong" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="asLittleEndian">Convert to little endian.</param>
		/// <returns>Array of bytes.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static byte[] ToBytes (this ulong value, bool? asLittleEndian = null)
#endif
			{
			return unchecked ((long)value).ToBytes (asLittleEndian);
			}

#if NETCF
		/// <summary>
		///     Converts <see cref="ulong" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">Buffer at least 8 bytes.</param>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static void ToBytes (this ulong value, byte[] buffer)
			{
			ToBytes (value, buffer, 0, null);
			}
		/// <summary>
		///     Converts <see cref="ulong" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">Buffer at least 8 bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static void ToBytes (this ulong value, byte[] buffer, int offset)
			{
			ToBytes (value, buffer, offset, null);
			}
		/// <summary>
		///     Converts <see cref="ulong" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">Buffer at least 8 bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
		/// <param name="asLittleEndian">Convert to little endian.</param>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static void ToBytes (this ulong value, byte[] buffer, int offset, bool? asLittleEndian)
#else
		/// <summary>
		///     Converts <see cref="ulong" /> to array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">Buffer at least 8 bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
		/// <param name="asLittleEndian">Convert to little endian.</param>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static void ToBytes (this ulong value, byte[] buffer, int offset = 0, bool? asLittleEndian = null)
#endif
			{
			unchecked((long)value).ToBytes (buffer, offset, asLittleEndian);
			}

#if NETCF
		/// <summary>
		///     Converts array of bytes to <see cref="ulong" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <returns><see cref="ulong" /> value.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static ulong ToUInt64 (this byte[] bytes)
			{
			return ToUInt64 (bytes, 0, null);
			}
		/// <summary>
		///     Converts array of bytes to <see cref="ulong" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <returns><see cref="ulong" /> value.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static ulong ToUInt64 (this byte[] bytes, int offset)
			{
			return ToUInt64 (bytes, offset, null);
			}
		/// <summary>
		///     Converts array of bytes to <see cref="ulong" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <returns><see cref="ulong" /> value.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static ulong ToUInt64 (this byte[] bytes, int offset, bool? asLittleEndian)
#else
		/// <summary>
		///     Converts array of bytes to <see cref="ulong" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <returns><see cref="ulong" /> value.</returns>
#if !NETCF
		 [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
		public static ulong ToUInt64 (this byte[] bytes, int offset = 0, bool? asLittleEndian = null)
#endif
			{
			return (ulong)bytes.ToInt64 (offset, asLittleEndian);
			}

		#endregion

		#region Int128

#if NETCF
		/// <summary>
		///     Converts an <see cref="Int128" /> value to an array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">An array of bytes.</param>
		public static void ToBytes (this Int128 value, byte[] buffer)
			{
			ToBytes (value, buffer, 0, null);
			}
		/// <summary>
		///     Converts an <see cref="Int128" /> value to an array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
		public static void ToBytes (this Int128 value, byte[] buffer, int offset)
			{
			ToBytes (value, buffer, offset, null);
			}
		/// <summary>
		///     Converts an <see cref="Int128" /> value to an array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		public static void ToBytes (this Int128 value, byte[] buffer, int offset, bool? asLittleEndian)
#else
		/// <summary>
		///     Converts an <see cref="Int128" /> value to an array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		public static void ToBytes (this Int128 value, byte[] buffer, int offset = 0, bool? asLittleEndian = null)
#endif
			{
			bool ale = GetIsLittleEndian (asLittleEndian);
			value.Low.ToBytes (buffer, ale ? offset : offset + 8, ale);
			value.High.ToBytes (buffer, ale ? offset + 8 : offset, ale);
			}

#if NETCF
		/// <summary>
		///     Converts an <see cref="Int128" /> value to a byte array.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <returns>Array of bytes.</returns>
		public static byte[] ToBytes (this Int128 value)
			{
			return ToBytes (value, null, false);
			}
		/// <summary>
		///     Converts an <see cref="Int128" /> value to a byte array.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <returns>Array of bytes.</returns>
		public static byte[] ToBytes (this Int128 value, bool? asLittleEndian)
			{
			return ToBytes (value, asLittleEndian, false);
			}
		/// <summary>
		///     Converts an <see cref="Int128" /> value to a byte array.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <param name="trimZeros">Trim zero bytes from left or right, depending on endian.</param>
		/// <returns>Array of bytes.</returns>
		public static byte[] ToBytes (this Int128 value, bool? asLittleEndian, bool trimZeros)
#else
		/// <summary>
		///     Converts an <see cref="Int128" /> value to a byte array.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <param name="trimZeros">Trim zero bytes from left or right, depending on endian.</param>
		/// <returns>Array of bytes.</returns>
		public static byte[] ToBytes (this Int128 value, bool? asLittleEndian = null, bool trimZeros = false)
#endif
			{
			var buffer = new byte[16];
			value.ToBytes (buffer, 0, asLittleEndian);

			if (trimZeros)
				buffer = buffer.TrimZeros (asLittleEndian);

			return buffer;
			}

#if NETCF
		/// <summary>
		///     Converts array of bytes to <see cref="Int128" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <returns><see cref="Int128" /> value.</returns>
		public static Int128 ToInt128 (this byte[] bytes)
			{
			return ToInt128 (bytes, 0, null);
			}
		/// <summary>
		///     Converts array of bytes to <see cref="Int128" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <returns><see cref="Int128" /> value.</returns>
		public static Int128 ToInt128 (this byte[] bytes, int offset)
			{
			return ToInt128 (bytes, offset, null);
			}
		/// <summary>
		///     Converts array of bytes to <see cref="Int128" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <returns><see cref="Int128" /> value.</returns>
		public static Int128 ToInt128 (this byte[] bytes, int offset, bool? asLittleEndian)
#else
		/// <summary>
		///     Converts array of bytes to <see cref="Int128" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <returns><see cref="Int128" /> value.</returns>
		public static Int128 ToInt128 (this byte[] bytes, int offset = 0, bool? asLittleEndian = null)
#endif
			{
			if (bytes == null)
				throw new ArgumentNullException ("bytes");
			if (bytes.Length == 0)
				return 0;
			if (bytes.Length <= offset)
				throw new InvalidOperationException ("Array length must be greater than offset.");
			bool ale = GetIsLittleEndian (asLittleEndian);
			EnsureLength (ref bytes, 16, offset, ale);

			return new Int128 (bytes.ToUInt64 (ale ? offset + 8 : offset, ale), bytes.ToUInt64 (ale ? offset : offset + 8, ale));
			}

		#endregion

		#region UInt128

#if NETCF
		/// <summary>
		///     Converts an <see cref="UInt128" /> value to an array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">An array of bytes.</param>
		public static void ToBytes (this UInt128 value, byte[] buffer)
			{
			ToBytes (value, buffer, 0, null);
			}
		/// <summary>
		///     Converts an <see cref="UInt128" /> value to an array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
		public static void ToBytes (this UInt128 value, byte[] buffer, int offset)
			{
			ToBytes (value, buffer, offset, null);
			}
		/// <summary>
		///     Converts an <see cref="UInt128" /> value to an array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		public static void ToBytes (this UInt128 value, byte[] buffer, int offset, bool? asLittleEndian)
#else
		/// <summary>
		///     Converts an <see cref="UInt128" /> value to an array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		public static void ToBytes (this UInt128 value, byte[] buffer, int offset = 0, bool? asLittleEndian = null)
#endif
			{
			bool ale = GetIsLittleEndian (asLittleEndian);
			value.Low.ToBytes (buffer, ale ? offset : offset + 8, ale);
			value.High.ToBytes (buffer, ale ? offset + 8 : offset, ale);
			}

#if NETCF
		/// <summary>
		///     Converts an <see cref="UInt128" /> value to a byte array.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <returns>Array of bytes.</returns>
		public static byte[] ToBytes (this UInt128 value)
			{
			return ToBytes (value, null, false);
			}
		/// <summary>
		///     Converts an <see cref="UInt128" /> value to a byte array.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <returns>Array of bytes.</returns>
		public static byte[] ToBytes (this UInt128 value, bool? asLittleEndian)
			{
			return ToBytes (value, asLittleEndian, false);
			}
		/// <summary>
		///     Converts an <see cref="UInt128" /> value to a byte array.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <param name="trimZeros">Trim zero bytes from left or right, depending on endian.</param>
		/// <returns>Array of bytes.</returns>
		public static byte[] ToBytes (this UInt128 value, bool? asLittleEndian, bool trimZeros)
#else
		/// <summary>
		///     Converts an <see cref="UInt128" /> value to a byte array.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <param name="trimZeros">Trim zero bytes from left or right, depending on endian.</param>
		/// <returns>Array of bytes.</returns>
		public static byte[] ToBytes (this UInt128 value, bool? asLittleEndian = null, bool trimZeros = false)
#endif
			{
			var buffer = new byte[16];
			value.ToBytes (buffer, 0, asLittleEndian);

			if (trimZeros)
				buffer = buffer.TrimZeros (asLittleEndian);

			return buffer;
			}

#if NETCF
		/// <summary>
		///     Converts array of bytes to <see cref="UInt128" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <returns><see cref="Int128" /> value.</returns>
		public static UInt128 ToUInt128 (this byte[] bytes)
			{
			return ToUInt128 (bytes, 0, null);
			}
		/// <summary>
		///     Converts array of bytes to <see cref="UInt128" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <returns><see cref="UInt128" /> value.</returns>
		public static UInt128 ToUInt128 (this byte[] bytes, int offset)
			{
			return ToUInt128 (bytes, offset, null);
			}
		/// <summary>
		///     Converts array of bytes to <see cref="UInt128" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <returns><see cref="UInt128" /> value.</returns>
		public static UInt128 ToUInt128 (this byte[] bytes, int offset, bool? asLittleEndian)
#else
		/// <summary>
		///     Converts array of bytes to <see cref="UInt128" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <returns><see cref="UInt128" /> value.</returns>
		public static UInt128 ToUInt128 (this byte[] bytes, int offset = 0, bool? asLittleEndian = null)
#endif
			{
			if (bytes == null)
				throw new ArgumentNullException ("bytes");
			if (bytes.Length == 0)
				return 0;
			if (bytes.Length <= offset)
				throw new InvalidOperationException ("Array length must be greater than offset.");
			bool ale = GetIsLittleEndian (asLittleEndian);
			EnsureLength (ref bytes, 16, offset, ale);

			return new UInt128 (bytes.ToUInt64 (ale ? offset + 8 : offset, ale), bytes.ToUInt64 (ale ? offset : offset + 8, ale));
			}

		#endregion

		#region Int256

#if NETCF
		/// <summary>
		///     Converts an <see cref="Int256" /> value to an array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">An array of bytes.</param>
		public static void ToBytes (this Int256 value, byte[] buffer)
			{
			ToBytes (value, buffer, 0, null);
			}
		/// <summary>
		///     Converts an <see cref="Int256" /> value to an array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
		public static void ToBytes (this Int256 value, byte[] buffer, int offset)
			{
			ToBytes (value, buffer, offset, null);
			}
		/// <summary>
		///     Converts an <see cref="Int256" /> value to an array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		public static void ToBytes (this Int256 value, byte[] buffer, int offset, bool? asLittleEndian)
#else
		/// <summary>
		///     Converts an <see cref="Int256" /> value to an array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		public static void ToBytes (this Int256 value, byte[] buffer, int offset = 0, bool? asLittleEndian = null)
#endif
			{
			bool ale = GetIsLittleEndian (asLittleEndian);

			value.D.ToBytes (buffer, ale ? offset : offset + 24, ale);
			value.C.ToBytes (buffer, ale ? offset + 8 : offset + 16, ale);
			value.B.ToBytes (buffer, ale ? offset + 16 : offset + 8, ale);
			value.A.ToBytes (buffer, ale ? offset + 24 : offset, ale);
			}

#if NETCF
		/// <summary>
		///     Converts an <see cref="Int256" /> value to a byte array.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <returns>Array of bytes.</returns>
		public static byte[] ToBytes (this Int256 value)
			{
			return ToBytes (value, null, false);
			}
		/// <summary>
		///     Converts an <see cref="Int256" /> value to a byte array.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <returns>Array of bytes.</returns>
		public static byte[] ToBytes (this Int256 value, bool? asLittleEndian)
			{
			return ToBytes (value, asLittleEndian, false);
			}
		/// <summary>
		///     Converts an <see cref="Int256" /> value to a byte array.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <param name="trimZeros">Trim zero bytes from left or right, depending on endian.</param>
		/// <returns>Array of bytes.</returns>
		public static byte[] ToBytes (this Int256 value, bool? asLittleEndian, bool trimZeros)
#else
		/// <summary>
		///     Converts an <see cref="Int256" /> value to a byte array.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <param name="trimZeros">Trim zero bytes from left or right, depending on endian.</param>
		/// <returns>Array of bytes.</returns>
		public static byte[] ToBytes (this Int256 value, bool? asLittleEndian = null, bool trimZeros = false)
#endif
			{
			var buffer = new byte[32];
			value.ToBytes (buffer, 0, asLittleEndian);

			if (trimZeros)
				buffer = buffer.TrimZeros (asLittleEndian);

			return buffer;
			}

#if NETCF
		/// <summary>
		///     Converts array of bytes to <see cref="Int256" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <returns><see cref="Int256" /> value.</returns>
		public static Int256 ToInt256 (this byte[] bytes)
			{
			return ToInt256 (bytes, 0, null);
			}
		/// <summary>
		///     Converts array of bytes to <see cref="Int256" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <returns><see cref="Int256" /> value.</returns>
		public static Int256 ToInt256 (this byte[] bytes, int offset)
			{
			return ToInt256 (bytes, offset, null);
			}
		/// <summary>
		///     Converts array of bytes to <see cref="Int256" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <returns><see cref="Int256" /> value.</returns>
		public static Int256 ToInt256 (this byte[] bytes, int offset, bool? asLittleEndian)
#else
		/// <summary>
		///     Converts array of bytes to <see cref="Int256" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <returns><see cref="Int256" /> value.</returns>
		public static Int256 ToInt256 (this byte[] bytes, int offset = 0, bool? asLittleEndian = null)
#endif
			{
			if (bytes == null)
				throw new ArgumentNullException ("bytes");
			if (bytes.Length == 0)
				return 0;
			if (bytes.Length <= offset)
				throw new InvalidOperationException ("Array length must be greater than offset.");
			bool ale = GetIsLittleEndian (asLittleEndian);
			EnsureLength (ref bytes, 32, offset, ale);

			ulong a = bytes.ToUInt64 (ale ? offset + 24 : offset, ale);
			ulong b = bytes.ToUInt64 (ale ? offset + 16 : offset + 8, ale);
			ulong c = bytes.ToUInt64 (ale ? offset + 8 : offset + 16, ale);
			ulong d = bytes.ToUInt64 (ale ? offset : offset + 24, ale);

			return new Int256 (a, b, c, d);
			}

		#endregion

		#region UInt256

#if NETCF
		/// <summary>
		///     Converts an <see cref="UInt256" /> value to an array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">An array of bytes.</param>
		public static void ToBytes (this UInt256 value, byte[] buffer)
			{
			ToBytes (value, buffer, 0, null);
			}
		/// <summary>
		///     Converts an <see cref="UInt256" /> value to an array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
		public static void ToBytes (this UInt256 value, byte[] buffer, int offset)
			{
			ToBytes (value, buffer, offset, null);
			}
		/// <summary>
		///     Converts an <see cref="UInt256" /> value to an array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		public static void ToBytes (this UInt256 value, byte[] buffer, int offset, bool? asLittleEndian)
#else
		/// <summary>
		///     Converts an <see cref="UInt256" /> value to an array of bytes.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="buffer">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="buffer" />.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		public static void ToBytes (this UInt256 value, byte[] buffer, int offset = 0, bool? asLittleEndian = null)
#endif
			{
			bool ale = GetIsLittleEndian (asLittleEndian);

			value.D.ToBytes (buffer, ale ? offset : offset + 24, ale);
			value.C.ToBytes (buffer, ale ? offset + 8 : offset + 16, ale);
			value.B.ToBytes (buffer, ale ? offset + 16 : offset + 8, ale);
			value.A.ToBytes (buffer, ale ? offset + 24 : offset, ale);
			}

#if NETCF
		/// <summary>
		///     Converts an <see cref="UInt256" /> value to a byte array.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <returns>Array of bytes.</returns>
		public static byte[] ToBytes (this UInt256 value)
			{
			return ToBytes (value, null, false);
			}
		/// <summary>
		///     Converts an <see cref="UInt256" /> value to a byte array.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <returns>Array of bytes.</returns>
		public static byte[] ToBytes (this UInt256 value, bool? asLittleEndian)
			{
			return ToBytes (value, asLittleEndian, false);
			}
		/// <summary>
		///     Converts an <see cref="UInt256" /> value to a byte array.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <param name="trimZeros">Trim zero bytes from left or right, depending on endian.</param>
		/// <returns>Array of bytes.</returns>
		public static byte[] ToBytes (this UInt256 value, bool? asLittleEndian, bool trimZeros)
#else
		/// <summary>
		///     Converts an <see cref="UInt256" /> value to a byte array.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <param name="trimZeros">Trim zero bytes from left or right, depending on endian.</param>
		/// <returns>Array of bytes.</returns>
		public static byte[] ToBytes (this UInt256 value, bool? asLittleEndian = null, bool trimZeros = false)
#endif
			{
			var buffer = new byte[32];
			value.ToBytes (buffer, 0, asLittleEndian);

			if (trimZeros)
				buffer = buffer.TrimZeros (asLittleEndian);

			return buffer;
			}

#if NETCF
		/// <summary>
		///     Converts array of bytes to <see cref="UInt256" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <returns><see cref="UInt256" /> value.</returns>
		public static UInt256 ToUInt256 (this byte[] bytes)
			{
			return ToUInt256 (bytes, 0, null);
			}
		/// <summary>
		///     Converts array of bytes to <see cref="UInt256" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <returns><see cref="UInt256" /> value.</returns>
		public static UInt256 ToUInt256 (this byte[] bytes, int offset)
			{
			return ToUInt256 (bytes, offset, null);
			}
		/// <summary>
		///     Converts array of bytes to <see cref="UInt256" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <returns><see cref="UInt256" /> value.</returns>
		public static UInt256 ToUInt256 (this byte[] bytes, int offset, bool? asLittleEndian)
#else
		/// <summary>
		///     Converts array of bytes to <see cref="UInt256" />.
		/// </summary>
		/// <param name="bytes">An array of bytes.</param>
		/// <param name="offset">The starting position within <paramref name="bytes" />.</param>
		/// <param name="asLittleEndian">Convert from little endian.</param>
		/// <returns><see cref="UInt256" /> value.</returns>
		public static UInt256 ToUInt256 (this byte[] bytes, int offset = 0, bool? asLittleEndian = null)
#endif
			{
			if (bytes == null)
				throw new ArgumentNullException ("bytes");
			if (bytes.Length == 0)
				return 0;
			if (bytes.Length <= offset)
				throw new InvalidOperationException ("Array length must be greater than offset.");
			bool ale = GetIsLittleEndian (asLittleEndian);
			EnsureLength (ref bytes, 32, offset, ale);

			ulong a = bytes.ToUInt64 (ale ? offset + 24 : offset, ale);
			ulong b = bytes.ToUInt64 (ale ? offset + 16 : offset + 8, ale);
			ulong c = bytes.ToUInt64 (ale ? offset + 8 : offset + 16, ale);
			ulong d = bytes.ToUInt64 (ale ? offset : offset + 24, ale);

			return new UInt256 (a, b, c, d);
			}

		#endregion
		}
	}
