//
//  DoubleInterval.cs
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

namespace IdpGie.Abstract {

	/// <summary>
	/// A structure that represents an interval that contains double values.
	/// </summary>
	public struct DoubleInterval : IInterval<double> {

		private double min;
		private double max;

		/// <summary>
		///  Gets or sets the maximum of the interval. 
		/// </summary>
		/// <value>
		///  The maximum of the interval. 
		/// </value>
		public double Max {
			get {
				return this.max;
			}
			set {
				this.max = value;
			}
		}

		/// <summary>
		///  Gets or sets the minimum of the interval. 
		/// </summary>
		/// <value>
		///  The minimum of the interval. 
		/// </value>
		public double Min {
			get {
				return this.min;
			}
			set {
				this.min = value;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Abstract.DoubleInterval"/> struct with a given minimum  and maximum.
		/// </summary>
		/// <param name='min'>
		/// The minimum of the interval.
		/// </param>
		/// <param name='max'>
		/// The maximum of the interval.
		/// </param>
		public DoubleInterval (double min, double max) {
			this.min = min;
			this.max = max;
		}

		/// <summary>
		///  Checks if the interval contains the specified value. 
		/// </summary>
		/// <param name='value'>
		///  The given item to check if it is an element of this interval. 
		/// </param>
		/// <returns>
		/// <c>true</c> if the interval contains the given <paramref name="value"/>, <c>false</c> otherwise.
		/// </returns>
		public bool Contains (double value) {
			return (min <= value && value <= max);
		}

	}
}

