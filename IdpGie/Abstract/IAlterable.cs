//
//  IAlterable.cs
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

namespace IdpGie.Abstract {
	/// <summary>
	/// An interface specifying the object can be altered with a given type of command.
	/// </summary>
	/// <typeparam name="TCommand">
	/// The type of the command.
	/// </typeparam>
	public interface IAlterable<TCommand> {

		/// <summary>
		/// Alter the object using a specified command.
		/// </summary>
		/// <param name='command'>
		/// The command that provides information on how the object should be altered.
		/// Command.
		/// </param>
		void Alter (TCommand command);
	}
}

