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
using Gdk;

namespace IdpGie.Core {

	/// <summary>
	/// An interface describing a theory to be drawn, rendered, executed or a webapp.
	/// </summary>
	/// <remarks>
	/// <para>The most important task of a <see cref="IDrawTheory"/> is to form a bridge between the logic space and the render space.</para>
	/// </remarks>
	public interface IDrawTheory : INameSet, ITimeSensitiveSet, IClearable, IWriteable {

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
		/// Gets the <see cref="T:System.Collections.Generic.ICollection`1{double}"/> of chapters.
		/// </summary>
		/// <value>
		/// The <see cref="T:System.Collections.Generic.ICollection`1{double}"/> of chapters.
		/// </value>
		/// <remarks>
		/// <para>Chapters are time events where a significant change occurs. They are used for more convinient seeking.</para>
		/// </remarks>
		ICollection<double> Chapters {
			get;
		}

		/// <summary>
		/// Gets the shape associated with the given name if the shape is of the type <typeparamref name="TShape"/>, otherwise the default value associated with <typeparamref name="TShape"/> is returned.
		/// </summary>
		/// <returns>
		/// The shape associated with the given name if the shape is of the type <typeparamref name="TShape"/>, otherwise the default value associated with <typeparamref name="TShape"/> is returned.
		/// </returns>
		/// <param name='name'>
		/// The name of the shape to look for.
		/// </param>
		/// <typeparam name='TShape'>
		/// The type of the shape to look for, needs to be a subtype of <see cref="IShape"/>.
		/// </typeparam>
		TShape GetShape<TShape> (IFunctionInstance name) where TShape : IShape;

		/// <summary>
		/// Reinitializes the theory with the specified set of theory items.
		/// </summary>
		/// <param name='values'>
		/// The enumerable of <see cref="ITheoryItem"/> instances.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method is mainly used as a callback for the parser. But can be used by any class that can feed the <see cref="IDrawTheory"/> with <see cref="ITheoryItem"/> instances.
		/// </para>
		/// </remarks>
		void Reinitialize (IEnumerable<ITheoryItem> values);

		/// <summary>
		/// Registers the time when a certain event will occur.
		/// </summary>
		/// <param name='time'>
		/// The time when an event will occur.
		/// </param>
		/// <remarks>
		/// <para>This method is used to set the timebounds: <see cref="IDrawTheory.MinTime"/> and <see cref="IDrawTheory.MaxTime"/>.</para>
		/// </remarks>
		void RegisterTime (double time);

		/// <summary>
		/// Register a certain point in time as a new chapter.
		/// </summary>
		/// <param name='time'>
		/// The time when the theory enters a new chapter.
		/// </param>
		/// <remarks>
		/// <para>This method is used to generate chapters in order to make seeking more convenient.</para>
		/// </remarks>
		void AddChapter (double time);

		/// <summary>
		/// Adds the given modifier to the shape associated with the given name. The modifier will be fired at the given time moment.
		/// </summary>
		/// <param name='name'>
		/// The given name of the <see cref="IShape"/> to search for.
		/// </param>
		/// <param name='time'>
		/// The given time when the modifier will fire.
		/// </param>
		/// <param name='modifier'>
		/// The modifier that describes how the given <see cref="IShape"/> should be modified.
		/// </param>
		/// <remarks>
		/// <para>The time event is registered as well: the timebounds <see cref="IDrawTheory.MinTime"/> and <see cref="IDrawTheory.MaxTime"/> are updated accordingly.</para>
		/// </remarks>
		void AddModifier (IFunctionInstance name, double time, Action<IShapeState> modifier);

		/// <summary>
		/// Adds the given <see cref="IShape"/> to the <see cref="IDrawTheory"/>.
		/// </summary>
		/// <param name='obj'>
		/// The given shape to be added.
		/// </param>
		void AddShape (IShape obj);

		/// <summary>
		/// Generates a <see cref="T:IEnumerable`1{TShape}"/> of all the <see cref="IShape"/>s who are a <paramref name="TShape"/> as well.
		/// </summary>
		/// <typeparam name='TShape'>
		/// The type of the desired <see cref="IShape"/> instances.
		/// </typeparam>
		IEnumerable<TShape> Objects<TShape> () where TShape : IShape;

		/// <summary>
		/// Converts the list of stored <see cref="ITheoryItem"/>s into a set of <see cref="IShape"/> instances.
		/// </summary>
		void Execute ();

		/// <summary>
		/// Adds the given hook to the theory.
		/// </summary>
		/// <param name='hook'>
		/// The given hook to be added.
		/// </param>
		/// <remarks>
		/// <para>A <see cref="IHook"/> described how the theory should be modified when the <see cref="IHook"/> fires.</para>
		/// </remarks>
		void AddHook (IHook hook);

		/// <summary>
		/// Fires all the <see cref="IHook"/> instances associated with the given <see cref="EventType"/>.
		/// </summary>
		/// <param name='type'>
		/// The given <see cref="EventType"/>.
		/// </param>
		/// <param name='parameters'>
		/// Parameters to be passed to all the <see cref="IHook"/> instances that will fire.
		/// </param>
		void FireHook (EventType type, params object[] parameters);

		/// <summary>
		/// Generate an <see cref="IShape"/> hierarchy by stating that the <paramref name="parent"/> is the parent of the <paramref name="child"/>.
		/// </summary>
		/// <param name='parent'>
		/// The associated name of the <see cref="IShape"/> that will become a parent of the <paramref name="child"/>.
		/// </param>
		/// <param name='child'>
		/// The associated name of the <see cref="IShape"/> that will become a child of the <paramref name="parent"/>.
		/// </param>
		void BuildHierarchy (IFunctionInstance parent, IFunctionInstance child);

		/// <summary>
		/// Gets the type of the registered <see cref="IHook"/> instances thus far.
		/// </summary>
		/// <returns>
		/// The type of the registered <see cref="IHook"/> instances thus far.
		/// </returns>
		IEnumerable<EventType> GetHookTypes ();

	}
}

