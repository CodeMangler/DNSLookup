namespace CodeMangler.DNSLookup.DNS.Records
{
    class DomainNameData : RecordData
    {
        private string _domainName = string.Empty;

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

        #endregion
    }
}
