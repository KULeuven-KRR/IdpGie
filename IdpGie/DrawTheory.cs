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
using IdpGie.Logic;

namespace IdpGie {

    public class DrawTheory : NameBase, ITimesensitive {

        private readonly List<ITheoryItem> elements;
        private readonly Dictionary<IFunctionInstance,IShape> objects = new Dictionary<IFunctionInstance, IShape> ();

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

        public IShape this [IFunctionInstance key] {
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
        

        #region ITimesensitive implementation
        public double Time {
            get {
                IEnumerable<IShape> tail;
                IShape head = this.objects.Values.SplitHead (out tail);
                if (head != null) {
                    double time = head.Time;
                    foreach (IShape obj in tail) {
                        if (obj.Time != time) {
                            return double.NaN;
                        }
                    }
                    return time;
                } else {
                    return double.NaN;
                }
            }
            set {
                foreach (IShape obj in this.objects.Values) {
                    obj.Time = value;
                }
            }
        }
        #endregion

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

        internal void AddIdpdObject (IShape obj) {
            this.objects.Add (obj.Name, obj);
        }

        public IEnumerable<IShape> Objects () {
            return this.objects.Values;
        }

        public void Execute (ProgramManager manager) {
            //TODO: Tp operator
            elements.Sort (PriorityComparator.Instance);
            foreach (ITheoryItem item in elements) {
                item.Execute (this);
            }
            this.Time = minTime;
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

        #region IComparable implementation
        public int CompareTo (ITimesensitive other) {
            if (other != null) {
                return this.Time.CompareTo (other.Time);
            } else {
                return -0x01;
            }
        }
        #endregion


    }
}

