//
//  IContentChangeableStream.cs
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
using System.IO;

namespace IdpGie.Abstract {

	/// <summary>
	/// An interface that represents a stream where the content might change. The interface supports an <see cref="EventHandler"/>
	/// that warns interested objects the content has changed.
	/// </summary>
	public interface IChangeableStream {

		/// <summary>
		/// Gets the stream of data that might change.
		/// </summary>
		/// <value>
		/// The stream of data that might change.
		/// </value>
		Stream Stream {
			get;
		}

		/// <summary>
		/// An event handler that warns interested object the content of the <see cref="IChangeableStream.Stream"/> has changed.
		/// </summary>
		event EventHandler Changed;
	}
}