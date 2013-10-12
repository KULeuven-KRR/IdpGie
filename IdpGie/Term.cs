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
using System.Collections.Generic;

namespace IdpGie {
    public class Term {

        private readonly TermBase header;
        private readonly List<Term> terms;

        public TermBase Header {
            get {
                return this.header;
            }
        }

        public List<FunctionInstance> Terms {
            get {
                return this.terms;
            }
        }

        public Term (TermBase termbase, List<FunctionInstance> terms) {
        }

        public override string ToString () {
            return string.Format ("{0}({1})", this.header.Name, string.Join (",", this.terms));
        }

    }
}

