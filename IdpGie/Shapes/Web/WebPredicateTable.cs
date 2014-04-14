//
//  WebPredicateTable.cs
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
using System.Xml.Serialization;

namespace IdpGie.Shapes.Web {

	/// <summary>
	/// A webshape that displays a table that contains the values of the predicates.
	/// </summary>
	[XmlType("PredicateTable")]
	[WebShape("PredicateTable")]
	public class WebPredicateTable {

		[XmlAttribute("query")]
		public string Query {
			get;
			set;
		}

		public WebPredicateTable () {
		}

	}
}

