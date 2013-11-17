//
//  UnificationException.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
//
//  Copyright (c) 2013 Willem Van Onsem
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
using System.Runtime.Serialization;

namespace IdpGie.Logic.Altering {

	public class UnificationException : Exception {
		public UnificationException () : base () {
		}

		public UnificationException (string message) : base (message) {
		}

		public UnificationException (string message, params object[] args) : base (string.Format (message, args)) {
		}

		public UnificationException (string message, Exception innerException) : base (message, innerException) {
		}

		public UnificationException (SerializationInfo info, StreamingContext context) : base (info, context) {
		}
	}
}

