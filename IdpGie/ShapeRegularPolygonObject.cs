//
//  IdpdRegularPolygonObject.cs
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
using System.Collections.Generic;
using Cairo;
using IdpGie.Logic;
using IdpGie.Utils;

namespace IdpGie.Shapes {
	public class ShapeRegularPolygonObject : ShapePolygon {
		private int nbOfEdges;
		private double sizeOfEdges;
		private double alpha;

		public int NumberOfEdges {
			get {
				return this.nbOfEdges;
			}
			set {
				this.nbOfEdges = Math.Max (0x00, value);
			}
		}

		public double Alpha {
			get {
				return this.alpha;
			}
			set {
				this.alpha = value;
			}
		}

		public double Beta {
			get {
				return MathExtra.Theta / this.nbOfEdges;
			}
			set {
				this.NumberOfEdges = (int)Math.Round (MathExtra.InvTheta / value);
			}
		}

		public double SizeOfEdges {
			get {
				return this.sizeOfEdges;
			}
			set {
				this.sizeOfEdges = Math.Abs (value);
			}
		}

		public ShapeRegularPolygonObject (IFunctionInstance name, int nbOfEdges, double sizeOfEdges, double alpha = 0.0d) : base (name) {
			this.NumberOfEdges = nbOfEdges;
			this.SizeOfEdges = sizeOfEdges;
			this.alpha = alpha;
		}

		public override IEnumerable<PointD> GetPoints () {
			int n = this.NumberOfEdges;
			double e = this.sizeOfEdges;
			double alpha = this.Alpha;
			double beta = this.Beta;
			for (int i = n - 0x01; i >= 0x00; i--) {
				yield return new PointD (e * Math.Cos (alpha), e * Math.Sin (alpha));
				alpha += beta;
			}
		}
	}
}

