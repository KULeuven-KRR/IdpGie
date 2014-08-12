//
//  AlterableContentChangeableStreamBase.cs
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

using System;
using System.IO;

namespace IdpGie.Interaction {
	/// <summary>
	/// A <see cref="Stream"/> that can be altered (using a <typeparamref name='TCommand'/> and if so, notifies interested parties.
	/// </summary>
	/// <typeparam name='TStream'>
	/// The type of stream used.
	/// </typeparam>
	/// <typeparam name='TCommand'>
	/// The type of commands that can be executed to alter the stream (probably textual).
	/// </typeparam>
	public class AlterableContentChangeableStreamBase<TStream,TCommand> : ContentChangeableStreamBase<TStream>, IAlterableReloadableChangeableStream<TCommand> where TStream : Stream {

		#region Constructors
		public AlterableContentChangeableStreamBase (TStream stream) : base (stream) {
		}
		#endregion
		#region IAlterableReloadableChangeableStream implementation
		public virtual void Alter (TCommand command) {
		}

		public virtual void Reload () {
		}
		#endregion
	}
}

