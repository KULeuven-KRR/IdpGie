//
//  PredicateInstance.cs
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
using IdpGie.Core;

namespace IdpGie.Logic {

    public class Atom : Term, IAtom {

        #region IPriority implementation
        public double Priority {
            get {
                return this.Header.Priority;
            }
        }
        #endregion

        #region IAtom implementation
        public IPredicate Predicate {
            get {
                return (IPredicate)this.Header;
            }
        }
        #endregion


        public Atom (IPredicate predicate, List<IFunctionInstance> terms) : base(predicate,terms) {
        }

        #region IAtom implementation
        public void Execute (DrawTheory theory) {
            this.Predicate.Execute (theory, this.Terms);
        }
        #endregion


    }
}

