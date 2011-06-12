using System;
using System.Net;
using CodeMangler.nDNS;
using System.Diagnostics;
using System.Net.Sockets;

namespace CodeMangler.DNSLookup
{
    public class LookupEngine
    {
        private const int LOCAL_PORT = 42424;
        private const int DNS_PORT = 53;
        private readonly string _server;
        IPEndPoint _serverEndpoint;

        public LookupEngine(string server)
        {
            _server = server;
            _serverEndpoint = new IPEndPoint(IPAddress.Parse(_server), DNS_PORT);
        }

        public string Lookup(string query, string queryType)
        {
            UdpClient udpChannel = null;
            try
            {
                udpChannel = new UdpClient(LOCAL_PORT);
                Message dnsRequest = new Message();
                dnsRequest.AddQuery(query, (RecordType) Enum.Parse(typeof (RecordType), queryType, true));
                byte[] requestDatagram = dnsRequest.AsByteArray();
                int sendResult = udpChannel.Send(requestDatagram, requestDatagram.Length, _serverEndpoint);
                    // Verify sendResult and throw exception if required..

                byte[] responseDatagram = udpChannel.Receive(ref _serverEndpoint);
                Message dnsResponse = new Message(responseDatagram);

                Debug.Assert(dnsResponse.IsForRequest(dnsRequest));
                    // Could make it an [if(isForRequest) ... else retry/throw] if required..

                return dnsResponse.AsString();
            } 
            finally
            {
                if(udpChannel != null)
                    udpChannel.Close();
            }
        }
    }
}
