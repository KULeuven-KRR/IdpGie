using System;
using System.Collections.Generic;
using System.Reflection;

namespace IdpGie {
	public class Body {
		private readonly IEnumerable<IAtom> body;

		public IEnumerable<IAtom> Elements {
			get {
				return body;
			}
		}

		public Body (IEnumerable<IAtom> elements) {
			this.body = elements;
		}

		public void Execute (DrawTheory theory) {
			foreach (IAtom atom in this.body) {
				atom.Execute (theory);
			}
		}
	}
}

