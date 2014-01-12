//
//  StructureFunctionInstance.cs
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

    public class StructureFunctionInstance : IFunctionInstance {

        private StructureFunction function;
        private object value;

        #region ITerm implementation
        public IFunctionInstance this [int index] {
            get {
                throw new IndexOutOfRangeException ();
            }
        }

        public ITermHeader Header {
            get {
                return this.function;
            }
        }

        public IEnumerable<IFunctionInstance> Terms {
            get {
                yield break;
            }
        }
        #endregion

        #region IFunctionInstance implementation
        public TermType Type {
            get {
                return TermType.None;//TODO
                //return this.function.ReturnType;
            }
        }

        public IFunction Function {
            get {
                return this.function;
            }
        }

        public object Value {
            get {
                return this.value;
            }
        }
        #endregion
        public StructureFunctionInstance (StructureFunction function, object structureValue) {
            this.function = function;
            this.value = structureValue;
        }


        #region ITerm implementation
        public bool Equals (ITerm other) {
            throw new System.NotImplementedException ();
        }
        #endregion

        #region IFunctionInstance implementation
        public bool CanConvert (TermType target) {
            return TypeSystem.CanConvert (this.Type, target);
        }

        public object ConvertedValue (TermType targetType) {
            return this.function.ConvertedValue (this.value, targetType);
        }
        #endregion

    }
}