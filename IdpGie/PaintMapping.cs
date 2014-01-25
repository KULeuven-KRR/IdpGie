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
using System;

namespace IdpGie {
	[Mapper]
	public static class PaintMapping {
		[PaintMethod ("rendering", false, false, -1.0d, TermType.Named)]
		public static void Rendering (DrawTheory dt, NamedObject nobj) {
			dt.Mode = (DrawTheoryMode)(byte)(((ulong)nobj) & 0xff);
		}

		[PaintMethod ("polygon", true, false, 0.0d, TermType.PointList)]
		public static void Polygon (DrawTheory dt, IFunctionInstance name, EnhancedTermCollection points) {
			dt.AddIdpdObject (new ShapeIrregularPolygonObject (name, points.ValueEnumerable<Point> (TermType.Point)));
		}

		[PaintMethod ("polygon", true, false, 0.0d, TermType.Int, TermType.Float)]
		public static void Polygon (DrawTheory dt, IFunctionInstance name, int nbOfEdges, double sizeOfEdges) {
			dt.AddIdpdObject (new ShapeRegularPolygonObject (name, nbOfEdges, sizeOfEdges));
		}

		[PaintMethod ("ellipse", true, false, 0.0d, TermType.Float, TermType.Float)]
		public static void Ellipse (DrawTheory dt, IFunctionInstance name, double width, double height) {
			dt.AddIdpdObject (new ShapeEllipse (name, width, height));
		}

		[PaintMethod ("console", false, false, 0.0d, TermType.String)]
		public static void Ellipse (DrawTheory dt, string text) {
			Console.Error.WriteLine (text);
		}

		[PaintMethod ("graph", true, false, 0.0d, TermType.Float, TermType.Float)]
		public static void Graph (DrawTheory dt, IFunctionInstance name, double width, double height) {

		}

		[PaintMethod ("node", true, true, 0.5d, TermType.String)]
		public static void Node (DrawTheory dt, IFunctionInstance name, string graph, double time = double.NaN) {

		}

		[PaintMethod ("text", true, true, TermType.String)]
		public static void Text (DrawTheory dt, IFunctionInstance name, string text, double time = double.NaN) {
			dt.AddModifier (name, time, x => x.SetText (text));
		}

		[PaintMethod ("edge", false, false, 0.75d, TermType.String, TermType.String, TermType.String)]
		public static void Edge (DrawTheory dt, string node1, string node2, string graph) {

		}

		[PaintMethod ("image", true, false, 0.0d, TermType.String, TermType.Float, TermType.Float)]
		public static void Image (DrawTheory dt, IFunctionInstance name, string filepath, double width, double height) {
			dt.AddIdpdObject (new ShapeImage (name, filepath, width, height));
		}

		[PaintMethod ("xpos", true, true, TermType.Float)]
		public static void Xpos (DrawTheory dt, IFunctionInstance name, double xpos, double time = double.NaN) {
			dt.AddModifier (name, time, x => x.SetXPos (xpos));
		}

		[PaintMethod ("ypos", true, true, TermType.Float)]
		public static void Ypos (DrawTheory dt, IFunctionInstance name, double ypos, double time = double.NaN) {
			dt.AddModifier (name, time, x => x.SetYPos (ypos));
		}

		[PaintMethod ("zpos", true, true, TermType.Float)]
		public static void Zpos (DrawTheory dt, IFunctionInstance name, double zpos, double time = double.NaN) {
			dt.AddModifier (name, time, x => x.SetZPos (zpos));
		}

		[PaintMethod ("pos", true, true, TermType.Float, TermType.Float, TermType.Float)]
		public static void Pos (DrawTheory dt, IFunctionInstance name, double xpos, double ypos, double zpos, double time = double.NaN) {
			Xpos (dt, name, xpos, time);
			Ypos (dt, name, ypos, time);
			Zpos (dt, name, zpos, time);
		}

		[PaintMethod ("xshift", true, true, TermType.Float)]
		public static void Xshift (DrawTheory dt, IFunctionInstance name, double xpos, double time = double.NaN) {

		}

