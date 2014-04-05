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

		[XmlIgnore]
		private readonly List<IWebPage>
			pages = new List<IWebPage> ();

		/// <summary>
		/// Gets the list of pages that should be listed in the navbar.
		/// </summary>
		/// <value>
		/// The list of pages that should be listed in the navbar.
		/// </value>
		public IList<IWebPage> Pages {
			get {
				return (IList<IWebPage>)this.pages.AsReadOnly ();
			}
		}

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
				return this.pages.Cast<WebPage> ().ToList ();
			}
			set {
				this.pages.Clear ();
				if (value != null) {
					foreach (WebPage page in value) {
						this.pages.Add (page);
					}
				}
			}
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
			this.pages.AddRange (pages);
		}

		/// <summary>
		/// Creates a new <see cref="Navbar"/> instance based from content read from the given <see cref="TextReader"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="Navbar"/> that corresponds to the content of the given <see cref="TextReader"/>.
		/// </returns>
		/// <param name='textReader'>
		/// The <see cref="TextReader"/> where the textual representation is read from.
		/// </param>
		public static Navbar FromStream (TextReader textReader) {
			XmlSerializer xs = new XmlSerializer (typeof(Navbar));
			return (Navbar)xs.Deserialize (textReader);
		}

		/// <summary>
		/// Creates a new <see cref="Navbar"/> instance based from content read from the given <see cref="Stream"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="Navbar"/> that corresponds to the content of the given <see cref="Stream"/>.
		/// </returns>
		/// <param name='stream'>
		/// The <see cref="Stream"/> that contains the textual representation.
		/// </param>
		public static Navbar FromStream (Stream stream) {
			using (TextReader textReader = new StreamReader(stream)) {
				return FromStream (textReader);
			}
		}

		/// <summary>
		/// Creates a new <see cref="Navbar"/> instance based from content read from the given file.
		/// </summary>
		/// <returns>
		/// A <see cref="Navbar"/> that corresponds to the content of the given file.
		/// </returns>
		/// <param name='filename'>
		/// The name of the file that contains the textual representation.
		/// </param>
		public static Navbar FromStream (string filename) {
			using (FileStream stream = File.Open(filename,FileMode.Open,FileAccess.Read,FileShare.Read)) {
				return FromStream (stream);
			}
		}

	}

}

