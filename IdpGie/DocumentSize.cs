using System;
using System.Text.RegularExpressions;

namespace IdpGie {
	public class DocumentSize {
		private double width = 100.0d, height = 100.0d;
		public static readonly Regex regex = RegexUtils.GetRegex (RegexUtils.Concat (RegexUtils.NameRegex ("width", RegexUtils.DoubleRegex), " *(x| ) *", RegexUtils.NameRegex ("width", RegexUtils.DoubleRegex)));

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
				double w = double.Parse (match.Groups ["width"].Value);
				double h = double.Parse (match.Groups ["height"].Value);
				return new DocumentSize (w, h);
			} else {
				throw new FormatException ("The document size does not meet the format criteria.");
			}
		}

		public override string ToString () {
			return string.Format ("{0} x {1}", this.Width, this.Height);
		}
	}
}

