//
//  TypesMethodHeadPredicate.cs
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
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace IdpGie.Logic {

    public class TypedMethodHeadPredicate : TypedMethodPredicate {

        public TypedMethodHeadPredicate (string name, IList<TermType> termTypes, MethodInfo method, double priority = 1.0d) : base(name,termTypes,method,priority) {
        }

        public override void Execute (DrawTheory theory, IEnumerable<IFunctionInstance> arguments, IEnumerable<IAtom> body) {
            object[] val = EnumerableUtils.HeadsLast (EnumerableUtils.HeadTail (theory, TypeSystem.GetArguments (arguments, this.TermTypes, this.Method.GetParameters ().Skip (0x01).Select (x => x.ParameterType)).SkipTail (0x01)), body).ToArray ();
            try {
                this.Method.Invoke (null, val);
                base.Execute (theory, arguments);
            } catch (Exception) {
                Console.WriteLine ("Could not execute the {0} atom.", this.TermString (arguments));
            }
        }

    }

}

