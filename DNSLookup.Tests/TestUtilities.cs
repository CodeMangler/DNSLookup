using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeMangler.nDNS.Tests
{
    public class TestUtilities
    {
        public static void AssertByteArrayContents(byte[] expected, byte[] actual)
        {
            if (expected == null)
                Assert.Fail("Expected is null");
            if (actual == null)
                Assert.Fail("Actual is null");
            if (expected.Length != actual.Length)
                Assert.Fail("Expected a byte array of size {0}, but got a byte array of size {1}", expected.Length, actual.Length);

            for (int i = 0; i < actual.Length; i++)
                Assert.AreEqual(expected[i], actual[i]);
        }
    }
}
