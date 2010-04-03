using System;
using System.Collections.Generic;

namespace CodeMangler.DNSLookup.DNS.Records
{
    class StartOfAuthorityData : RecordData
    {
        private DomainNameData _sourceNameServer;
        private DomainNameData _ownerMailbox;
        private UInt32 _serial;
        private UInt32 _refresh;
        private UInt32 _retry;
        private UInt32 _expire;
        private UInt32 _minTtl;

        public StartOfAuthorityData()
        {
            _sourceNameServer = new DomainNameData();
            _ownerMailbox = new DomainNameData();
            _serial = 0;
            _refresh = 0;
            _retry = 0;
            _expire = 0;
            _minTtl = 0;
        }

        #region RecordData Members

        public int PopulateFrom(byte[] data, int offset)
        {
            int usedBytes = _sourceNameServer.PopulateFrom(data, offset);
            usedBytes += _ownerMailbox.PopulateFrom(data, offset + usedBytes);
            _serial = data.ToUInt32(offset + usedBytes);
            usedBytes += 4; // sizeof(UInt32)
            _refresh = data.ToUInt32(offset + usedBytes);
            usedBytes += 4;
            _retry = data.ToUInt32(offset + usedBytes);
            usedBytes += 4;
            _expire = data.ToUInt32(offset + usedBytes);
            usedBytes += 4;
            _minTtl = data.ToUInt32(offset + usedBytes);
            usedBytes += 4;
            return usedBytes;
        }

        public string AsString
        {
            get { return string.Format("{0}\t{1}\t\t{2}  {3}  {4}  {5}  {6}", _sourceNameServer.AsString, _ownerMailbox.AsString, _serial, _refresh, _retry, _expire, _minTtl); }
        }

        public byte[] AsByteArray
        {
            get
            {
                List<byte> result = new List<byte>();
                result.AddRange(_sourceNameServer.AsByteArray);
                result.AddRange(_ownerMailbox.AsByteArray);
                result.AddRange(_serial.ToByteArray());
                result.AddRange(_refresh.ToByteArray());
                result.AddRange(_retry.ToByteArray());
                result.AddRange(_expire.ToByteArray());
                result.AddRange(_minTtl.ToByteArray());
                return result.ToArray();
            }
        }

        #endregion
    }
}
