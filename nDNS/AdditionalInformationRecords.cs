﻿using System;
using System.Collections.Generic;
using CodeMangler.nDNS;

namespace CodeMangler.nDNS
{
    [Serializable]
    class AdditionalInformationRecords
    {
        private List<ResourceRecord> _resourceRecords = new List<ResourceRecord>();

        internal int Parse(byte[] datagram, int offset, int additionalInformationRecordCount)
        {
            int usedBytes;
            _resourceRecords.AddRange(datagram.ParseResourceRecords(offset, additionalInformationRecordCount, out usedBytes));
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
