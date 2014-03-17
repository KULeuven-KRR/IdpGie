//
//  IPoint.cs
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

using Cairo;
using OpenTK;

namespace IdpGie.Geometry {

	/// <summary>
	/// An interface that specifies a point in a given - at most - 3-dimensional space.
	/// </summary>
	public interface IPoint3 {

		/// <summary>
		/// Gets or sets the x-coordinate of this point.
		/// </summary>
		/// <value>
		/// The x-coordinate of this point.
		/// </value>
		double X {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the y-coordinate of this point.
		/// </summary>
		/// <value>
		/// The y-coordinate of this point.
		/// </value>
		double Y {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the z-coordinate of this point.
		/// </summary>
		/// <value>
		/// The z-coordinate of this point.
		/// </value>
		double Z {
			get;
			set;
		}

		/// <summary>
		/// Transform this point with the given <see cref="Matrix4d"/>.
		/// </summary>
		/// <param name='m'>
		/// The given transformation matrix.
		/// </param>
		void Transform (Matrix4d m);

		/// <summary>
		/// Transform this point with the given <see cref="Matrix4"/>.
		/// </summary>
		/// <param name='m'>
		/// The given transformation matrix.
		/// </param>
		void Transform (Matrix4 m);

		/// <summary>
		/// Transform this point with the given <see cref="Matrix"/>.
		/// </summary>
		/// <param name='m'>
		/// The given transformation matrix.
		/// </param>
		void Transform (Matrix m);

	}
}

