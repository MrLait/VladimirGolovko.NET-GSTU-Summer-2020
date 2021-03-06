﻿using ClientServer.Domain.EventsArgs;
using ClientServer.Domain.Util;
using Infrastructure;
using Infrastructure.Interfaces;
using System;
using System.Net.Sockets;

namespace ClientServer.Domain.Model
{
    /// <summary>
    /// Incoming client to the server.
    /// </summary>
    public class AcceptedTcpClient
    {
        /// <summary>
        /// Debug logger.
        /// </summary>
        private ILogger _log { get; set; }

        /// <summary>
        /// Event to track new messages.
        /// </summary>
        public event EventHandler<NewMessageToServerEventArgs> NewMessage;

        /// <summary>
        /// Property tcpClient.
        /// </summary>
        public TcpClient TcpClient { get;}

        /// <summary>
        /// Property clientId.
        /// </summary>
        public int AcceptedClientID { get;}

        /// <summary>
        /// Through this object, you can send messages to the server or, conversely, receive data from the server.
        /// </summary>
        public NetworkStream NetworkStream { get; private set; }

        /// <summary>
        /// Property server name.
        /// </summary>
        public string ServerName { get; }

        /// <summary>
        /// Property server message.
        /// </summary>
        public string ServerMessage { get; }

        /// <summary>
        /// Constructor for initialize input poperty.
        /// </summary>
        /// <param name="tcpClient">Tcp client.</param>
        /// <param name="acceptedClientId">Accepted client id.</param>
        /// <param name="serverName">Server name.</param>
        /// <param name="serverMessage">Server message.</param>
        public AcceptedTcpClient(TcpClient tcpClient, int acceptedClientId, string serverName, string serverMessage)
        {
            _log = new DebugLogger();
            TcpClient = tcpClient;
            AcceptedClientID = acceptedClientId;
            ServerName = serverName;
            ServerMessage = serverMessage;
        }

        /// <summary>
        /// Server open stream witn client.
        /// </summary>
        internal void OpenStream()
        {
            try
            {
                NetworkStream = TcpClient.GetStream();

                while (true)
                {
                    try
                    {
                        //Send server name to client
                        NetworkStreamIO.SendMessage(NetworkStream, ServerName);

                        //Get client name
                        var clientName = NetworkStreamIO.GetMessage(NetworkStream);

                        //Get message from server
                        var clientMessage = NetworkStreamIO.GetMessage(NetworkStream);

                        //Register message from client
                        if (clientName != string.Empty & clientMessage != string.Empty)
                        { 
                            GetNewMessage(AcceptedClientID, clientName, clientMessage);

                        //Sending a message to the client with all received information.
                        NetworkStreamIO.SendMessage(NetworkStream, 
                            $"Сообщение получено от сервера: '{ServerName}'; " +
                            $"Получатель: '{clientName}', '{AcceptedClientID}'; " +
                            $"Сообщение сервера: '{ServerMessage}'; " +
                            $"Полученное сообщение клиента: '{clientMessage}'.");
                        }
                    }
                    catch (Exception)
                    {
                        _log.Error($"'{GetType().Name}' with id '{AcceptedClientID}' disconected.");
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                _log.Error($"'{GetType().Name}' with id '{AcceptedClientID}' get exception '{e.Message}'.");
            }
            finally
            {
                if (NetworkStream != null)
                    NetworkStream.Close();
                if (TcpClient != null)
                    TcpClient.Close();
            }
        }

        /// <summary>
        /// Used to synchronously call the methods supported by the delegate object.
        /// </summary>
        /// <param name="e"> Type to receive a message when an event occurs. </param>
        protected virtual void OnNewMessage(NewMessageToServerEventArgs e)
        {
            NewMessage?.Invoke(this, e);
        }

        /// <summary>
        /// Method for notifying receipt of a new message.
        /// </summary>
        /// <param name="clientId">Client id.</param>
        /// <param name="name">Client name.</param>
        /// <param name="message">Client message.</param>
        public void GetNewMessage(int clientId, string name, string message)
        {
            NewMessageToServerEventArgs e = new NewMessageToServerEventArgs(clientId, name, message);
            OnNewMessage(e);
        }


    }
}
