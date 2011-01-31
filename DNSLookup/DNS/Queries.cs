using System.Collections.Generic;
using System.Text;
using System;

namespace CodeMangler.DNSLookup.DNS
{
    [Serializable]
    public class Queries
    {
        private List<Query> _queries = new List<Query>();

        public int Parse(byte[] datagram, int offset, int questionCount)
        {
            int usedBytes, totalUsedBytes = 0;

            int i = offset;
            for (int j = 0; j < questionCount; j++)
            {
                _queries.Add(Query.Parse(datagram, i, out usedBytes));
                totalUsedBytes += usedBytes;
            }

            return totalUsedBytes;
        }

        public byte[] AsByteArray()
        {
            List<byte> result = new List<byte>();
            foreach (Query query in _queries)
                result.AddRange(query.AsByteArray());
            return result.ToArray();
        }

        internal void Add(string domainName, RecordType recordType = RecordType.ANY, RecordClass recordClass = RecordClass.IN)
        {
            _queries.Add(new Query(domainName, recordType, recordClass));
        }
    }
}
