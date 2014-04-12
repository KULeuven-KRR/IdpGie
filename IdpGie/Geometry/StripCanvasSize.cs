//
//  StripCanvasSize.cs
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
	/// An implementation with of the <see cref="ICanvasSize"/> interface with multiple frames specified by <see cref="StripCanvasSize.StripGeometry"/>.
	/// </summary>
	public class StripCanvasSize : CloneableBase<ICanvasSize>, IStripCanvasSize {

		#region IStripCanvasSize implementation
		/// <summary>
		/// Gets or sets the <see cref="ICanvasSize"/> of the <see cref="IStripCanvasSize"/> describing the size of a single canvas.
		/// </summary>
		/// <value>
		/// The <see cref="ICanvasSize"/> of the <see cref="IStripCanvasSize"/>.
		/// </value>
		public ICanvasSize CanvasSize {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the <see cref="IStripGeometry"/> of the <see cref="IStripCanvasSize"/> the describes the configuration of the canvasses.
		/// </summary>
		/// <value>
		/// The <see cref="IStripGeometry"/> of the <see cref="IStripCanvasSize"/>.
		/// </value>
		public IStripGeometry StripGeometry {
			get;
			set;
		}
		#endregion

		#region ICanvasSize implementation
		/// <summary>
		///  Gets or sets the width of a single frame. 
		/// </summary>
		/// <value>
		///  The width of a single frame. 
		/// </value>
		public double Width {
			get {
				return this.CanvasSize.Width;
			}
			set {
				this.CanvasSize.Width = value;
			}
		}

		/// <summary>
		///  Gets the total width of the graphical output. 
		/// </summary>
		/// <value>
		///  The total width of the graphical output. 
		/// </value>
		public double TotalWidth {
			get {
				int dw = StripGeometry.Width;
				return this.Width * dw + (dw + 0x01) * this.Margin;
			}
		}

		/// <summary>
		///  Gets or sets the height of a single frame. 
		/// </summary>
		/// <value>
		///  The height of a single frame. 
		/// </value>
		public double Height {
			get {
				return this.CanvasSize.Height;
			}
			set {
				this.CanvasSize.Height = value;
			}
		}

		/// <summary>
		///  Gets the total height of the graphical output. 
		/// </summary>
		/// <value>
		///  The total height of the graphical output. 
		/// </value>
		public double TotalHeight {
			get {
				int dh = StripGeometry.Height;
				return this.Height * dh + (dh + 0x01) * this.Margin;
			}
		}

		/// <summary>
		///  Gets or sets the margin between the frames and the output and the border frames. 
		/// </summary>
		/// <value>
		///  The margin between the frames and the output and the border frames. 
		/// </value>
		public double Margin {
			get {
				return this.CanvasSize.Margin;
			}
			set {
				this.CanvasSize.Margin = value;
			}
		}

		/// <summary>
		///  Gets the difference in X-value between two frames. 
		/// </summary>
		/// <value>
		///  The difference in X-value between two frames. 
		/// </value>
		public double StrideWidth {
			get {
				return this.Width + this.Margin;
			}
		}

		/// <summary>
		///  Gets the difference in Y-value between two frames. 
		/// </summary>
		/// <value>
		///  The difference in Y-value between two frames. 
		/// </value>
		public double StrideHeight {
			get {
				return this.Height + this.Margin;
			}
		}

		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="StripCanvasSize"/> class with a given a given <see cref="ICanvasSize"/> and <see cref="IStripGeometry"/>.
		/// </summary>
		/// <param name='canvasSize'>
		/// An <see cref="ICanvasSize"/> instance describing the size of a single frame.
		/// </param>
		/// <param name='geometry'>
		/// An <see cref="IStripGeometry"/> instance that describes how the frames are organized.
		/// </param>
		public StripCanvasSize (ICanvasSize canvasSize, IStripGeometry geometry) {
			this.CanvasSize = canvasSize;
			this.StripGeometry = geometry;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="StripCanvasSize"/> class with a given <see cref="ICanvasSize"/>, <see cref="IStripGeometry"/> and the number of frames involved.
		/// </summary>
		/// <param name='canvasSize'>
		/// An <see cref="ICanvasSize"/> instance describing the size of a single frame.
		/// </param>
		/// <param name='geometry'>
		/// An <see cref="IStripGeometry"/> that describes how the frames are organized.
		/// </param>
		/// <param name='size'>
		/// The number of frames involved.
		/// </param>
		public StripCanvasSize (ICanvasSize canvasSize, IStripGeometry geometry, int size) : this(canvasSize,geometry.CollapseClone (size)) {
		}

		#region ICanvasSize implementation
		/// <summary>
		///  Gets the offset of the frame with the given index. 
		/// </summary>
		/// <returns>
		///  The offset point of the frame with the given index. 
		/// </returns>
		/// <param name='index'>
		///  The index of the specified frame. 
		/// </param>
		public IPoint3 GetCanvasOffset (int index) {
			int y = index / this.StripGeometry.Width;
			int x = index - this.StripGeometry.Width * y;
			return new Point3 (Margin + StrideWidth * x, Margin + StrideHeight * y);
		}

		/// <summary>
		/// Widen the <see cref="ICanvasSize"/> such that the geometry of frames specified by <paramref name="geometry"/> is contained.
		/// </summary>
		/// <param name='geometry'>
		/// The given <see cref="IStripGeometry"/> of the frames.
		/// </param>
		public void StripSequence (IStripGeometry geometry) {
			this.CanvasSize.StripSequence (geometry);
		}

		/// <summary>
		/// Generate a clone that is widened by the <paramref name="geometry"/>.
		/// </summary>
		/// <returns>
		/// A cloned instance that is widened by the given <paramref name="geometry"/>.
		/// </returns>
		/// <param name='geometry'>
		/// The given <see cref="IStripGeometry"/> of the frames.
		/// </param>
		public ICanvasSize StripSequenceClone (IStripGeometry geometry) {
			ICanvasSize cs = this.CanvasSize.StripSequenceClone (geometry);
			this.CanvasSize = cs;
			return cs;
		}
		#endregion

		#region CloneableBase implementation
		/// <summary>
		/// Creates a copy of this instance which is equivalent to the original one.
		/// </summary>
		/// <returns>
		/// An instance of this <see cref="CanvasSize"/> instance which is equivalent.
		/// </returns>
		public override ICanvasSize Clone () {
			return new StripCanvasSize (this.CanvasSize.Clone (), this.StripGeometry.Clone ());
		}
		#endregion

	}
}