//
//  IFavIcon.cs
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
using System.IO;

namespace IdpGie.Shapes.Pages {


	/// <summary>
	/// The web page that provides the favicon of the web server.
	/// </summary>
	public interface IFavIcon : IWebPage {

		/// <summary>
		///  Render the webpage icon onto the give specified engine. 
		/// </summary>
		/// <param name='engine'>
		///  The given specified engine. 
		/// </param>
		/// <param name='stream'>
		/// The stream to write the content to.
		/// </param>
		void RenderIcon (HttpEngine engine, Stream stream);

	}
}

