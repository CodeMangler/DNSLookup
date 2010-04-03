using System.Collections.Generic;
namespace CodeMangler.DNSLookup.DNS.Records
{
    class HostInformationData : RecordData
    {
        private CharacterStringData _cpu;
        private CharacterStringData _os;

        public HostInformationData()
        {
            _cpu = new CharacterStringData();
            _os = new CharacterStringData();
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

        #endregion
    }
}
