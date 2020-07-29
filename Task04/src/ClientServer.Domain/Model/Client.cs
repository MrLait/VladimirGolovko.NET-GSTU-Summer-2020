using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace ClientServer.Domain.Model
{
    public class Client : BaseClientServer
    {
        public string ClientName { get; }

        public Client(string clientName, IPAddress ipAddress, int port) : base(ipAddress, port)
        {
            ClientName = clientName;
            ConnectionToServer();
        }


        public void OpenStream()
        {
            try
            {
                NetworkStream networkStream = TcpClient.GetStream();
                Debug.WriteLine($"Client with name '{ClientName}' OpenStream.");
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void ConnectionToServer()
        {
            try
            {
                TcpClient = new TcpClient(IPAddress.ToString(), Port);
                Debug.WriteLine($"Client with name '{ClientName}' connected to server");
            }
            catch (SocketException)
            {
                Debug.WriteLine($"Client with name '{ClientName}' can't connected to server. Exception: SocketException");
                throw new SocketException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
