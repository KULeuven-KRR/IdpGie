using System;
using System.Text.RegularExpressions;

namespace IdpGie {
	public class DocumentSize {
		public const string identifier_width = @"w";
		public const string identifier_heigh = @"h";
		private double width = 100.0d, height = 100.0d;
		public static readonly Regex regex = RegexDevelopment.DoubleRegex / identifier_width + "[^0-9+-.]+" + RegexDevelopment.DoubleRegex / identifier_heigh;

		public double Width {
			get {
				return width;
			}
			set {
				width = Math.Max (1.0d, value);
			}
		}

		public double Height {
			get {
				return height;
			}
			set {
				height = Math.Max (1.0d, value);
			}
		}

		public DocumentSize (double width, double height) {
			this.Width = width;
			this.Height = height;
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
			return string.Format ("{0} x {1}", this.Width, this.Height);
		}
	}
}

