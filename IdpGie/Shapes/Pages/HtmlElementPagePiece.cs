//
//  HtmlTagWebPagePiece.cs
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
using System;
using System.Web.UI;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace IdpGie.Shapes.Pages {

	/// <summary>
	/// An <see cref="IWebPagePieceBase"/> that describes a html tag.
	/// </summary>
	public class HtmlElementPagePiece : WebPagePieceBase {

		private readonly HtmlNode node;

		private IList<IWebPagePiece> pieces = null;

		#region IWebPagePiece implementation
		/// <summary>
		/// Gets the pieces that compose the <see cref="IWebPage"/>.
		/// </summary>
		/// <value>
		/// The pieces that compose the <see cref="IWebPage"/>.
		/// </value>
		public override IList<IWebPagePiece> Pieces {
			get {
				this.Load (null);
				return this.pieces;
			}
		}
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="HtmlElementPagePiece"/> class with a given <see cref="HtmlNode"/>.
		/// </summary>
		/// <param name='node'>
		/// The node to print.
		/// </param>
		public HtmlElementPagePiece (HtmlNode node) {
			this.node = node;
		}

		#region IWebPagePiece implementation
		/// <summary>
		///  Loading the page from the given server folder. 
		/// </summary>
		/// <param name='serverFolder'>
		///  The root of the folder of the web server. 
		/// </param>
		public override void Load (string serverFolder) {
			this.pieces = WebPagePieceBase.Expand (this.node);
			base.Load (serverFolder);
		}

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
			this.Load (serverFolder);
			foreach (HtmlAttribute ha in this.node.Attributes) {
				writer.AddAttribute (ha.Name, ha.Value);
			}
			writer.RenderBeginTag (this.node.Name);
			if (this.pieces != null) {
				foreach (IWebPagePiece piece in this.pieces) {
					piece.Render (serverFolder, engine, writer);
				}
			}
			writer.RenderEndTag ();
		}
		#endregion

	}

}

