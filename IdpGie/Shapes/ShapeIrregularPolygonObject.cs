//
//  IdpdIrregularPolygonObject.cs
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
using System.Linq;
using System.Collections.Generic;
using Cairo;
using IdpGie.Logic;
using IdpGie.Geometry;

namespace IdpGie.Shapes {
	public class ShapeIrregularPolygonObject : ShapePolygon {
		private readonly List<IdpGie.Geometry.Point3> points;

		public ShapeIrregularPolygonObject (IFunctionInstance name, IEnumerable<IdpGie.Geometry.Point3> points) : base (name) {
			this.points = points.ToList ();
			double minx = double.PositiveInfinity, miny = double.PositiveInfinity, maxx = double.NegativeInfinity, maxy = double.NegativeInfinity;
			foreach (IdpGie.Geometry.Point3 p in this.points) {
				minx = Math.Min (minx, p.X);
				miny = Math.Min (miny, p.Y);
				maxx = Math.Max (maxx, p.X);
				maxy = Math.Max (maxy, p.Y);
			}
			this.TextOffset = new IdpGie.Geometry.Point3 (0.5d * (minx + maxx), 0.5d * (miny + maxy));
		}

		public override IEnumerable<PointD> GetPoints () {
			return points.Select (x => (PointD)x);
		}
	}
}

