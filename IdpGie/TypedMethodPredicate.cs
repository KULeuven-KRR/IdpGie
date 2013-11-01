//
//  TypedActionPredicate.cs
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

    public class TypedMethodPredicate : TypedPredicate {

        private MethodInfo method;

        public MethodInfo Method {
            get {
                return this.method;
            }
            protected set {
                this.method = value;
            }
        }

        public TypedMethodPredicate (string name, IList<TermType> termTypes, MethodInfo method, double priority = 1.0d) : base(name,termTypes,priority) {
            this.method = method;
        }

        public override void Execute (DrawTheory theory, IEnumerable<IFunctionInstance> arguments) {
            object[] val = EnumerableUtils.HeadTail (theory, TypeSystem.GetArguments (arguments, this.TermTypes, this.method.GetParameters ().Skip (0x01).Select (x => x.ParameterType))).ToArray ();
            try {
                this.method.Invoke (null, val);
                base.Execute (theory, arguments);
            } catch (Exception e) {
                Console.WriteLine ("Could not execute the {0} atom.", this.TermString (arguments));
                //Console.WriteLine (e);
            }
        }

    }
}

