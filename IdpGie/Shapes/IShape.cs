//
//  IIdpdObject.cs
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
using IdpGie.Abstract;
using IdpGie.Logic;
using IdpGie.Shapes.Modifiers;

namespace IdpGie.Shapes {

    public interface IShape : IZIndex, IShapeTransformable {

        IFunctionInstance Name {
            get;
        }

        ShapeState State {
            get;
        }

        double Time {
            get;
            set;
        }

        void PaintObject (Context ctx);

        void WriteTikz (StringBuilder builder);

        void Render (FrameEventArgs e);

        void AddModifier (ShapeStateModifier modifier);

        void AddModifier (double time, Action<ShapeState> modifier);

    }

}

