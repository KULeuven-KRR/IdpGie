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

namespace IdpGie {

    public class IdpdRegularPolygonObject : IdpdPolygonObject {

        private int nbOfEdges;
        private double sizeOfEdges;

        public int NumberOfEdges {
            get {
                return this.nbOfEdges;
            }
            set {
                this.nbOfEdges = Math.Max (0x00, this.nbOfEdges);
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

        public IdpdRegularPolygonObject (IFunctionInstance name, int nbOfEdges, double sizeOfEdges) : base(name) {
            this.NumberOfEdges = nbOfEdges;
            this.SizeOfEdges = sizeOfEdges;
        }

        public override IEnumerable<PointD> GetPoints () {
            int n = this.nbOfEdges;
            double e = this.sizeOfEdges;
            double alpha = 0.0d;
            double beta = MathExtra.Theta / n;
            for (int i = n-0x01; i >= 0x00; i--) {
                yield return new PointD (e * Math.Cos (alpha), e * Math.Sin (alpha));
                alpha += beta;
            }
        }

    }
}

