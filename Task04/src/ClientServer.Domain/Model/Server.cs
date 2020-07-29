using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ClientServer.Domain.Model
{
    public class Server
    {
        private static TcpListener _tcpListener;

        public Server(IPAddress iPAddress , int port)
        {
            Port = port;
            IPAddress = iPAddress;
            _tcpListener = new TcpListener(IPAddress, Port);
        }

        public int Port { get; }
        public IPAddress IPAddress { get; }

        public void Start()
        {
            try
            {
                int acceptedClientId = 0;
                _tcpListener.Start();
                Debug.WriteLine("Waiting for connection... ");

                while (true)
                {
                    AcceptedTcpClient acceptedTcpClient = new AcceptedTcpClient(_tcpListener.AcceptTcpClient(), acceptedClientId);
                    Debug.WriteLine(String.Format("Client with id: {0} connected.", acceptedClientId));
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
