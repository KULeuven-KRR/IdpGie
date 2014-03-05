//
//  IdpEllipseObject.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
//
//  Copyright (c) 2013 Willem Van Onsem
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
using Cairo;
using System;
using IdpGie.Logic;
using IdpGie.Utils;

namespace IdpGie.Shapes {
	public class ShapeEllipse : Shape<ShapeState> {
		private double width;
		private double height;

		public double Width {
			get {
				return width;
			}
			set {
				width = value;
			}
		}

		public double Height {
			get {
				return height;
			}
			set {
				height = value;
			}
		}

		public ShapeEllipse (IFunctionInstance name, double width, double height) : base (name) {
			this.width = width;
			this.height = height;
		}

		protected override void InnerPaintObject (Context ctx) {
			ctx.Save ();
			ctx.Translate (0.5d * this.Width, 0.5d * this.Height);
			ctx.Scale (0.5d * this.Width, 0.5 * this.Height);
			ctx.Arc (0.0d, 0.0d, 1.0d, 0.0d, MathExtra.Theta);
			ctx.Restore ();
			base.InnerPaintObject (ctx);
		}
	}
}

