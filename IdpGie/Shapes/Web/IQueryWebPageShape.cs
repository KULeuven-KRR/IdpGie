//
//  IQueryWebPageShape.cs
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

using IdpGie.Shapes.Pages;

namespace IdpGie.Shapes.Web {
	/// <summary>
	/// A marker interface that specifies that the instance implements both a <see cref="IQueryWebPage"/>
	/// and <see cref="IWebShape"/>. This is done to save memory of there is a one-to-one mapping between the
	/// shape and the query page.
	/// </summary>
	public interface IQueryWebPageShape : IQueryWebPage, IWebShape {
	}
}

