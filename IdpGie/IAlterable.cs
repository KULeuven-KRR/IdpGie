using System;

namespace IdpGie.Abstract {
	public interface IAlterable<TCommand> {
		void Alter (TCommand command);
	}
}

