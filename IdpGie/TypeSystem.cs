//
//  TypeSystem.cs
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

    public static class TypeSystem {

        public static bool CanConvert (TermType frm, TermType to) {
            return (frm & to) == to;
        }

        public static IEnumerable<object> GetArguments (IEnumerable<IFunctionInstance> arguments, IEnumerable<TermType> termTypes, IEnumerable<Type> methodTypes) {
            return methodTypes.GenerateDual (arguments.SelectDual (termTypes, (x,y) => x.ConvertedValue (y)), GetDefault);
        }

        public static object GetDefault (Type type) {
            if (type.IsValueType) {
                return Activator.CreateInstance (type);
            } else {
                return null;
            }
        }

    }
}

