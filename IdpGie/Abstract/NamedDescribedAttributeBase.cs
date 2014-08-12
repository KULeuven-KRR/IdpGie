//
//  NamedDescribedAttributeBase.cs
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
	/// An implementation of a <see cref="Attribute"/> that comes with a <see cref="IName.Name"/> and <see cref="IDescription.Description"/>.
	/// </summary>
	public abstract class NamedDescribedAttributeBase : NamedAttributeBase, INameDescription {
		private readonly string description;
		#region IDescription implementation
		/// <summary>
		///  Gets the description associated with this attribute.
		/// </summary>
		/// <value>
		///  The description associated with this attribute.
		/// </value>
		public string Description {
			get {
				return this.description;
			}
		}
		#endregion
		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Abstract.NamedDescribedAttributeBase"/> class with a specified name and description.
		/// </summary>
		/// <param name='name'>
		/// The name of the attribute.
		/// </param>
		/// <param name='description'>
		/// The description of the attribute.
		/// </param>
		protected NamedDescribedAttributeBase (string name, string description = "No description available") : base (name) {
			this.description = description;
		}
	}
}