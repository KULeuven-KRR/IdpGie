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
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Xml.Serialization;
using HtmlAgilityPack;

namespace IdpGie.Shapes.Pages {

	/// <summary>
	/// An implementation of the <see cref="IWebPage"/> interface that has a name and a reference to the <c>.idpml</c> file.
	/// </summary>
	[XmlType("WebPage")]
	public class WebPage : NameHrefBase, IWebPage {

		private IList<IWebPagePiece> pieces = null;

		#region IWebPage implementation
		/// <summary>
		/// Gets or sets the navbar to which the <see cref="IWebPage"/> belongs.
		/// </summary>
		/// <value>
		/// The navbar to which the <see cref="IWebPage"/> belongs.
		/// </value>
		[XmlIgnore]
		public INavbar Navbar {
			get;
			set;
		}

		/// <summary>
		/// Gets the pieces that compose the <see cref="IWebPage"/>.
		/// </summary>
		/// <value>
		/// The pieces that compose the <see cref="IWebPage"/>.
		/// </value>
		[XmlIgnore]
		public IList<IWebPagePiece> Pieces {
			get {
				return this.pieces;
			}
		}
		#endregion

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="WebPage"/> is the default page.
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
		/// Initializes a new instance of the <see cref=".WebPage"/> class.
		/// </summary>
		public WebPage () : base() {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="WebPage"/> class.
		/// </summary>
		/// <param name='name'>
		/// The name of the navbar page.
		/// </param>
		public WebPage (string name) : base(name) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="WebPage"/> class.
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
		///  Loading the page from the given server folder. 
		/// </summary>
		/// <param name='serverFolder'>
		///  The root of the folder of the web server. 
		/// </param>
		public virtual void Load (string serverFolder) {
			if (this.pieces == null) {
				string filename = Path.Combine (serverFolder, this.Href);
				if (File.Exists (filename)) {
					HtmlDocument doc = new HtmlDocument ();
					doc.Load (filename);
					HtmlNode node = doc.DocumentNode;
					Console.WriteLine (node);
					/*using (FileStream fs = File.Open(filename,FileMode.Open,FileAccess.Read,FileShare.Read)) {
						using (TextReader tr = new StreamReader(fs)) {

							this.pieces = tr.ReadToEnd ();
						}
					}
				} else {
					this.pieces = string.Format (Error404, this.Href);*/
					this.pieces = new List<IWebPagePiece> ();
				} else {
					this.pieces = new IWebPagePiece[] {DefaultWebPagePiece.SingleInstance};
				}
			}
		}

		/// <summary>
		///  Render the webpage onto the give specified engine. 
		/// </summary>
		/// <param name='serverFolder'>
		/// The root of the folder of the web server.
		/// </param>
		/// <param name='engine'>
		///  The given specified engine. 
		/// </param>
		/// <param name='writer'>
		/// The html writer to write content to.
		/// </param>
		public virtual void Render (string serverFolder, HttpEngine engine, Html32TextWriter writer) {
			this.Load (serverFolder);
			if (this.pieces != null) {
				foreach (IWebPagePiece piece in this.Pieces) {
					piece.Render (serverFolder, engine, writer);
				}
			}
		}
		#endregion


	}
}

