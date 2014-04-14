//
//  DefaultWebPagePiece.cs
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
using System.Web.UI;
using System.Collections.Generic;

namespace IdpGie.Shapes.Pages {

	/// <summary>
	/// A default implementation of the <see cref="IWebPagePiece"/> in case no other content is found.
	/// </summary>
	public class DefaultWebPagePiece : WebPagePieceBase {

		/// <summary>
		/// Gets the single instance of the <see cref="DefaultWebPagePiece"/>. The singleton pattern is used for memory
		/// footprint reduction reasons.
		/// </summary>
		public static readonly DefaultWebPagePiece SingleInstance = new DefaultWebPagePiece ();

		/// <summary>
		/// The message when the webserver cannot find the corresponding webpage.
		/// </summary>
		public const string Error404 = "<div class=\"alert alert-danger\"><strong>Error:</strong> cannot find the " +
				"webpage piece. Please contact the site administrator.</div>";

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Shapes.Pages.DefaultWebPagePiece"/> class.
		/// </summary>
		private DefaultWebPagePiece () {
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
		public override void Render (string serverFolder, HttpEngine engine, Html32TextWriter writer) {
			writer.WriteLine (Error404);
		}
		#endregion


	}
}

