//
//  TypedPredicate.cs
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

namespace IdpGie.Logic {

    public class TypedPredicate : Predicate {

        private readonly IList<TermType> termTypes;

        public IList<TermType> TermTypes {
            get {
                return this.termTypes;
            }
        }

        public TypedPredicate (string name, IList<TermType> termTypes, double priority = 1.0d) : base(name,termTypes.Count,priority) {
            this.termTypes = termTypes;
        }

    }

}

