namespace CodeMangler.DNSLookup.DNS.Records
{
    public class AddressData : RecordData
    {
        private string _ipAddress = string.Empty;
        private const int IPADDRESS_SIZE = 4; // 4 Bytes for the IP Address.. Obviously, not considering IPv6
        private RecordType _recordType;

        public AddressData(RecordType recordType)
        {
            _recordType = recordType;
        }

        #region RecordData Members

        public int PopulateFrom(byte[] data, int offset)
        {
            _ipAddress = string.Format("{0}.{1}.{2}.{3}", data[offset], data[offset + 1], data[offset + 2], data[offset + 3]);
            return IPADDRESS_SIZE;
        }

        public string AsString
        {
            get { return _ipAddress; }
        }

        public byte[] AsByteArray
        {
            get
            {
                string[] ipAddressSegments = _ipAddress.Split('.');
                if (ipAddressSegments.Length < IPADDRESS_SIZE)
                    return new byte[0];

                byte[] result = new byte[IPADDRESS_SIZE];
                result[0] = byte.Parse(ipAddressSegments[0]);
                result[1] = byte.Parse(ipAddressSegments[1]);
                result[2] = byte.Parse(ipAddressSegments[2]);
                result[3] = byte.Parse(ipAddressSegments[3]);

                return result;
            }
        }

        public RecordType RecordType { get { return _recordType; } }

        #endregion
    }
}
