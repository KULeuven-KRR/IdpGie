//
//  DrawTheory.cs
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
using System.Linq;
using System.Text;
using Gdk;
using IdpGie.Parser;
using IdpGie.Abstract;
using IdpGie.Logic;
using IdpGie.Interaction;
using IdpGie.Utils;
using IdpGie.Shapes;

namespace IdpGie.Core {

	/// <summary>
	/// A basic implementation of the <see cref="IDrawTheory"/> interface used to translate logic into drawing objects.
	/// </summary>
	public class DrawTheory : NameBase, IDrawTheory {
		private readonly List<ITheoryItem> elements = new List<ITheoryItem> ();
		private readonly Dictionary<IFunctionInstance,IShape> objects = new Dictionary<IFunctionInstance, IShape> ();
		private readonly Dictionary<EventType,LinkedList<IHook>> hooks = new Dictionary<EventType, LinkedList<IHook>> ();
		private readonly IAlterableReloadableChangeableStream<string> source;
		private double minTime = 0.0d;
		private double maxTime = 0.0d;
		private readonly SortedSet<double> chapters = new SortedSet<double> ();

		private event EventHandler changed;
		

		#region IDrawTheory implementation
		/// <summary>
		/// Gets the source of the logical statements.
		/// </summary>
		/// <value>
		/// The source of the logical statements.
		/// </value>
		/// <remarks>
		/// <para>The source is feeded to the parser and then converted to shape objects.</para>
		/// </remarks>
		public IAlterableReloadableChangeableStream<string> Source {
			get {
				return this.source;
			}
		}

		/// <summary>
		/// Occurs when a part of the <see cref="IDrawTheory"/> changes.
		/// </summary>
		public event EventHandler Changed {
			add {
				this.changed += value;
			}
			remove {
				this.changed -= value;
			}
		}

		/// <summary>
		/// Gets the <see cref="IShape"/> associated with the given name.
		/// </summary>
		/// <param name='name'>
		/// The given name of the shape.
		/// </param>
		/// <value>The <see cref="IShape"/> associated with the given name.</value>
		public IShape this [IFunctionInstance name] {
			get {
				return this.objects [name];
			}
		}

		/// <summary>
		/// Gets the list of <see cref="ITheoryItem"/> instances stored in this <see cref="IDrawTheory"/>.
		/// </summary>
		/// <value>
		/// The <see cref="ITheoryItem"/> instances stored in this <see cref="IDrawTheory"/>.
		/// </value>
		public IList<ITheoryItem> Elements {
			get {
				return this.elements;
			}
		}

		/// <summary>
		/// Gets the time when the first event occurs.
		/// </summary>
		/// <value>
		/// The time when the first event occurs.
		/// </value>
		public double MinTime {
			get {
				return this.minTime;
			}
		}

		/// <summary>
		/// Gets the time when the latest event occurs.
		/// </summary>
		/// <value>
		/// The time when the latest event occurs.
		/// </value>
		public double MaxTime {
			get {
				return this.maxTime;
			}
		}

