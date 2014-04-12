//
//  IBox2d.cs
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

namespace IdpGie.Geometry {

	/// <summary>
	/// A two dimensional rectangular box that contains all the points with an X-coordinate between <see cref="IBox2d.Xmin"/> and <see cref="IBox2d.Xmax"/> and an Y-coordinate between <see cref="IBox2d.Ymin"/> and <see cref="IBox2d.Ymax"/>.
	/// </summary>
	public interface IBox2d : IGeometry2dSpace {

		/// <summary>
		/// Gets or sets the minimum value for the X-coordinate a point should have to belong to the box.
		/// </summary>
		/// <value>
		/// The minimum value for the X-coordinate a point should have to belong to the box.
		/// </value>
		double Xmin {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the maximum value for the X-coordinate a point should have to belong to the box.
		/// </summary>
		/// <value>
		/// The maximum value for the X-coordinate a point should have to belong to the box.
		/// </value>
		double Xmax {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the minimum value for the Y-coordinate a point should have to belong to the box.
		/// </summary>
		/// <value>
		/// The minimum value for the Y-coordinate a point should have to belong to the box.
		/// </value>
		double Ymin {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the maximum value for the Y-coordinate a point should have to belong to the box.
		/// </summary>
		/// <value>
		/// The maximum value for the Y-coordinate a point should have to belong to the box.
		/// </value>
		double Ymax {
			get;
			set;
		}

	}

}