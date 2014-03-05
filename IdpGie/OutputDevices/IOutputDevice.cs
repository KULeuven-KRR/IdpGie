using System;
using IdpGie.Core;

namespace IdpGie.OutputDevices {
	public interface IOutputDevice : IDisposable {
		DrawTheory Theory {
			get;
		}

		void Run (ProgramManager manager);
	}
}

