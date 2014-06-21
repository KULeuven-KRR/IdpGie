//
//  IPredicateInterpretation.cs
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
	/// An interface describing the interpretation of a <see cref="IVocabularyPredicate"/>.
	/// </summary>
	public interface IPredicateInterpretation {

		/// <summary>
		/// Gets a <see cref="IPredicateTable"/> that contains all <see cref="ITuple"/> instances that are certainly true.
		/// </summary>
		/// <value>The <see cref="IPredicateTable"/> of <see cref="ITuple"/> instances that are certainly true.</value>
		IPredicateTable CertainlyTrue {
			get;
		}

		/// <summary>
		/// Gets a <see cref="IPredicateTable"/> that contains all <see cref="ITuple"/> instances that are certainly false.
		/// </summary>
		/// <value>The <see cref="IPredicateTable"/> of <see cref="ITuple"/> instances that are certainly false.</value>
		IPredicateTable CertainlyFalse {
			get;
		}
	}
}

