//
//  QueryWebPage.cs
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
using IdpGie.Abstract;

namespace IdpGie.Shapes.Pages {
	/// <summary>
	/// A basic implementation of the <see cref="IQueryWebPage"/> interface.
	/// </summary>
	public abstract class QueryWebPageBase : WebPage, IQueryWebPage {
		/// <summary>
		/// Initializes a new instance of the <see cref="QueryWebPageBase"/> class.
		/// </summary>
		protected QueryWebPageBase () : base() {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="QueryWebPageBase"/> class with an href reference.
		/// </summary>
		/// <param name='href'>
		/// The reference of the <see cref="IQueryWebPage"/>.
		/// </param>
		protected QueryWebPageBase (string href) : base(string.Empty,href) {
		}
	}
}