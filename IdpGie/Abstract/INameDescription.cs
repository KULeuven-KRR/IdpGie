//
//  INameDescription.cs
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
	/// An interface that combines the <see cref="IName"/> and <see cref="IDescription"/> interface.
	/// </summary>
	/// <remarks>
	/// <para>This interface is popular for aspects a user can select: by providing an identifer and a description
	/// on the expected behavior.</para>
	/// </remarks>
	public interface INameDescription : IName, IDescription {
	}

}

