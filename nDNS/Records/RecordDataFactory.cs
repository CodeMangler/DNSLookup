using CodeMangler.nDNS.Records;

namespace CodeMangler.nDNS
{
    class RecordDataFactory
    {
        public static RecordData RecordDataFor(RecordType recordType)
        {
            switch (recordType)
            {
                case RecordType.A:
                    return new AddressData(recordType);
                case RecordType.AAAA:
                    return new IPv6AddressData(recordType);
                case RecordType.CNAME:
                case RecordType.MB: // Experimental
                case RecordType.MD: // Obsolete.. Should throw exception instead? Or use MX?
                case RecordType.MF: // Obsolete.. Should throw exception instead? Or use MX?
                case RecordType.MG: // Experimental
                case RecordType.MR: // Experimental
                case RecordType.NS:
                case RecordType.PTR:
                    return new DomainNameData(recordType);
                case RecordType.HINFO:
                    return new HostInformationData(recordType);
                case RecordType.MINFO:
                    return new MailInformationData(recordType);
                case RecordType.MX:
                    return new MailExchangeData(recordType);
                case RecordType.SOA:
                    return new StartOfAuthorityData(recordType);
                case RecordType.TXT:
                    return new TextData(recordType);
                case RecordType.WKS:
                    return new WellKnownServiceData(recordType);
                case RecordType.NULL: // Experimental
                    return new NullData(recordType);

            }
            return new NullData(recordType);
        }
    }
}
