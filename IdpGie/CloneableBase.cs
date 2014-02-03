using System;

namespace IdpGie {
	public abstract class CloneableBase<TResult> : ICloneable<TResult> where TResult : class {
		protected CloneableBase () {
		}

		#region ICloneable implementation

		public abstract TResult Clone ();

		#endregion

		#region ICloneable implementation

		object ICloneable.Clone () {
			return this.Clone ();
		}

		#endregion

	}
}

