using System;
using System.Text.RegularExpressions;

namespace IdpGie {
	public class DocumentSize {
		public const string identifier_width = @"w", identifier_heigh = @"h", identifier_margi = @"m";
		private double width = DefaultWidth, height = DefaultHeight, margin = DefaultMargin;
		public const double DefaultWidth = 640.0d, DefaultHeight = 480.0d, DefaultMargin = 5.0d;
		public const double MinWidth = 1.0d, MinHeight = 1.0d, MinMargin = 0.0d;
		private static readonly Regex regex = RegexDevelopment.DoubleRegex / identifier_width + "[^0-9+-.]+" + RegexDevelopment.DoubleRegex / identifier_heigh;

		public double Width {
			get {
				return width;
			}
			set {
				width = Math.Max (MinWidth, value);
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

		public double Margin {
			get {
				return margin;
			}
			set {
				margin = Math.Max (MinMargin, value);
			}
		}

		public DocumentSize (double width = DefaultWidth, double height = DefaultHeight, double margin = DefaultMargin) {
			this.Width = width;
			this.Height = height;
			this.Margin = margin;
		}

		public static DocumentSize Parse (string text) {
			Match match = regex.Match (text);
			if (match.Success) {
				double w = double.Parse (match.Groups [identifier_width].Value);
				double h = double.Parse (match.Groups [identifier_heigh].Value);
				return new DocumentSize (w, h);
			} else {
				throw new FormatException (string.Format ("The document size \"{0}\" does not meet the format criteria.", text));
			}
		}

		public override string ToString () {
			return string.Format ("{0} x {1} x {2}", this.Width, this.Height, this.Margin);
		}
	}
}

