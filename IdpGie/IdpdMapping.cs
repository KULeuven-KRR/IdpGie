//
//  IdpdMapping.cs
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
using Cairo;
using System.Collections.Generic;

namespace IdpGie {

    [IdpdMapper]
    public class IdpdMapping {

        public IdpdMapping () {
        }

        [IdpdMethod("polygon",true,false,TermType.PointList)]
        public void Polygon (DrawTheory dt, string name, IList<Point> points) {

        }

        [IdpdMethod("polygon",true,false,TermType.Int,TermType.Float)]
        public void Polygon (DrawTheory dt, string name, int nbOfEdges, double sizeOfEdge) {

        }

        [IdpdMethod("ellipse",true,false,TermType.Float,TermType.Float)]
        public void Ellipse (DrawTheory dt, string name, double width, double height) {

        }

        [IdpdMethod("graph",true,false,TermType.Float,TermType.Float)]
        public void Graph (DrawTheory dt, string name, double width, double height) {

        }

        [IdpdMethod("node",true,true,TermType.String)]
        public void Node (DrawTheory dt, string name, string graph) {

        }

        [IdpdMethod("text",true,true,TermType.String)]
        public void Text (DrawTheory dt, string name, string text) {

        }

        [IdpdMethod("edge",false,false,TermType.String,TermType.String,TermType.String)]
        public void Edge (DrawTheory dt, string node1, string node2, string graph) {

        }

        [IdpdMethod("image",true,true,TermType.Float,TermType.Float,TermType.String)]
        public void Image (DrawTheory dt, string name, double width, double height, string filepath) {

        }

        [IdpdMethod("xpos",true,true,TermType.Float)]
        public void Xpos (DrawTheory dt, string name, double xpos) {

        }

        [IdpdMethod("ypos",true,true,TermType.Float)]
        public void Ypos (DrawTheory dt, string name, double ypos) {

        }

        [IdpdMethod("zpos",true,true,TermType.Float)]
        public void Zpos (DrawTheory dt, string name, double zpos) {

        }

        [IdpdMethod("pos",true,true,TermType.Float,TermType.Float,TermType.Float)]
        public void Pos (DrawTheory dt, string name, double xpos, double ypos, double zpos) {
            this.Xpos (dt, name, xpos);
            this.Ypos (dt, name, ypos);
            this.Zpos (dt, name, zpos);
        }

        

        [IdpdMethod("xshift",true,true,TermType.Float)]
        public void Xshift (DrawTheory dt, string name, double xpos) {

        }

        [IdpdMethod("yshift",true,true,TermType.Float)]
        public void Yshift (DrawTheory dt, string name, double ypos) {

        }

        [IdpdMethod("zshift",true,true,TermType.Float)]
        public void Zshift (DrawTheory dt, string name, double zpos) {

        }

        [IdpdMethod("shift",true,true,TermType.Float,TermType.Float,TermType.Float)]
        public void Shift (DrawTheory dt, string name, double xpos, double ypos, double zpos) {
            this.Xshift (dt, name, xpos);
            this.Yshift (dt, name, ypos);
            this.Zshift (dt, name, zpos);
        }

        [IdpdMethod("xscale",true,true,TermType.Float)]
        public void Xscale (DrawTheory dt, string name, double xscale) {

        }

        [IdpdMethod("yscale",true,true,TermType.Float)]
        public void Yscale (DrawTheory dt, string name, double yscale) {

        }

        [IdpdMethod("zscale",true,true,TermType.Float)]
        public void Zscale (DrawTheory dt, string name, double zscale) {

        }

        [IdpdMethod("scale",true,true,TermType.Float,TermType.Float,TermType.Float)]
        public void Scale (DrawTheory dt, string name, double xscale, double yscale, double zscale) {
            this.Xscale (dt, name, xscale);
            this.Yscale (dt, name, yscale);
            this.Zscale (dt, name, zscale);
        }

        [IdpdMethod("rotate",true,true,TermType.Float,TermType.Float,TermType.Float,TermType.Float)]
        public void Rotate (DrawTheory dt, string name, double ex, double ey, double ez, double alpha) {
        }

        [IdpdMethod("rotateX",true,true,TermType.Float)]
        public void RotateX (DrawTheory dt, string name, double alpha) {
        }

        [IdpdMethod("rotateY",true,true,TermType.Float)]
        public void RotateY (DrawTheory dt, string name, double alpha) {
        }

        [IdpdMethod("rotateZ",true,true,TermType.Float)]
        public void RotateZ (DrawTheory dt, string name, double alpha) {
        }

        [IdpdMethod("edgecolor",true,true,TermType.Int,TermType.Int,TermType.Int)]
        public void EdgeColor (DrawTheory dt, string name, double r, double g, double b) {

        }

        [IdpdMethod("innercolor",true,true,TermType.Int,TermType.Int,TermType.Int)]
        public void InnerColor (DrawTheory dt, string name, double r, double g, double b) {

        }

        [IdpdMethod("depth",true,true,TermType.Float)]
        public void Depth (DrawTheory dt, string name, double index) {
        }

        [IdpdMethod("show",true,true)]
        public void Show (DrawTheory dt, string name) {

        }

        [IdpdMethod("hide",true,true)]
        public void Hide (DrawTheory dt, string name) {

        }

    }

}