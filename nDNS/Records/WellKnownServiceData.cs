using System;
using System.Collections.Generic;
namespace CodeMangler.nDNS.Records
{
    class WellKnownServiceData : RecordData
    {
        AddressData _address;
        byte _protocol;
        byte[] _bitMap;
        private RecordType _recordType;

        public WellKnownServiceData(RecordType recordType)
        {
            _address = new AddressData(recordType);
            _protocol = 0;
            _bitMap = new byte[0];
            _recordType = recordType;
        }

        #region RecordData Members

        public int PopulateFrom(byte[] data, int offset)
        {
            int usedBytes = _address.PopulateFrom(data, offset); // Should return 4 bytes, since we support only IPv4 at the moment..
            _protocol = data[offset + usedBytes];
            usedBytes += 1;

            _bitMap = new byte[data.Length - offset - usedBytes];
            Array.Copy(data, offset + usedBytes, _bitMap, 0, _bitMap.Length);

            return data.Length - offset;

        }

        public string AsString
        {
            get { return string.Format("{0}\tProtocol: {1}, Port Map: {2} bytes long", _address.AsString, _protocol, _bitMap.Length); }
        }

        public byte[] AsByteArray
        {
            get
            {
                List<byte> result = new List<byte>();
                result.AddRange(_address.AsByteArray);
                result.Add(_protocol);
                result.AddRange(_bitMap);
                return result.ToArray();
            }
        }

        public RecordType RecordType { get { return _recordType; } }

        #endregion
    }
}
