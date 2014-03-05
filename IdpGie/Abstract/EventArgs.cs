//
//  EventArgs.cs
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

using System;

namespace IdpGie.Abstract {

	/// <summary>
	/// A utility class that provides tags when using a <see cref="EventArgs"/> instance.
	/// </summary>
	/// <remarks>
	/// <para>This is useful when data should be passed doing this in a typesafe way.</para>
	/// </remarks>
	/// <typeparam name="TTag">
	/// The type of the associated tag and <see cref="ITagable{TTag}"/>.
	/// </typeparam>
	public class EventArgs<TTag> : EventArgs, ITagable<TTag> {

		private readonly TTag tag;

		/// <summary>
		/// Gets the tag, data that comes along with the <see cref="EventArgs"/>.
		/// </summary>
		/// <value>
		/// The tag.
		/// </value>
		public TTag Tag {
			get {
				return this.tag;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Abstract.EventArgs`1"/> class with a given tag item.
		/// </summary>
		/// <param name='tag'>
		/// The given tag to pass with the <see cref="EventArgs"/>.
		/// </param>
		public EventArgs (TTag tag) {
			this.tag = tag;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Abstract.EventArgs`1"/> class.
		/// </summary>
		/// <remarks>
		/// <para>The tags is set to the default of the type variable.</para>
		/// </remarks>
		public EventArgs () : this(default(TTag)) {
		}

	}

}