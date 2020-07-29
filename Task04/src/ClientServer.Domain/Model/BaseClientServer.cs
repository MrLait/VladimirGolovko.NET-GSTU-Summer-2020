using System.Net;
using System.Net.Sockets;

namespace ClientServer.Domain.Model
{
    public abstract class BaseClientServer
    {
        public BaseClientServer(IPAddress ipAddress, int port)
        {
            Port = port;
            IPAddress = ipAddress;
        }

        public int Port { get; }
        public IPAddress IPAddress { get; }
        public TcpClient TcpClient { get; set; }
    }
}
