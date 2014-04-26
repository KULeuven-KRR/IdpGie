//
//  IStripCanvasSize.cs
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
	/// An interface that specifies a strip of several canvasses.
	/// </summary>
	public interface IStripCanvasSize : ICloneable<ICanvasSize>, ICanvasSize {

		/// <summary>
		/// Gets or sets the <see cref="ICanvasSize"/> of the <see cref="IStripCanvasSize"/> describing the size of a single canvas.
		/// </summary>
		/// <value>
		/// The <see cref="ICanvasSize"/> of the <see cref="IStripCanvasSize"/>.
		/// </value>
		ICanvasSize CanvasSize {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the <see cref="IStripGeometry"/> of the <see cref="IStripCanvasSize"/> the describes the configuration of the canvasses.
		/// </summary>
		/// <value>
		/// The <see cref="IStripGeometry"/> of the <see cref="IStripCanvasSize"/>.
		/// </value>
		IStripGeometry StripGeometry {
			get;
			set;
		}

	}

}

