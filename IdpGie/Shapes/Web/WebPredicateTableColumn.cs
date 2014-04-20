//
//  WebPredicateTableColumn.cs
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
using System.Xml.Serialization;
using IdpGie.Abstract;

namespace IdpGie.Shapes.Web {
	/// <summary>
	/// A class representing a table in the <see cref="WebPredicateTable"/> class.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The columns contain the text that should be displayed in the table header together withe the index
	/// of the queried predicate.
	/// </para>
	/// </remarks>
	[XmlType("PredicateTableColumn")]
	public class WebPredicateTableColumn : NameIndexBase {

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="WebPredicateTableColumn"/> class.
		/// </summary>
		/// <remarks>
		/// <para>Used for XML serialization purposes.</para>
		/// </remarks>
		public WebPredicateTableColumn () {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="WebPredicateTableColumn"/> class with a name and index.
		/// </summary>
		/// <param name="name">The name of the column.</param>
		/// <param name="index">The index of the predicate queried for this column.</param>
		public WebPredicateTableColumn (string name, int index) {
		}
		#endregion
	}
}

