//
//  Term.cs
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

    public class Term : ITerm {

        private readonly ITermHeader header;
        private readonly List<IFunctionInstance> terms;

        public ITermHeader Header {
            get {
                return this.header;
            }
        }

        IEnumerable<IFunctionInstance> ITerm.Terms {
            get {
                return this.Terms;
            }
        }

        public List<IFunctionInstance> Terms {
            get {
                return this.terms;
            }
        }

        public IFunctionInstance this [int index] {
            get {
                return this.terms [index];
            }
        }

        public Term (ITermHeader header, List<IFunctionInstance> terms) {
            if (header == null) {
                throw new ArgumentNullException ("The header of a term always must be effective.", "header");
            } else if (terms == null) {
                throw new ArgumentNullException ("The list of terms must be effective.", "terms");
            } else if (terms.Any (x => x == null)) {
                throw new ArgumentException ("All subterms must be effective.", "terms");
            } else {
                this.header = header;
                this.terms = terms;
            }
        }

        public override string ToString () {
            return this.header.TermString (this.terms);
        }

        #region ITerm implementation
        public bool Equals (ITerm other) {
            return Object.Equals (this.Header, other.Header) && this.Terms.AllDual (other.Terms, (x,y) => x.Equals (y));
        }
        #endregion

    }
}

