//
//  QueryLandingWebPagePiece.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
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

using System.Web.UI;
using IdpGie.Engines;

namespace IdpGie.Shapes.Pages {
	/// <summary>
	/// An implementation of the <see cref="IQueryLandingWebPagePiece"/> interface, a <see cref="IWebPagePiece"/>
	/// that functions as a landing place for ajax queries.
	/// </summary>
	public class QueryLandingWebPagePiece : WebPagePieceBase, IQueryLandingWebPagePiece {

		#region IQueryLandingWebPagePiece
		/// <summary>
		/// Gets the name of the landing object in the webpage.
		/// </summary>
		/// <value>The name of the landing object in the webpage.</value>
		public string LandingName {
			get {
				return string.Format ("landing{0}", this.QueryPage.Id);
			}
		}
		#endregion
		#region IQueryLandingWebPagePiece implementation
		/// <summary>
		/// Gets the query page that should be queried.
		/// </summary>
		/// <value>The query page that should be queried.</value>
		public IQueryWebPage QueryPage {
			get;
			protected set;
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="QueryLandingWebPagePiece"/> class with an intial query page.
		/// </summary>
		/// <param name="queryPage">The initial query page.</param>
		public QueryLandingWebPagePiece (IQueryWebPage queryPage) {
			this.QueryPage = queryPage;
		}
		#endregion
		#region IWebPagePiece implementation
		/// <summary>
		/// Render the webpage onto the give specified engine.
		/// </summary>
		/// <param name="serverFolder">The root of the folder of the web server.</param>
		/// <param name="engine">The given specified engine.</param>
		/// <param name="writer">The html writer to write content to.</param>
		public override void Render (string serverFolder, HttpEngine engine, Html32TextWriter writer) {
			string landingName = this.LandingName;
			writer.AddAttribute (HtmlTextWriterAttribute.Id, landingName);
			writer.RenderBeginTag (HtmlTextWriterTag.Div);
			writer.RenderEndTag ();
			if (this.QueryPage != null) {
				writer.RenderBeginTag (HtmlTextWriterTag.Script);
				writer.WriteLine ("genericAjax (\"{0}\", \"{1}\");", this.QueryPage.Href, landingName);
				writer.RenderEndTag ();
			}
		}

		/// <summary>
		/// Registers the query pages that can be activated in the specified <see cref="INavbar"/>.
		/// </summary>
		/// <param name="navbar">The <see cref="INavbar"/> to register <see cref="IQueryWebPage"/> instance.</param>
		public override void RegisterQueryPages (INavbar navbar) {
			base.RegisterQueryPages (navbar);
			navbar.AddQueryPage (this.QueryPage);
		}
		#endregion
	}
}

