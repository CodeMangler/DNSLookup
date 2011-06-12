using System.Collections.Generic;

namespace CodeMangler.nDNS.Records
{
    class TextData : RecordData
    {
        List<CharacterStringData> _characterStrings = new List<CharacterStringData>();
        private RecordType _recordType;

        public TextData(RecordType recordType)
        {
            _recordType = recordType;
        }

        #region RecordData Members

        public int PopulateFrom(byte[] data, int offset)
        {
            int usedBytes = 0;
            bool done = false;
            do
            {
                CharacterStringData characterString = new CharacterStringData(_recordType);
                usedBytes += characterString.PopulateFrom(data, offset + usedBytes);

                if(usedBytes >= (data.Length - offset)) // used up all bytes
                    done = true;
            } while (!done);

            return usedBytes;
        }

        public string AsString
        {
            get { return string.Join("\n", _characterStrings); }
        }

        public byte[] AsByteArray
        {
            get
            {
                List<byte> result = new List<byte>();
                foreach (CharacterStringData characterString in _characterStrings)
                    result.AddRange(characterString.AsByteArray);
                return result.ToArray();
            }
        }

        public RecordType RecordType { get { return _recordType; } }

        #endregion
    }
}
