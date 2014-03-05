//
//  IShapeState.cs
//
//  Author:
//       Willem Van Onsem <Willem.VanOnsem@cs.kuleuven.be>
//
//  Copyright (c) 2014 Willem Van Onsem
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
using IdpGie.Abstract;
using IdpGie.Shapes.Modifiers;

namespace IdpGie.Shapes {

	public interface IShapeState : IShapeTransformable, ITimeSensitiveFastReversible, IVisible, IZIndex {

		void Reset ();

		void Reset (double time);

		void Advance (double time);

		void SetTime (double time);

		void AddModifier (IShapeStateModifier modifier);

		void AddModifier (double time, Action<IShapeState> modifier);

		bool ContainsElement (string key);

		T GetElement<T> (string key, T defaultValue = default(T));

		void SetElement<T> (string key, T value = default(T));

	}

}

