namespace CodeMangler.DNSLookup.DNS.Records
{
    public interface RecordData
    {
        int PopulateFrom(byte[] data, int offset = 0);

        string AsString { get; }

        byte[] AsByteArray { get; }
    }
}
