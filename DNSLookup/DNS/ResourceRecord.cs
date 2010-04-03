using System;
using System.Collections.Generic;
using System.Text;
using CodeMangler.DNSLookup.DNS.Records;

namespace CodeMangler.DNSLookup.DNS
{
    public struct ResourceRecord
    {
        Query _query;
        Int32 _ttl;
        UInt16 _resourceDataLength;
        RecordData _recordData;

        public static ResourceRecord Parse(byte[] datagram, int offset, out int usedBytes)
        {
            ResourceRecord resourceRecord = new ResourceRecord();
            resourceRecord._query = Query.Parse(datagram, offset, out usedBytes);
            offset += usedBytes;
            resourceRecord._ttl = datagram.ToInt32(offset);
            offset += 4; // sizeof(UInt32)
            usedBytes += 4;
            resourceRecord._resourceDataLength = datagram.ToUInt16(offset);
            offset += 2; // sizeof(UInt16)
            usedBytes += 2;

            // Extract resource data bytes and parse them into a meaningful structure..
            byte[] resourceDataBytes = new byte[resourceRecord._resourceDataLength];
            Array.Copy(datagram, offset, resourceDataBytes, 0, resourceRecord._resourceDataLength);
            resourceRecord._recordData = RecordDataFactory.RecordDataFor(resourceRecord._query.Type);
            resourceRecord._recordData.PopulateFrom(resourceDataBytes);
            offset += resourceRecord._resourceDataLength;
            usedBytes += resourceRecord._resourceDataLength;

            return resourceRecord;
        }

        public byte[] AsByteArray()
        {
            List<byte> result = new List<byte>();
            result.AddRange(_query.AsByteArray());
            result.AddRange(_ttl.ToByteArray());
            result.AddRange(_resourceDataLength.ToByteArray());
            result.AddRange(_recordData.AsByteArray);
            return result.ToArray();
        }

        internal string AsString()
        {
            return _recordData.AsString;
        }
    }
}
