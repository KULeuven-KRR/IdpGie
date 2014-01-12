using System;

namespace IdpGie {
	public class AddTheoryAlteringMethod : ITheoryAlteringMethod {
		public AddTheoryAlteringMethod (ITerm term) {
		}

		#region IAlteringStreamMethod implementation

		public void Execute (System.IO.Stream stream) {
			throw new NotImplementedException ();
		}

		#endregion

	}
}

