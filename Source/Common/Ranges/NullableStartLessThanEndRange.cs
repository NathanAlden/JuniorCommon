﻿using System;
using System.Collections.Generic;

namespace Junior.Common.Ranges
{
	/// <summary>
	/// A range of nullable <typeparamref name="T"/> where the start must be less than the end.
	/// </summary>
	public class NullableStartLessThanEndRange<T> : Range<T?>
		where T : struct, IComparable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="NullableStartLessThanEndRange{T}"/> class.
		/// </summary>
		/// <param name="start">The start of the range.</param>
		/// <param name="end">The end of the range.</param>
		/// <exception cref="ArgumentException">Thrown when <paramref name="start"/> is greater than or equal to <paramref name="end"/>.</exception>
		public NullableStartLessThanEndRange(T? start, T? end)
			: base(start, end)
		{
			if (Comparer<T?>.Default.Compare(start, end) >= 0)
			{
				throw new ArgumentException("Start value must be less than end value.", "start");
			}
		}
	}
}