using System;
using System.Text.RegularExpressions;

namespace IdpGie {
	public class Geometry {
		public const string identifier_width = @"		w";
		public const string identifier_heigh = @"		h";
		private int width = 0x05, height = 0x05;
		public static readonly Regex regex = RegexDevelopment.IntegerRegex / identifier_width + "[^0-9+-.]+" + RegexDevelopment.IntegerRegex / identifier_heigh;

		public int Width {
			get {
				return width;
			}
			set {
				width = Math.Max (0x01, value);
			}
		}

		public int Height {
			get {
				return height;
			}
			set {
				height = Math.Max (0x01, value);
			}
		}

		public Geometry (int width, int height) {
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

