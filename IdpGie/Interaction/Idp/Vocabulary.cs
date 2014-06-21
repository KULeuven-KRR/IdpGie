//
//  Vocabulary.cs
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
	/// An implementation of the <see cref="IVocabulary"/> interface. The default implementation to interact with
	/// the IDP system.
	/// </summary>
	public class Vocabulary : IdpIdentifier, IVocabulary {

		#region IVocabulary implementation
		/// <summary>
		/// Gets the <see cref="Vocabulary"/> with the specified predicatename.
		/// </summary>
		/// <param name="predicatename">The name of the predicate to query.</param>
		public IVocabularyPredicate this [string predicatename] {
			get {
				throw new NotImplementedException ();
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Vocabulary"/> class with a given name and idp session.
		/// </summary>
		/// <param name="name">The name of the identifier.</param>
		/// <param name="session">The idp session that is the origin of the identifier.</param>
		public Vocabulary (string name, IIdpSession session) : base(name,session) {
		}
		#endregion
	}
}

