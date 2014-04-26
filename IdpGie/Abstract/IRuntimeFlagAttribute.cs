//
//  IRuntimeFlagAttribute.cs
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

namespace IdpGie.Abstract {

	/// <summary>
	/// An interface for an attribute to specify that the field corresponds to a runtime flag (this can be used to parse arguments).
	/// </summary>
	public interface IRuntimeFlagAttribute : INameDescription {

		/// <summary>
		/// Gets the alternatives names for the flag.
		/// </summary>
		/// <value>
		/// The alternatives names for the flag.
		/// </value>
		ICollection<string> Alternatives {
			get;
		}

		/// <summary>
		/// Gets the parser that parses the textual representation to the desired object.
		/// </summary>
		/// <value>
		/// The parser to convert the textual representation to the desired object.
		/// </value>
		Func<string,object> Parser {
			get;
		}

		/// <summary>
		/// Checks if the attribute comes with a parser.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance has a parser; otherwise, <c>false</c>.
		/// </value>
		bool HasParser {
			get;
		}

	}

}

