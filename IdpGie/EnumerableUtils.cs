//
//  EnumerableUtils.cs
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
using System.Linq;
using System.Collections.Generic;

namespace IdpGie {
	public static class EnumerableUtils {
		public static T SplitHead<T> (this IEnumerable<T> source, out IEnumerable<T> tail) {
			tail = source.Tail ();
			return source.FirstOrDefault ();
		}

		public static IEnumerable<T> Tail<T> (this IEnumerable<T> source) {
			IEnumerator<T> tor = source.GetEnumerator ();
			if (tor.MoveNext ()) {
				while (tor.MoveNext ()) {
					yield return tor.Current;
				}
			}
		}

		public static IEnumerable<T> Append<T> (this IEnumerable<T> source1, IEnumerable<T> source2) {
			foreach (T t in source1) {
				yield return t;
			}
			foreach (T t in source2) {
				yield return t;
			}
		}

		public static IEnumerable<Q> GenerateDual<T,Q> (this IEnumerable<T> source1, IEnumerable<Q> source2, Func<T,Q> generator) {
			IEnumerator<T> e1 = source1.GetEnumerator ();
			IEnumerator<Q> e2 = source2.GetEnumerator ();
			bool n1 = e1.MoveNext (), n2 = e2.MoveNext ();
			while (n1 && n2) {
				yield return e2.Current;
				n1 = e1.MoveNext ();
				n2 = e2.MoveNext ();
			}
			while (n1) {
				yield return generator (e1.Current);
				n1 = e1.MoveNext ();
			}
		}

		public static IEnumerable<R> SelectDual<T,Q,R> (this IEnumerable<T> source1, IEnumerable<Q> source2, Func<T,Q,R> function) {
			IEnumerator<T> e1 = source1.GetEnumerator ();
			IEnumerator<Q> e2 = source2.GetEnumerator ();
			bool n1 = e1.MoveNext (), n2 = e2.MoveNext ();
			while (n1 && n2) {
				T v1 = e1.Current;
				Q v2 = e2.Current;
				yield return function (v1, v2);
				n1 = e1.MoveNext ();
				n2 = e2.MoveNext ();
			}
		}

		public static IEnumerable<T> OrderBy<T,Q> (this IEnumerable<T> source, IComparer<Q> comparer) where T : Q {
			return source.OrderBy (x => x, comparer);
		}

		public static IEnumerable<T> OrderByDescending<T,Q> (this IEnumerable<T> source, IComparer<Q> comparer) where T : Q {
			return source.OrderByDescending (x => x, comparer);
		}

		public static IEnumerable<Tuple<T,Q>> WhereDual<T,Q> (this IEnumerable<T> source1, IEnumerable<Q> source2, Func<T,Q,bool> predicate) {
			return WhereDual<T,Q,Tuple<T,Q>> (source1, source2, predicate, (x, y) => new Tuple<T,Q> (x, y));
		}

		public static IEnumerable<Tuple<T,Q,int>> WhereIndexedDual<T,Q> (this IEnumerable<T> source1, IEnumerable<Q> source2, Func<T,Q,int,bool> predicate) {
			return WhereIndexedDual<T,Q,Tuple<T,Q,int>> (source1, source2, predicate, (x, y, z) => new Tuple<T,Q,int> (x, y, z));
		}

		public static IEnumerable<R> WhereDual<T,Q,R> (this IEnumerable<T> source1, IEnumerable<Q> source2, Func<T,Q,bool> predicate, Func<T,Q,R> function) {
			IEnumerator<T> e1 = source1.GetEnumerator ();
			IEnumerator<Q> e2 = source2.GetEnumerator ();
			bool n1 = e1.MoveNext (), n2 = e2.MoveNext ();
			while (n1 && n2) {
				T v1 = e1.Current;
				Q v2 = e2.Current;
				if (predicate (v1, v2)) {
					yield return function (v1, v2);
				}
				n1 = e1.MoveNext ();
				n2 = e2.MoveNext ();
			}
		}

		public static IEnumerable<R> WhereIndexedDual<T,Q,R> (this IEnumerable<T> source1, IEnumerable<Q> source2, Func<T,Q,int,bool> predicate, Func<T,Q,int,R> function) {
			IEnumerator<T> e1 = source1.GetEnumerator ();
			IEnumerator<Q> e2 = source2.GetEnumerator ();
			int index = 0x00;
			bool n1 = e1.MoveNext (), n2 = e2.MoveNext ();
			while (n1 && n2) {
				T v1 = e1.Current;
				Q v2 = e2.Current;
				if (predicate (v1, v2, index)) {
					yield return function (v1, v2, index);
				}
				n1 = e1.MoveNext ();
				n2 = e2.MoveNext ();
				index++;
			}
		}

		public static bool AllDual<T,Q> (this IEnumerable<T> source1, IEnumerable<Q> source2, Func<T,Q,bool> predicate) {
			IEnumerator<T> e1 = source1.GetEnumerator ();
			IEnumerator<Q> e2 = source2.GetEnumerator ();
			bool n1 = e1.MoveNext (), n2 = e2.MoveNext ();
			while (n1 && n2) {
				T v1 = e1.Current;
				Q v2 = e2.Current;
				if (!predicate (v1, v2)) {
					return false;
				}
				n1 = e1.MoveNext ();
				n2 = e2.MoveNext ();
			}
			return n1 == n2;
		}

		public static bool AnyDual<T,Q> (this IEnumerable<T> source1, IEnumerable<Q> source2, Func<T,Q,bool> predicate) {
			return !source1.WhereDual (source2, predicate).Empty ();
		}

		public static bool Empty<T> (this IEnumerable<T> source) {
			return !source.GetEnumerator ().MoveNext ();
		}

		public static IEnumerable<T> HeadTail<T> (T head, IEnumerable<T> tail) {
			yield return head;
			foreach (T val in tail) {
				yield return val;
			}
		}

		public static IEnumerable<T> Zero<T> () {
			yield break;
		}
	}
}

