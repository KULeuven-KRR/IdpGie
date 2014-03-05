//
//  Predicate.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
//
//  Copyright (c) 2013 Willem Van Onsem
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System.Linq;
using System.Collections.Generic;
using IdpGie.Core;
using IdpGie.Utils;

namespace IdpGie.Logic {
	public class Predicate : TermHeader, IPredicate {

		#region IPredicate implementation

		public virtual bool IsDrawCommand {
			get {
				return false;
			}
		}

		public virtual bool IsHook {
			get {
				return false;
			}
		}

		#endregion

		public Predicate (string name, int arity, double priority = 1.0d) : base (name, arity, priority) {
		}

		public bool ValidateAtom (Atom atom) {
			return (atom != null && atom.Header == this && atom.Terms.Count == this.Arity);
		}

		public virtual void Execute (DrawTheory theory, IEnumerable<IFunctionInstance> arguments) {
			this.Execute (theory, arguments, EnumerableUtils.Zero<IAtom> ());
		}

		public virtual void Execute (DrawTheory theory, IEnumerable<IFunctionInstance> arguments, IEnumerable<IAtom> body) {
		}

		IAtom IPredicate.CreateInstance (IEnumerable<IFunctionInstance> terms) {
			return (IAtom)this.CreateInstance (terms);
		}

		#region IPredicate implementation

		public override ITerm CreateInstance (IEnumerable<IFunctionInstance> terms) {
			List<IFunctionInstance> list;
			if (terms != null) {
				list = terms.ToList ();
			} else {
				list = new List<IFunctionInstance> ();
			}
			return new Atom (this, list);
		}

		#endregion

		#region IPredicate implementation

		public IAtom GetInstance (IEnumerable<IFunctionInstance> terms) {
			throw new System.NotImplementedException ();
		}

		#endregion

	}
}

