//
//  Tuple.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
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
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace IdpGie.Interaction.Idp {
	/// <summary>
	/// A basic implementation of the <see cref="ITuple"/> interface. A <see cref="T:List`1"/> is used
	/// to store the elements.
	/// </summary>
	public class Tuple : List<object>, ITuple {

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Tuple"/> class.
		/// </summary>
		public Tuple () {
		}
		#endregion
		#region static methods
		public static Tuple Parse (string line) {
			bool isString;
			//reader
			foreach (char c in line) {
				switch (c) {

				}
			}
			return null;
		}
		#endregion
		#region ToString method
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="Tuple"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="Tuple"/>.</returns>
		public override string ToString () {
			StringBuilder sb = new StringBuilder ();
			sb.Append ('{');
			int i = 0x00;
			foreach (object e in this) {
				if (i > 0x00) {
					sb.Append (',');
				}
				if (e is string) {
					sb.Append ('"');
					sb.Append ((string)e);
					sb.Append ('"');
				} else {
					sb.Append (e);
				}
				i++;
			}
			sb.Append ('}');
			return sb.ToString ();
		}
		#endregion
	}
}