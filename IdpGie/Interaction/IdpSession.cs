//
//  IdpSession.cs
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
using IdpGie.Utils;
using System.Text;

namespace IdpGie.Interaction {
	//TODO: interface
	/// <summary>
	/// A class representing an interactive session with the idp system.
	/// </summary>
	public class IdpSession : ProcessSession {

		private readonly string theory, structure, vocabulary;

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Interaction.IdpSession"/> class.
		/// </summary>
		/// <param name="interaction">An <see cref="IdpInteraction"/> configuration class that describes which executable that should be called
		/// together with the settings of the idp session.</param>
		/// <param name="filename">The name of the <c>.idp</c>-file to execute.</param>
		/// <param name="theory">The name of the theory to be used.</param>
		/// <param name="structure">The name of the structure to be used.</param>
		/// <param name="vocabulary">The name of the vocabulary to be used.</param>
		public IdpSession (IdpInteraction interaction, string filename, string theory, string structure, string vocabulary) : base (interaction.IdpExecutable, string.Format ("--nowarnings -i {0}", filename)) {
			this.theory = theory;
			this.structure = structure;
			this.vocabulary = vocabulary;
			this.Stdin.WriteLine ("stdoptions.xsb={0}", interaction.Xsb.ToString ().ToLower ());
			this.Stdin.WriteLine ("stdoptions.groundwithbounds={0}", interaction.Groundwithbounds.ToString ().ToLower ());
			this.Stdin.WriteLine ("stdoptions.liftedunitpropagation={0}", interaction.Liftedunitpropagation.ToString ().ToLower ());
			this.Stdin.WriteLine ("stdoptions.nbmodels={0}", interaction.Nbmodels);
			this.Stdin.WriteLine ("stdoptions.language=\"asp\"");
			this.Stdin.WriteLine ("cs = calculatedefinitions({0},{1})", this.theory, this.structure);
			this.Stdin.WriteLine ("ps, a, b, iv = initialise({0},cs)", this.theory);
			this.Stdin.Flush ();
		}

		/// <summary>
		/// Executes the given command in the given IDP session.
		/// </summary>
		/// <param name="command">The given command to execute.</param>
		public void Execute (string command) {
			Console.Error.WriteLine (StringUtils.ReplaceDollar (command, "the", this.theory, "str", this.structure, "voc", this.vocabulary));
			this.Stdin.WriteLine (StringUtils.ReplaceDollar (command, "the", this.theory, "str", this.structure, "voc", this.vocabulary));
			this.Stdin.Flush ();
		}

		/// <summary>
		/// Echos the current model in the session.
		/// </summary>
		/// <returns>A textual representation of the currently generated model.</returns>
		public string EchoModel () {
			this.Stdin.WriteLine ("struc = ps[1];");
			this.Stdin.WriteLine (@"print(string.format(""\a%s\n\a"",tostring (struc)));");
			this.Stdin.Flush ();
			while (this.Stdout.Read () != 0x07)
				;
			this.Stdout.Read ();
			StringBuilder sb = new StringBuilder ();
			while (this.Stdout.Peek () != 0x07) {
				sb.AppendLine (this.Stdout.ReadLine ());
			}
			this.Stdout.Read ();
			return sb.ToString ();
		}
	}
}

