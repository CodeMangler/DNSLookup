using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeMangler.nDNS.Tests
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
                    0x03, 119, 119, 119, 0x06, 103, 111, 111, 103, 108, 101, 0x03, 99, 111, 109, 0x00, // Reads: 3www6google3com0 [with numbers being actual bytes, not ASCII]
                    0x00, 0xFF, // Record Type
                    0x00, 0x01 // Record Class
                };
            int usedBytes;
            Query query = Query.Parse(datagram, 2, out usedBytes);
            Assert.AreEqual("www.google.com", query.DomainName);
            Assert.AreEqual(20, usedBytes);
        }

        [TestMethod]
        public void CanDecodeMultipleQueries()
        {
            byte[] datagram = new byte[] {0x0F, 0x00, 
                    0x03, 119, 119, 119, 0x06, 103, 111, 111, 103, 108, 101, 0x03, 99, 111, 109, 0x00, // Reads: 3www6google3com0 [with numbers being actual bytes, not ASCII]
                    0x00, 0xFF, // Record Type
                    0x00, 0x01, // Record Class
                    0x03, 119, 119, 119, 0x05, 121, 97, 104, 111, 111, 0x03, 99, 111, 109, 0x00, // Reads: 3www5yahoo3com0
                    0x00, 0xFF, // Record Type
                    0x00, 0x01, // Record Class
                };
            int usedBytes;
            Query query = Query.Parse(datagram, 2, out usedBytes);
            Assert.AreEqual("www.google.com", query.DomainName);
            Assert.AreEqual(RecordType.ANY, query.Type);
            Assert.AreEqual(RecordClass.IN, query.Class);
            Assert.AreEqual(20, usedBytes);
            
            query = Query.Parse(datagram, 2 + 20, out usedBytes); // 20 -> where we left off
            Assert.AreEqual("www.yahoo.com", query.DomainName);
            Assert.AreEqual(RecordType.ANY, query.Type);
            Assert.AreEqual(RecordClass.IN, query.Class);
            Assert.AreEqual(19, usedBytes);
        }

        [TestMethod]
        public void CanEncodeQuery()
        {
            byte[] expected = new byte[] { 0x03, 119, 119, 119, 0x06, 103, 111, 111, 103, 108, 101, 0x03, 99, 111, 109, 0x00,
                                            0x00, 0xFF,
                                            0x00, 0x01
                                         };
            Query query = new Query("www.google.com");
            byte[] actual = query.AsByteArray();
            TestUtilities.AssertByteArrayContents(expected, actual);
        }
    }
}
