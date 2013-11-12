//
//  Box2d.cs
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
using IdpGie.Logic.Structures;

namespace IdpGie {

    public class Box2d : IGeometry2d {

        private double xmin;
        private double xmax;
        private double ymin;
        private double ymax;

        public double Xmin {
            get {
                return this.xmin;
            }
            set {
                this.xmin = value;
            }
        }

        public double Xmax {
            get {
                return this.xmax;
            }
            set {
                this.xmax = value;
            }
        }

        public double Ymin {
            get {
                return this.ymin;
            }
            set {
                this.ymin = value;
            }
        }

        public double Ymax {
            get {
                return this.ymax;
            }
            set {
                this.ymax = value;
            }
        }

        #region IGeometry2d implementation
        public Box2d SurroundingBox {
            get {
                return this;
            }
        }
        #endregion

        public Box2d (double xmin, double xmax, double ymin, double ymax) {
            this.Xmin = xmin;
            this.Xmax = xmax;
            this.Ymin = ymin;
            this.Ymax = ymax;
        }

        #region IGeometry2d implementation
        public bool Contains (Point pt) {
            return xmin <= pt.X && pt.X <= xmax && ymin <= pt.Y && pt.Y <= ymax;
        }
        #endregion

    }
}

