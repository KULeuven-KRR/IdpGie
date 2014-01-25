using System;

namespace IdpGie {
	public interface IOutputDevice : IDisposable {
		DrawTheory Theory {
			get;
		}

		void Run (ProgramManager manager);
	}
}

