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
using System.Xml.Serialization;

namespace IdpGie.OutputDevices.Web {

	/// <summary>
	/// An implementation of the <see cref="IWebPage"/> interface that has a name and a reference to the <c>.idpml</c> file.
	/// </summary>
	[XmlType("WebPage")]
	public class WebPage : NameHrefBase, IWebPage {

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
		public WebPage (string name, string href) : base(name,href) {
		}

	}
}

