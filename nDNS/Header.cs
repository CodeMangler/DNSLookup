using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;

namespace CodeMangler.nDNS
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Header
    {
        private const int HEADER_SIZE = 12; // bytes

        UInt16 _id;
        UInt16 _flags;
        UInt16 _queryCount;
        UInt16 _answerCount;
        UInt16 _authorityResourceRecordCount;
        UInt16 _additionalResourceRecordCount;

        public int Id { get { return _id; } }

        public int Flags { get { return _flags; } } // Remove this and change the way flags are handled..

        public int QueryCount 
        { 
            get { return _queryCount; } 
            set { _queryCount = (UInt16) value; } 
        }

        public int AnswerCount { get { return _answerCount; } }

        public int AuthorityResourceRecordCount { get { return _authorityResourceRecordCount; } }

        public int AdditionalResourceRecordCount { get { return _additionalResourceRecordCount; } }

        public int Parse(byte[] datagram)
        {
            _id = datagram.ToUInt16(0);
            _flags = datagram.ToUInt16(2);
            _queryCount = datagram.ToUInt16(4);
            _answerCount = datagram.ToUInt16(6);
            _authorityResourceRecordCount = datagram.ToUInt16(8);
            _additionalResourceRecordCount = datagram.ToUInt16(10);
            return HEADER_SIZE; // Number of bytes consumed..
        }

        /* Almost works, except it screws up the byte order..
        public static Header Parse(byte[] datagram)
        {
            int headerSize = Marshal.SizeOf(typeof(Header));
            byte[] headerBytes = new byte[headerSize];
            Array.Copy(datagram, headerBytes, headerSize);
            GCHandle gcHandle = GCHandle.Alloc(headerBytes, GCHandleType.Pinned);
            Header header = (Header) Marshal.PtrToStructure(gcHandle.AddrOfPinnedObject(), typeof(Header));
            gcHandle.Free();
            return header;
        }
        */

        public byte[] AsByteArray()
        {
            byte[] result = new byte[HEADER_SIZE];
            Array.Copy(((UInt16)_id).ToByteArray(), 0, result, 0, 2);
            Array.Copy(((UInt16)_flags).ToByteArray(), 0, result, 2, 2);
            Array.Copy(((UInt16)_queryCount).ToByteArray(), 0, result, 4, 2);
            Array.Copy(((UInt16)_answerCount).ToByteArray(), 0, result, 6, 2);
            Array.Copy(((UInt16)_authorityResourceRecordCount).ToByteArray(), 0, result, 8, 2);
            Array.Copy(((UInt16)_additionalResourceRecordCount).ToByteArray(), 0, result, 10, 2);
            return result;
        }
    }
}
