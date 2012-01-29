using NUnit.Framework;

namespace CodeMangler.nDNS.Tests
{
    [TestFixture]
    public class DNSHeaderTest
    {
        [Test]
        public void EnsureDatagramCorrectParsingOfTheDatagram()
        {
            byte[] datagram = new byte[] { 
                0x01, 0x02, // id
                0xFF, 0xFF, // all flags on..
                0x00, 0x01, // 1 Question
                0x00, 0x0A, // 10 Answers
                0x00, 0x02, // 2 Authority RRs
                0x00, 0x01, // 1 Additional RR
            };
            Header header = new Header();
            header.Parse(datagram);
            Assert.AreEqual(258, header.Id);
            Assert.AreEqual(65535, (ushort) header.Flags);
            Assert.AreEqual(1, header.QueryCount);
            Assert.AreEqual(10, header.AnswerCount);
            Assert.AreEqual(2, header.AuthorityResourceRecordCount);
            Assert.AreEqual(1, header.AdditionalResourceRecordCount);
        }
    }
}
