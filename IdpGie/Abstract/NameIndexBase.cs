//
//  NameIndexBase.cs
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

using System.Xml.Serialization;

namespace IdpGie.Abstract {
	/// <summary>
	/// A basic implementation of the <see cref="INameIndex"/> inte.
	/// </summary>
	public abstract class NameIndexBase : NameBase, INameIndex {

		#region IIndex implementation
		/// <summary>
		/// Gets the index of this instance.
		/// </summary>
		/// <value>The index of this instance.</value>
		[XmlAttribute("index")]
		public virtual int Index {
			get;
			protected set;
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="NameIndexBase"/> class.
		/// </summary>
		/// <param name="index">The initial index of this instance.</param>
		protected NameIndexBase (int index = 0x00) : base() {
			this.Index = index;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="NameIndexBase"/> class.
		/// </summary>
		/// <param name="name">The intial name of this instance.</param>
		/// <param name="index">The initial index of this instance.</param>
		protected NameIndexBase (string name, int index = 0x00) : base(name) {
			this.Index = index;
		}
		#endregion
	}
}

