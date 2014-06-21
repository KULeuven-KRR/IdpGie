//
//  IIdpIdentifier.cs
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
	/// An interface specifying that the instance is an identifier in some weird environment that never works
	/// developed by the a team that takes more holidays than working days and has no documentation whatsoever.
	/// </summary>
	public interface IIdpIdentifier : IIdentifier {

		/// <summary>
		/// Gets the <see cref="IIdpSession"/> that is the origin of the identifier.
		/// </summary>
		/// <value>The idp session that is the origin of the identifier.</value>
		IIdpSession IdpSession {
			get;
		}
	}
}

