//
//  IIdpInference.cs
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
using System.Collections.Generic;

namespace IdpGie.Interaction.Idp {
	/// <summary>
	/// An interface that enables the different types if IDP inference.
	/// </summary>
	public interface IIdpInference {

		/// <summary>
		/// Makes the given structure more precise than the given one by evaluating all definitions with known open
		/// symbols. This procedure works recursively: as long as some definitions of which all open symbols are known exists, it
		/// calculates the definition (possibly deriving open symbols or other defnitions).
		/// </summary>
		/// <returns>
		/// A structure that is more precise than the given one.
		/// </returns>
		/// <param name='theory'>
		/// The given theory that contains the definitions to calculate.
		/// </param>
		/// <param name='structure'>
		/// The given structure to make more precise.
		/// </param>
		IStructure CalculateDefintions (ITheory theory, IStructure structure);

		/// <summary>
		/// Create the reduced grounding of the given theory and structure.
		/// </summary>
		/// <param name="theory">The given theory that shapes the structure.</param>
		/// <param name="structure">The given structure to ground.</param>
		ITheory Ground (ITheory theory, IStructure structure);

		/// <summary>
		/// Prints the reduced grounding of the given theory and structure.
		/// </summary>
		/// <returns>The grounding.</returns>
		/// <param name="theory">The given theory that shapes the structure.</param>
		/// <param name="structure">The given structure to ground.</param>
		/// <remarks>This method improves the memory efficiency since the grounding is not stored internally.</remarks>
		string PrintGrounding (ITheory theory, IStructure structure);

		/// <summary>
		/// Returns a structure, made more precise than the input by grounding and unit propagation on the theory.
		/// </summary>
		/// <returns>A structure that is more precise than the input by grounding and unit propagation.</returns>
		/// <param name="theory">The given theory that shapes the structure.</param>
		/// <param name="structure">The given structure to propagate.</param>
		/// <remarks>
		/// <para>Returns nil when propagation makes the given structure inconsistent.</para>
		/// </remarks>
		IStructure GroundPropagate (ITheory theory, IStructure structure);

		/// <summary>
		/// Returns a structure, made more precise than the input by generating all the models and checking which
		/// literals always have the same truth value.
		/// </summary>
		/// <returns>A structure that is more precise than the input by grounding and unit propagation.</returns>
		/// <param name="theory">The given theory that shapes the structure.</param>
		/// <param name="structure">The given structure to propagate.</param>
		/// <remarks>
		/// <para>This grounding is complete: everything that can be derived from the theory will be derived.</para>
		/// <para>Returns nil when propagation makes the given structure inconsistent.</para>
		/// </remarks>
		IStructure OptimalPropagate (ITheory theory, IStructure structure);

		/// <summary>
		/// Returns a structure, made more precise than the input by doing symbolic propagation on the theory.
		/// </summary>
		/// <returns>A structure that is more precise than the input by grounding and unit propagation.</returns>
		/// <param name="theory">The given theory that shapes the structure.</param>
		/// <param name="structure">The given structure to propagate.</param>
		/// <remarks>
		/// <para>Returns nil when propagation makes the given structure inconsistent.</para>
		/// </remarks>
		IStructure Propagate (ITheory theory, IStructure structure);

		/// <summary>
		/// Performs initialisation for the progression inference.
		/// </summary>
		/// <returns>A tuple containing an <see cref="T:IEnumerable`1"/> of direct new structures, two structures
		/// and a vocabulary.</returns>
		/// <param name="theory">The given theory that shapes the structure.</param>
		/// <param name="structure">The given structure to propagate.</param>
		/// <remarks>
		/// <para>Can only be called with an LTC theory.</para>
		/// <para>The first and second <see cref="ITheory"/> are respectively the bistate and onestate variants of the
		/// structure.</para>
		/// <para>The first and second <see cref="IVocabulary"/> are respectively the bistate and onestate variants of the
		/// structure.</para>
		/// </remarks>
		System.Tuple<IEnumerable<IStructure>,ITheory,ITheory,IVocabulary,IVocabulary> Initialise (ITheory theory, IStructure structure);

		/// <summary>
		/// Performs one progression step for the progression inference.
		/// </summary>
		/// <param name="theory">The given theory that shapes the structure.</param>
		/// <param name="structure">The given structure to propagate.</param>
		/// <remarks>
		/// <para>Can only be called with an LTC theory.</para>
		/// </remarks>
		IEnumerable<IStructure> Progress (ITheory theory, IStructure structure);
	}
}