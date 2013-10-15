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

    //[Idpd]
    public class IdpdMapping {

        private readonly Dictionary<string,IdpdObject> objects = new Dictionary<string, IdpdObject> ();
        private readonly SortedSet<IdpdObject> zObjects = new SortedSet<IdpdObject> ();

        public double Time {
            set {
                foreach (IdpdObject obj in objects.Values) {
                    obj.Time = value;
                }
            }
        }

        [IdpdMethod("polygon",true,false,TermType.PointList)]
        public void Polygon (string name, IList<Point> points) {

        }

        [IdpdMethod("polygon",true,false,TermType.Int,TermType.Float)]
        public void Polygon (string name, int nbOfEdges, float sizeOfEdge) {

        }

        [IdpdMethod("ellipse",true,false,TermType.Float,TermType.Float)]
        public void Ellipse (string name, double width, double height) {

        }

        [IdpdMethod("graph",true,false,TermType.Float,TermType.Float)]
        public void Graph (string name, double width, double height) {

        }

        [IdpdMethod("node",true,true,TermType.String)]
        public void Node (string name, string graph) {

        }

        [IdpdMethod("text",true,true,TermType.String)]
        public void Text (string name, string text) {

        }

        [IdpdMethod("edge",false,false,TermType.String,TermType.String,TermType.String)]
        public void Edge (string node1, string node2, string graph) {

        }

        [IdpdMethod("image",true,true,TermType.Float,TermType.Float,TermType.String)]
        public void Image (string name, double width, double height, string filepath) {

        }

        [IdpdMethod("xpos",true,true,TermType.Float)]
        public void Xpos (string name, double xpos) {

        }

        [IdpdMethod("ypos",true,true,TermType.Float)]
        public void Ypos (string name, double ypos) {

        }

        [IdpdMethod("zpos",true,true,TermType.Float)]
        public void Zpos (string name, double zpos) {

        }

        [IdpdMethod("edgecolor",true,true,TermType.Int,TermType.Int,TermType.Int)]
        public void EdgeColor (string name, double r, double g, double b) {

        }

        [IdpdMethod("innercolor",true,true,TermType.Int,TermType.Int,TermType.Int)]
        public void InnerColor (string name, double r, double g, double b) {

        }

        [IdpdMethod("depth",true,true,TermType.Float)]
        public void Depth (string name, double index) {
        }

        [IdpdMethod("show",true,true)]
        public void Show (string name) {

        }

        [IdpdMethod("hide",true,true)]
        public void Hide (string name) {

        }

        public IEnumerable<IdpdObject> ObjectsTime (double t) {
            this.Time = t;
            return this.zObjects;
        }

    }

}