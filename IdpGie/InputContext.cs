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
using System.Collections.Generic;

namespace IdpGie {

    public class InputContext {

        private readonly Dictionary<Tuple<string,int>,Function> functions = new Dictionary<Tuple<string, int>, Function> ();
        private readonly Dictionary<Tuple<string,int>,Predicate> predicates = new Dictionary<Tuple<string, int>, Predicate> ();

        public InputContext () {
        }

        public Function CreateFunction (string name, int arity) {
            Tuple<string,int> key = new Tuple<string, int> (name, arity);
            Function f;
            if (!this.functions.TryGetValue (key, out f)) {
                f = new Function (name, arity);
                this.functions.Add (key, f);
            }
            return f;
        }

        public Predicate CreatePredicate (string name, int arity) {
            Tuple<string,int> key = new Tuple<string, int> (name, arity);
            Predicate p;
            if (!this.predicates.TryGetValue (key, out p)) {
                p = new Predicate (name, arity);
                this.predicates.Add (key, p);
            }
            return p;
        }

    }
}

