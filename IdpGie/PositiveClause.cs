//
//  PositiveClause.cs
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

using System.Collections.Generic;
using System;

namespace IdpGie {
	public class PositiveClause : IPositiveClause {
		private readonly IAtom head;
		private readonly Body body;

		#region IPositiveClause implementation

		public IAtom Head {
			get {
				return this.head;
			}
		}

		IEnumerable<IAtom> IPositiveClause.Body {
			get {
				return this.body.Elements;
			}
		}

		#endregion

		public Body Body {
			get {
				return this.body;
			}
		}

		#region IPriority implementation

		public double Priority {
			get {
				return this.head.Priority;
			}
		}

		#endregion

		public PositiveClause (IAtom head, IEnumerable<IAtom> body) : this (head, new Body (body)) {
		}

		public PositiveClause (IAtom head, Body body) {
			this.head = head;
			this.body = body;
		}

		public override string ToString () {
			return string.Format ("{0} :- {1}", this.head, string.Join (", ", this.body));
		}

		public virtual void Execute (DrawTheory theory) {
			this.head.Predicate.Execute (theory, this.head.Terms, this.Body.Elements);
		}
	}
}