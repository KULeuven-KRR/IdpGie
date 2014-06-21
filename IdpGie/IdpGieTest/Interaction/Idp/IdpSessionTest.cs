using NUnit.Framework;
using System;
using IdpGie.Interaction.Idp;

namespace IdpGieTest.Interaction.Idp {
	[TestFixture()]
	public class IdpSessionTest {
		[Test()]
		public void ScenarioTest () {
			string the = "T";
			string str = "S";
			string voc = "V";
			IdpInteraction ii = new IdpInteraction ();
			IdpSession session = new IdpSession (ii, "/home/kommusoft/Projects/IdpGie/IdpGie/testinput/us.idp", the, str, voc);
			IVocabulary voca = session.getVocabulary ();
			Assert.AreEqual (voc, voca.Name);
			Assert.AreEqual (session, voca.IdpSession);
		}
	}
}

