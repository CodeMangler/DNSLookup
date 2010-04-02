using System.Text;
using System;
using System.Collections.Generic;
namespace CodeMangler.DNSLookup.DNS
{
    public static class ExtensionMethods
    {
        public static string DecodeDomainName(this byte[] datagram, int offset, out int usedBytes)
        {
            StringBuilder result = new StringBuilder();
            usedBytes = 0;
            int i = offset;
            bool done = false;
            do
            {
                byte c = datagram[i];
                i++;
                usedBytes++;

                if (c == 0) // end of name
                {
                    done = true;
                }
                else if(c >= 192) // => c > = 11000000 => the first two bits turned on, marking the start of compression..
                {
                    UInt16 pointer = datagram.ToUInt16(i - 1); // Get two bytes..
                    pointer <<= 2; // To lose the two high bits..
                    pointer >>= 2; // Revert back, thus setting the 2 high bits to 0, and getting the actual pointer back..
                    i++; // We just read an extra byte _in addition_ to the one we'd just read..
                    usedBytes++; // We used up just 2 bytes.. Not the length of the parsed string..

                    int domainNameByteCount;
                    return DecodeDomainName(datagram, pointer, out domainNameByteCount); // Return the decoded name from the pointer offset..
                }
                else
                {
                    result.Append(Encoding.ASCII.GetString(datagram, i, c)).Append(".");
                    usedBytes += c;
                    i += c;
                }
            } while (!done);

            if (result[result.Length - 1] == '.') // Remove the extra dot
                result.Remove(result.Length - 1, 1);

            return result.ToString();
        }

        public static byte[] EncodeDomainName(this string query)
        {
            byte[] result = new byte[query.Length + 2]; // Additional 2 bytes to accomodate for the terminating '0' byte and 1 extra count byte that gets added in place of the dots..
            string[] namesegments = query.Split('.');
            int i = 0;
            foreach (string namesegment in namesegments)
            {
                byte[] namesegmentBytes = Encoding.ASCII.GetBytes(namesegment);
                result[i] = (byte) namesegmentBytes.Length;
                Array.Copy(namesegmentBytes, 0, result, i + 1, namesegmentBytes.Length);
                i += namesegmentBytes.Length + 1;
            }
            result[i] = 0; // Redundant, but mentioned just for clarity..
            return result;
        }

        public static List<ResourceRecord> ParseResourceRecords(this byte[] datagram, int offset, int recordCount, out int usedBytes)
        {
            List<ResourceRecord> result = new List<ResourceRecord>();
            usedBytes = 0;
            for (int i = 0; i < recordCount; i++)
            {
                int recordSize;
                result.Add(ResourceRecord.Parse(datagram, offset, out recordSize));
                offset += recordSize;
                usedBytes += recordSize;
            }
            return result;
        }

        public static byte[] ToByteArray(this List<ResourceRecord> resourceRecords)
        {
            List<byte> result = new List<byte>();
            foreach (ResourceRecord resourceRecord in resourceRecords)
                result.AddRange(resourceRecord.AsByteArray());
            return result.ToArray();
        }

        public static string AsString(this List<ResourceRecord> resourceRecords)
        {
            StringBuilder result = new StringBuilder();
            foreach (ResourceRecord resourceRecord in resourceRecords)
                result.AppendLine(resourceRecord.AsString());
            return result.ToString();
        }

        public static UInt16 ToUInt16(this byte[] twoBytes, int offset)
        {
            return (UInt16)((((UInt16)twoBytes[offset + 0]) << 8) | twoBytes[offset + 1]);
        }

        public static UInt32 ToUInt32(this byte[] fourBytes, int offset)
        {
            return (UInt32)((((UInt32)fourBytes[offset + 0]) << 24) | (((UInt32)fourBytes[offset + 1]) << 16) | (((UInt32)fourBytes[offset + 2]) << 8) | fourBytes[offset + 1]);
        }

        public static Int32 ToInt32(this byte[] fourBytes, int offset)
        {
            return (Int32)fourBytes.ToUInt32(offset);
        }

        public static byte[] ToByteArray(this UInt16 unsignedInteger)
        {
            byte[] result = new byte[2];
            result[0] = (byte)(unsignedInteger >> 8); // high byte
            result[1] = (byte)unsignedInteger; // low byte.. assuming the high byte gets truncated in the casting process..
            return result;
        }

        public static byte[] ToByteArray(this Int32 integer)
        {
            byte[] result = new byte[4];
            result[0] = (byte)(integer >> 24); // high byte
            result[1] = (byte)(integer >> 16); 
            result[2] = (byte)(integer >> 8); 
            result[3] = (byte)integer; // low byte.. assuming the high byte gets truncated in the casting process..
            return result;
        }

    }
}
