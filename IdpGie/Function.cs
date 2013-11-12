//
//  Function.cs
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

namespace IdpGie.Logic {

    public class Function : TermHeader, IFunction {

        private TermType outputType;
        private readonly TermType[] inputTypes;


        #region IFunction implementation
        public TermType OutputType {
            get {
                return this.outputType;
            }
            protected set {
                this.outputType = value;
            }
        }

        public bool HasInstance {
            get {
                return true;
            }
        }
        #endregion

        public Function (string name, int arity, TermType outputType = TermType.All, params TermType[] inputTypes) : base(name,arity) {
            this.OutputType = outputType;
            this.inputTypes = new TermType[arity];
            for (int i = arity-0x01; i >= 0x00; i--) {
                this.inputTypes [i] = TermType.None;
            }
            this.WidenInput (inputTypes);
        }

        #region IFunction implementation
        public TermType InputType (int index) {
            return this.inputTypes [index];
        }
        #endregion

        public void WidenInput (TermType[] types, int termOffset = 0x00, int inputOffset = 0x00) {
            this.WidenInput (types, termOffset, inputOffset, types.Length);
        }

        public void WidenInput (TermType[] types, int termOffset, int inputOffset, int inputLength) {
            int io = Math.Min (Math.Max (0x00, inputOffset), types.Length);
            int n = io + Math.Min (Math.Min (inputLength, types.Length - io), this.inputTypes.Length - termOffset);
            for (int i = io, j = termOffset; i < n; i++, j++) {
                inputTypes [j] |= types [i];
            }
        }

        public void WidenInput (IEnumerable<IFunctionInstance> fis) {
            IEnumerator<IFunctionInstance> fise = fis.GetEnumerator ();
            int n = inputTypes.Length;
            for (int i = 0x00; i < n && fise.MoveNext(); i++) {
                inputTypes [i] |= fise.Current.Type;
            }
        }

        IFunctionInstance IFunction.CreateInstance (IEnumerable<IFunctionInstance> terms) {
            return (IFunctionInstance)this.CreateInstance (terms);
        }

        #region IFunction implementation
        public override ITerm CreateInstance (IEnumerable<IFunctionInstance> terms) {
            List<IFunctionInstance> list;
            if (terms != null) {
                list = terms.ToList ();
            } else {
                list = new List<IFunctionInstance> ();
            }
            return new FunctionInstance (this, list);
        }
        #endregion


    }
}