		[PaintMethod ("yshift", true, true, TermType.Float)]
		public static void Yshift (DrawTheory dt, IFunctionInstance name, double ypos, double time = double.NaN) {

		}

		[PaintMethod ("zshift", true, true, TermType.Float)]
		public static void Zshift (DrawTheory dt, IFunctionInstance name, double zpos, double time = double.NaN) {

		}

		[PaintMethod ("shift", true, true, TermType.Float, TermType.Float, TermType.Float)]
		public static void Shift (DrawTheory dt, IFunctionInstance name, double xpos, double ypos, double zpos, double time = double.NaN) {
			Xshift (dt, name, xpos, time);
			Yshift (dt, name, ypos, time);
			Zshift (dt, name, zpos, time);
		}

		[PaintMethod ("xscale", true, true, TermType.Float)]
		public static void Xscale (DrawTheory dt, IFunctionInstance name, double xscale, double time = double.NaN) {

		}

		[PaintMethod ("yscale", true, true, TermType.Float)]
		public static void Yscale (DrawTheory dt, IFunctionInstance name, double yscale, double time = double.NaN) {

		}

		[PaintMethod ("zscale", true, true, TermType.Float)]
		public static void Zscale (DrawTheory dt, IFunctionInstance name, double zscale, double time = double.NaN) {

		}

		[PaintMethod ("scale", true, true, TermType.Float, TermType.Float, TermType.Float)]
		public static void Scale (DrawTheory dt, IFunctionInstance name, double xscale, double yscale, double zscale, double time = double.NaN) {
			Xscale (dt, name, xscale, time);
			Yscale (dt, name, yscale, time);
			Zscale (dt, name, zscale, time);
		}

		[PaintMethod ("rotate", true, true, TermType.Float, TermType.Float, TermType.Float, TermType.Float)]
		public static void Rotate (DrawTheory dt, IFunctionInstance name, double ex, double ey, double ez, double alpha, double time = double.NaN) {
		}

		[PaintMethod ("rotateX", true, true, TermType.Float)]
		public static void RotateX (DrawTheory dt, IFunctionInstance name, double alpha, double time = double.NaN) {
		}

		[PaintMethod ("rotateY", true, true, TermType.Float)]
		public static void RotateY (DrawTheory dt, IFunctionInstance name, double alpha, double time = double.NaN) {
		}

		[PaintMethod ("rotateZ", true, true, TermType.Float)]
		public static void RotateZ (DrawTheory dt, IFunctionInstance name, double alpha, double time = double.NaN) {
		}

		[PaintMethod ("edgecolor", true, true, TermType.Int, TermType.Int, TermType.Int)]
		public static void EdgeColor (DrawTheory dt, IFunctionInstance name, double r, double g, double b, double time = double.NaN) {
			dt.AddModifier (name, time, x => x.SetEdgeColor (r, g, b));
		}

		[PaintMethod ("innercolor", true, true, TermType.Int, TermType.Int, TermType.Int)]
		public static void InnerColor (DrawTheory dt, IFunctionInstance name, double r, double g, double b, double time = double.NaN) {
			dt.AddModifier (name, time, x => x.SetInnerColor (r, g, b));
		}

		[PaintMethod ("color", true, true, TermType.Int, TermType.Int, TermType.Int)]
		public static void Color (DrawTheory dt, IFunctionInstance name, double r, double g, double b, double time = double.NaN) {
			InnerColor (dt, name, r, g, b, time);
		}

		[PaintMethod ("depth", true, true, TermType.Float)]
		public static void Depth (DrawTheory dt, IFunctionInstance name, double index, double time = double.NaN) {
			dt.AddModifier (name, time, x => x.SetZPos (index));
		}

		[PaintMethod ("show", true, true)]
		public static void Show (DrawTheory dt, IFunctionInstance name, double time = double.NaN) {
			dt.AddModifier (name, time, x => x.Show ());
		}

		[PaintMethod ("hide", true, true)]
		public static void Hide (DrawTheory dt, IFunctionInstance name, double time = double.NaN) {
			dt.AddModifier (name, time, x => x.Hide ());
		}
	}
}