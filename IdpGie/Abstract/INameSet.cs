//
//  INameSet.cs
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

namespace IdpGie.Abstract {

	/// <summary>
	/// An interface that specifies that besides having a name, the name of the instance can be modified as well.
	/// </summary>
	/// <remarks>
	/// <para>One can of course implement a setter for the name. However the specifications of .NET state that interfaces cannot add a setter to
	/// an already existing property.</para>
	/// </remarks>
	public interface INameSet : IName {

		/// <summary>
		/// Sets the name of the object to the given <paramref name="name"/>.
		/// </summary>
		/// <param name='name'>
		/// The new name of the object.
		/// </param>
		void SetName (string name);

	}

}

