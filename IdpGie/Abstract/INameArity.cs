//
//  INameArity.cs
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

namespace IdpGie.Abstract {

	/// <summary>
	/// An interface combining the <see cref="IName"/> and <see cref="IArity"/>.
	/// </summary>
	/// <remarks>
	/// <para>This interface is popular in mathematics where a function has a name and an arity</para>
	/// </remarks>
	public interface INameArity : IName, IArity {

		/// <summary>
		/// Gets the signature of this object.
		/// </summary>
		/// <value>
		/// The signature of this object.
		/// </value>
		/// <remarks>
		/// <para>The signature of a method is a tuple that contains the name and the arity of that method.</para>
		/// </remarks>
		Tuple<string, int> Signature {
			get;
		}

	}

}