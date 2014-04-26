//
//  IQueryLandingPagePiece.cs
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
using IdpGie.Abstract;

namespace IdpGie.Shapes.Pages {
	/// <summary>
	/// An <see cref="IWebPagePiece"/> that is a landing place for an ajax query.
	/// </summary>
	public interface IQueryLandingWebPagePiece : IWebPagePiece, IId {

		/// <summary>
		/// Gets the name of the landing object in the webpage.
		/// </summary>
		/// <value>The name of the landing object in the webpage.</value>
		string LandingName {
			get;
		}

		/// <summary>
		/// Gets the query page that should be queried.
		/// </summary>
		/// <value>The query page that should be queried.</value>
		IQueryWebPage QueryPage {
			get;
		}
	}
}

