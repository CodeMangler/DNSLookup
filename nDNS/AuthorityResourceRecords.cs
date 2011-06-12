using System;
using System.Collections.Generic;

namespace CodeMangler.nDNS
{
    [Serializable]
    class AuthorityResourceRecords
    {
        private List<ResourceRecord> _resourceRecords = new List<ResourceRecord>();

        internal int Parse(byte[] datagram, int offset, int authorityResourceRecordCount)
        {
            int usedBytes;
            _resourceRecords.AddRange(datagram.ParseResourceRecords(offset, authorityResourceRecordCount, out usedBytes));
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
