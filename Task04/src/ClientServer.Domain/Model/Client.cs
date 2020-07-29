using ClientServer.Domain.Util;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace ClientServer.Domain.Model
{
    public class Client : BaseClientServer
    {
        public string ClientName { get; }
        public NetworkStream NetworkStream { get; private set; }

        public Client(string clientName, IPAddress ipAddress, int port) : base(ipAddress, port)
        {
            ClientName = clientName;
            ConnectionToServer();
        }


        public void OpenStream()
        {
            try
            {
                NetworkStream = TcpClient.GetStream();
                while (true)
                {
                    Debug.WriteLine($"Client with name '{ClientName}' OpenStream.");
                    string sendMessage = "asdasdasd";
                    NetworkStreamIO.SendMessage(NetworkStream, sendMessage);
                    Debug.WriteLine($"Client with name '{ClientName}' send message '{sendMessage}'.");

                    var getMessage = NetworkStreamIO.GetMessage(NetworkStream);
                    Debug.WriteLine($"'{GetType().Name}' with name '{ClientName}' get message from client '{getMessage}'.");

                    break;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Client with name '{ClientName}' get exception '{e.Message}'.");
                throw;
            }
            finally
            {
                if (NetworkStream != null)
                    NetworkStream.Close();
                if (TcpClient != null)
                    TcpClient.Close();
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
