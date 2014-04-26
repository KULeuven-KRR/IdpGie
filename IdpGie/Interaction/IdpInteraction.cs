using System;
using System.Xml.Serialization;
using System.Text;
using IdpGie.Utils;
using IdpGie.Core;

namespace IdpGie.Interaction {
	/// <summary>
	/// A class that handles the interaction with the IDP system and some relevant programs to translate the structure
	/// into shapes.
	/// </summary>
	[XmlType ("Interaction")]
	public class IdpInteraction {
		/// <summary>
		/// A field that points to the binary executable of the idp system.
		/// </summary>
		[XmlAttribute ("Idp")]
		public string IdpExecutable = @"/home/kommusoft/idp/bin/idp";
		/// <summary>
		/// A field that points to the binary executable of gringo.
		/// </summary>
		/// <remarks>
		/// <para>Since gringo can be installed on a linux system, the default is <c>gringo</c>.</para>
		/// </remarks>
		[XmlAttribute ("Gringo")]
		public string GringoExecutable = @"gringo";
		/// <summary>
		/// A field that points to the binary executable of clang.
		/// </summary>
		/// <remarks>
		/// <para>Since clang can be installed on a linux system, the default is <c>clang</c>.</para>
		/// </remarks>
		[XmlAttribute ("Clang")]
		public string ClangExecutable = @"clang";
		/// <summary>
		/// A field that points to the binary executable of clingo.
		/// </summary>
		/// <remarks>
		/// <para>Since clingo can be installed on a linux system, the default is <c>clingo</c>.</para>
		/// </remarks>
		[XmlAttribute ("Clingo")]
		public string ClingoExecutable = @"clingo";
		/// <summary>
		/// A boolean indicating whether xsb should be enabled in the execution of the IDP system.
		/// </summary>
		[XmlAttribute ("Xsb")]
		public bool Xsb = false;
		/// <summary>
		/// A boolean that specifies whether there should be a bound on the grounding.
		/// </summary>
		[XmlAttribute ("Groundwithbounds")]
		public bool Groundwithbounds = false;
		/// <summary>
		/// A boolean indicating whether lifted unit propagation should be enabled.
		/// </summary>
		[XmlAttribute ("Liftedunitpropagation")]
		public bool Liftedunitpropagation = false;
		/// <summary>
		/// An integer that specifies the number of models that should be generated.
		/// </summary>
		/// <remarks>
		/// <para>If <c>0</c> is specified, all models are generated.</para>
		/// </remarks>
		[XmlAttribute ("Nbmodels")]
		public int Nbmodels = 0;

		/// <summary>
		/// Creates a new interactive session with the IDP system.
		/// </summary>
		public IdpInteraction () {
		}

		/// <summary>
		/// Runs the given IDP file with the given default theory, structure and vocabulary.
		/// </summary>
		/// <returns>A <see cref="IdpSession"/> instance to communicate further with the IDP system.</returns>
		/// <param name="file">The given idp file to process.</param>
		/// <param name="theory">The given default theory.</param>
		/// <param name="structure">The given default structure.</param>
		/// <param name="vocabulary">The given default vocabulary.</param>
		public IdpSession RunIdpfile (string file, string theory, string structure, string vocabulary) {
			return new IdpSession (this, file, theory, structure, vocabulary);
		}

		/// <summary>
		/// Runs gringo on the given <paramref name="original"/> stream of data and the <paramref name="aspContent"/> to translate the theory.
		/// </summary>
		/// <returns>The resulting program after gringo is ran on it.</returns>
		/// <param name="original">The original program to translate.</param>
		/// <param name="aspContent">The asp content that describes how to translate the input to the output.</param>
		public string TranslateClingo (string original, string aspContent) {
			using (ClingoSession cs = new ClingoSession (this, aspContent, original)) {
				return cs.Output;
			}
		}
	}
}