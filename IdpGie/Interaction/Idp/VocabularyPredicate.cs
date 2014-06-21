//
//  VocabularyPredicate.cs
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
namespace IdpGie.Interaction.Idp {
	/// <summary>
	/// A basic implemetation of the <see cref="IVocabularyPredicate"/> interface. A vocabulary predicate
	/// is an identifier that points to a predicate given a <see cref="IVocabulary"/>.
	/// </summary>
	public class VocabularyPredicate : Identifier, IVocabularyPredicate {

		#region IVocabularySensitive implementation
		/// <summary>
		/// Gets or sets the vocabulary of the predicate name.
		/// </summary>
		/// <value>The vocabulary of the predicate name.</value>
		public IVocabulary Vocabulary {
			get;
			protected set;
		}
		#endregion
		#region IIdpIdentifier implementation
		/// <summary>
		/// Gets the idp session from which the identifier originates.
		/// </summary>
		/// <value>The idp session from which the identifier originates.</value>
		public IIdpSession IdpSession {
			get {
				return this.Vocabulary.IdpSession;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="VocabularyPredicate"/> class.
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="vocabulary">Vocabulary.</param>
		public VocabularyPredicate (string name, IVocabulary vocabulary) : base(name) {
			this.Vocabulary = vocabulary;
		}
		#endregion
	}
}

