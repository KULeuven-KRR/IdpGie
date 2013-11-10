//
//  IdpdObject.cs
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
using System.Text;
using Cairo;
using OpenTK;

namespace IdpGie {

    public abstract class IdpdObject : IIdpdObject {

        private readonly IFunctionInstance name;
        private readonly IdpdObjectTimeState state = new IdpdObjectTimeState ();

        #region IIdpdObject implementation
        public IFunctionInstance Name {
            get {
                return this.name;
            }
        }

        public double Time {
            get {
                return this.state.Time;
            }
            set {
                this.state.SetTime (value);
            }
        }
        #endregion

        #region IZIndix implementation
        public double ZIndex {
            get {
                return this.state.Zpos;
            }
        }
        #endregion

        #region IIdpdObject implementation
        public IdpdObjectTimeState State {
            get {
                return this.state;
            }
        }
        #endregion

        protected IdpdObject (IFunctionInstance name) {
            this.name = name;
        }

        protected virtual void InnerPaintObject (Context ctx) {
            cairoFillStroke (ctx);
        }

        protected virtual void InnerWriteTikz (StringBuilder sb) {

        }

        #region IIdpdObject implementation
        public virtual void PaintObject (Context ctx) {
            if (this.state.Visible) {
                ctx.Save ();
                ctx.Transform (this.state.CairoTransformations);
                this.InnerPaintObject (ctx);
                ctx.Restore ();
            }
        }

        public virtual void WriteTikz (StringBuilder builder) {
            builder.AppendFormat ("\\begin{scope}[xshift={0} cm,yshift={1} cm]", this.State.Xpos, this.State.Ypos);
            this.InnerWriteTikz (builder);
            builder.Append (@"\end{scope}");
        }

        public virtual void Render (FrameEventArgs e) {

        }

        public void AddModifier (IdpdObjectTimeStateModifier modifier) {
            this.State.AddModifier (modifier);
        }

        public void AddModifier (double time, Action<IdpdObjectTimeState> modifier) {
            this.State.AddModifier (time, modifier);
        }
        #endregion

        private void cairoFillStroke (Context ctx) {
            ctx.Color = this.state.InnerColor;
            ctx.FillPreserve ();
            ctx.Color = this.state.EdgeColor;
            ctx.Stroke ();
        }

        public override string ToString () {
            return string.Format ("{0}[{1}]", this.GetType ().Name, this.Name);
        }

        #region IIdpdTransformable implementation
        public void SetXPos (double xpos) {
            this.state.SetXPos (xpos);
        }

        public void SetYPos (double ypos) {
            this.state.SetYPos (ypos);
        }

        public void SetZPos (double zpos) {
            this.state.SetZPos (zpos);
        }
        #endregion

    }

}

