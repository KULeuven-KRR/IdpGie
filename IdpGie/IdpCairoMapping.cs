//
//  IdpCairoMapping.cs
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
    public class IdpCairoMapping {

        private readonly Dictionary<string,IdpdObject> objects = new Dictionary<string, IdpdObject> ();

        public void setTime (double time) {
            foreach (IdpdObject obj in objects.Values) {
                obj.setTime (time);
            }
        }

        [IdpdMethod("idpd_polygon")]
        public void Polygon (string name, IList<Point> points) {

        }

        [IdpdMethod("idpd_polygon")]
        public void Polygon (string name, int nbOfEdges, IList<Point> sizeOfEdge) {

        }

        [IdpdMethod("idpd_ellipse")]
        public void Ellipse (string name, double width, double height) {

        }

        [IdpdMethod("idpd_graph")]
        public void Graph (string name, double width, double height) {

        }

        [IdpdMethod("idpd_node")]
        public void Node (string name, string graph) {

        }

        [IdpdMethod("idpd_edge")]
        public void Edge (string node1, string node2, string graph) {

        }

        [IdpdMethod("idpd_image")]
        public void Image (string name, double width, double height, string filepath) {

        }

        [IdpdMethod("idpd_xpos")]
        public void Xpos (string name, double xpos) {

        }

        [IdpdMethod("idpd_ypos")]
        public void Ypos (string name, double ypos) {

        }

        [IdpdMethod("idpd_edgecolor")]
        public void EdgeColor (string name, double r, double g, double b) {

        }

        [IdpdMethod("idpd_innercolor")]
        public void InnerColor (string name, double r, double g, double b) {

        }

        [IdpdMethod("idpd_depth")]
        public void Depth (string name, double index) {
        }

        [IdpdMethod("idpd_show")]
        public void Show (string name) {

        }

        [IdpdMethod("idpd_hide")]
        public void Hide (string name) {

        }

        public void PaintWidget (Context ctx, int w, int h, double t) {
            throw new System.NotImplementedException ();
        }

    }
}

