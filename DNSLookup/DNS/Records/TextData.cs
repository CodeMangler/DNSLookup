using System.Collections.Generic;
namespace CodeMangler.DNSLookup.DNS.Records
{
    class TextData : RecordData
    {
        List<CharacterStringData> _characterStrings = new List<CharacterStringData>();

        #region RecordData Members

        public int PopulateFrom(byte[] data, int offset)
        {
            int usedBytes = 0;
            bool done = false;
            do
            {
                CharacterStringData characterString = new CharacterStringData();
                usedBytes += characterString.PopulateFrom(data, offset + usedBytes);

                if(usedBytes >= (data.Length - offset)) // used up all bytes
                    done = true;
            } while (!done);
            throw new System.NotImplementedException();
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

        #endregion
    }
}