		/// <summary>
		/// Gets the time span between the first and the last event.
		/// </summary>
		/// <value>
		/// The time span between the first and the last event.
		/// </value>
		public double TimeSpan {
			get {
				return this.maxTime - minTime;
			}
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
		public ICollection<double> Chapters {
			get {
				return this.chapters.AsReadonly ();
			}
		}
		#endregion

		#region IClearable implementation
		/// <summary>
		///  Sets the state of the object again in its original state. 
		/// </summary>
		public void Clear () {
			this.elements.Clear ();
			this.objects.Clear ();
			this.hooks.Clear ();
			this.minTime = 0.0d;
			this.maxTime = 0.0d;
		}
		#endregion

		#region ITimesensitive implementation

		public double Time {
			get {
				IEnumerable<IShape> tail;
				IShape head = this.objects.Values.SplitHead (out tail);
				if (head != null) {
					double time = head.Time;
					foreach (IShape obj in tail) {
						if (obj.Time != time) {
							return double.NaN;
						}
					}
					return time;
				} else {
					return double.NaN;
				}
			}
			set {
				foreach (IShape obj in this.objects.Values) {
					obj.Time = value;
				}
			}
		}

		#endregion

		public DrawTheory (string name, IAlterableReloadableChangeableStream<string> source) : base (name) {
			this.source = source;
			this.source.Changed += HandleChanged;
			this.HandleChanged (null, null);
		}

		#region IDrawTheory implementation
		public TShape GetShape<TShape> (IFunctionInstance key) where TShape : IShape {
			IShape shp = this.objects [key];
			if (shp is TShape) {
				return (TShape)shp;
			} else {
				return default(TShape);
			}
		}

		public void SetName (string name) {
			this.Name = name;
		}

		void HandleChanged (object sender, EventArgs e) {
			Lexer scnr = new Lexer (this.Source.Stream);
			IdpParser pars = new IdpParser (scnr, this);
			pars.Parse ();
		}

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
		public void Reinitialize (IEnumerable<ITheoryItem> values) {
			if (values != null) {
				this.Clear ();
				if (values != null) {
					this.elements.AddRange (values);
				}
				this.Execute ();
			}
			this.Time = 0.0d;
		}

		/// <summary>
		/// Registers the time when a certain event will occur.
		/// </summary>
		/// <param name='time'>
		/// The time when an event will occur.
		/// </param>
		/// <remarks>
		/// <para>This method is used to set the timebounds: <see cref="IDrawTheory.MinTime"/> and <see cref="IDrawTheory.MaxTime"/>.</para>
		/// </remarks>
		public void RegisterTime (double time) {
			if (this.minTime > time) {
				this.minTime = time;
			} else if (this.maxTime < time) {
				this.maxTime = time;
			}
		}

		/// <summary>
		/// Register a certain point in time as a new chapter.
		/// </summary>
		/// <param name='time'>
		/// The time when the theory enters a new chapter.
		/// </param>
		/// <remarks>
		/// <para>This method is used to generate chapters in order to make seeking more convenient.</para>
		/// </remarks>
		public void AddChapter (double time) {
			this.chapters.Add (time);
		}

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
		public void AddModifier (IFunctionInstance name, double time, Action<IShapeState> modifier) {
			this [name].State.AddModifier (time, modifier);
			this.RegisterTime (time);
			this.trigger_changed ();
		}

		private void trigger_changed () {
			EventArgs e = new EventArgs ();
			this.OnChanged (e);
			if (this.changed != null) {
				this.changed (this, e);
			}
		}

		/// <summary>
		/// Raises the changed event.
		/// </summary>
		/// <param name='e'>
		/// The corresponding <see cref="EventArgs"/> parameter.
		/// </param>
		/// <remarks>
		/// <para>This method can be used to generate a metacompiler based on the original <see cref="DrawTheory"/> implementation.</para>
		/// </remarks>
		protected virtual void OnChanged (EventArgs e) {

		}

		public string ToFullString () {
			StringBuilder sb = new StringBuilder ();
			foreach (ITheoryItem atm in elements) {
				sb.AppendFormat ("{0}.", atm);
				sb.AppendLine ();
			}
			return sb.ToString ();
		}

		/// <summary>
		/// Adds the given <see cref="IShape"/> to the <see cref="IDrawTheory"/>.
		/// </summary>
		/// <param name='obj'>
		/// The given shape to be added.
		/// </param>
		public void AddShape (IShape obj) {
			this.objects.Add (obj.Name, obj);
		}

		/// <summary>
		/// Generates a <see cref="IEnumerable`1"/> of all the <see cref="IShapes"/> who are a <paramref name="TShape"/> as well.
		/// </summary>
		/// <typeparam name='TShape'>
		/// The type of the desired <see cref="IShape"/> instances.
		/// </typeparam>
		public IEnumerable<TShape> Objects<TShape> () where TShape : IShape {
			return this.objects.Values.Where (x => x is TShape).Cast<TShape> ();
		}

		/// <summary>
		/// Converts the list of stored <see cref="ITheoryItems"/> into a set of <see cref="IShape"/> instances.
		/// </summary>
		public void Execute () {
			//TODO: Tp operator
			elements.Sort (PriorityComparator.Instance);
			foreach (ITheoryItem item in elements) {
				item.Execute (this);
			}
		}

		/// <summary>
		/// Adds the given hook to the theory.
		/// </summary>
		/// <param name='hook'>
		/// The given hook to be added.
		/// </param>
		/// <remarks>
		/// <para>A <see cref="IHook"/> described how the theory should be modified when the <see cref="IHook"/> fires.</para>
		/// </remarks>
		public void AddHook (IHook hook) {
			this.hooks.AddListDictionary (hook.HookType, hook);
		}

		/// <summary>
		/// Fires all the <see cref="IHook"/> instances associated with the given <see cref="EventType"/>.
		/// </summary>
		/// <param name='type'>
		/// The given <see cref="EventType"/>.
		/// </param>
		/// <param name='parameters'>
		/// Parameters to be passed to all the <see cref="IHook"/> instances that will fire.
		/// </param>
		public void FireHook (EventType type, params object[] parameters) {
			LinkedList<IHook> firelist;
			if (hooks.TryGetValue (type, out firelist)) {
				foreach (IHook hook in firelist) {
					hook.Execute (this, parameters);
				}
			}
		}

		/// <summary>
		/// Generate an <see cref="IShape"/> hierarchy by stating that the <paramref name="parent"/> is the parent of the <paramref name="child"/>.
		/// </summary>
		/// <param name='parent'>
		/// The associated name of the <see cref="IShape"/> that will become a parent of the <paramref name="child"/>.
		/// </param>
		/// <param name='child'>
		/// The associated name of the <see cref="IShape"/> that will become a child of the <paramref name="parent"/>.
		/// </param>
		public void BuildHierarchy (IFunctionInstance parent, IFunctionInstance child) {
			IShapeHierarchical schild = this.GetShape<IShapeHierarchical> (child);
			if (schild != null) {
				IShapeHierarchical sparnt = this.GetShape<IShapeHierarchical> (parent);
				if (sparnt != null) {
					schild.Parent = sparnt;
				}
			}
		}

		/// <summary>
		/// Gets the type of the registered <see cref="IHook"/> instances thus far.
		/// </summary>
		/// <returns>
		/// The type of the registered <see cref="IHook"/> instances thus far.
		/// </returns>
		public IEnumerable<EventType> GetHookTypes () {
			return this.hooks.Keys;
		}
		#endregion

		#region IComparable implementation
		/// <summary>
		/// Compares this <see cref="ITimeSensitive"/> instance with the given one.
		/// </summary>
		/// <returns>
		/// A value smaller than zero if this instance will take place before the given one, a value larger than zero if this event
		/// will take place after the given one, zero if both events will be triggered at the same time.
		/// </returns>
		/// <param name='other'>
		/// The <see cref="ITimeSensitive"/> instance to compare with.
		/// </param>
		/// <remarks>
		/// <para>In case the given <see cref="ITimeSensitive"/> is not effective, a negative value is returned.</para>
		/// </remarks>
		public int CompareTo (ITimeSensitive other) {
			if (other != null) {
				return this.Time.CompareTo (other.Time);
			} else {
				return -0x01;
			}
		}
		#endregion

	}
}

