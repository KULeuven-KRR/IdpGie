using System;
using Cairo;

namespace IdpGie.UserInterface {
	public class StripCanvasSize : ICanvasSize {
		public CanvasSize CanvasSize;
		public StripGeometry StripGeometry;

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

		public StripCanvasSize (CanvasSize canvasSize, StripGeometry geometry, int size) {
			this.CanvasSize = canvasSize;
			this.StripGeometry = geometry.CollapseClone (size);
		}

		public Point GetCanvasOffset (int index) {
			int y = index / this.StripGeometry.Width;
			int x = index - y;
			return new Point (Margin + StrideWidth * x, Margin + StrideHeight * y);
		}
	}
}

