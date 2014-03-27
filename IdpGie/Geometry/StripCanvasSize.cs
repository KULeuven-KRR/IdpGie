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
	public class StripCanvasSize : CloneableBase<ICanvasSize>, ICanvasSize {

		public ICanvasSize CanvasSize;
		public IStripGeometry StripGeometry;

		#region ICanvasSize implementation

		public double Width {
			get {
				return this.CanvasSize.Width;
			}
			set {
				this.CanvasSize.Width = value;
			}
		}

		public double TotalWidth {
			get {
				int dw = StripGeometry.Width;
				return this.Width * dw + (dw + 0x01) * this.Margin;
			}
		}

		public double Height {
			get {
				return this.CanvasSize.Height;
			}
			set {
				this.CanvasSize.Height = value;
			}
		}

		public double TotalHeight {
			get {
				int dh = StripGeometry.Height;
				return this.Height * dh + (dh + 0x01) * this.Margin;
			}
		}

		public double Margin {
			get {
				return this.CanvasSize.Margin;
			}
			set {
				this.CanvasSize.Margin = value;
			}
		}

		public double StrideWidth {
			get {
				return this.Width + this.Margin;
			}
		}

		public double StrideHeight {
			get {
				return this.Height + this.Margin;
			}
		}

		#endregion

		public StripCanvasSize (ICanvasSize canvasSize, IStripGeometry geometry) {
			this.CanvasSize = canvasSize;
			this.StripGeometry = geometry;
		}

		public StripCanvasSize (ICanvasSize canvasSize, IStripGeometry geometry, int size) : this(canvasSize,geometry.CollapseClone (size)) {
		}

		public Point3 GetCanvasOffset (int index) {
			int y = index / this.StripGeometry.Width;
			int x = index - this.StripGeometry.Width * y;
			return new Point3 (Margin + StrideWidth * x, Margin + StrideHeight * y);
		}

		#region ICanvasSize implementation
		public void StripSequence (IStripGeometry geometry) {
			throw new System.NotImplementedException ();
		}

		public ICanvasSize StripSequenceClone (IStripGeometry geometry) {
			throw new System.NotImplementedException ();
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