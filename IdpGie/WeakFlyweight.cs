//
//  WeakFlyweight.cs
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
using System.Collections.Generic;

namespace IdpGie.Abstract {

    public class WeakFlyweight<TKey,TValue> : IFlyWeight<TKey,TValue> {

        private readonly Dictionary<TKey,WeakReference> cache = new Dictionary<TKey, WeakReference> ();
        private readonly Func<TKey,TValue> generator;

        #region IFlyWeight implementation
        public Func<TKey, TValue> Generator {
            get {
                return this.generator;
            }
        }

        public bool IsWeak {
            get {
                return true;
            }
        }

        public bool DisposeSupport {
            get {
                return false;
            }
        }
        #endregion
        public WeakFlyweight (Func<TKey,TValue> generator) {
            this.generator = generator;
        }

        #region IFlyWeight implementation
        public TValue GetOrCreate (TKey key) {
            WeakReference wr;
            TValue res;
            if (!this.cache.TryGetValue (key, out wr)) {
                res = generator (key);
                this.cache.Add (key, new WeakReference (res));
            } else if (!wr.IsAlive) {
                res = generator (key);
                wr.Target = res;
            } else {
                res = (TValue)wr.Target;
            }
            return res;
        }

        public bool Contains (TKey key) {
            WeakReference wr;
            return (this.cache.TryGetValue (key, out wr) && wr.IsAlive);
        }
        #endregion

        public void Compact () {
            Stack<TKey> toRemove = new Stack<TKey> ();
            foreach (KeyValuePair<TKey,WeakReference> kvp in this.cache) {
                if (!kvp.Value.IsAlive) {
                    toRemove.Push (kvp.Key);
                }
            }
            foreach (TKey key in toRemove) {
                this.cache.Remove (key);
            }
        }

    }

}