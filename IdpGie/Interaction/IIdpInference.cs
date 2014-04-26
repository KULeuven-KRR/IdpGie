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

namespace IdpGie.Interaction {
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
		//IIdpTheory Ground (IIdpTheory theory, IIdpStructure structure);
	}
}

