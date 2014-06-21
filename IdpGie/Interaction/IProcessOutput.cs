//
//  IProcessOutput.cs
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

namespace IdpGie.Interaction {
	/// <summary>
	/// An interfacing specifying that the process produces output and that this output can
	/// be consumed by another program.
	/// </summary>
	public interface IProcessOutput {

		/// <summary>
		/// Gets the output of the process up till termination.
		/// </summary>
		/// <value>The output of the process up till termination.</value>
		/// <remarks>
		/// <para>When the program has not yet finished (or is stuck in an infinite loop),
		/// this method will block as well.</para>
		/// </remarks>
		string ProcessOutput {
			get;
		}
	}
}

