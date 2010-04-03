using System;
using System.Text;
namespace CodeMangler.DNSLookup.DNS.Records
{
    class NullData : RecordData
    {
        private byte[] _data = new byte[0];

        #region RecordData Members

        public int PopulateFrom(byte[] data, int offset)
        {
            _data = new byte[data.Length - offset];
            Array.Copy(data, offset, _data, 0, _data.Length);
            return _data.Length;
        }

        public string AsString
        {
            // TODO: Return hex values of each byte instead.. Encoding.ASCII.GetString() for the moment..
            get { return Encoding.ASCII.GetString(_data); }
        }

        public byte[] AsByteArray
        {
            get { return _data; }
        }

        #endregion
    }
}
