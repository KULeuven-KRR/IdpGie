//
//  NamePriorityArityBase.cs
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

namespace IdpGie {

    public abstract class NameArityPriorityBase : NameBase, IPriority, IArity {

        private int arity;
        private double priority;

        #region IArity implementation
        public virtual int Arity {
            get {
                return this.arity;
            }
            protected set {
                this.arity = value;
            }
        }
        #endregion

        #region IPriority implementation
        public virtual double Priority {
            get {
                return this.priority;
            }
            protected set {
                this.priority = value;
            }
        }
        #endregion

        protected NameArityPriorityBase (string name, int arity = 0x00, double priority = 1.0d) : base(name) {
            this.Arity = arity;
            this.Priority = priority;
        }
    }
}

