//
//  Navbar.cs
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
using IdpGie.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace IdpGie.OutputDevices.Web {

	/// <summary>
	/// Navbar.
	/// </summary>
	[XmlRoot("Navbar")]
	public class Navbar : NameBase, INavbar {

		private List<WebPage> pages = null;
		private readonly List<IQueryWebPage> queries = new List<IQueryWebPage> ();
		private string serverFolder;
		private FavIcon favIcon;

		#region INavbar implementation
		/// <summary>
		/// Gets the list of pages that should be listed in the navbar.
		/// </summary>
		/// <value>
		/// The list of pages that should be listed in the navbar.
		/// </value>
		[XmlIgnore]
		public IList<IWebPage> Pages {
			get {
				return this.pages.Cast<IWebPage> ().ToList ();
			}
		}

		/// <summary>
		///  Gets the fav icon of the web server. 
		/// </summary>
		/// <value>
		///  The fav icon of the web server. 
		/// </value>
		[XmlIgnore]
		public IFavIcon FavIcon {
			get {
				if (this.favIcon == null) {
					this.favIcon = new FavIcon ();
				}
				return this.favIcon;
			}
		}

		/// <summary>
		/// Gets the fav icon of the web server in xml serialization.
		/// </summary>
		/// <value>
		/// The fav icon of the web server in xml serialization.
		/// </value>
		public FavIcon FavIconXml {
			get {
				return this.favIcon;
			}
		}

		/// <summary>
		///  Gets the root of the web server folder. 
		/// </summary>
		/// <value>
		///  The root of the web server folder. 
		/// </value>
		[XmlIgnore]
		public string ServerFolder {
			get {
				return this.serverFolder;
			}
			protected set {
				this.serverFolder = value;
			}
		}

		/// <summary>
		///  Gets the default web page. 
		/// </summary>
		/// <value>
		///  The default web page. 
		/// </value>
		public IWebPage DefaultPage {
			get {
				return this.pages.FirstOrDefault (x => x.Default);
			}
		}
		#endregion

		/// <summary>
		/// Gets or sets the pages for the XML serialization.
		/// </summary>
		/// <value>
		/// The pages for the XML serialization.
		/// </value>
		[XmlArray("Pages")]
		[XmlArrayItem("Page")]
		public List<WebPage> PagesXml {
			get {
				return this.pages;
			}
			set {
				this.pages = value;
				if (value != null) {
					foreach (WebPage wp in value) {
						if (wp != null) {
							wp.Navbar = this;
						}
					}
				}
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.OutputDevices.Web.Navbar"/> class.
		/// </summary>
		public Navbar () : base() {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.OutputDevices.Web.Navbar"/> class.
		/// </summary>
		/// <param name='name'>
		/// The name of the application.
		/// </param>
		public Navbar (string name) : base(name) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.OutputDevices.Web.Navbar"/> class.
		/// </summary>
		/// <param name='name'>
		/// The name of the application.
		/// </param>
		/// <param name='pages'>
		/// A (possibly empty) list of pages that should appear in the navbar.
		/// </param>
		public Navbar (string name, params WebPage[] pages) : base(name) {
			this.pages = new List<WebPage> ();
			this.pages.AddRange (pages);
		}

		/// <summary>
		/// Creates a new <see cref="Navbar"/> instance based from content read from the given <see cref="TextReader"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="Navbar"/> that corresponds to the content of the given <see cref="TextReader"/>.
		/// </returns>
		/// <param name='serverFolder'>
		/// The root of the folder of the web server.
		/// </param>
		/// <param name='textReader'>
		/// The <see cref="TextReader"/> where the textual representation is read from.
		/// </param>
		public static Navbar FromStream (string serverFolder, TextReader textReader) {
			XmlSerializer xs = new XmlSerializer (typeof(Navbar));
			Navbar nb = (Navbar)xs.Deserialize (textReader);
			nb.ServerFolder = serverFolder;
			return nb;
		}

		/// <summary>
		/// Creates a new <see cref="Navbar"/> instance based from content read from the given <see cref="Stream"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="Navbar"/> that corresponds to the content of the given <see cref="Stream"/>.
		/// </returns>
		/// <param name='serverFolder'>
		/// The root of the folder of the web server.
		/// </param>
		/// <param name='stream'>
		/// The <see cref="Stream"/> that contains the textual representation.
		/// </param>
		public static Navbar FromStream (string serverFolder, Stream stream) {
			using (TextReader textReader = new StreamReader(stream)) {
				return FromStream (serverFolder, textReader);
			}
		}

		/// <summary>
		/// Creates a new <see cref="Navbar"/> instance based from content read from the given file.
		/// </summary>
		/// <returns>
		/// A <see cref="Navbar"/> that corresponds to the content of the given file.
		/// </returns>
		/// <param name='serverFolder'>
		/// The root of the folder of the web server.
		/// </param>
		/// <param name='filename'>
		/// The name of the file that contains the textual representation.
		/// </param>
		public static Navbar FromStream (string serverFolder, string filename) {
			using (FileStream stream = File.Open(filename,FileMode.Open,FileAccess.Read,FileShare.Read)) {
				return FromStream (serverFolder, stream);
			}
		}

		/// <summary>
		/// Writes a textual representation of this <see cref="Navbar"/> to the given <see cref="TextWriter"/>.
		/// </summary>
		/// <param name='textWriter'>
		/// The given <see cref="TextWriter"/> to write the textual representation to.
		/// </param>
		public void ToStream (TextWriter textWriter) {
			XmlSerializer xs = new XmlSerializer (typeof(Navbar));
			xs.Serialize (textWriter, this);
		}

		/// <summary>
		/// Writes a textual representation of this <see cref="Navbar"/> to the given <see cref="Stream"/>.
		/// </summary>
		/// <param name='stream'>
		/// The given <see cref="Stream"/> to write the textual representation to.
		/// </param>
		public void ToStream (Stream stream) {
			using (TextWriter textWriter = new StreamWriter(stream)) {
				ToStream (textWriter);
			}
		}

		/// <summary>
		/// Writes a textual representation of this <see cref="Navbar"/> to a file with the given filename.
		/// </summary>
		/// <param name='filename'>
		/// The given filename of the file to write the textual representation to.
		/// </param>
		public void ToStream (string filename) {
			using (FileStream stream = File.Open(filename,FileMode.OpenOrCreate,FileAccess.Write,FileShare.Write)) {
				ToStream (stream);
			}
		}

		#region INavbar implementation
		/// <summary>
		///  Gets the web page associated with the given reference. 
		/// </summary>
		/// <returns>
		///  The web page associated with the given reference. 
		/// </returns>
		/// <param name='href'>
		///  The given reference. 
		/// </param>
		public IWebPage GetPage (string href) {
			Console.WriteLine (href);
			IWebPage result = null;
			if (href != null && href != string.Empty) {
				string path = Path.Combine (this.serverFolder, href);
				result = this.pages.Append<IWebPage> (this.queries).FirstOrDefault (x => Path.Combine (this.serverFolder, x.Href) == path);
			}
			if (result == null) {
				result = this.DefaultPage;
			}
			return result;
		}

		/// <summary>
		/// Adds the given <see cref="IQueryWebPage"/> page to the navigation page.
		/// </summary>
		/// <param name='webpage'>
		/// The given <see cref="IQueryWebPage"/>.
		/// </param>
		public void AddQueryPage (IQueryWebPage webpage) {
			if (webpage != null) {
				webpage.Navbar = this;
				this.queries.Add (webpage);
			}
		}
		#endregion


	}

}

