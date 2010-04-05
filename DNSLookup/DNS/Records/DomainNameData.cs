namespace CodeMangler.DNSLookup.DNS.Records
{
    class DomainNameData : RecordData
    {
        private string _domainName = string.Empty;
        private RecordType _recordType;

        public DomainNameData(RecordType recordType)
        {
            _recordType = recordType;
        }

        #region RecordData Members

        public int PopulateFrom(byte[] data, int offset)
        {
            int usedBytes;
            _domainName = data.DecodeDomainName(offset, out usedBytes);
            return usedBytes;
        }

        public string AsString
        {
            get { return _domainName; }
        }

        public byte[] AsByteArray
        {
            get { return _domainName.EncodeDomainName(); }
        }

        public RecordType RecordType { get { return _recordType; } }

        #endregion
    }
}
