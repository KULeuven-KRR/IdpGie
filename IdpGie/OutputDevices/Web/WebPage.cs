//
//  NavbarPage.cs
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
using IdpGie.Engines;
using System.IO;
using System.Xml.Serialization;

namespace IdpGie.OutputDevices.Web {

	/// <summary>
	/// An implementation of the <see cref="IWebPage"/> interface that has a name and a reference to the <c>.idpml</c> file.
	/// </summary>
	[XmlType("WebPage")]
	public class WebPage : NameHrefBase, IWebPage {

		private string content = null;

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="IdpGie.OutputDevices.Web.WebPage"/> is the default page.
		/// </summary>
		/// <value>
		/// <c>true</c> if this page is the default web page; otherwise, <c>false</c>.
		/// </value>
		[XmlAttribute("default")]
		public bool Default {
			get;
			set;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.OutputDevices.Web.WebPage"/> class.
		/// </summary>
		public WebPage () : base() {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.OutputDevices.Web.WebPage"/> class.
		/// </summary>
		/// <param name='name'>
		/// The name of the navbar page.
		/// </param>
		public WebPage (string name) : base(name) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.OutputDevices.Web.WebPage"/> class.
		/// </summary>
		/// <param name='name'>
		/// The name of the navbar page.
		/// </param>
		/// <param name='href'>
		/// The reference to the resource file of the navbar page.
		/// </param>
		/// <param name='defaultPage'>
		/// A value indicating that the page is the default one to show.
		/// </param>
		public WebPage (string name, string href, bool defaultPage = false) : base(name,href) {
		}

		#region IWebPage implementation
		/// <summary>
		/// Gets a <see cref="TextReader"/> that reads the content of the web page.
		/// </summary>
		/// <param name='serverFolder'>
		/// The root of the folder of the web server.
		/// </param>
		/// <returns>
		/// A <see cref="TextReader"/> that reads the content of the web page.
		/// </returns>
		public virtual TextReader GetReader (string serverFolder) {
			if (this.content == null) {
				string filename = Path.Combine (serverFolder, this.Href);
				if (File.Exists (filename)) {
					using (FileStream fs = File.Open(filename,FileMode.Open,FileAccess.Read,FileShare.Read)) {
						using (TextReader tr = new StreamReader(fs)) {
							this.content = tr.ReadToEnd ();
						}
					}
				} else {
					throw new IOException (string.Format ("Server folder does not contain a file for \"{0}\".", this.Href));
				}
			}
			return new StringReader (this.content);
		}

		/// <summary>
		///  Render the webpage onto the give specified engine. 
		/// </summary>
		/// <param name='engine'>
		///  The given specified engine. 
		/// </param>
		public virtual void Render (HttpEngine engine) {

		}
		#endregion


	}
}

