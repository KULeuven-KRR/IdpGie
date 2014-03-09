//
//  IDrawTheory.cs
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
using System.Collections.Generic;
using IdpGie.Abstract;
using IdpGie.Logic;
using IdpGie.Interaction;
using IdpGie.Shapes;

namespace IdpGie.Core {
	/// <summary>
	/// An interface describing a theory to be drawn, rendered, executed or a webapp.
	/// </summary>
	/// <remarks>
	/// <para>The most important task of a <see cref="IDrawTheory"/> is to form a bridge between the logic space and the render space.</para>
	/// </remarks>
	public interface IDrawTheory : IName, ITimeSensitive {

		/// <summary>
		/// Gets the source of the logical statements.
		/// </summary>
		/// <value>
		/// The source of the logical statements.
		/// </value>
		/// <remarks>
		/// <para>The source is feeded to the parser and then converted to shape objects.</para>
		/// </remarks>
		IAlterableReloadableChangeableStream<string> Source {
			get;
		}

		/// <summary>
		/// Occurs when a part of the <see cref="IDrawTheory"/> changes.
		/// </summary>
		event EventHandler Changed;

		/// <summary>
		/// Gets the <see cref="IShape"/> associated with the given name.
		/// </summary>
		/// <param name='name'>
		/// The given name of the shape.
		/// </param>
		/// <value>The <see cref="IShape"/> associated with the given name.</value>
		IShape this [IFunctionInstance name] {
			get;
		}

		/// <summary>
		/// Gets the list of <see cref="ITheoryItem"/> instances stored in this <see cref="IDrawTheory"/>.
		/// </summary>
		/// <value>
		/// The <see cref="ITheoryItem"/> instances stored in this <see cref="IDrawTheory"/>.
		/// </value>
		IList<ITheoryItem> Elements {
			get;
		}

		/// <summary>
		/// Gets the time when the first event occurs.
		/// </summary>
		/// <value>
		/// The time when the first event occurs.
		/// </value>
		double MinTime {
			get;
		}

		/// <summary>
		/// Gets the time when the latest event occurs.
		/// </summary>
		/// <value>
		/// The time when the latest event occurs.
		/// </value>
		double MaxTime {
			get;
		}

		/// <summary>
		/// Gets the time span between the first and the last event.
		/// </summary>
		/// <value>
		/// The time span between the first and the last event.
		/// </value>
		double TimeSpan {
			get;
		}

		/// <summary>
		/// Gets the <see cref="ICollection`1"/> of chapters.
		/// </summary>
		/// <value>
		/// The <see cref="ICollection`1"/> of chapters.
		/// </value>
		/// <remarks>
		/// <para>Chapters are time events where a significant change occurs. They are used for more convinient seeking.</para>
		/// </remarks>
		ICollection<double> Chapters {
			get;
		}

	}
}

