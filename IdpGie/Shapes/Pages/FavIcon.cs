//
//  FavIcon.cs
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
using System.Reflection;
using System.Xml.Serialization;

namespace IdpGie.Shapes.Pages {

	/// <summary>
	/// An implementation of a favicon, an icon that represents the website.
	/// </summary>
	[XmlType("FavIcon")]
	public class FavIcon : WebPage, IFavIcon {

		byte[] data;

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.OutputDevices.Web.FavIcon"/> class.
		/// </summary>
		public FavIcon () {
		}

		#region IWebPage implementation
		/// <summary>
		///  Loading the page from the given server folder. 
		/// </summary>
		/// <param name='serverFolder'>
		///  The root of the folder of the web server. 
		/// </param>
		public override void Load (string serverFolder) {
			if (data == null) {
				if (this.Href == null) {
					Stream s = Assembly.GetExecutingAssembly ().GetManifestResourceStream ("IdpGie.resources.favicon.ico");
					int l = (int)s.Length;
					byte[] buffer = new byte[l];
					s.Read (buffer, 0x00, l);
					this.data = buffer;
				} else {
					//TODO: implement customly specified favicon
				}
			}
		}

		/// <summary>
		///  Render the webpage icon onto the give specified engine. 
		/// </summary>
		/// <param name='serverFolder'>
		/// The root of the server folder that contains the custom favoicon.
		/// </param>
		/// <param name='engine'>
		///  The given specified engine. 
		/// </param>
		/// <param name='stream'>
		/// The stream to write the content to.
		/// </param>
		public void RenderIcon (string serverFolder, HttpEngine engine, Stream stream) {
			this.Load (serverFolder);
			using (BinaryWriter bw = new BinaryWriter (stream)) {
				bw.Write (this.data);
			}
		}
		#endregion

	}
}

