using CodeMangler.DNSLookup.DNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DNSLookup.Tests
{
    [TestClass()]
    public class QueryTest
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        public void CanDecodeOneQuery()
        {
            byte[] datagram = new byte[] {0x0F, 0x00, 
                    0x03, 119, 119, 119, 0x06, 103, 111, 111, 103, 108, 101, 0x03, 99, 111, 109, 0x00 // Reads: 3www6google3com0 [with numbers being actual bytes, not ASCII]
                };
            int usedBytes;
            Query query = Query.Parse(datagram, 2, out usedBytes);
            Assert.AreEqual("www.google.com", query.DomainName);
            Assert.AreEqual(16, usedBytes);
        }

        [TestMethod]
        public void CanDecodeMultipleQueries()
        {
            byte[] datagram = new byte[] {0x0F, 0x00, 
                    0x03, 119, 119, 119, 0x06, 103, 111, 111, 103, 108, 101, 0x03, 99, 111, 109, 0x00, // Reads: 3www6google3com0 [with numbers being actual bytes, not ASCII]
                    0x03, 119, 119, 119, 0x05, 121, 97, 104, 111, 111, 0x03, 99, 111, 109, 0x00 // Reads: 3www5yahoo3com0
                };
            int usedBytes;
            Query query = Query.Parse(datagram, 2, out usedBytes);
            Assert.AreEqual("www.google.com", query.DomainName);
            Assert.AreEqual(16, usedBytes);
            
            query = Query.Parse(datagram, 2 + 16, out usedBytes);
            Assert.AreEqual("www.yahoo.com", query.DomainName);
            Assert.AreEqual(15, usedBytes);
        }

        [TestMethod]
        public void CanEncodeQuery()
        {
            byte[] expected = new byte[] { 0x03, 119, 119, 119, 0x06, 103, 111, 111, 103, 108, 101, 0x03, 99, 111, 109, 0x00 };
            Query query = new Query("www.google.com");
            byte[] actual = query.AsByteArray();
            TestUtilities.AssertByteArrayContents(expected, actual);
        }
    }
}
