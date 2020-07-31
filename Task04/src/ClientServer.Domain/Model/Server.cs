using ClientServer.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ClientServer.Domain.Model
{
    /// <summary>
    /// Server class that describes a server connections with client.
    /// </summary>
    public class Server : BaseClientServer
    {
        /// <summary>
        /// Field with tcp listener.
        /// </summary>
        private static TcpListener _tcpListener;

        /// <summary>
        /// A list to store each client’s messages.
        /// </summary>
        public List<ServerMessageRepository> ServerMessageRepositories { get; private set; }

        /// <summary>
        /// Constructor for initialize TcpListener, ServerMessageRepositories and input poperty.
        /// </summary>
        /// <param name="name">Server name.</param>
        /// <param name="ipAddress">Server ip address.</param>
        /// <param name="port">Server port.</param>
        public Server(string name, IPAddress ipAddress , int port) : base(name, ipAddress, port)
        {
            _tcpListener = new TcpListener(IPAddress, Port);
            ServerMessageRepositories = new List<ServerMessageRepository>();
        }

        /// <summary>
        /// Server launch.
        /// </summary>
        public void Start()
        {
            try
            {
                int acceptedClientId = 0;
                _tcpListener.Start();
                Debug.WriteLine("Waiting for connection... ");

                while (true)
                {
                    TcpClient = _tcpListener.AcceptTcpClient();

                    AcceptedTcpClient acceptedTcpClient = new AcceptedTcpClient(TcpClient, acceptedClientId, Name, Message);
                    Debug.WriteLine(string.Format("Client with id: {0} connected.", acceptedClientId));
                    Thread thread = new Thread(new ThreadStart(acceptedTcpClient.OpenStream));
                    thread.Start();
                    acceptedClientId++;
                    ServerMessageRepositories.Add(new ServerMessageRepository(acceptedTcpClient));
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"'{e.Message}'");
            }
            finally
            {
                if (_tcpListener != null)
                {
                    Debug.WriteLine("Server stop");
                    _tcpListener.Stop();
                }
            }
        }
    }
}
