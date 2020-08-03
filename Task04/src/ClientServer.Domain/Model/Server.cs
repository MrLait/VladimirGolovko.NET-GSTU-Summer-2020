using ClientServer.Domain.Repositories;
using Infrastructure;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
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
        /// Debug logger.
        /// </summary>
        private ILogger _log { get; set; }

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
            _log = new DebugLogger();
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
                _log.Info("Waiting for connection... ");

                while (true)
                {
                    TcpClient = _tcpListener.AcceptTcpClient();

                    AcceptedTcpClient acceptedTcpClient = new AcceptedTcpClient(TcpClient, acceptedClientId, Name, Message);
                    _log.Info(string.Format("Client with id: {0} connected.", acceptedClientId));
                    Thread thread = new Thread(new ThreadStart(acceptedTcpClient.OpenStream));
                    thread.Start();
                    acceptedClientId++;
                    ServerMessageRepositories.Add(new ServerMessageRepository(acceptedTcpClient));
                }
            }
            catch (Exception e)
            {
                _log.Error($"'{e.Message}'");
            }
            finally
            {
                if (_tcpListener != null)
                {
                    _log.Info("Server stop");
                    _tcpListener.Stop();
                }
            }
        }
    }
}
