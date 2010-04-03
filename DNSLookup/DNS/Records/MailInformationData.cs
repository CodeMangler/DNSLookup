using System.Collections.Generic;
namespace CodeMangler.DNSLookup.DNS.Records
{
    class MailInformationData : RecordData
    {
        private DomainNameData _responsibleMailbox;
        private DomainNameData _errorMailBox;

        public MailInformationData()
        {
            _responsibleMailbox = new DomainNameData();
            _errorMailBox = new DomainNameData();
        }

        #region RecordData Members

        public int PopulateFrom(byte[] data, int offset)
        {
            int usedBytes = _responsibleMailbox.PopulateFrom(data, offset);
            offset += usedBytes;
            usedBytes += _errorMailBox.PopulateFrom(data, offset);
            return usedBytes;
        }

        public string AsString
        {
            get { return _responsibleMailbox.AsString + "\n" + _errorMailBox.AsString; }
        }

        public byte[] AsByteArray
        {
            get
            {
                List<byte> result = new List<byte>();
                result.AddRange(_responsibleMailbox.AsByteArray);
                result.AddRange(_errorMailBox.AsByteArray);
                return result.ToArray();
            }
        }

        #endregion
    }
}
