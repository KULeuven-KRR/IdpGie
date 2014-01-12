using System;

namespace IdpGie {
	public class RemoveTheoryAlteringMethod : ITheoryAlteringMethod {
		public RemoveTheoryAlteringMethod () {
		}

		#region IAlteringStreamMethod implementation

		public void Execute (System.IO.Stream stream) {
			throw new NotImplementedException ();
		}

		#endregion

	}
}

