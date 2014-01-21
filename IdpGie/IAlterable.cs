using System;

namespace IdpGie {
	public interface IAlterable<TCommand> {
		void Alter (TCommand command);
	}
}

