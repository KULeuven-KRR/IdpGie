using NUnit.Framework;
using System;
using IdpGie.Geometry;

namespace IdpGieTest {
	[TestFixture ()]
	public class DocumentSizeTest {
		[Test ()]
		public void TestParse () {
			CanvasSize ds;
			ds = CanvasSize.Parse ("400x600");
			Assert.AreEqual (400, ds.Width);
			Assert.AreEqual (600, ds.Height);
			Assert.AreEqual (CanvasSize.DefaultMargin, ds.Margin);
			ds = CanvasSize.Parse ("400x600x32");
			Assert.AreEqual (400, ds.Width);
			Assert.AreEqual (600, ds.Height);
			Assert.AreEqual (32, ds.Margin);
			ds = CanvasSize.Parse ("32 x 400@600");
			Assert.AreEqual (32, ds.Width);
			Assert.AreEqual (400, ds.Height);
			Assert.AreEqual (600, ds.Margin);
		}
	}
}

