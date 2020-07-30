using ClientServer.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ClientServer.Domain.Model
{
    public class Server : BaseClientServer
    {
        private static TcpListener _tcpListener;

        public List<ServerMessageRepository> ServerMessageRepositories { get; private set; }

        public Server(string name, IPAddress ipAddress , int port) : base(name, ipAddress, port)
        {
            _tcpListener = new TcpListener(IPAddress, Port);
            ServerMessageRepositories = new List<ServerMessageRepository>();
        }

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

                    AcceptedTcpClient acceptedTcpClient = new AcceptedTcpClient(TcpClient, acceptedClientId, this);
                    Debug.WriteLine(string.Format("Client with id: {0} connected.", acceptedClientId));
                    Thread thread = new Thread(new ThreadStart(acceptedTcpClient.OpenStreamConnection));
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
