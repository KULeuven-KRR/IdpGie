//
//  ClingoSession.cs
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
using IdpGie.Core;

namespace IdpGie.Interaction {
	/// <summary>
	/// A class representing an (interactive) session with the clingo program: a program that users
	/// the answer set programming semantic to generate, based on conversion rules more facts.
	/// </summary>
	public class ClingoSession : ProcessSession {

		//TODO: interface
		/// <summary>
		/// Gets the output of the process when until termination.
		/// </summary>
		/// <value>The output of the process until termination.</value>
		public string Output {
			get {
				return this.Stdout.ReadToEnd ();
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ClingoSession"/> class with a given class of interaction flags,
		/// an original answer set program and the input to translate.
		/// </summary>
		/// <param name="interaction">A <see cref="IdpInteraction"/> instance that describes how the program should run.</param>
		/// <param name="aspContent">An asp-program that specifies how the new facts should be generated.</param>
		/// <param name="inp">The given input to transform.</param>
		public ClingoSession (IdpInteraction interaction, string aspContent, string inp) : base (interaction.ClingoExecutable, string.Format ("-n 1 --verbose=0")) {
			this.Stdin.Write (aspContent);
			this.Stdin.Write (inp);
			this.Stdin.Close ();
		}
	}
}

