﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CodeMangler.DNSLookup.DNS
{
    // A DNS Message. i.e. the Packet that's exchanged between the server and the client as part of the protocol..
    public class Message
    {
        private Header _header;
        private Queries _queries;
        private Answers _answers;
        private AuthorityResourceRecords _authorityResourceRecords;
        private AdditionalInformationRecords _additionalInformationRecords;

        public Message()
        {
            _header = new Header();
            _queries = new Queries();
            _answers = new Answers();
            _authorityResourceRecords = new AuthorityResourceRecords();
            _additionalInformationRecords = new AdditionalInformationRecords();
        }

        public Message(byte[] datagram) : this()
        {
            int offset = _header.Parse(datagram);
            offset = _queries.Parse(datagram, offset, _header.QueryCount);
            offset = _answers.Parse(datagram, offset, _header.AnswerCount);
            offset = _authorityResourceRecords.Parse(datagram, offset, _header.AuthorityResourceRecordCount);
            offset = _additionalInformationRecords.Parse(datagram, offset, _header.AdditionalResourceRecordCount);
        }

        internal void AddQuery(string query)
        {
            _header.QueryCount++;
            _queries.Add(query);
        }

        internal bool IsForRequest(Message dnsRequest)
        {
            return _header.Id == dnsRequest._header.Id;
        }

        internal byte[] AsByteArray()
        {
            List<byte> result = new List<byte>();
            result.AddRange(_header.AsByteArray());
            result.AddRange(_queries.AsByteArray());
            result.AddRange(_answers.AsByteArray());
            result.AddRange(_authorityResourceRecords.AsByteArray());
            result.AddRange(_additionalInformationRecords.AsByteArray());
            return result.ToArray();
        }

        internal string AsString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(_answers.AsString());
            result.Append(_authorityResourceRecords.AsString());
            result.Append(_additionalInformationRecords.AsString());
            return result.ToString();
        }
    }
}