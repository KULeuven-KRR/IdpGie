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

namespace IdpGie {

    public class IdpdObjectTimeState {

        private bool visible;
        private Matrix4d transformations;
        private string text;

        public bool Visible {
            get {
                return visible;
            }
            set {
                visible = value;
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

        public double Xpos {
            get {
                return this.transformations.M14;
            }
            set {
                this.transformations.M14 = value;
            }
        }

        public double Ypos {
            get {
                return this.transformations.M24;
            }
            set {
                this.transformations.M24 = value;
            }
        }
        
        public double Zpos {
            get {
                return this.transformations.M34;
            }
            set {
                this.transformations.M34 = value;
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

    }

}

