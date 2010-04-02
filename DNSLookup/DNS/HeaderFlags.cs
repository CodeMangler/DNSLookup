namespace CodeMangler.DNSLookup.DNS
{
    /*
  0  1  2  3  4  5  6  7  8  9  0  1  2  3  4  5
+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
|QR|   Opcode  |AA|TC|RD|RA|   Z    |   RCODE   |
+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
     */
    public enum HeaderFlags
    {
        Response = 0x8000, // QR -> Turning this bit off => it's a query
        OpCode1 = 0x4000,
        OpCode2 = 0x2000,
        OpCode3 = 0x1000,
        OpCode4 = 0x0800,
        AuthoritativeAnswer = 0x0400,
        Truncated = 0x0200,
        RecursionDesired = 0x100,
        RecursionAvailable = 0x0080,
        Resv1 = 0x0040,
        Resv2 = 0x0020,
        Resv3 = 0x0010,
        ReturnCode1 = 0x0008,
        ReturnCode2 = 0x0004,
        ReturnCode3 = 0x0002,
        ReturnCode4 = 0x0001
    }
}
