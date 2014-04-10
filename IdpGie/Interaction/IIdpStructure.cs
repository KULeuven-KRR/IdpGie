//
//  IIdpStructure.cs
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
	/// An interface that is a wrapper to the IDP structure type.
	/// </summary>
	public interface IIdpStructure {

		/// <summary>
		/// Determines whether this instance is consistent.
		/// </summary>
		/// <returns>
		/// <c>true</c> if this instance is consistent; otherwise, <c>false</c>.
		/// </returns>
		bool IsConsistent ();

		/// <summary>
		/// Sets all tuples of the given table to false. Modifies the table interpretation.
		/// </summary>
		/// <param name='predicate'>
		/// The given predicate to modify.
		/// </param>
		/// <param name='table'>
		/// The table that contains the collection of tuples to make false.
		/// </param>
		void MakeFalse (IIdpPredicate predicate, IIdpTable table);

		/// <summary>
		/// Sets the interpretation of the given tuple to false modifies the table-interpretation.
		/// </summary>
		/// <param name='predicate'>
		/// The given predicate to modify.
		/// </param>
		/// <param name='tuple'>
		/// The tuple that is set to false.
		/// </param>
		void MakeFalse (IIdpPredicate predicate, IIdpTuple tuple);

		/// <summary>
		/// Sets all tuples of the given table to true. Modifies the table interpretation.
		/// </summary>
		/// <param name='predicate'>
		/// The given predicate to modify.
		/// </param>
		/// <param name='table'>
		/// The table that contains the collection of tuples to make true.
		/// </param>
		void MakeTrue (IIdpPredicate predicate, IIdpTable table);

		/// <summary>
		/// Sets the interpretation of the given tuple to true modifies the table-interpretation.
		/// </summary>
		/// <param name='predicate'>
		/// The given predicate to modify.
		/// </param>
		/// <param name='tuple'>
		/// The tuple that is set to true.
		/// </param>
		void MakeTrue (IIdpPredicate predicate, IIdpTuple tuple);

		/// <summary>
		/// Sets all tuples of the given table to unknown. Modifies the table interpretation.
		/// </summary>
		/// <param name='predicate'>
		/// The given predicate to modify.
		/// </param>
		/// <param name='table'>
		/// The table that contains the collection of tuples to make unknown.
		/// </param>
		void MakeUnknown (IIdpPredicate predicate, IIdpTable table);

		/// <summary>
		/// Sets the interpretation of the given tuple to unknown modifies the table-interpretation.
		/// </summary>
		/// <param name='predicate'>
		/// The given predicate to modify.
		/// </param>
		/// <param name='tuple'>
		/// The tuple that is set to unknown.
		/// </param>
		void MakeUnKnown (IIdpPredicate predicate, IIdpTuple tuple);

	}
}

