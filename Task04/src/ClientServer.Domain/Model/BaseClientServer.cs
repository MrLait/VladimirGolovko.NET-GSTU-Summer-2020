using System.Net;
using System.Net.Sockets;

namespace ClientServer.Domain.Model
{
    public abstract class BaseClientServer
    {
        public BaseClientServer(string name, IPAddress ipAddress, int port)
        {
            Name = name;
            Port = port;
            IPAddress = ipAddress;
        }

        public string Name { get; }
        public int Port { get; }
        public IPAddress IPAddress { get; }
        public TcpClient TcpClient { get; set; }
        public string Message { get; set; }
    }
}
