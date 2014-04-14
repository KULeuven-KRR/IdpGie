//
//  StringWebPagePiece.cs
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

using IdpGie.Engines;
using System.Collections.Generic;
using System.Web.UI;

namespace IdpGie.Shapes.Pages {

	/// <summary>
	/// A <see cref="IWebPagePiece"/> that contains a small fragment of static HTML.
	/// </summary>
	public class HtmlFragmentWebPagePiece : IWebPagePiece {

		private readonly string fragment;

		#region IWebPagePiece implementation
		/// <summary>
		/// Gets the pieces that compose the <see cref="IWebPage"/>.
		/// </summary>
		/// <value>
		/// The pieces that compose the <see cref="IWebPage"/>.
		/// </value>
		public IList<IWebPagePiece> Pieces {
			get {
				return new IWebPagePiece[0x00];//TODO: subpieces
			}
		}
		#endregion

		public HtmlFragmentWebPagePiece (string fragment) {
			this.fragment = fragment;
		}

		#region IWebPagePiece implementation
		/// <summary>
		///  Render the webpage onto the give specified engine. 
		/// </summary>
		/// <param name='serverFolder'>
		///  The root of the folder of the web server. 
		/// </param>
		/// <param name='engine'>
		///  The given specified engine. 
		/// </param>
		/// <param name='writer'>
		///  The html writer to write content to. 
		/// </param>
		public void Render (string serverFolder, HttpEngine engine, Html32TextWriter writer) {
			writer.WriteLine (this.fragment);
		}
		#endregion


	}
}

