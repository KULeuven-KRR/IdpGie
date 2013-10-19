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

namespace IdpGie {

    [AttributeUsage(AttributeTargets.Method)]
    public class IdpdMethodAttribute : Attribute, IName {

        private readonly string name;
        private readonly bool nameDependent;
        private readonly bool timeDependent;
        private readonly IList<TermType> types;

        public string Name {
            get {
                return name;
            }
        }

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

        public IList<TermType> Types {
            get {
                return this.types;
            }
        }

        public Tuple<string, int> Signature {
            get {
                return new Tuple<string,int> ("idpd_" + this.Name, this.types.Count);
            }
        }
        public IdpdMethodAttribute (string name, bool nameDepedent = true, bool timeDependent = false, params TermType[] types) {
            this.name = name;
            this.nameDependent = nameDepedent;
            this.timeDependent = timeDependent;
            this.types = types;
        }

    }

}