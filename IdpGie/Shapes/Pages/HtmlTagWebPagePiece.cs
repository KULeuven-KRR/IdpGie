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
using System.Web.UI;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace IdpGie.Shapes.Pages {

	public class HtmlTagWebPagePiece : IWebPagePiece {

		private readonly HtmlNode node;

		public IList<IWebPagePiece> Pieces {
			get {
				throw new System.NotImplementedException ();
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="HtmlTagWebPagePiece"/> class with a given <see cref="HtmlNode"/>.
		/// </summary>
		/// <param name='node'>
		/// The node to print.
		/// </param>
		public HtmlTagWebPagePiece (HtmlNode node) {
			this.node = node;
		}

		#region IWebPagePiece implementation
		public void Render (string serverFolder, HttpEngine engine, Html32TextWriter writer) {
			writer.WriteLine (node.OuterHtml);
		}
		#endregion


	}

}

