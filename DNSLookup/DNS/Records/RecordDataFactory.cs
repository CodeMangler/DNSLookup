using CodeMangler.DNSLookup.DNS.Records;

namespace CodeMangler.DNSLookup.DNS
{
    class RecordDataFactory
    {
        public static RecordData RecordDataFor(RecordType recordType)
        {
            switch (recordType)
            {
                case RecordType.A:
                    return new AddressData();
                case RecordType.CNAME:
                case RecordType.MB: // Experimental
                case RecordType.MD: // Obsolete.. Should throw exception instead? Or use MX?
                case RecordType.MF: // Obsolete.. Should throw exception instead? Or use MX?
                case RecordType.MG: // Experimental
                case RecordType.MR: // Experimental
                case RecordType.NS:
                case RecordType.PTR:
                    return new DomainNameData();
                case RecordType.HINFO:
                    return new HostInformationData();
                case RecordType.MINFO:
                    return new MailInformationData();
                case RecordType.MX:
                    return new MailExchangeData();
                case RecordType.SOA:
                    return new StartOfAuthorityData();
                case RecordType.TXT:
                    return new TextData();
                case RecordType.WKS:
                    return new WellKnownServiceData();
                case RecordType.NULL: // Experimental
                    return new NullData();

            }
            return new NullData();
        }
    }
}
