//
//  NameHrefBase.cs
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

using System.Xml.Serialization;

namespace IdpGie.Abstract {

	/// <summary>
	/// An implementation of the <see cref="INameHref"/> interface that contains both the name of the instance and a (possibly related)
	/// reference to a resource.
	/// </summary>
	public abstract class NameHrefBase : NameBase, INameHref {

		private string href;

		#region IHref implementation
		/// <summary>
		///  Gets the reference to the resource to store. 
		/// </summary>
		/// <value>
		///  The reference to the resource to store. 
		/// </value>
		[XmlAttribute("href")]
		public virtual string Href {
			get {
				return this.href;
			}
			protected set {
				this.href = value;
			}
		}
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Abstract.NameHrefBase"/> class.
		/// </summary>
		/// <remarks>
		/// <para>The name of the object is set to <c>null</c>.</para>
		/// </remarks>
		protected NameHrefBase () : base() {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Abstract.NameHrefBase"/> class with a given name.
		/// </summary>
		/// <param name='name'>
		/// The name of the object.
		/// </param>
		protected NameHrefBase (string name) : base(name) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Abstract.NameHrefBase"/> class with a given name.
		/// </summary>
		/// <param name='name'>
		/// The name of the object.
		/// </param>
		/// <param name='href'>
		/// The references to a (possibly related) resource.
		/// </param>
		protected NameHrefBase (string name, string href) : base(name) {
			this.Href = href;
		}

	}

}

