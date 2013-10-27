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
    public static class IdpdMapping {

        [IdpdDrawMethod("rendering",false,false,-1.0d,TermType.Named)]
        public static void Rendering (DrawTheory dt, NamedObject nobj) {
            dt.Mode = (DrawTheoryMode)(byte)(((ulong)nobj) & 0xff);
        }

        [IdpdDrawMethod("polygon",true,false,TermType.PointList)]
        public static void Polygon (DrawTheory dt, string name, IList<Point> points) {

        }

        [IdpdDrawMethod("polygon",true,false,TermType.Int,TermType.Float)]
        public static void Polygon (DrawTheory dt, string name, int nbOfEdges, double sizeOfEdge) {

        }

        [IdpdDrawMethod("ellipse",true,false,TermType.Float,TermType.Float)]
        public static void Ellipse (DrawTheory dt, string name, double width, double height) {

        }

        [IdpdDrawMethod("graph",true,false,TermType.Float,TermType.Float)]
        public static void Graph (DrawTheory dt, string name, double width, double height) {

        }

        [IdpdDrawMethod("node",true,true,TermType.String)]
        public static void Node (DrawTheory dt, string name, string graph) {

        }

        [IdpdDrawMethod("text",true,true,TermType.String)]
        public static void Text (DrawTheory dt, string name, string text) {

        }

        [IdpdDrawMethod("edge",false,false,TermType.String,TermType.String,TermType.String)]
        public static void Edge (DrawTheory dt, string node1, string node2, string graph) {

        }

        [IdpdDrawMethod("image",true,true,TermType.Float,TermType.Float,TermType.String)]
        public static void Image (DrawTheory dt, string name, double width, double height, string filepath) {

        }

        [IdpdDrawMethod("xpos",true,true,TermType.Float)]
        public static void Xpos (DrawTheory dt, string name, double xpos) {

        }

        [IdpdDrawMethod("ypos",true,true,TermType.Float)]
        public static void Ypos (DrawTheory dt, string name, double ypos) {

        }

        [IdpdDrawMethod("zpos",true,true,TermType.Float)]
        public static void Zpos (DrawTheory dt, string name, double zpos) {

        }

        [IdpdDrawMethod("pos",true,true,TermType.Float,TermType.Float,TermType.Float)]
        public static void Pos (DrawTheory dt, string name, double xpos, double ypos, double zpos) {
            Xpos (dt, name, xpos);
            Ypos (dt, name, ypos);
            Zpos (dt, name, zpos);
        }

        

        [IdpdDrawMethod("xshift",true,true,TermType.Float)]
        public static void Xshift (DrawTheory dt, string name, double xpos) {

        }

        [IdpdDrawMethod("yshift",true,true,TermType.Float)]
        public static void Yshift (DrawTheory dt, string name, double ypos) {

        }

        [IdpdDrawMethod("zshift",true,true,TermType.Float)]
        public static void Zshift (DrawTheory dt, string name, double zpos) {

        }

        [IdpdDrawMethod("shift",true,true,TermType.Float,TermType.Float,TermType.Float)]
        public static void Shift (DrawTheory dt, string name, double xpos, double ypos, double zpos) {
            Xshift (dt, name, xpos);
            Yshift (dt, name, ypos);
            Zshift (dt, name, zpos);
        }

        [IdpdDrawMethod("xscale",true,true,TermType.Float)]
        public static void Xscale (DrawTheory dt, string name, double xscale) {

        }

        [IdpdDrawMethod("yscale",true,true,TermType.Float)]
        public static void Yscale (DrawTheory dt, string name, double yscale) {

        }

        [IdpdDrawMethod("zscale",true,true,TermType.Float)]
        public static void Zscale (DrawTheory dt, string name, double zscale) {

        }

        [IdpdDrawMethod("scale",true,true,TermType.Float,TermType.Float,TermType.Float)]
        public static void Scale (DrawTheory dt, string name, double xscale, double yscale, double zscale) {
            Xscale (dt, name, xscale);
            Yscale (dt, name, yscale);
            Zscale (dt, name, zscale);
        }

        [IdpdDrawMethod("rotate",true,true,TermType.Float,TermType.Float,TermType.Float,TermType.Float)]
        public static void Rotate (DrawTheory dt, string name, double ex, double ey, double ez, double alpha) {
        }

        [IdpdDrawMethod("rotateX",true,true,TermType.Float)]
        public static void RotateX (DrawTheory dt, string name, double alpha) {
        }

        [IdpdDrawMethod("rotateY",true,true,TermType.Float)]
        public static void RotateY (DrawTheory dt, string name, double alpha) {
        }

        [IdpdDrawMethod("rotateZ",true,true,TermType.Float)]
        public static void RotateZ (DrawTheory dt, string name, double alpha) {
        }

        [IdpdDrawMethod("edgecolor",true,true,TermType.Int,TermType.Int,TermType.Int)]
        public static void EdgeColor (DrawTheory dt, string name, double r, double g, double b) {

        }

        [IdpdDrawMethod("innercolor",true,true,TermType.Int,TermType.Int,TermType.Int)]
        public static void InnerColor (DrawTheory dt, string name, double r, double g, double b) {

        }

        [IdpdDrawMethod("depth",true,true,TermType.Float)]
        public static void Depth (DrawTheory dt, string name, double index) {
        }

        [IdpdDrawMethod("show",true,true)]
        public static void Show (DrawTheory dt, string name) {

        }

        [IdpdDrawMethod("hide",true,true)]
        public static void Hide (DrawTheory dt, string name) {

        }

    }

}