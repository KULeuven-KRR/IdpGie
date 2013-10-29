//
//  StructureFunction.cs
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

namespace IdpGie {

    public class StructureFunction : NameArityPriorityBase, IFunction {

        private readonly TermType outputType;
        private readonly IList<TermType> inputTypes;
        private readonly ConstructorInfo constructor;
        private readonly Dictionary<TermType,MethodInfo> converts = new Dictionary<TermType, MethodInfo> ();

        #region IFunction implementation
        public TermType OutputType {
            get {
                return this.outputType;
            }
        }

        public bool HasInstance {
            get {
                return true;
            }
        }
        #endregion

        public ConstructorInfo Constructor {
            get {
                return this.constructor;
            }
        }

        public StructureFunction (string name, int arity, TermType outputType, ConstructorInfo constructor, params TermType[] inputTypes) : this(name,arity,outputType,constructor,1.0d,inputTypes) {
        }

        public StructureFunction (string name, int arity, TermType outputType, ConstructorInfo constructor, double priority = 1.0d, params TermType[] inputTypes) : base(name,arity,priority) {
            this.outputType = outputType;
            this.inputTypes = inputTypes;
            this.constructor = constructor;
        }

        public object Fold (IEnumerable<IFunctionInstance> fis) {
            object[] vals = fis.SelectDual (this.inputTypes, (x,y) => x.ConvertedValue (y)).ToArray ();
            return this.constructor.Invoke (vals);
        }

        #region ITermHeader implementation
        public string TermString (IEnumerable<IFunctionInstance> terms) {
            return TermHeader.TermString (this.Name, terms);
        }
        #endregion

        #region IFunction implementation
        public TermType InputType (int index) {
            return this.inputTypes [index];
        }

        public void WidenInput (TermType[] types, int termOffset, int inputOffset) {
        }

        public void WidenInput (TermType[] types, int termOffset, int inputOffset, int inputLength) {
        }

        public void WidenInput (IEnumerable<IFunctionInstance> terms) {
        }
        #endregion

        public object ConvertedValue (object source, TermType targetType) {
            return this.converts [targetType].Invoke (source, new object[0x00]);
        }

        #region IFunction implementation
        public IFunctionInstance CreateInstance (IEnumerable<IFunctionInstance> terms) {
            return new StructureFunctionInstance (this, this.Fold (terms));
        }
        #endregion

        #region ITermHeader implementation
        ITerm ITermHeader.CreateInstance (IEnumerable<IFunctionInstance> terms) {
            return this.CreateInstance (terms);
        }
        #endregion


    }

}
