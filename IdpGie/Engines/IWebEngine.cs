//
//  IWebEngine.cs
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

using System.Net.Sockets;

namespace IdpGie.Engines {

	/// <summary>
	/// The interface of a <see cref="IEngine"/> that converts a set of a <see cref="IdpGie.Shapes.IShape"/> into a webpage.
	/// </summary>
	public interface IWebEngine : IEngine {

		/// <summary>
		/// Gets the <see cref="TcpClient"/> that contains data about the requested page and a stream to send a response.
		/// </summary>
		/// <value>
		/// The <see cref="TcpClient"/> that contains data about the requested page and a stream to send a response.
		/// </value>
		TcpClient Client {
			get;
		}

	}

}