//
//  ICanvasSize.cs
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
	/// The specification of the size of graphical output together with a margin and possible fragments.
	/// </summary>
	public interface ICanvasSize : ICloneable<ICanvasSize> {

		/// <summary>
		/// Gets or sets the width of a single frame.
		/// </summary>
		/// <value>
		/// The width of a single frame.
		/// </value>
		double Width {
			get;
			set;
		}

		/// <summary>
		/// Gets the total width of the graphical output.
		/// </summary>
		/// <value>
		/// The total width of the graphical output.
		/// </value>
		double TotalWidth {
			get;
		}

		/// <summary>
		/// Gets or sets the height of a single frame.
		/// </summary>
		/// <value>
		/// The height of a single frame.
		/// </value>
		double Height {
			get;
			set;
		}

		/// <summary>
		/// Gets the total height of the graphical output.
		/// </summary>
		/// <value>
		/// The total height of the graphical output.
		/// </value>
		double TotalHeight {
			get;
		}

		/// <summary>
		/// Gets the difference in X-value between two frames.
		/// </summary>
		/// <value>
		/// The difference in X-value between two frames.
		/// </value>
		double StrideWidth {
			get;
		}

		/// <summary>
		/// Gets the difference in Y-value between two frames.
		/// </summary>
		/// <value>
		/// The difference in Y-value between two frames.
		/// </value>
		double StrideHeight {
			get;
		}

		/// <summary>
		/// Gets or sets the margin between the frames and the output and the border frames.
		/// </summary>
		/// <value>
		/// The margin between the frames and the output and the border frames.
		/// </value>
		double Margin {
			get;
			set;
		}

		/// <summary>
		/// Gets the offset of the frame with the given index.
		/// </summary>
		/// <returns>
		/// The offset point of the frame with the given index.
		/// </returns>
		/// <param name='index'>
		/// The index of the specified frame.
		/// </param>
		Point3 GetCanvasOffset (int index);

		/// <summary>
		/// Widen the <see cref="ICanvasSize"/> such that the geometry of frames specified by <paramref name="geometry"/> is contained.
		/// </summary>
		/// <param name='geometry'>
		/// The given <see cref="IStripGeometry"/> of the frames.
		/// </param>
		void StripSequence (IStripGeometry geometry);

		/// <summary>
		/// Generate a clone that is widened by the <paramref name="geometry"/>.
		/// </summary>
		/// <returns>
		/// A cloned instance that is widened by the given <paramref name="geometry"/>.
		/// </returns>
		/// <param name='geometry'>
		/// The given <see cref="IStripGeometry"/> of the frames.
		/// </param>
		ICanvasSize StripSequenceClone (IStripGeometry geometry);

	}
}

