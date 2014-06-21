using NUnit.Framework;
using System;
using IdpGie.Interaction.Idp;

namespace IdpGieTest.Interaction.Idp {
	[TestFixture()]
	public class IdpSessionTest {
		[Test()]
		public void ScenarioTest () {
			IdpInteraction ii = new IdpInteraction ();
			IdpSession session = new IdpSession (ii, "/home/kommusoft/Projects/IdpGie/IdpGie/testinput/us.idp", "T", "S", "V");
		}
	}
}

