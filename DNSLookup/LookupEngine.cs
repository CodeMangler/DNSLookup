using System.Net;
using CodeMangler.DNSLookup.DNS;
using System.Diagnostics;
using System.Net.Sockets;

namespace CodeMangler.DNSLookup
{
    public class LookupEngine
    {
        private const int LOCAL_PORT = 42424;
        private const int DNS_PORT = 53;
        private string _server;
        private UdpClient _udpChannel = new UdpClient(LOCAL_PORT);
        IPEndPoint _serverEndpoint;

        public LookupEngine(string server)
        {
            _server = server;
            _serverEndpoint = new IPEndPoint(IPAddress.Parse(server), DNS_PORT);
        }

        internal string Lookup(string query, string queryType)
        {
            Message dnsRequest = new Message();
            dnsRequest.AddQuery(query, RecordType.A);
            byte[] requestDatagram = dnsRequest.AsByteArray();
            int sendResult = _udpChannel.Send(requestDatagram, requestDatagram.Length, _serverEndpoint); // Verify sendResult and throw exception if required..

            byte[] responseDatagram = _udpChannel.Receive(ref _serverEndpoint);
            Message dnsResponse = new Message(responseDatagram);

            Debug.Assert(dnsResponse.IsForRequest(dnsRequest)); // Could make it an [if(isForRequest) ... else retry/throw] if required..

            return dnsResponse.AsString();
        }
    }
}
