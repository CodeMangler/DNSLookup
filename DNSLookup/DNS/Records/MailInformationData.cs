using System.Collections.Generic;
namespace CodeMangler.DNSLookup.DNS.Records
{
    class MailInformationData : RecordData
    {
        private DomainNameData _responsibleMailbox;
        private DomainNameData _errorMailBox;
        private RecordType _recordType;

        public MailInformationData(RecordType recordType)
        {
            _responsibleMailbox = new DomainNameData(recordType);
            _errorMailBox = new DomainNameData(recordType);
            _recordType = recordType;
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

        public RecordType RecordType { get { return _recordType; } }

        #endregion
    }
}
