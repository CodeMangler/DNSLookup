using System;
using System.Text;

namespace CodeMangler.DNSLookup.DNS
{
    public struct Query
    {
        string _domainName;
        RecordType _type;
        UInt16 _class;

        public Query(string domainName, RecordType type = RecordType.ANY, UInt16 queryClass = 1)
        {
            _domainName = domainName;
            _type = type;
            _class = queryClass;
        }

        public string DomainName
        {
            get { return _domainName; }
        }

        internal RecordType Type
        {
            get { return _type; }
        }

        public UInt16 Class
        {
            get { return _class; }
        }

        public static Query Parse(byte[] datagram, int offset, out int usedBytes)
        {
            int domainNameBytesLength;
            Query query = new Query();
            query._domainName = datagram.DecodeDomainName(offset, out domainNameBytesLength);
            offset += domainNameBytesLength;
            usedBytes = domainNameBytesLength;
            query._type = (RecordType)datagram.ToUInt16(offset);
            offset += 2; // sizeof(UInt16)
            usedBytes += 2;
            query._class = datagram.ToUInt16(offset + 2);
            usedBytes += 2; // sizeof(UInt16)
            return query;
        }

        public byte[] AsByteArray()
        {
            int ADDITIONAL_BYTES = 4; // sizeof(RecordType:UInt16) <2 bytes> + sizeof(RecordClass:UInt16) <2 bytes>
            byte[] domainNameBytes = _domainName.EncodeDomainName();

            byte[] result = new byte[domainNameBytes.Length + ADDITIONAL_BYTES];
            Array.Copy(domainNameBytes, result, domainNameBytes.Length); // Copy encoded domain name bytes..
            Array.Copy(((UInt16)_type).ToByteArray(), 0, result, domainNameBytes.Length, 2); // Copy RecordType bytes..
            Array.Copy(_class.ToByteArray(), 0, result, domainNameBytes.Length + 2, 2); // Copy RecordClass bytes..
            return result;
        }
    }
}
