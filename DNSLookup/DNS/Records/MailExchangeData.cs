using System;
using System.Collections.Generic;

namespace CodeMangler.DNSLookup.DNS.Records
{
    class MailExchangeData : RecordData
    {
        private UInt16 _preference;
        private DomainNameData _mailExchange;
        private RecordType _recordType;

        public MailExchangeData(RecordType recordType)
        {
            _preference = 0;
            _mailExchange = new DomainNameData(recordType);
            _recordType = recordType;
        }

        #region RecordData Members

        public int PopulateFrom(byte[] data, int offset)
        {
            _preference = data.ToUInt16(offset);
            int usedBytes = 2; // sizeof(UInt16)
            offset += 2; // sizeof(UInt16)
            usedBytes += _mailExchange.PopulateFrom(data, offset);
            return usedBytes;
        }

        public string AsString
        {
            get { return string.Format("{0}\t{1}", _preference, _mailExchange.AsString); }
        }

        public byte[] AsByteArray
        {
            get
            {
                List<byte> result = new List<byte>();
                result.AddRange(_preference.ToByteArray());
                result.AddRange(_mailExchange.AsByteArray);
                return result.ToArray();
            }
        }

        public RecordType RecordType { get { return _recordType; } }

        #endregion
    }
}
