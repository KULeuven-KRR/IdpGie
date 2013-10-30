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
using OpenTK;
using Cairo;

namespace IdpGie {

    public class IdpdObjectTimeState {

        private bool visible;
        private Matrix4d transformations;
        private Matrix cairoTransformations = null;
        private string text;
        private Color innerColor = new Color (0.0d, 0.0d, 0.0d, 0.0d);
        private Color edgeColor = new Color (0.0d, 0.0d, 0.0d);

        public bool Visible {
            get {
                return visible;
            }
            set {
                visible = value;
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
                return this.calcCairoTransformations ();
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

        public IdpdObjectTimeState () {
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

        private Matrix calcCairoTransformations () {
            Matrix ct = this.cairoTransformations;
            if (ct == null) {
                Matrix4d t = this.transformations;
                ct = new Matrix (t.M11, t.M21, t.M12, t.M22, t.M14, t.M24);
                this.cairoTransformations = ct;
            }
            return ct;
        }

        private void makeDirty () {
            this.cairoTransformations = null;
        }

    }

}

