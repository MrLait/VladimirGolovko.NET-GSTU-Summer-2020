using ClientServer.Domain.EventsArgs;
using ClientServer.Domain.Util;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace ClientServer.Domain.Model
{
    public class Client : BaseClientServer
    {
        public event EventHandler<NewMessagaToClientEventArgs> NewMessage;

        public NetworkStream NetworkStream { get; private set; }

        public Client(string name, IPAddress ipAddress, int port) : base(name, ipAddress, port)
        {
            ConnectionToServer();
        }

        public void OpenStream()
        {
            try
            {
                NetworkStream = TcpClient.GetStream();
                while (true)
                {
                    Debug.WriteLine($"Client with name '{Name}' OpenStream.");
                    
                    //Get server name
                    var serverName = NetworkStreamIO.GetMessage(NetworkStream);

                    //Send client name;
                    NetworkStreamIO.SendMessage(NetworkStream, Name);

                    //Send message to server
                    NetworkStreamIO.SendMessage(NetworkStream, Message);
                    Debug.WriteLine($"Client with name '{Name}' send message '{Message}'.");

                    //Geting a message from client with all sending information
                    var getMessage = NetworkStreamIO.GetMessage(NetworkStream);

                    //Register messsage from server
                    if (serverName != string.Empty & getMessage != string.Empty)
                        GetNewMessage(serverName, getMessage);
                    else
                        GetNewMessage(serverName, "Message not receive");

                    break;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Client with name '{Name}' get exception '{e.Message}'.");
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
                Debug.WriteLine($"Client with name '{Name}' connected to server");
            }
            catch (SocketException)
            {
                Debug.WriteLine($"Client with name '{Name}' can't connected to server. Exception: SocketException");
                throw new SocketException();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        protected virtual void OnNewMessage(NewMessagaToClientEventArgs e)
        {
            NewMessage?.Invoke(this, e);
        }

        public void GetNewMessage(string name, string message)
        {
            NewMessagaToClientEventArgs newMessagaToClient = new NewMessagaToClientEventArgs(name, message);
            OnNewMessage(newMessagaToClient);
        }

    }
}
