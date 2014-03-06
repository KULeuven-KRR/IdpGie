//
//  IVisible.cs
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
	/// Specifies that this object might be visible.
	/// </summary>
	public interface IVisible {

		/// <summary>
		/// Gets a value indicating whether this <see cref="IdpGie.Abstract.IVisible"/> is visible.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance is visible; otherwise, <c>false</c>.
		/// </value>
		bool Visible {
			get;
		}

	}
}

