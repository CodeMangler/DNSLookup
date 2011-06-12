using System.Collections.Generic;
namespace CodeMangler.nDNS.Records
{
    class HostInformationData : RecordData
    {
        private CharacterStringData _cpu;
        private CharacterStringData _os;
        private RecordType _recordType;

        public HostInformationData(RecordType recordType)
        {
            _cpu = new CharacterStringData(recordType);
            _os = new CharacterStringData(recordType);
            _recordType = recordType;
        }

        #region RecordData Members

        public int PopulateFrom(byte[] data, int offset)
        {
            int usedBytes = _cpu.PopulateFrom(data, offset);
            offset += usedBytes;
            usedBytes += _os.PopulateFrom(data, offset);
            return usedBytes;
        }

        public string AsString
        {
            get { return _cpu.AsString + "\n" + _os.AsString; }
        }

        public byte[] AsByteArray
        {
            get
            {
                List<byte> result = new List<byte>();
                result.AddRange(_cpu.AsByteArray);
                result.AddRange(_os.AsByteArray);
                return result.ToArray();
            }
        }

        public RecordType RecordType { get { return _recordType; } }

        #endregion
    }
}
