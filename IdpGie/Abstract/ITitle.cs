//
//  ITitle.cs
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
	/// An interface that specifies the object has a <see cref="ITitle.Title"/>.
	/// </summary>
	/// <remarks>
	/// <para>This interface is strongly related to, but not the same as <see cref="IName"/>. A name is associated to the element while a title is more a property.
	/// In general for each name, there is only one <see cref="IName"/> object while for a title, several <see cref="ITitle"/> objects might exist.</para>
	/// </remarks>
	public interface ITitle {

		/// <summary>
		/// Gets the title of this object.
		/// </summary>
		/// <value>
		/// The title of this object.
		/// </value>
		string Title {
			get;
		}

	}
}

