using NUnit.Framework;
using System;
using IdpGie;

namespace IdpGieTest {
	[TestFixture ()]
	public class DocumentSizeTest {
		[Test ()]
		public void TestParse () {
		DocumentSize ds;
		ds = DocumentSize.Parse("400x600");
		Assert.AreEqual(400,ds.Width);
		Assert.AreEqual(600,ds.Height);
		}
	}
}

