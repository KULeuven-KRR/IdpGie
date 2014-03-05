using System;
using System.Collections.Generic;
using System.Reflection;

namespace IdpGie.Logic {
	public class Body {
		private readonly IEnumerable<IAtom> elements;

		public IEnumerable<IAtom> Elements {
			get {
				return elements;
			}
		}

		public Body (IEnumerable<IAtom> elements) {
			this.elements = elements;
		}

		public void Execute (DrawTheory theory) {
			foreach (IAtom atom in this.elements) {
				atom.Execute (theory);
			}
		}
	}
}

