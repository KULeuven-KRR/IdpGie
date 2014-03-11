//
//  WriteableExtensions.cs
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
using System.IO;

namespace IdpGie.Abstract {

	/// <summary>
	/// Extensions to the <see cref="IWriteable"/> interfacing making the interface more convenient to use.
	/// </summary>
	public static class WriteableExtensions {


		/// <summary>
		/// Write the content of the specified <see cref="IWriteable"/> to the given <see cref="Stream"/>.
		/// </summary>
		/// <param name='writeable'>
		/// The <see cref="IWriteable"/> that contains the data and knows how to encode it.
		/// </param>
		/// <param name='stream'>
		/// The <see cref="Stream"/> to write to.
		/// </param>
		public static void Write (this IWriteable writeable, Stream stream) {
			using (StreamWriter sw = new StreamWriter(stream)) {
				writeable.Write (sw);
			}
		}

		/// <summary>
		/// Write the content of the specified <see cref="IWriteable"/> to a <see cref="string"/>.
		/// </summary>
		/// <param name='writeable'>
		/// The <see cref="IWriteable"/> that contains the data and knows how to encode it.
		/// </param>
		public static string Write (this IWriteable writeable) {
			using (StringWriter sw = new StringWriter()) {
				writeable.Write (sw);
				return sw.GetStringBuilder ().ToString ();
			}
		}

	}
}

