//
//  WebShape.cs
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
using IdpGie.Shapes.Pages;

namespace IdpGie.Shapes.Web {

	/// <summary>
	/// A basic abstract implementation of a web shape.
	/// </summary>
	public abstract class WebShape : IWebShape {

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Shapes.Web.WebShape"/> class.
		/// </summary>
		protected WebShape () {
		}

		#region IWebShape implementation
		/// <summary>
		/// Translates the given <see cref="IWebShape"/> into a relevant <see cref="IQueryWebPage"/> instance.
		/// </summary>
		/// <returns>
		/// An <see cref="IQueryWebPage"/> instances that can produce dynamic content.
		/// </returns>
		public abstract IQueryWebPage GetShapePage ();
		#endregion


	}
}

