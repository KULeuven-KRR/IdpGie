using System;

namespace IdpGie.Core {
	public interface IOutputDevice : IDisposable {
		DrawTheory Theory {
			get;
		}

		void Run (ProgramManager manager);
	}
}

