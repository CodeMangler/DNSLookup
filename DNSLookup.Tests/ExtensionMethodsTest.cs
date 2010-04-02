using CodeMangler.DNSLookup.DNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace DNSLookup.Tests
{
    [TestClass]
    public class ExtensionMethodsTest
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        public void EnsureByteArrayIsCorrectlyConvertedToUInt16()
        {
            byte[] twoBytes = new byte[] { 0x0F, 0xF0 };
            Assert.AreEqual(4080, twoBytes.ToUInt16(0));
        }

        [TestMethod]
        public void EnsureUInt16ConversionWorksOnMultibyteArrayAccountingForOffset()
        {
            byte[] manyBytes = new byte[] { 0x0F, 0xF0, 0xFF, 0xFF, 0x1A, 0x1B };
            Assert.AreEqual(4080, manyBytes.ToUInt16(0)); // 0x0F0F
            Assert.AreEqual(61695, manyBytes.ToUInt16(1)); // 0xF0FF
            Assert.AreEqual(65535, manyBytes.ToUInt16(2)); // 0xFFFF
            Assert.AreEqual(6683, manyBytes.ToUInt16(4)); // 0x1A1B
        }

        [TestMethod]
        public void CanConvertUInt16ToByteArray()
        {
            TestUtilities.AssertByteArrayContents(new byte[] { 0x0F, 0xF0 }, ((UInt16) 4080).ToByteArray());
            TestUtilities.AssertByteArrayContents(new byte[] { 0xF0, 0xFF }, ((UInt16) 61695).ToByteArray());
            TestUtilities.AssertByteArrayContents(new byte[] { 0xFF, 0xFF }, ((UInt16) 65535).ToByteArray());
            TestUtilities.AssertByteArrayContents(new byte[] { 0x1A, 0x1B }, ((UInt16) 6683).ToByteArray());
        }

        [TestMethod]
        public void CanDecodeDomainName()
        {
            byte[] datagram = new byte[] { 0x03, 119, 119, 119, 0x06, 103, 111, 111, 103, 108, 101, 0x03, 99, 111, 109, 0x00 }; // Reads: 3www6google3com0 [with numbers being actual bytes, not ASCII]
            int usedBytes;
            Assert.AreEqual("www.google.com", datagram.DecodeDomainName(0, out usedBytes));
            Assert.AreEqual(16, usedBytes);
        }


        [TestMethod]
        public void CanEncodeDomainName()
        {
            byte[] expected = new byte[] { 0x03, 119, 119, 119, 0x06, 103, 111, 111, 103, 108, 101, 0x03, 99, 111, 109, 0x00 };
            TestUtilities.AssertByteArrayContents(expected, "www.google.com".EncodeDomainName());
        }
    }
}
