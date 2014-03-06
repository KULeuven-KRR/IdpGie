//
//  NamedAttributeBase.cs
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

using System;

namespace IdpGie.Abstract {

	/// <summary>
	/// The implementation of a <see cref="Attribute"/> that has a <see cref="IName.Name"/> attached to it.
	/// </summary>
	public class NamedAttributeBase : Attribute, IName {

		private readonly string name;

		/// <summary>
		///  Gets the name associated with the attribute.
		/// </summary>
		/// <value>
		///  The name associated with the attribute. 
		/// </value>
		public string Name {
			get {
				return this.name;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Abstract.NamedAttributeBase"/> class with a given name.
		/// </summary>
		/// <param name='name'>
		/// The name associated with the attribute.
		/// </param>
		protected NamedAttributeBase (string name) {
			this.name = name;
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="IdpGie.Abstract.NamedAttributeBase"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents the current <see cref="IdpGie.Abstract.NamedAttributeBase"/>.
		/// </returns>
		/// <remarks>
		/// <para>By default, the textual representation of a <see cref="NamedAttributeBase"/> is its <see cref="IName.Name"/>.</para>
		/// </remarks>
		public override string ToString () {
			return this.name;
		}

	}
}

