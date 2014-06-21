//
//  IdpIdentifier.cs
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

namespace IdpGie.Interaction.Idp {
	/// <summary>
	/// A basic implementation of a <see cref="IIdpIdentifier"/> instance.
	/// </summary>
	public class IdpIdentifier : Identifier, IIdpIdentifier {

		#region IIdpIdentifier implementation
		/// <summary>
		/// Gets the <see cref="IIdpSession"/> that is the origin of the identifier.
		/// </summary>
		/// <value>The idp session that is the origin of the identifier.</value>
		public IIdpSession IdpSession {
			get;
			protected set;
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="IdpIdentifier"/> class.
		/// </summary>
		/// <param name="name">The name of the identifier.</param>
		/// <param name="session">The idp session that is the origin of the identifier.</param>
		public IdpIdentifier (string name, IIdpSession session) : base(name) {
			this.IdpSession = session;
		}
		#endregion
	}
}

