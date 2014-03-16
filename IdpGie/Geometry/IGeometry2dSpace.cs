//
//  IGeometry2d.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
//
//  Copyright (c) 2013 Willem Van Onsem
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
using System;

namespace IdpGie.Geometry {

	/// <summary>
	/// A geometrical object that is a somehow constrained set of 2d-points.
	/// </summary>
	public interface IGeometry2dSpace {

		/// <summary>
		/// Gets the surrounding box of the space.
		/// </summary>
		/// <value>
		/// The surrounding box of the space.
		/// </value>
		Box2d SurroundingBox {
			get;
		}

		/// <summary>
		/// Checks if the given space contains the given point.
		/// </summary>
		/// <param name='pt'>
		/// The point to check for.
		/// </param>
		/// <returns>
		/// <c>true</c> if the given point is part of the <see cref="IGeometry2dSpace"/>, <c>false</c> otherwise.
		/// </returns>
		bool Contains (Point pt);

	}

}

