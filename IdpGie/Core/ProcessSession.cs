//
//  ProcessSession.cs
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

using System.Diagnostics;
using System.IO;

namespace IdpGie.Core {

	/// <summary>
	/// A basic implementation of the <see cref="IProcessSession"/> interface.
	/// </summary>
	public abstract class ProcessSession : IProcessSession {

		/// <summary>
		/// The process on which operations take place.
		/// </summary>
		protected readonly Process Process;

		/// <summary>
		/// The <c>stdin</c> of the <see cref="ProcessSession.Process"/>. One can communicate with the process by writing messages to this <see cref="StreamWriter"/>.
		/// </summary>
		protected readonly StreamWriter Stdin;

		/// <summary>
		/// The <c>stdout</c> of the <see cref="ProcessSession.Process"/>. One can communicate with the process by reading messages from this <see cref="StreamWriter"/>.
		/// </summary>
		protected readonly StreamReader Stdout;

		/// <summary>
		/// The <c>stderr</c> of the <see cref="ProcessSession.Process"/>. One can communicate with the process by reading messages from this <see cref="StreamWriter"/>.
		/// </summary>
		protected readonly StreamReader Stderr;

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Core.ProcessSession"/> class with the given <paramref name="filename"/> of the executable and the <paramref name="arguments"/> with which it should be invoked.
		/// </summary>
		/// <param name='filename'>
		/// The filename of the executable to run.
		/// </param>
		/// <param name='arguments'>
		/// The arguments with which the executable should be executed.
		/// </param>
		protected ProcessSession (string filename, string arguments) {
			this.Process = new Process ();
			this.Process.StartInfo.FileName = filename;
			this.Process.StartInfo.Arguments = arguments;
			this.Process.StartInfo.UseShellExecute = false;
			this.Process.StartInfo.RedirectStandardInput = true;
			this.Process.StartInfo.RedirectStandardOutput = true;
			this.Process.StartInfo.RedirectStandardError = true;
			this.Process.StartInfo.CreateNoWindow = true;
			this.Process.Start ();
			this.Stdin = this.Process.StandardInput;
			this.Stdin.AutoFlush = false;
			this.Stdout = this.Process.StandardOutput;
			this.Stderr = this.Process.StandardError;
		}

		#region IDisposable implementation

		/// <summary>
		/// Releases all resource used by the <see cref="IdpGie.Core.ProcessSession"/> object.
		/// </summary>
		/// <remarks>
		/// Call <see cref="Dispose"/> when you are finished using the <see cref="IdpGie.Core.ProcessSession"/>. The
		/// <see cref="Dispose"/> method leaves the <see cref="IdpGie.Core.ProcessSession"/> in an unusable state. After
		/// calling <see cref="Dispose"/>, you must release all references to the <see cref="IdpGie.Core.ProcessSession"/> so
		/// the garbage collector can reclaim the memory that the <see cref="IdpGie.Core.ProcessSession"/> was occupying.
		/// </remarks>
		public void Dispose () {
			this.Stdin.Close ();
			this.Stdout.Close ();
			this.Stderr.Close ();
			this.Process.Close ();
		}

		#endregion

	}
}

