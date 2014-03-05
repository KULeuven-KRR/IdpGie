using System;
using System.Diagnostics;
using System.IO;

namespace IdpGie.Core {
	public abstract class ProcessSession : IDisposable {
		protected readonly Process Process;
		protected readonly StreamWriter Stdin;
		protected readonly StreamReader Stdout, Stderr;

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

		public void Dispose () {
			this.Stdin.Close ();
			this.Stdout.Close ();
			this.Stderr.Close ();
			this.Process.Close ();
		}

		#endregion

	}
}

