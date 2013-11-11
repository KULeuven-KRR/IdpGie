//
//  ObjectTimeState.cs
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
using OpenTK;
using Cairo;

namespace IdpGie {

    public class ShapeState : TimeSensitiveFastReversibleBase, IShapeTransformable {

        private bool visible;
        private Matrix4d transformations;
        private Matrix cairoTransformations;
        private string text;
        private Color innerColor;
        private Color edgeColor;
        private readonly SortedSet<IShapeStateModifier> before = new SortedSet<IShapeStateModifier> ();
        private readonly SortedSet<IShapeStateModifier> after = new SortedSet<IShapeStateModifier> ();

        public bool Visible {
            get {
                return visible;
            }
            set {
                visible = value;
            }
        }

        public override double Time {
            get {
                return base.Time;
            }
            protected set {
                if (value != double.NaN) {
                    this.SetTime (value);
                    base.Time = value;
                }
            }
        }

        public Color InnerColor {
            get {
                return this.innerColor;
            }
            set {
                this.innerColor = value;
            }
        }

        public Color EdgeColor {
            get {
                return this.edgeColor;
            }
            set {
                this.edgeColor = value;
            }
        }

        public Matrix4d Transformations {
            get {
                return this.transformations;
            }
            set {
                this.transformations = value;
            }
        }

        public Matrix CairoTransformations {
            get {
                return this.CalcCairoTransformations ();
            }
        }

        public double Xpos {
            get {
                return this.transformations.M14;
            }
            set {
                this.transformations.M14 = value;
                this.makeDirty ();
            }
        }

        public double Ypos {
            get {
                return this.transformations.M24;
            }
            set {
                this.transformations.M24 = value;
                this.makeDirty ();
            }
        }
        
        public double Zpos {
            get {
                return this.transformations.M34;
            }
            set {
                this.transformations.M34 = value;
                this.makeDirty ();
            }
        }

        public string Text {
            get {
                return this.text;
            }
            set {
                this.text = value;
            }
        }

        public ShapeState () : base(double.NegativeInfinity,double.NegativeInfinity) {
            this.Reset ();
        }

        public void Reset () {
            this.visible = false;
            this.transformations = Matrix4d.Identity;
            this.cairoTransformations = null;
            this.text = null;
            this.innerColor = new Color (0.0d, 0.0d, 0.0d, 0.0d);
            this.edgeColor = new Color (0.0d, 0.0d, 0.0d);
            base.Time = double.NegativeInfinity;
            this.Checkpoint = double.NegativeInfinity;
        }

        public void Reset (double time) {
            this.Reset ();
            this.after.AddAll (this.before);
            before.Clear ();
            this.Advance (time);
        }

        public void Advance (double time) {
            double checkpoint = this.Checkpoint;
            IShapeStateModifier mod = this.after.Min;
            while (mod != null && mod.Time <= time) {
                this.after.Remove (mod);
                this.before.Add (mod);
                mod.Action (this);
                if (!mod.Reversible) {
                    checkpoint = mod.Time;
                }
                mod = this.after.Min;
            }
            this.Checkpoint = checkpoint;
            base.Time = time;
        }

        private void FastReverse (double time) {
            IShapeStateModifier mod = this.before.Max;
            while (mod != null && mod.Time > time) {
                this.before.Remove (mod);
                this.after.Add (mod);
                mod.ReverseAction (this);
                mod = this.before.Max;
            }
            base.Time = time;
        }

        public void Show () {
            this.visible = true;
        }

        public void Hide () {
            this.visible = false;
        }

        public void SetText (string text) {
            this.text = text;
        }

        public void Transform (Matrix4d transformation) {
            this.transformations *= transformation;
            this.makeDirty ();
        }

        public void Shift (Vector3d shift) {
            this.transformations.M14 += shift.X;
            this.transformations.M24 += shift.Y;
            this.transformations.M34 += shift.Z;
            this.makeDirty ();
        }

        public void Shift (double dx, double dy, double dz = 0.0d) {
            this.transformations.M14 += dx;
            this.transformations.M24 += dy;
            this.transformations.M34 += dz;
            this.makeDirty ();
        }

        public void SetXPos (double xpos) {
            this.transformations.M14 = xpos;
            this.makeDirty ();
        }

        public void SetYPos (double ypos) {
            this.transformations.M24 = ypos;
            this.makeDirty ();
        }

        public void SetZPos (double zpos) {
            this.transformations.M34 = zpos;
            this.makeDirty ();
        }

        private Matrix CalcCairoTransformations () {
            Matrix ct = this.cairoTransformations;
            if (Object.ReferenceEquals (ct, null)) {
                Matrix4d t = this.transformations;
                ct = new Matrix (t.M11, t.M21, t.M12, t.M22, t.M14, t.M24);
                this.cairoTransformations = ct;
            }
            return ct;
        }

        private void makeDirty () {
            this.cairoTransformations = null;
        }

        public void SetTime (double time) {
            if (time > base.Time) {
                this.Advance (time);
            } else if (time < base.Time) {
                this.Reverse (time);
            }
        }

        public void AddModifier (IShapeStateModifier modifier) {
            if (modifier != null) {
                int comp = this.CompareTo (modifier);
                if (comp < 0x00) {
                    this.after.Add (modifier);
                } else {
                    //TODO: reprocess?
                    this.before.Add (modifier);
                }
            }
        }

        public void AddModifier (double time, Action<ShapeState> modifier) {
            this.AddModifier (new ShapeStateModifier (time, modifier));
        }

        public void SetEdgeColor (double r, double g, double b) {
            this.edgeColor = new Color (r * MathExtra.Inv255, g * MathExtra.Inv255, b * MathExtra.Inv255);
        }

        public void SetInnerColor (double r, double g, double b) {
            this.innerColor = new Color (r * MathExtra.Inv255, g * MathExtra.Inv255, b * MathExtra.Inv255);
        }

        public override bool CanReverse (double time) {
            return time <= this.Time;
        }

        public override bool CanFastReverse (double time) {
            return time > this.Checkpoint;
        }

        public override void Reverse (double time) {
            if (this.CanFastReverse (time)) {
                FastReverse (time);
            } else if (this.CanReverse (time)) {
                this.Reset (time);
            } else {
                throw new ArgumentException ("Cannot reverse to the given time!");
            }
        }

    }

}