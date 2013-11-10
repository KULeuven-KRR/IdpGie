//
//  DrawTheory.cs
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
using System.Text;

namespace IdpGie {

    public class DrawTheory : NameBase {

        private readonly List<ITheoryItem> elements;
        private readonly Dictionary<IFunctionInstance,IIdpdObject> objects = new Dictionary<IFunctionInstance, IIdpdObject> ();

        private DrawTheoryMode mode = DrawTheoryMode.Cairo;
        private double minTime = 0.0d;
        private double maxTime = 0.0d;

        public DrawTheoryMode Mode {
            get {
                return this.mode;
            }
            set {
                this.mode = value;
            }
        }

        public IIdpdObject this [IFunctionInstance key] {
            get {
                return this.objects [key];
            }
        }

        public List<ITheoryItem> Elements {
            get {
                return this.elements;
            }
        }

        public double MinTime {
            get {
                return this.minTime;
            }
        }

        public double MaxTime {
            get {
                return this.maxTime;
            }
        }

        public double TimeSpan {
            get {
                return this.maxTime - minTime;
            }
        }

        public DrawTheory (string name, List<ITheoryItem> elements) : base(name) {
            if (elements != null) {
                this.elements = elements;
            } else {
                this.elements = new List<ITheoryItem> ();
            }
        }

        public void RegisterTime (double time) {
            if (this.minTime > time) {
                this.minTime = time;
            } else if (this.maxTime < time) {
                this.maxTime = time;
            }
        }

        public string ToFullString () {
            StringBuilder sb = new StringBuilder ();
            foreach (ITheoryItem atm in elements) {
                sb.AppendFormat ("{0}.", atm);
                sb.AppendLine ();
            }
            return sb.ToString ();
        }

        internal void AddIdpdObject (IIdpdObject obj) {
            this.objects.Add (obj.Name, obj);
            Console.WriteLine ("added {0} as {1}", obj, obj.Name);
            if (this.objects [obj.Name] != obj) {
                Console.WriteLine ("CORRUPT HASH!");
            }
        }

        public IEnumerable<IIdpdObject> Objects () {
            return this.objects.Values;
        }

        public void Execute (ProgramManager manager) {
            //TODO: Tp operator
            elements.Sort (PriorityComparator.Instance);
            foreach (ITheoryItem item in elements) {
                item.Execute (this);
            }
            foreach (IdpdObject obj in this.objects.Values) {
                obj.Time = 0.0d;
            }
            switch (this.Mode) {
            case DrawTheoryMode.Cairo:
                using (OutputDevice device = new OutputCairoDevice(this)) {
                    device.Run (manager);
                }
                break;
            case DrawTheoryMode.OpenGL:
                using (OutputDevice device = new OutputOpenGLDevice(this)) {
                    device.Run (manager);
                }
                break;
            case DrawTheoryMode.LaTeX:
                using (OutputDevice device = new OutputLaTeXDevice(this)) {
                    device.Run (manager);
                }
                break;
            case DrawTheoryMode.Print:
                using (OutputDevice device = new OutputPrintDevice(this)) {
                    device.Run (manager);
                }
                break;
            }
        }

    }
}

