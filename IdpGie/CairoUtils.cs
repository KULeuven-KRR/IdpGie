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
using IdpGie.Utils;

namespace IdpGie.Draws {
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

