using System;
using System.Text.RegularExpressions;

namespace IdpGie {
	public class Geometry : CloneableBase<Geometry> {
		public const string identifier_width = @"w";
		public const string identifier_heigh = @"h";
		public const int DefaultWidth = 0x05, DefaultHeight = 0x05;
		public const int MinWidth = 0x01, MinHeight = 0x01;
		private int width = DefaultWidth, height = DefaultHeight;
		private static readonly Regex regex = RegexDevelopment.IntegerRegex / identifier_width + "[^0-9+-.]+" + RegexDevelopment.IntegerRegex / identifier_heigh;

		public int Width {
			get {
				return width;
			}
			set {
				width = Math.Max (MinWidth, value);
			}
		}

		public int Height {
			get {
				return height;
			}
			set {
				height = Math.Max (MinHeight, value);
			}
		}

		public Geometry (int width = DefaultWidth, int height = DefaultHeight) {
			this.Width = width;
			this.Height = height;
		}

		public static Geometry Parse (string text) {
			Match match = regex.Match (text);
			if (match.Success) {
				int w = int.Parse (match.Groups [identifier_width].Value);
				int h = int.Parse (match.Groups [identifier_heigh].Value);
				return new Geometry (w, h);
			} else {
				throw new FormatException (string.Format ("The geometry \"{0}\" does not meet the format criteria.", text));
			}
		}

		public override string ToString () {
			return string.Format ("{0} x {1}", this.Width, this.Height);
		}

		public void Collapse (int size) {
			if (size < this.width) {
				this.width = size;
				this.height = 0x01;
			} else {
				this.height = (size + width - 0x01) / width;
			}
		}

		public Geometry CollapseClone (int size) {
			Geometry g = this.Clone ();
			g.Collapse (size);
			return g;
		}

		#region CloneableBase implementation

		public override Geometry Clone () {
			return new Geometry (this.width, this.height);
		}

		#endregion

	}
}

