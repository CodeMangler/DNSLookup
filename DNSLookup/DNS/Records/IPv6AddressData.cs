namespace CodeMangler.DNSLookup.DNS.Records
{
    public class IPv6AddressData : RecordData
    {
        private string _ipv6Address = string.Empty;
        private const int IPv6ADDRESS_SIZE = 16;
        private RecordType _recordType;

        public IPv6AddressData(RecordType recordType)
        {
            _recordType = recordType;
        }

        #region RecordData Members

        public int PopulateFrom(byte[] data, int offset)
        {
            _ipv6Address = string.Format("{0:x}:{1:x}:{2:x}:{3:x}:{4:x}:{5:x}:{6:x}:{7:x}", data.ToUInt16(offset), data.ToUInt16(offset + 2), data.ToUInt16(offset + 4), data.ToUInt16(offset + 6),
                                            data.ToUInt16(offset + 8), data.ToUInt16(offset + 10), data.ToUInt16(offset + 12), data.ToUInt16(offset + 14));
            return IPv6ADDRESS_SIZE;
        }

        public string AsString
        {
            get { return _ipv6Address; }
        }

        public byte[] AsByteArray
        {
            get
            {
                string[] ipAddressSegments = _ipv6Address.Split(':');
                if (ipAddressSegments.Length < IPv6ADDRESS_SIZE)
                    return new byte[0];

                byte[] result = new byte[IPv6ADDRESS_SIZE];
                for (int i = 0; i < 8; i++)
                {
                    byte[] addressBytes = int.Parse(ipAddressSegments[0]).ToByteArray();
                    result[i*2] = addressBytes[0];
                    result[(i*2) + 1] = addressBytes[1];
                }

                return result;
            }
        }

        public RecordType RecordType { get { return _recordType; } }

        #endregion
    }
}