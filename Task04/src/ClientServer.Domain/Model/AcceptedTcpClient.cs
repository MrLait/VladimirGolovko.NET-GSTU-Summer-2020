using ClientServer.Domain.EventsArgs;
using ClientServer.Domain.Util;
using System;
using System.Diagnostics;
using System.Net.Sockets;

namespace ClientServer.Domain.Model
{
    public class AcceptedTcpClient
    {
        public event EventHandler<NewMessageToServerEventArgs> NewMessage;

        public TcpClient TcpClient { get;}
        public int AcceptedClientID { get;}
        public NetworkStream NetworkStream { get; private set; }
        public Server Server { get; }

        public AcceptedTcpClient(TcpClient tcpClient, int acceptedClientId, Server server)
        {
            TcpClient = tcpClient;
            AcceptedClientID = acceptedClientId;
            Server = server;
        }

        internal void OpenStreamConnection()
        {
            try
            {
                NetworkStream = TcpClient.GetStream();

                while (true)
                {
                    try
                    {
                        //Send server name to client
                        NetworkStreamIO.SendMessage(NetworkStream, Server.Name);

                        //Get client name
                        var getName = NetworkStreamIO.GetMessage(NetworkStream);

                        //Get message from server
                        var getMessage = NetworkStreamIO.GetMessage(NetworkStream);

                        //Register message from client
                        if (getName != string.Empty & getMessage != string.Empty)
                        { 
                            GetNewMessage(AcceptedClientID, getName, getMessage);

                        //Sending a message to the client with all received information.
                        NetworkStreamIO.SendMessage(NetworkStream, 
                            $"Сообщение получено от сервера(Имя сервера): '{Server.Name}')), " +
                            $"кому (Имя и id пользователя): '{getName}', '{AcceptedClientID}';" +
                            $"Сообщение сервера: '{Server.Message}';" +
                            $"Полученное сообщение пользовалетя: '{getMessage}'");
                        }

                    }
                    catch (Exception)
                    {
                        Debug.WriteLine($"'{GetType().Name}' with id '{AcceptedClientID}' disconected.");
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"'{GetType().Name}' with id '{AcceptedClientID}' get exception '{e.Message}'.");
            }
            finally
            {
                if (NetworkStream != null)
                    NetworkStream.Close();
                if (TcpClient != null)
                    TcpClient.Close();
            }
        }


        protected virtual void OnNewMessage(NewMessageToServerEventArgs e)
        {
            NewMessage?.Invoke(this, e);
        }

        public void GetNewMessage(int clientId, string name, string message)
        {
            NewMessageToServerEventArgs newMessageToServer = new NewMessageToServerEventArgs(clientId, name, message);
            OnNewMessage(newMessageToServer);
        }


    }
}
