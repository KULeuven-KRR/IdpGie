//
//  QueryWebPageShapeBase.cs
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

using System.Collections.Generic;
using System.Web.UI;
using IdpGie.Engines;
using IdpGie.Shapes.Pages;
using IdpGie.Abstract;

namespace IdpGie.Shapes.Web {
	/// <summary>
	/// An implementation of the <see cref="IQueryWebPageShape"/> interface.
	/// </summary>
	public abstract class QueryWebPageShapeBase : WebShapeBase, IQueryWebPageShape, IId {

		private static ulong idDispatcher = 0x00;
		#region IId implementation
		/// <summary>
		/// Gets the id of this instance.
		/// </summary>
		/// <value>The id of this instance, a unique number.</value>
		public ulong Id {
			get;
			private set;
		}
		#endregion
		#region IWebPagePiece implementation
		/// <summary>
		/// Gets the subpieces of the current <see cref="IWebPagePiece"/>.
		/// </summary>
		/// <value>The subpieces of the current <see cref="IWebPagePiece"/>.</value>
		public virtual IList<IWebPagePiece> Pieces {
			get {
				return new IWebPagePiece[0x00];
			}
		}
		#endregion
		#region IWebPage implementation
		/// <summary>
		/// Gets or sets the navigation bar of the current <see cref="IWebPage"/>.
		/// </summary>
		/// <value>The navbar.</value>
		public virtual INavbar Navbar {
			get;
			set;
		}
		#endregion
		#region IHref implementation
		/// <summary>
		/// Gets the reference to the resource to store.
		/// </summary>
		/// <value>The reference to the resource to store.</value>
		public virtual string Href {
			get {
				return string.Format ("query{0}.idpql", this.Id);
			}
		}
		#endregion
		#region IName implementation
		/// <summary>
		/// Gets the name of this instance.
		/// </summary>
		/// <value>The name of this instance.</value>
		public virtual string Name {
			get {
				return string.Format ("#query{0}", this.Id);
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="QueryWebPageShapeBase"/> class.
		/// </summary>
		protected QueryWebPageShapeBase () {
			this.Id = idDispatcher++;
		}
		#endregion
		#region IWebPagePiece implementation
		/// <summary>
		/// Loading the page from the given server folder.
		/// </summary>
		/// <param name="serverFolder">The root of the folder of the web server.</param>
		public virtual void Load (string serverFolder) {
		}

		/// <summary>
		/// Render the webpage onto the give specified engine.
		/// </summary>
		/// <param name="serverFolder">The root of the folder of the web server.</param>
		/// <param name="engine">The given specified engine.</param>
		/// <param name="writer">The html writer to write content to.</param>
		/// <remarks>
		/// <para>This method should be overridden with the query answer.</para>
		/// </remarks>
		public virtual void Render (string serverFolder, HttpEngine engine, Html32TextWriter writer) {
		}
		#endregion
		/// <summary>
		/// Gets the query page of this <see cref="IWebShape"/>.
		/// </summary>
		/// <returns>The query page of the <see cref="IWebShape"/>.</returns>
		/// <remarks>
		/// <para>By default, this instance is returned.</para>
		/// </remarks>
		public override IQueryWebPage GetQueryPage () {
			return this;
		}
	}
}

