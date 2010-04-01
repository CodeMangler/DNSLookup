﻿namespace CodeMangler.DNSLookup.DNS
{
    // http://publib.boulder.ibm.com/infocenter/tivihelp/v3r1/index.jsp?topic=/com.ibm.itcamISM.doc/rg/concept/ISM_Ref_DNS_guideline_dnsquery.html
    // http://www.ietf.org/rfc/rfc1035.txt
    public enum RecordType
    {
        ANY = 0xFF,
        A = 0x01,
        NS = 0x02,
        MD = 0x03,
        MF = 0x04,
        CNAME = 0x05,
        SOA = 0x06,
        MB = 0x07,
        MG = 0x08,
        MR = 0x09,
        NULL = 0x0A,
        WKS = 0x0B,
        PTR = 0x0C,
        HINFO = 0x0D,
        MX = 0x0F,
        TXT = 0x10,
        AXFR = 0xFC,
        MAILB = 0xFD,
        MAILA = 0xFE,
        //SRV,
        //AAAA,
        //A_PLUS_AAAA,
        //MINFO,
    }
}