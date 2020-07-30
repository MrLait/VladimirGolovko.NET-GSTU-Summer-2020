using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ClientServer.Domain.Model
{
    public class Server : BaseClientServer
    {
        private static TcpListener _tcpListener;

        public Server(string name, IPAddress ipAddress , int port) : base(name, ipAddress, port)
        {
            _tcpListener = new TcpListener(IPAddress, Port);
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
                }
                
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
