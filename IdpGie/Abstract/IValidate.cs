//
//  IValidate.cs
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
	/// An interface specifying that the state of this object can be validated.
	/// </summary>
	public interface IValidate {

		/// <summary>
		/// Validates the state of this instance.
		/// </summary>
		/// <returns>
		/// <c>true</c> if the state of this instance is valid, <c>false</c> otherwise.
		/// </returns>
		bool Validate ();

	}

}