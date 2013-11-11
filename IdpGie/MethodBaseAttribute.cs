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

    public abstract class MethodBaseAttribute : NamedAttributeBase, IPriority {

        private readonly double priority;
        private readonly IList<TermType> types;

        #region IPriority implementation
        public virtual double Priority {
            get {
                return this.priority;
            }
        }
        #endregion

        public virtual IList<TermType> Types {
            get {
                return this.types;
            }
        }

        public virtual Tuple<string, int> Signature {
            get {
                return new Tuple<string,int> ("idpd_" + this.Name, this.Types.Count);
            }
        }

        protected MethodBaseAttribute (string name, double priority = 1.0d, params TermType[] types) : base(name) {
            this.priority = priority;
            this.types = types;
        }

    }
}

