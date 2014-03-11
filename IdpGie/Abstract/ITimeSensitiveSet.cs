//
//  ITimeSensitiveSet.cs
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
	/// An interface specifing that the instance is an <see cref="ITimeSensitive"/>, but that the <see cref="ITimeSensitive.Time"/> can be set as well.
	/// </summary>
	/// <remarks>
	/// <para>One can of course implement a setter for the <see cref="ITimeSensitive.Time"/> property. However the specifications of .NET state that interfaces cannot add a setter to an already existing property.</para>
	/// </remarks>
	public interface ITimeSensitiveSet : ITimeSensitive {

		/// <summary>
		/// Sets the time of the event to the given time.
		/// </summary>
		/// <param name='time'>
		/// The given time.
		/// </param>
		void SetTime (double time);

	}
}

