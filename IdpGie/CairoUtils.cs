//
//  CairoUtils.cs
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
using System;
using System.Collections;
using System.Collections.Generic;
using Cairo;

namespace IdpGie.UserInterface {
	public static class CairoUtils {
		public static void LineTo (this Context ctx, params double[] vals) {
			if (vals != null && vals.Length > 0x00) {
				IEnumerator enu = vals.GetEnumerator ();
				while (enu.MoveNext ()) {
					double xn = (double)enu.Current;
					if (enu.MoveNext ()) {
						double yn = (double)enu.Current;
						ctx.LineTo (xn, yn);
					}
				}
			}
		}

		public static void MoveTo (this Context ctx, IdpGie.Point p) {
			ctx.MoveTo (p.X, p.Y);
		}

		public static void LineTo (this Context ctx, IdpGie.Point p) {
			ctx.LineTo (p.X, p.Y);
		}

		public static void CurveTo (this Context ctx, IdpGie.Point p1, IdpGie.Point p2, IdpGie.Point p3) {
			ctx.CurveTo (p1.X, p1.Y, p2.X, p2.Y, p3.X, p3.Y);
		}

		public static void SetFill (this Context ctx, Color c) {
			ctx.SetSourceRGBA (c.R, c.G, c.B, c.A);
		}

		public static void SetFill (this Context ctx, double r, double g, double b) {
			ctx.SetSourceRGB (r, g, b);
		}

		public static void SetFill (this Context ctx, double r, double g, double b, double a) {
			ctx.SetSourceRGBA (r, g, b, a);
		}

		public static void SetFill (this Context ctx, Surface surface) {
			ctx.SetSource (surface);
		}

		public static void SetFill (this Context ctx, Surface surface, double x, double y) {
			ctx.SetSource (surface, x, y);
		}

		public static void SetFill (this Context ctx, Pattern pattern) {
			ctx.Pattern = pattern;
		}

		public static void MoveLineTo (this Context ctx, IEnumerable<PointD> pts) {
			IEnumerable<PointD> tail;
			ctx.MoveTo (pts.SplitHead (out tail));
			foreach (PointD pt in tail) {
				ctx.LineTo (pt);
			}
		}

		public static void LineTo (this Context ctx, params PointD[] vals) {
			if (vals != null) {
				foreach (PointD p in vals) {
					ctx.LineTo (p);
				}
			}
		}

		public static void RelLineTo (this Context ctx, params double[] vals) {
			if (vals != null && vals.Length > 0x00) {
				IEnumerator enu = vals.GetEnumerator ();
				while (enu.MoveNext ()) {
					double xn = (double)enu.Current;
					if (enu.MoveNext ()) {
						double yn = (double)enu.Current;
						ctx.RelLineTo (xn, yn);
					}
				}
			}
		}

		public static void LineTo (this Context ctx, params Distance[] vals) {
			if (vals != null) {
				foreach (Distance p in vals) {
					ctx.RelLineTo (p);
				}
			}
		}
	}
}

