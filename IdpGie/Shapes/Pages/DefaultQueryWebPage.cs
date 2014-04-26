//
//  DefaultQueryWebPage.cs
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
using System.IO;

namespace IdpGie.Shapes.Pages {

	/// <summary>
	/// A default <see cref="IQueryWebPage"/> that is used when no other query page is available.
	/// </summary>
	public class DefaultQueryWebPage : QueryWebPageBase {

		/// <summary>
		/// The single instance of the <see cref="DefaultQueryWebPage"/>. A singleton for memory footprint reduction.
		/// </summary>
		public static readonly DefaultQueryWebPage SingleInstance = new DefaultQueryWebPage ();

		/// <summary>
		/// Gets the default value for a query that cannot be resolved.
		/// </summary>
		public const string Error404 = "<div class=\"alert alert-danger\"><strong>Error:</strong> corrupt query. Possible tampering with the webserver. A system administrator will be notified.</div>";

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.OutputDevices.Web.DefaultQueryWebPage"/> class.
		/// </summary>
		private DefaultQueryWebPage () : base("defaultquery") {
		}

		#region IWebPage implementation
		/// <summary>
		///  Loading the page from the given server folder. 
		/// </summary>
		/// <param name='serverFolder'>
		///  The root of the folder of the web server. 
		/// </param>
		public override void Load (string serverFolder) {
		}

		/// <summary>
		///  Render the result of the query onto the give specified engine. 
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