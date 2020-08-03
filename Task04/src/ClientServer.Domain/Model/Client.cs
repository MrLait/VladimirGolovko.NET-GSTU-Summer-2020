using ClientServer.Domain.EventsArgs;
using ClientServer.Domain.Util;
using Infrastructure;
using Infrastructure.Interfaces;
using System;
using System.Net;
using System.Net.Sockets;

namespace ClientServer.Domain.Model
{
    /// <summary>
    /// Client class that describes a client connections.
    /// </summary>
    public class Client : BaseClientServer
    {
        /// <summary>
        /// Debug logger.
        /// </summary>
        private ILogger _log { get; set; }

        /// <summary>
        /// Event to track new messages.
        /// </summary>
        public event EventHandler<NewMessagaToClientEventArgs> NewMessage;

        /// <summary>
        /// Through this object, you can send messages to the server or, conversely, receive data from the server.
        /// </summary>
        public NetworkStream NetworkStream { get; private set; }

        /// <summary>
        /// Constructor for initialize input poperty.
        /// </summary>
        /// <param name="name">Client name.</param>
        /// <param name="ipAddress">Client ip address.</param>
        /// <param name="port">Client port.</param>
        public Client(string name, IPAddress ipAddress, int port) : base(name, ipAddress, port)
        {
            _log = new DebugLogger();
            ConnectionToServer();
        }

        /// <summary>
        /// Client open stream.
        /// </summary>
        public void OpenStream()
        {
            try
            {
                NetworkStream = TcpClient.GetStream();
                while (true)
                {
                    _log.Info($"Client with name '{Name}' OpenStream.");
                    //Get server name
                    var serverName = NetworkStreamIO.GetMessage(NetworkStream);

                    //Send client name;
                    NetworkStreamIO.SendMessage(NetworkStream, Name);

                    //Send message to server
                    if (Message == null)
                        throw new ArgumentNullException("Messsage is null");

                    NetworkStreamIO.SendMessage(NetworkStream, Message);
                    _log.Info($"Client with name '{Name}' send message '{Message}'.");

                    //Geting a message from client with all sending information
                    var serverMessage = NetworkStreamIO.GetMessage(NetworkStream);

                    //Register messsage from server
                    if (!string.IsNullOrEmpty(serverName) & !string.IsNullOrEmpty(serverMessage))
                        GetNewMessage(serverName, serverMessage);
                    else
                        GetNewMessage(serverName, "Message not received");
                    break;
                }
            }
            catch (ArgumentNullException)
            {
                _log.Error($"Client name: '{Name}' - Message is null");
            }
            catch (Exception e)
            {
                _log.Error($"Client with name '{Name}' get exception '{e.Message}'.");
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

        /// <summary>
        /// Connection to server.
        /// </summary>
        private void ConnectionToServer()
        {
            try
            {
                TcpClient = new TcpClient(IPAddress.ToString(), Port);
                _log.Info($"Client with name '{Name}' connected to server");
            }
            catch (SocketException)
            {
                _log.Error($"Client with name '{Name}' can't connected to server. Exception: SocketException");
                throw new SocketException();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Used to synchronously call the methods supported by the delegate object.
        /// </summary>
        /// <param name="e"> Type to receive a message when an event occurs. </param>
        protected virtual void OnNewMessage(NewMessagaToClientEventArgs e)
        {
            NewMessage?.Invoke(this, e);
        }

        /// <summary>
        /// Method for notifying receipt of a new message.
        /// </summary>
        /// <param name="name">Server name.</param>
        /// <param name="message">New message.</param>
        public void GetNewMessage(string name, string message)
        {
            NewMessagaToClientEventArgs e = new NewMessagaToClientEventArgs(name, message);
            OnNewMessage(e);
        }

    }
}
