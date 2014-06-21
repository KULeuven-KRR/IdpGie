//
//  IIdpSession.cs
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
using IdpGie.Core;

namespace IdpGie.Interaction.Idp {
	/// <summary>
	/// An interface describing an interactive session with the idp system, since this interface is an interactive
	/// session, the <see cref="IIdpInference"/> interface is supported as well.
	/// </summary>
	public interface IIdpSession : IProcessSession, IIdpInference {

		/// <summary>
		/// Gets the name of the default structure of the session.
		/// </summary>
		/// <value>The name of the default structure of the session.</value>
		string StructureName {
			get;
		}

		/// <summary>
		/// Gets the name of the default theory of the session.
		/// </summary>
		/// <value>The name of the default theory of the session.</value>
		string TheoryName {
			get;
		}

		/// <summary>
		/// Gets the name of the default vocabulary of the session.
		/// </summary>
		/// <value>The name of the default vocabulary of the session.</value>
		string VocabularyName {
			get;
		}

		/// <summary>
		/// Gets the default vocabulary of the idp session.
		/// </summary>
		/// <returns>An <see cref="IVocabulary"/> instance representing the default vocabulary.</returns>
		IVocabulary getVocabulary ();

		/// <summary>
		/// Gets the vocabulary of the idp session with the given name.
		/// </summary>
		/// <returns>An <see cref="IVocabulary"/> instance representing the vocabulary with the given name.</returns>
		/// <param name="name">The name of the vocabulary to query for.</param>
		IVocabulary getVocabulary (string name);

		/// <summary>
		/// Gets the default structure of the idp session.
		/// </summary>
		/// <returns>An <see cref="IStructure"/> instance representing the default structure.</returns>
		IStructure getStructure ();

		/// <summary>
		/// Gets the structure of the idp session with the given name.
		/// </summary>
		/// <returns>An <see cref="IStructure"/> instance representing the structure with the given name.</returns>
		/// <param name="name">The name of the structure to query for.</param>
		IStructure getStructure (string name);

		/// <summary>
		/// Gets the default theory of the idp session.
		/// </summary>
		/// <returns>An <see cref="ITheory"/> instance representing the default theory.</returns>
		ITheory getTheory ();

		/// <summary>
		/// Gets the theory of the idp session with the given name.
		/// </summary>
		/// <returns>An <see cref="ITheory"/> instance representing the theory with the given name.</returns>
		/// <param name="name">The name of the theory to query for.</param>
		ITheory getTheory (string name);
	}
}

