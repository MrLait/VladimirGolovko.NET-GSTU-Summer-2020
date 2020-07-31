using System.Net;
using System.Net.Sockets;

namespace ClientServer.Domain.Model
{
    /// <summary>
    /// Base abstract type for client and server.
    /// </summary>
    public abstract class BaseClientServer
    {
        /// <summary>
        /// Constructor for initialize input poperty.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="ipAddress">Ip address.</param>
        /// <param name="port">Port.</param>
        public BaseClientServer(string name, IPAddress ipAddress, int port)
        {
            Name = name;
            Port = port;
            IPAddress = ipAddress;
        }
        /// <summary>
        /// Property name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Property port.
        /// </summary>
        public int Port { get; }

        /// <summary>
        /// Property IPAddress.
        /// </summary>
        public IPAddress IPAddress { get; }

        /// <summary>
        /// Property tcpClient.
        /// </summary>
        public TcpClient TcpClient { get; set; }

        /// <summary>
        /// Property mMessage.
        /// </summary>
        public string Message { get; set; }
    }
}
