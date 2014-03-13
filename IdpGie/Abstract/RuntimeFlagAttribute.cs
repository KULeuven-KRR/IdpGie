//
//  RuntimeFlagAttribute.cs
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

namespace IdpGie.Abstract {

	/// <summary>
	/// An attribute to specify that the field corresponds to a that of a runtime flag (this can be used to parse arguments).
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class RuntimeFlagAttribute : NamedDescribedAttributeBase {

		private readonly string[] alternatives;
		private Func<string,object> parser = null;

		/// <summary>
		/// Gets the alternatives names for the flag.
		/// </summary>
		/// <value>
		/// The alternatives names for the flag.
		/// </value>
		public ICollection<string> Alternatives {
			get {
				return this.alternatives.ToList ().AsReadOnly ();
			}
		}

		/// <summary>
		/// Gets the parser that parses the textual representation to the desired object.
		/// </summary>
		/// <value>
		/// The parser to convert the textual representation to the desired object.
		/// </value>
		public Func<string,object> Parser {
			get {
				return this.parser;
			}
			internal set {
				this.parser = value;
			}
		}

		/// <summary>
		/// Checks if the attribute comes with a parser.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance has a parser; otherwise, <c>false</c>.
		/// </value>
		public bool HasParser {
			get {
				return (this.parser != null);
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Abstract.RuntimeFlagAttribute"/> class with the given name of the flag.
		/// </summary>
		/// <param name='name'>
		/// The name of the flag.
		/// </param>
		/// <remarks>
		/// <para>The alternatives can also be encoded in the name by using the bar character. E.g.: <c>"f|flag"</c>.</para>
		/// </remarks>
		public RuntimeFlagAttribute (string name) : base(name) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Abstract.RuntimeFlagAttribute"/> class with a given name and a list of alternatives.
		/// </summary>
		/// <param name='name'>
		/// The name of the flag.
		/// </param>
		/// <param name='alternatives'>
		/// The possible alternative names.
		/// </param>
		/// <remarks>
		/// <para>The alternatives can also be encoded in the name by using the bar character. E.g.: <c>"f|flag"</c>.</para>
		/// </remarks>
		public RuntimeFlagAttribute (string name, string[] alternatives) : base(name) {
			this.alternatives = alternatives;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Abstract.RuntimeFlagAttribute"/> class with a given name, description and alternative names.
		/// </summary>
		/// <param name='name'>
		/// The name of the flag.
		/// </param>
		/// <param name='description'>
		/// A description of the flag.
		/// </param>
		/// <param name='alternatives'>
		/// Alternative names for the flag.
		/// </param>
		/// <remarks>
		/// <para>The alternatives can also be encoded in the name by using the bar character. E.g.: <c>"f|flag"</c>.</para>
		/// </remarks>
		public RuntimeFlagAttribute (string name, string description, params string[] alternatives) : base(name,description) {
			this.alternatives = alternatives;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Abstract.RuntimeFlagAttribute"/> class with the given name of the flag and a parser.
		/// </summary>
		/// <param name='name'>
		/// The name of the flag.
		/// </param>
		/// <param name='parser'>
		/// The parser to convert the textual representation to the desired object.
		/// </param>
		/// <remarks>
		/// <para>The alternatives can also be encoded in the name by using the bar character. E.g.: <c>"f|flag"</c>.</para>
		/// </remarks>
		public RuntimeFlagAttribute (string name, Func<string,object> parser) : this(name) {
			this.parser = parser;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Abstract.RuntimeFlagAttribute"/> class with a given name, a list of alternatives and a parser.
		/// </summary>
		/// <param name='name'>
		/// The name of the flag.
		/// </param>
		/// <param name='alternatives'>
		/// The possible alternative names.
		/// </param>
		/// <param name='parser'>
		/// The parser to convert the textual representation to the desired object.
		/// </param>
		/// <remarks>
		/// <para>The alternatives can also be encoded in the name by using the bar character. E.g.: <c>"f|flag"</c>.</para>
		/// </remarks>
		public RuntimeFlagAttribute (string name, string[] alternatives, Func<string,object> parser) : this(name,alternatives) {
			this.parser = parser;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Abstract.RuntimeFlagAttribute"/> class with a given name, description, a parser and alternative names.
		/// </summary>
		/// <param name='name'>
		/// The name of the flag.
		/// </param>
		/// <param name='description'>
		/// A description of the flag.
		/// </param>
		/// <param name='parser'>
		/// The parser to convert the textual representation to the desired object.
		/// </param>
		/// <param name='alternatives'>
		/// Alternative names for the flag.
		/// </param>
		/// <remarks>
		/// <para>The alternatives can also be encoded in the name by using the bar character. E.g.: <c>"f|flag"</c>.</para>
		/// </remarks>
		public RuntimeFlagAttribute (string name, string description, Func<string,object> parser, params string[] alternatives) : this(name,description,alternatives) {
			this.parser = parser;
		}
	}
}

