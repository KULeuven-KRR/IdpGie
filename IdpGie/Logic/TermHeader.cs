//
//  TermBase.cs
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
using System;
using System.Collections.Generic;
using IdpGie.Abstract;
using IdpGie.Utils;

namespace IdpGie.Logic {
	public abstract class TermHeader : NameBase, ITermHeader {
		private int arity;
		private double priority;

		#region ITermHeader implementation

		public int Arity {
			get {
				return this.arity;
			}
			protected set {
				this.arity = value;
			}
		}

		public Tuple<string, int> Signature {
			get {
				return new Tuple<string, int> (this.Name, this.Arity);
			}
		}

		#endregion

		#region IPriority implementation

		public double Priority {
			get {
				return this.priority;
			}
			protected set {
				this.priority = value;
			}
		}

		#endregion

		protected TermHeader (string name, int arity, double priority = 1.0d) : base (name) {
			if (name == null || name == string.Empty) {
				throw new ArgumentNullException ("The name of a function or predicate must be effective.", "name");
			} else if (arity < 0x00 || arity > 0xff) {
				throw new ArgumentException ("The arity of a function must be larger or equal to zero and lower than 256.", "arity");
			}
			this.Arity = arity;
			this.Priority = priority;
		}

		public override string ToString () {
			return string.Format ("{0}/{1}", this.Name, this.Arity);
		}

		public static string TermString (string name, IEnumerable<IFunctionInstance> terms) {
			if (!terms.Empty ()) {
				return string.Format ("{0}({1})", name, string.Join (",", terms));
			} else {
				return name;
			}
		}

		public virtual string TermString (IEnumerable<IFunctionInstance> terms) {
			return TermHeader.TermString (this.Name, terms);
		}

		public abstract ITerm CreateInstance (IEnumerable<IFunctionInstance> terms);

		public ITerm CreateInstance (params IFunctionInstance[] terms) {
			return this.CreateInstance ((IEnumerable<IFunctionInstance>)terms);
		}
	}
}

