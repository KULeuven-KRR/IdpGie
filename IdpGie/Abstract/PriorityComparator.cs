//
//  PriorityComparator.cs
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
	/// The implementation of a <see cref="IComparer`1"/> that compares two <see cref="IPriority"/> objects.
	/// </summary>
	public class PriorityComparator : IComparer<IPriority> {

		/// <summary>
		/// A single instance of the comparator.
		/// </summary>
		/// <remarks>
		/// <para>
		/// One cannot create new instances of the comparer to reduce the memory footprint.
		/// </para>
		/// </remarks>
		public static readonly PriorityComparator Instance = new PriorityComparator ();

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Abstract.PriorityComparator"/> class.
		/// </summary>
		/// <remarks>
		/// <para>
		/// This constructor is not public to prevent creating several instances introducing a large memory footprint.
		/// </para>
		/// </remarks>
		protected PriorityComparator () {
		}

        #region IComparer implementation
		/// <summary>
		/// Compares the two <see cref="IPrioirity"/> objects.
		/// </summary>
		/// <param name='x'>
		/// The first <see cref="IPrioirity"/> instance to compare.
		/// </param>
		/// <param name='y'>
		/// The second <see cref="IPriority"/> instance to compare.
		/// </param>
		/// <returns>
		/// A value smaller than zero if <paramref name="x"/> has priority over <paramref name="y"/>, a value larger than
		/// zero if <paramref name="y"/> has priority over <paramref name="x"/>, zero in case both parameters have the
		/// same priority.
		/// </returns>
		/// <remarks>
		/// <para>In case one of the parameters is not effective, the effective parameter has a higher priority.</para>
		/// <para>When both parameters are not effective, the first parameter has priority over the second.</para>
		/// </remarks>
		public int Compare (IPriority x, IPriority y) {
			if (y == null) {
				return -0x01;
			} else if (x == null) {
				return 0x01;
			} else {
				return x.Priority.CompareTo (y.Priority);
			}
		}
        #endregion

	}

}