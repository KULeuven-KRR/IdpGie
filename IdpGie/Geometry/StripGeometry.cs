using System;
using System.Text.RegularExpressions;
using IdpGie.Abstract;
using IdpGie.Utils;

namespace IdpGie.Geometry {

	/// <summary>
	/// An implementation of the <see cref="IStripGeometry"/> that describes how frames are organized in the graphical output.
	/// </summary>
	public class StripGeometry : CloneableBase<IStripGeometry>, IStripGeometry {

		#region Constants
		/// <summary>
		/// Gets the identifier of the <see cref="ParserRegex"/> for the <see cref="Width"/> value.
		/// </summary>
		public const string IdentifierWidth = @"w";

		/// <summary>
		/// Gets the identifier of the <see cref="ParserRegex"/> for the <see cref="Height"/> value.
		/// </summary>
		public const string IdentifierHeigh = @"h";

		/// <summary>
		/// The default value for the <see cref="Width"/> property.
		/// </summary>
		public const int DefaultWidth = 0x05;

		/// <summary>
		/// The default value for the <see cref="Height"/> property.
		/// </summary>
		public const int DefaultHeight = 0x05;

		/// <summary>
		/// The minimum value for the <see cref="Width"/> property.
		/// </summary>
		public const int MinWidth = 0x01;

		/// <summary>
		/// The minimum value for the <see cref="Height"/> property.
		/// </summary>
		public const int MinHeight = 0x01;

		/// <summary>
		/// The regular expression to parse <see cref="StripGeometry"/> instances.
		/// </summary>
		public static readonly Regex ParserRegex = RegexDevelopment.IntegerRegex / IdentifierWidth + "[^0-9+-.]+" + RegexDevelopment.IntegerRegex / IdentifierHeigh;
		#endregion

		private int width = DefaultWidth, height = DefaultHeight;

		#region IStripGeometry
		/// <summary>
		///  Gets or sets the number of frames in the X-direction. 
		/// </summary>
		/// <value>
		///  The number of frames in the X-direction. 
		/// </value>
		public int Width {
			get {
				return width;
			}
			set {
				width = Math.Max (MinWidth, value);
			}
		}

		/// <summary>
		///  Gets or sets the number of frames in the Y-direction. 
		/// </summary>
		/// <value>
		///  The number of frames in the Y-direction. 
		/// </value>
		public int Height {
			get {
				return height;
			}
			set {
				height = Math.Max (MinHeight, value);
			}
		}
		#endregion
		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Geometry.StripGeometry"/> class with a specified number of frames in the X- and Y-direction.
		/// </summary>
		/// <param name='width'>
		/// The number of frames in the X-direction.
		/// </param>
		/// <param name='height'>
		/// The number of frames in the Y-direction.
		/// </param>
		public StripGeometry (int width = DefaultWidth, int height = DefaultHeight) {
			this.Width = width;
			this.Height = height;
		}

		#region Parse method
		/// <summary>
		/// Parses the specified text into a <see cref="StripGeometry"/> instance.
		/// </summary>
		/// <param name='text'>
		/// The texutal representation to parse.
		/// </param>
		/// <exception cref="FormatException">If the given textual representation does not match the <see cref="ParserRegex"/> format.</exception>
		public static StripGeometry Parse (string text) {
			Match match = ParserRegex.Match (text);
			if (match.Success) {
				int w = int.Parse (match.Groups [IdentifierWidth].Value);
				int h = int.Parse (match.Groups [IdentifierHeigh].Value);
				return new StripGeometry (w, h);
			} else {
				throw new FormatException (string.Format ("The geometry \"{0}\" does not meet the format criteria.", text));
			}
		}
		#endregion

		#region ToString method
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="IdpGie.Geometry.StripGeometry"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents the current <see cref="IdpGie.Geometry.StripGeometry"/>.
		/// </returns>
		public override string ToString () {
			return string.Format ("{0} x {1}", this.Width, this.Height);
		}
		#endregion

		#region IStripGeometry implementation
		/// <summary>
		/// Collapse this <see cref="IStripGeometry"/> with the given number of required frames.
		/// </summary>
		/// <param name='size'>
		/// The required number of frames.
		/// </param>
		public void Collapse (int size) {
			if (size < this.width) {
				this.width = size;
				this.height = 0x01;
			} else {
				this.height = (size + width - 0x01) / width;
			}
		}

		/// <summary>
		/// Collapses a clone of this <see cref="IStripGeometry"/>.
		/// </summary>
		/// <returns>
		/// A clone of this <see cref="IStripGeometry"/> that is collapsed with the given <paramref name="size"/>.
		/// </returns>
		/// <param name='size'>
		/// The required number of frames.
		/// </param>
		public IStripGeometry CollapseClone (int size) {
			IStripGeometry g = this.Clone ();
			g.Collapse (size);
			return g;
		}
		#endregion

		#region CloneableBase implementation
		/// <summary>
		/// Create a new instance of a <see cref="IStripGeometry"/> that contains the same information.
		/// </summary>
		public override IStripGeometry Clone () {
			return new StripGeometry (this.width, this.height);
		}

		#endregion

	}
}

