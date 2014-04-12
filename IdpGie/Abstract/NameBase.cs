//
//  NameBase.cs
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
	/// A basic implementation of the <see cref="IName"/> interface. This class is used as a coninient basic implementation.
	/// </summary>
	public abstract class NameBase : IName {

		private string name;

		#region IName implementation
		/// <summary>
		///  Gets the name of this instance. 
		/// </summary>
		/// <value>
		///  The name of this instance. 
		/// </value>
		[XmlAttribute("name")]
		public virtual string Name {
			get {
				return this.name;
			}
			protected set {
				this.name = value;
			}
		}
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Abstract.NameBase"/> class.
		/// </summary>
		/// <remarks>
		/// <para>The name of the object is set to <c>null</c>.</para>
		/// </remarks>
		protected NameBase () {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Abstract.NameBase"/> class with a given name.
		/// </summary>
		/// <param name='name'>
		/// The name of the object.
		/// </param>
		protected NameBase (string name) {
			this.Name = name;
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="IdpGie.Abstract.NameBase"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents the current <see cref="IdpGie.Abstract.NameBase"/>.
		/// </returns>
		/// <remarks>
		/// <para>The textual representation of a <see cref="IName"/> object is by default its name.</para>
		/// <c/remarks>
		public override string ToString () {
			return this.Name;
		}

	}
}

