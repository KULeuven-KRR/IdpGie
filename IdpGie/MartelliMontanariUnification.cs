//
//  MartelliMontanariUnification.cs
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
using IdpGie.Utils;

namespace IdpGie.Logic.Altering {

	public class MartelliMontanariUnification : IUnificationAlgorithm {
		public MartelliMontanariUnification () {
		}

		#region IUnificationAlgorithm implementation

		public IEnumerable<Tuple<IVariable, IFunctionInstance>> Unify (IEnumerable<ITerm> terms) {
			Stack<IEnumerable<ITerm>> state = new Stack<IEnumerable<ITerm>> ();
			state.Push (terms);
			IEnumerable<ITerm> top;
			while (state.Count > 0x00) {
				top = state.Pop ();

			}
			yield break;
		}

		private void Peel (Stack<IEnumerable<ITerm>> stack, IEnumerable<ITerm> toPeel) {

		}

		private void Peel (Stack<Tuple<ITerm,ITerm>> stack, ITerm a, ITerm b) {
			if (a.Header != b.Header) {
				throw new UnificationException ("Both headers of the term/atom must have the same name and arity.");
			} else {
				stack.PushAll (a.Terms.TupleWith<ITerm,ITerm> (b.Terms));
			}
		}

		public IEnumerable<Tuple<IVariable, IFunctionInstance>> Unify (ITerm term1, ITerm term2) {
			Stack<Tuple<ITerm,ITerm>> state = new Stack<Tuple<ITerm,ITerm>> ();
			state.Push (new Tuple<ITerm,ITerm> (term1, term2));
			Tuple<ITerm,ITerm> top;
			ITerm topa, topb;
			while (state.Count > 0x00) {
				top = state.Pop ();
				topa = top.Item1;
				topb = top.Item2;
				if (topa is IFunctionInstance && topb is IFunctionInstance) {
					if (topa is IVariable) {
						yield return new Tuple<IVariable,IFunctionInstance> ((IVariable)topa, (IFunctionInstance)topb);
					} else if (topb is IVariable) {
						yield return new Tuple<IVariable,IFunctionInstance> ((IVariable)topb, (IFunctionInstance)topa);
					}
				} else if (topa is IAtom && topb is IAtom) {
					this.Peel (state, topa, topb);
				} else {
					throw new UnificationException ("An atom and term cannot be unified.");
				}
			}
			yield break;
		}

		#endregion

	}
}

