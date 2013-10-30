//
//  InputContext.cs
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
using System.Linq;
using System.Collections.Generic;

namespace IdpGie {

    public class LocalInputContext : IInputContext {

        private readonly Dictionary<Tuple<string,int>,IFunction> functions = new Dictionary<Tuple<string, int>, IFunction> ();
        private readonly Dictionary<Tuple<string,int>,IPredicate> predicates = new Dictionary<Tuple<string, int>, IPredicate> ();
        private static readonly List<IFunctionInstance> emptyList = new List<IFunctionInstance> ();

        public LocalInputContext () {
        }

        public IFunction GetFunction (string name, int arity) {
            IFunction f = GlobalInputContext.Instance.GetFunction (name, arity);
            if (f == null) {
                Tuple<string,int> key = new Tuple<string, int> (name, arity);
                if (!this.functions.TryGetValue (key, out f)) {
                    f = new Function (name, arity);
                    this.functions.Add (key, f);
                }
            }
            return f;
        }

        public IAtom GetAtom (string name, IEnumerable<IFunctionInstance> terms) {
            int size = 0x00;
            if (terms != null) {
                size = terms.Count ();
            }
            IPredicate p = this.GetPredicate (name, size);
            return GetAtom (p, terms);
        }

        public IAtom GetAtom (IPredicate predicate, IEnumerable<IFunctionInstance> terms) {
            return predicate.CreateInstance (terms);
        }

        public IAtom GetAtom (string name) {
            return this.GetAtom (name, emptyList);
        }

        public IFunctionInstance GetFunctionInstance (string name, IEnumerable<IFunctionInstance> terms) {
            int size = 0x00;
            if (terms != null) {
                size = terms.Count ();
            }
            IFunction f = this.GetFunction (name, size);
            return GetFunctionInstance (f, terms);
        }

        public IFunctionInstance GetFunctionInstance (IFunction function, IEnumerable<IFunctionInstance> terms) {
            return function.CreateInstance (terms);
        }

        public IFunctionInstance GetFunctionInstance (string name) {
            return this.GetFunctionInstance (name, emptyList);
        }

        public IFunctionInstance GetFunctionInstance (Function function) {
            return this.GetFunctionInstance (function, emptyList);
        }

        public IPredicate GetPredicate (string name, int arity) {
            IPredicate p = GlobalInputContext.Instance.GetPredicate (name, arity);
            if (p == null) {
                Tuple<string,int> key = new Tuple<string, int> (name, arity);
                if (!this.predicates.TryGetValue (key, out p)) {
                    p = new Predicate (name, arity);
                    Console.WriteLine ("CP {0}/{1}", name, arity);
                    this.predicates.Add (key, p);
                }
            }
            return p;
        }

    }
}

