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
using System.Text;
using System.Collections.Generic;

namespace IdpGie {

    public class DrawTheory {

        private readonly List<Atom> atoms;
        private readonly Dictionary<string,IdpdObject> objects = new Dictionary<string, IdpdObject> ();
        private readonly SortedSet<IdpdObject> zObjects = new SortedSet<IdpdObject> ();

        private DrawTheoryMode mode = DrawTheoryMode.Cairo;

        public DrawTheoryMode Mode {
            get {
                return this.mode;
            }
            set {
                this.mode = value;
            }
        }

        public double Time {
            set {
                foreach (IdpdObject obj in objects.Values) {
                    obj.Time = value;
                }
            }
        }

        public List<Atom> Atoms {
            get {
                return this.atoms;
            }
        }

        public DrawTheory (List<Atom> atoms) {
            if (atoms != null) {
                this.atoms = atoms;
            } else {
                atoms = new List<Atom> ();
            }
        }

        public override string ToString () {
            StringBuilder sb = new StringBuilder ();
            foreach (Atom atm in atoms) {
                sb.AppendFormat ("{0}.", atm);
                sb.AppendLine ();
            }
            return sb.ToString ();
        }

        public IEnumerable<IdpdObject> ObjectsTime (double t) {
            this.Time = t;
            return this.zObjects;
        }

        public void Compile () {
            atoms.Sort (PriorityComparator.Instance);
        }

    }
}

