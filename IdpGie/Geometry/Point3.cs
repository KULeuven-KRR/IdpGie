//
//  Point3.cs
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

using Cairo;
using OpenTK;
using IdpGie.Logic;

namespace IdpGie.Geometry {

	/// <summary>
	/// An implementation of <see cref="IPoint3"/> that contains maximally three dimensions and supports
	/// reflection constors together with transformations.
	/// </summary>
	[FunctionStructure("point",TermType.Point)]
	public struct Point3 : IPoint3 {

		private double x;
		private double y;
		private double z;

		#region IPoint3 implementation
		/// <summary>
		///  Gets or sets the x-coordinate of this point. 
		/// </summary>
		/// <value>
		///  The x-coordinate of this point. 
		/// </value>
		public double X {
			get {
				return x;
			}
			set {
				this.x = value;
			}
		}

		/// <summary>
		///  Gets or sets the y-coordinate of this point. 
		/// </summary>
		/// <value>
		///  The y-coordinate of this point. 
		/// </value>
		public double Y {
			get {
				return y;
			}
			set {
				this.y = value;
			}
		}

		/// <summary>
		///  Gets or sets the z-coordinate of this point. 
		/// </summary>
		/// <value>
		///  The z-coordinate of this point. 
		/// </value>
		public double Z {
			get {
				return this.z;
			}
			set {
				this.z = value;
			}
		}
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Geometry.Point3"/> struct with a given x-coordiante.
		/// </summary>
		/// <param name='x'>
		/// The given x-coordinate.
		/// </param>
		[FunctionStructureConstructor(TermType.Float)]
		public Point3 (double x) : this(x,0.0d,0.0d) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Geometry.Point3"/> struct with a given x- and y-coordinate.
		/// </summary>
		/// <param name='x'>
		/// The given x-coordinate.
		/// </param>
		/// <param name='y'>
		/// The given y-coordinate.
		/// </param>
		[FunctionStructureConstructor(TermType.Float,TermType.Float)]
		public Point3 (double x, double y) : this(x,y,0.0d) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Geometry.Point3"/> struct with a given x-, y- and z-coordinate.
		/// </summary>
		/// <param name='x'>
		/// The given x-coordinate.
		/// </param>
		/// <param name='y'>
		/// The given y-coordinate.
		/// </param>
		/// <param name='z'>
		/// The given z-coordinate.
		/// </param>
		[FunctionStructureConstructor(TermType.Float,TermType.Float,TermType.Float)]
		public Point3 (double x, double y, double z) {
			this.x = x;
			this.y = y;
			this.z = z;
		}

		#region IPoint3 implementation
		/// <summary>
		/// Transform this point with the given <see cref="Matrix4d"/>.
		/// </summary>
		/// <param name='m'>
		/// The given transformation matrix.
		/// </param>
		public void Transform (Matrix4d m) {
			double newx = this.x * m.M11 + this.y * m.M12 + this.z * m.M13 + m.M14;
			double newy = this.x * m.M21 + this.y * m.M22 + this.z * m.M23 + m.M24;
			double newz = this.x * m.M31 + this.y * m.M32 + this.z * m.M33 + m.M34;
			this.x = newx;
			this.y = newy;
			this.z = newz;
		}

		/// <summary>
		/// Transform this point with the given <see cref="Matrix4"/>.
		/// </summary>
		/// <param name='m'>
		/// The given transformation matrix.
		/// </param>
		public void Transform (Matrix4 m) {
			double newx = this.x * m.M11 + this.y * m.M12 + this.z * m.M13 + m.M14;
			double newy = this.x * m.M21 + this.y * m.M22 + this.z * m.M23 + m.M24;
			double newz = this.x * m.M31 + this.y * m.M32 + this.z * m.M33 + m.M34;
			this.x = newx;
			this.y = newy;
			this.z = newz;
		}

