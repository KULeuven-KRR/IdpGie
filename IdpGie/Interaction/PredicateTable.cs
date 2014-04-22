//
//  PredicateTable.cs
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

using System;
using System.Collections.Generic;
using System.Text;

namespace IdpGie.Interaction {
	/// <summary>
	/// An implementation of the <see cref="IPredicateTable"/> interface. In other words a list of tuples. The
	/// default way to interact with the IDP system.
	/// </summary>
	public class PredicateTable : List<ITuple>, IPredicateTable {

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="PredicateTable"/> class.
		/// </summary>
		public PredicateTable () {
		}
		#endregion
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="PredicateTable"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="PredicateTable"/>.</returns>
		public override string ToString () {
			StringBuilder sb = new StringBuilder ();
			sb.Append ('{');
			bool rf = false, tf;
			foreach (ITuple tuple in this) {
				if (rf) {
					sb.Append (';');
				}
				tf = true;
				foreach (object entry in tuple) {
					if (tf) {
						sb.Append (',');
					}
					if (entry is string) {
						sb.Append ('"');
						sb.Append (entry);
						sb.Append ('"');
					} else {
						sb.Append (entry);
					}
					tf = true;
				}
				rf = true;
			}
			sb.Append ('}');
			return sb.ToString ();
		}
	}
}

