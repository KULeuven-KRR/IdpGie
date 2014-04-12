//
//  IDrawTheorySensitive.cs
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

namespace IdpGie.Core {

	/// <summary>
	/// An interface specifying that the instance is sensitive to modifications of the <see cref="IDrawTheory"/> and therefore contains a reference to it.
	/// </summary>
	public interface IDrawTheorySensitive {

		/// <summary>
		/// Gets or sets the theory to which the <see cref="IDrawTheorySensitive"/> is sensitive to.
		/// </summary>
		/// <value>
		/// The theory to which the <see cref="IDrawTheorySensitive"/> is sensitive to.
		/// </value>
		IDrawTheory Theory {
			get;
			set;
		}

	}

}