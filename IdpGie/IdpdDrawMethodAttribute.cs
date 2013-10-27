//
//  IdpdMethodAttribute.cs
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
using IdpGie.Utils;

namespace IdpGie {

    [AttributeUsage(AttributeTargets.Method)]
    public class IdpdDrawMethodAttribute : IdpdMethodAttribute {

        private readonly bool nameDependent;
        private readonly bool timeDependent;

        public bool NameDependent {
            get {
                return this.nameDependent;
            }
        }

        public bool TimeDependent {
            get {
                return this.timeDependent;
            }
        }

        public IdpdDrawMethodAttribute (string name, bool nameDepedent = true, bool timeDependent = false, double priority = 1.0d, params TermType[] types) : base(name,priority,types) {
            this.nameDependent = nameDepedent;
            this.timeDependent = timeDependent;
        }

        public IdpdDrawMethodAttribute (string name, bool nameDepedent = true, bool timeDependent = false, params TermType[] types) : this(name,nameDepedent,timeDependent,1.0d,types) {
        }

        public IEnumerable<TypedMethodPredicate> Predicates (MethodInfo mi) {
            string stem = "idpd_" + this.Name;
            List<TermType> tt = this.Types.ToList ();
            if (this.nameDependent) {
                tt.Insert (0x00, TermType.String);
            }
            yield return new TypedMethodPredicate (stem, tt, mi);
            if (this.TimeDependent) {
                tt.Add (TermType.Float);
                yield return new TypedMethodPredicate (stem, tt, mi);
                stem += "_t";
                yield return new TypedMethodPredicate (stem, tt, mi);
            }
        }

    }

}
