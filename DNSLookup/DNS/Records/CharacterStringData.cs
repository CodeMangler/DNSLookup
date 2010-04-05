using System.Collections.Generic;
using System.Text;
using System;
namespace CodeMangler.DNSLookup.DNS.Records
{
    class CharacterStringData : RecordData
    {
        private string _characterString = string.Empty;
        private RecordType _recordType;

        public CharacterStringData(RecordType recordType)
        {
            _recordType = recordType;
        }

        #region RecordData Members

        public int PopulateFrom(byte[] data, int offset)
        {
            // Assumption: Every data block passed in contains exactly one character string.. The consumer of this class is expected to handle multiple character strings appropriately..
            byte characterStringLength = data[offset];
            _characterString = Encoding.ASCII.GetString(data, offset + 1, characterStringLength);
            return characterStringLength + 1; // Additional 1 byte is the string length byte..
        }

        public string AsString
        {
            get { return _characterString; }
        }

        public byte[] AsByteArray
        {
            get
            {
                byte[] stringBytes = Encoding.ASCII.GetBytes(_characterString);
                byte[] result = new byte[stringBytes.Length + 1]; // Additional 1 for the string length byte..
                result[0] = (byte)stringBytes.Length;
                Array.Copy(stringBytes, 0, result, 1, stringBytes.Length);
                return result;
            }
        }

        public RecordType RecordType { get { return _recordType; } }

        #endregion
    }
}