		/// <summary>
		/// Transform this point with the given <see cref="Matrix"/>.
		/// </summary>
		/// <param name='m'>
		/// The given transformation matrix.
		/// </param>
		public void Transform (Matrix m) {
			double newx = this.x * m.Xx + this.y * m.Xy + m.X0;
			double newy = this.x * m.Yx + this.y * m.Yy + m.Y0;
			this.x = newx;
			this.y = newy;
		}
		#endregion

		#region Equals method
		/// <summary>
		/// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="IdpGie.Geometry.Point3"/>.
		/// </summary>
		/// <param name='obj'>
		/// The <see cref="System.Object"/> to compare with the current <see cref="IdpGie.Geometry.Point3"/>.
		/// </param>
		/// <returns>
		/// <c>true</c> if the specified <see cref="System.Object"/> is equal to the current
		/// <see cref="IdpGie.Geometry.Point3"/>; otherwise, <c>false</c>.
		/// </returns>
		public override bool Equals (object obj) {
			if (obj is Point3) {
				Point3 p = (Point3)obj;
				return (this.X == p.X && this.Y == p.Y && this.Z == p.Z);
			}
			return base.Equals (obj);
		}
		#endregion

		#region GetHashCode method
		/// <summary>
		/// Serves as a hash function for a <see cref="IdpGie.Geometry.Point3"/> object.
		/// </summary>
		/// <returns>
		/// A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a hash table.
		/// </returns>
		public override int GetHashCode () {
			return base.GetHashCode () ^ this.X.GetHashCode () ^ (this.Y.GetHashCode () << 0x0b) ^ (this.Z.GetHashCode () << 0x16);
		}
		#endregion

		#region ToString method
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="IdpGie.Geometry.Point3"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents the current <see cref="IdpGie.Geometry.Point3"/>.
		/// </returns>
		public override string ToString () {
			return string.Format ("({0} ; {1} ; {2})", this.X, this.Y, this.Z);
		}
		#endregion

		#region converter operators
		/// <summary>
		/// Converts the given <see cref="Point3"/> to the <see cref="PointD"/>.
		/// </summary>
		/// <param name='v'>
		/// The given <see cref="Point3"/> to convert.
		/// </param>
		public static explicit operator PointD (Point3 v) {
			return new PointD (v.x, v.y);
		}

		/// <summary>
		/// Converts the given <see cref="PointD"/> to the <see cref="Point3"/>.
		/// </summary>
		/// <param name='v'>
		/// The given <see cref="PointD"/> to convert.
		/// </param>
		public static explicit operator Point3 (PointD v) {
			return new Point3 (v.X, v.Y);
		}

		/// <summary>
		/// Converts the given <see cref="Vector2"/> to the <see cref="Point3"/>.
		/// </summary>
		/// <param name='v'>
		/// The given <see cref="Vector2"/> to convert.
		/// </param>
		public static explicit operator Point3 (Vector2 v) {
			return new Point3 (v.X, v.Y);
		}

		/// <summary>
		/// Converts the given <see cref="Vector2d"/> to the <see cref="Point3"/>.
		/// </summary>
		/// <param name='v'>
		/// The given <see cref="Vector2d"/> to convert.
		/// </param>
		public static explicit operator Point3 (Vector2d v) {
			return new Point3 (v.X, v.Y);
		}

		/// <summary>
		/// Converts the given <see cref="Vector3"/> to the <see cref="Point3"/>.
		/// </summary>
		/// <param name='v'>
		/// The given <see cref="Vector3"/> to convert.
		/// </param>
		public static explicit operator Point3 (Vector3 v) {
			return new Point3 (v.X, v.Y, v.Z);
		}

		/// <summary>
		/// Converts the given <see cref="Vector3d"/> to the <see cref="Point3"/>.
		/// </summary>
		/// <param name='v'>
		/// The given <see cref="Vector3d"/> to convert.
		/// </param>
		public static explicit operator Point3 (Vector3d v) {
			return new Point3 (v.X, v.Y, v.Z);
		}
		#endregion

	}

}