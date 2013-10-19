//
//  GlobalContext.cs
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
using System.Linq;
using System.Reflection;

namespace IdpGie {

    public class GlobalInputContext : IInputContext {

        private readonly Dictionary<Tuple<string,int>,TypedMethodPredicate> predicates = new Dictionary<Tuple<string, int>, TypedMethodPredicate> ();
        public static readonly GlobalInputContext Instance = new GlobalInputContext ();

        private GlobalInputContext () {
            this.LoadAssembly (Assembly.GetExecutingAssembly ());
        }

        public void LoadAssembly (Assembly assembly) {
            foreach (Type type in assembly.GetTypes()) {
                analyzeType (type);
            }
        }

        private void analyzeType (Type type) {
            if (!type.IsAbstract && type.GetCustomAttributes (typeof(IdpdMapperAttribute), false).Length > 0x00) {
                foreach (MethodInfo method in type.GetMethods()) {
                    analyzeMethod (type, method);
                }
            }
        }

        private void analyzeMethod (Type type, MethodInfo method) {
            if (!method.IsAbstract) {
                foreach (IdpdMethodAttribute ma in method.GetCustomAttributes(typeof(IdpdMethodAttribute),false).Cast<IdpdMethodAttribute>()) {
                    this.predicates.Add (ma.Signature, new TypedMethodPredicate ("idpd_" + ma.Name, ma.Types, method));
                }
            }
        }

        #region IInputContext implementation
        public Predicate GetPredicate (string name, int arity) {
            TypedMethodPredicate p;
            Tuple<string,int> key = new Tuple<string, int> (name, arity);
            if (predicates.TryGetValue (key, out p)) {
                return p;
            } else {
                return null;
            }
        }

        public Function GetFunction (string name, int arity) {
            return null;
        }
        #endregion


    }

}

