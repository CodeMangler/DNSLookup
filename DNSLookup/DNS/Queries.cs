﻿using System.Collections.Generic;
using System.Text;

namespace CodeMangler.DNSLookup.DNS
{
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

        internal void Add(string domainName)
        {
            _queries.Add(new Query(domainName));
        }
    }
}