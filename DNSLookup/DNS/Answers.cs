using System;
using System.Collections.Generic;

namespace CodeMangler.DNSLookup.DNS
{
    [Serializable]
    class Answers
    {
        private List<ResourceRecord> _resourceRecords = new List<ResourceRecord>();

        internal int Parse(byte[] datagram, int offset, int answerCount)
        {
            int usedBytes;
            _resourceRecords.AddRange(datagram.ParseResourceRecords(offset, answerCount, out usedBytes));
            return usedBytes;
        }

        internal byte[] AsByteArray()
        {
            return _resourceRecords.ToByteArray();
        }

        internal string AsString()
        {
            return _resourceRecords.AsString();
        }
    }
}
