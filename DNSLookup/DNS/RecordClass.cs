namespace CodeMangler.DNSLookup.DNS
{
    // http://www.ietf.org/rfc/rfc1035.txt
    public enum RecordClass
    {
        IN = 1, // Internet
        CS = 2, // CSNET - Obsolete
        CH = 3, // CHAOS
        HS = 4, // Hesiod
        ANY = 255
    }
}
