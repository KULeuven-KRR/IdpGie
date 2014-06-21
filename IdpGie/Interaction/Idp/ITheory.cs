//
//  ITheory.cs
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
using IdpGie.Abstract;

namespace IdpGie.Interaction.Idp {
	/// <summary>
	/// An interface specifying a theory: a set of constraints that specify the <see cref="IStructure"/> of a specified
	/// <see cref="IVocabulary"/>.
	/// </summary>
	public interface ITheory : IName, ICloneable<ITheory>, IVocabularySensitive {

		/// <summary>
		/// Adds definitional completion of all the definitions in the theory.
		/// </summary>
		void Completion ();

		/// <summary>
		/// Rewrites the formulas with the same operations in their children formulas by reducing the nesting.
		/// </summary>
		/// <example>
		/// Given a clause <c>a and (b and c)</c> is rewritten to <c>a and b and c</c>.
		/// </example>
		void Flatten ();

		/// <summary>
		/// Creates a new theory which is the result of combining (the conjunction) of this and the given <see cref="ITheory"/>.
		/// </summary>
		/// <param name="other">The given <see cref="ITheory"/> to merge with.</param>
		ITheory Merge (ITheory other);

		/// <summary>
		/// Push negations inwards until they are right in from of literals.
		/// </summary>
		void PushNegations ();

		/// <summary>
		/// Move nested terms out of predicates (except for the equality-predicate) and functions.
		/// </summary>
		void RemoveNesting ();
	}
}

