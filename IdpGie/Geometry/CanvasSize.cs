//
//  CanvasSize.cs
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

using System;
using System.Text.RegularExpressions;
using IdpGie.Abstract;
using IdpGie.Utils;

namespace IdpGie.Geometry {

	/// <summary>
	/// A basic implementation of the <see cref="ICanvasSize"/> interface containing only a single frame, but with a margin.
	/// </summary>
	public class CanvasSize : CloneableBase<ICanvasSize>, ICanvasSize {

		private double width = DefaultWidth, height = DefaultHeight, margin = DefaultMargin;

		#region Constants
		/// <summary>
		/// Gets the identifier of the <see cref="ParserRegex"/> for the <see cref="Width"/> value.
		/// </summary>
		public const string IdentifierWidth = @"w";

		/// <summary>
		/// Gets the identifier of the <see cref="ParserRegex"/> for the <see cref="Height"/> value.
		/// </summary>
		public const string IdentifierHeight = @"h";

		/// <summary>
		/// Gets the identifier of the <see cref="ParserRegex"/> for the <see cref="Margin"/> value.
		/// </summary>
		public const string IdentifierMargin = @"m";

		/// <summary>
		/// The regular expression to parse <see cref="StripGeometry"/> instances.
		/// </summary>
		public static readonly Regex ParserRegex = RegexDevelopment.DoubleRegex / IdentifierWidth + "[^0-9+-.]+" + RegexDevelopment.DoubleRegex / IdentifierHeight + ~("[^0-9+-.]+" + RegexDevelopment.DoubleRegex / IdentifierMargin);

		/// <summary>
		/// The default value of the <see cref="ICanvasSize.Width"/>.
		/// </summary>
		public const double DefaultWidth = 640.0d;

		/// <summary>
		/// The default value of the <see cref="ICanvasSize.Height"/>.
		/// </summary>
		public const double DefaultHeight = 480.0d;

		/// <summary>
		/// The default value of the <see cref="ICanvasSize.Margin"/>.
		/// </summary>
		public const double DefaultMargin = 5.0d;

		/// <summary>
		/// The minimum value of the <see cref="ICanvasSize.Width"/>.
		/// </summary>
		public const double MinWidth = 1.0d;

		/// <summary>
		/// The minimum value of the <see cref="ICanvasSize.Height"/>.
		/// </summary>
		public const double MinHeight = 1.0d;

		/// <summary>
		/// The minimum value of the <see cref="ICanvasSize.Margin"/>.
		/// </summary>
		public const double MinMargin = 0.0d;
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
				return width;
			}
			set {
				width = Math.Max (MinWidth, value);
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
				return this.Width + 2.0d * this.Margin;
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

		/// <summary>
		///  Gets or sets the height of a single frame. 
		/// </summary>
		/// <value>
		///  The height of a single frame. 
		/// </value>
		public double Height {
			get {
				return height;
			}
			set {
				height = Math.Max (MinHeight, value);
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
				return this.Width + 2.0d * this.Margin;
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
				return margin;
			}
			set {
				margin = Math.Max (MinMargin, value);
			}
		}

		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Geometry.CanvasSize"/> class with a given width, height and margin.
		/// </summary>
		/// <param name='width'>
		/// The given initial width of the <see cref="ICanvasSize"/>.
		/// </param>
		/// <param name='height'>
		/// The given initial height of the <see cref="ICanvasSize"/>.
		/// </param>
		/// <param name='margin'>
		/// The given initial margin of the <see cref="ICanvasSize"/>.
		/// </param>
		public CanvasSize (double width = DefaultWidth, double height = DefaultHeight, double margin = DefaultMargin) {
			this.Width = width;
			this.Height = height;
			this.Margin = margin;
		}

		#region Parser method
		/// <summary>
		/// Converts the textual representation of the <see cref="CanvasSize"/> into an equivalent <see cref="CanvasSize"/> instance.
		/// </summary>
		/// <param name='text'>
		/// The textual representation to convert.
		/// </param>
		/// <exception cref="FormatException">If the given textual representation does not match the <see cref="ParserRegex"/> format.</exception>
		public static CanvasSize Parse (string text) {
			Match match = ParserRegex.Match (text);
			if (match.Success) {
				double w = double.Parse (match.Groups [IdentifierWidth].Value);
				double h = double.Parse (match.Groups [IdentifierHeight].Value);
				Group gm = match.Groups [IdentifierMargin];
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
		#endregion

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
			return new Point3 (this.Margin, this.Margin);
		}

		/// <summary>
		/// Widen the <see cref="ICanvasSize"/> such that the geometry of frames specified by <paramref name="geometry"/> is contained.
		/// </summary>
		/// <param name='geometry'>
		/// The given <see cref="IStripGeometry"/> of the frames.
		/// </param>
		public void StripSequence (IStripGeometry geometry) {
			int w = geometry.Width;
			double margin = this.Margin;
			this.Width = this.Width * w + margin * (w - 0x01);
			int h = geometry.Height;
			this.Height = this.Height * h + margin * (h - 0x01);
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
			ICanvasSize cs = this.Clone ();
			cs.StripSequence (geometry);
			return cs;
		}
		#endregion

		#region ToString method
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="IdpGie.Geometry.CanvasSize"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents the current <see cref="IdpGie.Geometry.CanvasSize"/>.
		/// </returns>
		public override string ToString () {
			return string.Format ("{0} x {1} x {2}", this.Width, this.Height, this.Margin);
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
			return new CanvasSize (this.width, this.height, this.margin);
		}
		#endregion

	}
}

