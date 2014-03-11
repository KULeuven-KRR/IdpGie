//
//  IZIndex.cs
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
	/// An interface specifying that this object has a Z-Index specifying in which order, object should be painted.
	/// </summary>
	public interface IZIndex {

		/// <summary>
		/// Gets the z-index of this instance.
		/// </summary>
		/// <value>
		/// The z-index of this instance.
		/// </value>
		/// <remarks>
		/// <para>As the value increases, the object is painted more on the background.</para>
		/// </remarks>
		double ZIndex {
			get;
		}

	}

}

