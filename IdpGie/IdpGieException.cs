using System;
using System.Runtime.Serialization;

namespace IdpGie {
	public class IdpGieException : Exception {
		public IdpGieException () : base () {
		}

		public IdpGieException (string message) : base (message) {
		}

		public IdpGieException (string message, params object[] parameters) : base (string.Format (message, parameters)) {
		}

		public IdpGieException (string message, Exception innerException) : base (message, innerException) {
		}

		public IdpGieException (string message, Exception innerException, params object[] parameters) : base (string.Format (message, parameters), innerException) {
		}

		public IdpGieException (SerializationInfo info, StreamingContext context) : base (info, context) {
		}
	}
}

