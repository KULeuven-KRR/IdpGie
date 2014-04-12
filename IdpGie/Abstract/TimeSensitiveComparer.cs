//
//  TimeSensitiveComparer.cs
//
//  Author:
//       Willem Van Onsem <Willem.VanOnsem@cs.kuleuven.be>
//
//  Copyright (c) 2014 Willem Van Onsem
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System.Collections.Generic;

namespace IdpGie.Abstract {

	/// <summary>
	/// A compararer to compare two <see cref="ITimeSensitive"/> objects.
	/// </summary>
	public class TimeSensitiveComparer : IComparer<ITimeSensitive> {

		/// <summary>
		/// An instance of the <see cref="TimeSensitiveComparer"/>, used to reduce the memory footprint.
		/// </summary>
		public static readonly TimeSensitiveComparer Instance = new TimeSensitiveComparer ();

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Abstract.TimeSensitiveComparer"/> class.
		/// </summary>
		/// <remarks>
		/// <para>This constructor is not public to prevent creating several instances increasing the footprint.</para>
		/// </remarks>
		protected TimeSensitiveComparer () {
		}

        #region IComparer implementation
		/// <summary>
		/// Compares the two given <see cref="ITimeSensitive"/> instances.
		/// </summary>
		/// <param name='x'>
		/// The first <see cref="ITimeSensitive"/> instance to compare.
		/// </param>
		/// <param name='y'>
		/// The second <see cref="ITimeSensitive"/> instance to compare.
		/// </param>
		/// <returns>
		/// A value smaller than zero if <paramref name="x"/> occurs before <paramref name="y"/>, a value larger than
		/// zero if <paramref name="y"/> occurs before <paramref name="x"/>, zero in case both parameters occur at the
		/// same time.
		/// </returns>
		/// <remarks>
		/// <para>In case one of the parameters is not effective, the effective parameter occurs first.</para>
		/// <para>When both parameters are not effective, the first parameter occurs before the second.</para>
		/// </remarks>
		public int Compare (ITimeSensitive x, ITimeSensitive y) {
			if (x == null) {
				return 0x01;
			} else if (y == null) {
				return -0x01;
			} else {
				return x.Time.CompareTo (y.Time);
			}
		}
        #endregion

	}

}