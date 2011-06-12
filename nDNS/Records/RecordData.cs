namespace CodeMangler.nDNS.Records
{
    public interface RecordData
    {
        int PopulateFrom(byte[] data, int offset);

        string AsString { get; }

        byte[] AsByteArray { get; }

        RecordType RecordType { get; }
    }
}
