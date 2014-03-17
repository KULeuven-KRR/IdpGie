//
//  IStripGeometry.cs
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
using IdpGie.Abstract;

namespace IdpGie.Geometry {

	/// <summary>
	/// An interface that specifies how the different frames should be aligned.
	/// </summary>
	public interface IStripGeometry : ICloneable<IStripGeometry> {

		/// <summary>
		/// Gets or sets the number of frames in the X-direction.
		/// </summary>
		/// <value>
		/// The number of frames in the X-direction.
		/// </value>
		int Width {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the number of frames in the Y-direction.
		/// </summary>
		/// <value>
		/// The number of frames in the Y-direction.
		/// </value>
		int Height {
			get;
			set;
		}

		/// <summary>
		/// Collapse this <see cref="IStripGeometry"/> with the given number of required frames.
		/// </summary>
		/// <param name='size'>
		/// The required number of frames.
		/// </param>
		void Collapse (int size);

		/// <summary>
		/// Collapses a clone of this <see cref="IStripGeometry"/>.
		/// </summary>
		/// <returns>
		/// A clone of this <see cref="IStripGeometry"/> that is collapsed with the given <paramref name="size"/>.
		/// </returns>
		/// <param name='size'>
		/// The required number of frames.
		/// </param>
		IStripGeometry CollapseClone (int size);

	}

}

