using System;
using System.Text.RegularExpressions;
using IdpGie.Abstract;
using IdpGie.Utils;

namespace IdpGie.Geometry {
	public class CanvasSize : CloneableBase<CanvasSize>, ICanvasSize {
		public const string identifier_width = @"w", identifier_heigh = @"h", identifier_margi = @"m";
		private double width = DefaultWidth, height = DefaultHeight, margin = DefaultMargin;
		public const double DefaultWidth = 640.0d, DefaultHeight = 480.0d, DefaultMargin = 5.0d;
		public const double MinWidth = 1.0d, MinHeight = 1.0d, MinMargin = 0.0d;
		private static readonly Regex regex = RegexDevelopment.DoubleRegex / identifier_width + "[^0-9+-.]+" + RegexDevelopment.DoubleRegex / identifier_heigh + ~("[^0-9+-.]+" + RegexDevelopment.DoubleRegex / identifier_margi);

		#region ICanvasSize implementation

		public double Width {
			get {
				return width;
			}
			set {
				width = Math.Max (MinWidth, value);
			}
		}

		public double TotalWidth {
			get {
				return this.Width + 2.0d * this.Margin;
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

		public double Height {
			get {
				return height;
			}
			set {
				height = Math.Max (MinHeight, value);
			}
		}

		public double TotalHeight {
			get {
				return this.Width + 2.0d * this.Margin;
			}
		}

		public double Margin {
			get {
				return margin;
			}
			set {
				margin = Math.Max (MinMargin, value);
			}
		}

		#endregion

		public CanvasSize (double width = DefaultWidth, double height = DefaultHeight, double margin = DefaultMargin) {
			this.Width = width;
			this.Height = height;
			this.Margin = margin;
		}

		public static CanvasSize Parse (string text) {
			Match match = regex.Match (text);
			if (match.Success) {
				double w = double.Parse (match.Groups [identifier_width].Value);
				double h = double.Parse (match.Groups [identifier_heigh].Value);
				Group gm = match.Groups [identifier_margi];
				if (gm.Success) {
					double m = double.Parse (gm.Value);
					return new CanvasSize (w, h, m);
				} else {
					return new CanvasSize (w, h);
				}
			} else {
				throw new FormatException (string.Format ("The document size \"{0}\" does not meet the format criteria.", text));
			}
		}

		public void StripSequence (StripGeometry geometry) {
			int w = geometry.Width;
			double margin = this.Margin;
			this.Width = this.Width * w + margin * (w - 0x01);
			int h = geometry.Height;
			this.Height = this.Height * h + margin * (h - 0x01);
		}

		public CanvasSize StripSequenceClone (StripGeometry geometry) {
			CanvasSize cs = this.Clone ();
			cs.StripSequence (geometry);
			return cs;
		}

		public override string ToString () {
			return string.Format ("{0} x {1} x {2}", this.Width, this.Height, this.Margin);
		}

		#region CloneableBase implementation

		public override CanvasSize Clone () {
			return new CanvasSize (this.width, this.height, this.margin);
		}

		#endregion

		public Point GetCanvasOffset (int index) {
			return new Point (this.Margin, this.Margin);
		}
	}
}

