//
//  GlobalContext.cs
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

    public class GlobalInputContext : IInputContext {

        private readonly Dictionary<Tuple<string,int>,IPredicate> predicates = new Dictionary<Tuple<string, int>, IPredicate> ();
        private readonly Dictionary<Tuple<string,int>,IFunction> functions = new Dictionary<Tuple<string, int>, IFunction> ();
        public static readonly GlobalInputContext Instance = new GlobalInputContext ();

        private GlobalInputContext () {
            this.LoadAssembly (Assembly.GetExecutingAssembly ());
        }

        private void addPredicate (IPredicate pred) {
            this.predicates.Add (pred.Signature, pred);
        }

        private void addFunction (IFunction func) {
            this.functions.Add (func.Signature, func);
        }

        public void LoadAssembly (Assembly assembly) {
            foreach (Type type in assembly.GetTypes()) {
                if (type.IsClass) {
                    analyzeClass (type);
                }
                if (type.IsValueType) {
                    this.analyzeStruct (type);
                }
                if (type.IsEnum) {
                    analyzeEnum (type);
                }
            }
        }

        private void analyzeEnum (Type type) {
            if (type.GetCustomAttributes (typeof(IdpdNamedObjectEnumAttribute), false).Length > 0x00) {
                foreach (FieldInfo field in type.GetFields()) {
                    analyzeField (field);
                }
            }
        }

        private void analyzeField (FieldInfo field) {
            foreach (IdpdNamedObjectAttribute noa in field.GetCustomAttributes(typeof(IdpdNamedObjectAttribute),false)) {
                NamedFunctionInstance nfi = new NamedFunctionInstance (field.GetValue (null));
                this.functions.Add (nfi.Signature, nfi);
            }
        }

        private void analyzeClass (Type type) {
            if (type.GetCustomAttributes (typeof(MapperAttribute), false).Length > 0x00) {
                this.analyzeMapperClass (type);
            }
        }

        private void analyzeStruct (Type type) {
            foreach (IdpdFunctionStructureAttribute fsa in type.GetCustomAttributes(typeof(IdpdFunctionStructureAttribute),false).Cast<IdpdFunctionStructureAttribute>()) {
                analyzeFunctionStruct (type, fsa);
            }
        }

        private void analyzeFunctionStruct (Type type, IdpdFunctionStructureAttribute fsa) {
            foreach (ConstructorInfo ci in type.GetConstructors()) {
                foreach (IdpdFunctionStructureConstructorAttribute fsca in ci.GetCustomAttributes(typeof(IdpdFunctionStructureConstructorAttribute),false).Cast<IdpdFunctionStructureConstructorAttribute>()) {
                    foreach (StructureFunction f in fsca.StructureFunctions(fsa,ci)) {
                        this.addFunction (f);
                    }
                }
            }
        }

        private void analyzeMapperClass (Type type) {
            foreach (MethodInfo method in type.GetMethods()) {
                analyzeMethod (type, method);
            }
        }

        private void analyzeMethod (Type type, MethodInfo method) {
            if (method.IsStatic) {
                ParameterInfo[] pis = method.GetParameters ();
                if (pis.Length > 0x00) {
                    ParameterInfo pi0 = pis [0x00];
                    if (!pi0.IsRetval && pi0.ParameterType.IsAssignableFrom (typeof(DrawTheory))) {
                        foreach (DrawMethodAttribute ma in method.GetCustomAttributes(typeof(DrawMethodAttribute),false).Cast<DrawMethodAttribute>()) {
                            foreach (TypedMethodPredicate p in ma.Predicates(method)) {
                                this.addPredicate (p);
                            }
                        }
                    }
                }
            }
        }

        #region IInputContext implementation
        public IPredicate GetPredicate (string name, int arity) {
            IPredicate p;
            Tuple<string,int> key = new Tuple<string, int> (name, arity);
            if (predicates.TryGetValue (key, out p)) {
                return p;
            } else {
                return null;
            }
        }

        public IFunction GetFunction (string name, int arity) {
            IFunction f;
            Tuple<string,int> key = new Tuple<string, int> (name, arity);
            if (functions.TryGetValue (key, out f)) {
                return f;
            } else {
                return null;
            }
        }
        #endregion


    }

}

