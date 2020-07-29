using ClientServer.Domain.Util;
using System;
using System.Diagnostics;
using System.Net.Sockets;

namespace ClientServer.Domain.Model
{
    public class AcceptedTcpClient
    {
        public TcpClient TcpClient { get;}
        public int AcceptedClientID { get;}
        public NetworkStream NetworkStream { get; private set; }

        public AcceptedTcpClient(TcpClient tcpClient, int acceptedClientId)
        {
            TcpClient = tcpClient;
            AcceptedClientID = acceptedClientId;
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
                        var getMessage = NetworkStreamIO.GetMessage(NetworkStream);
                        Trace.WriteLine($"'{GetType().Name}' with id '{AcceptedClientID}' get message from client '{getMessage}'.");
                        NetworkStreamIO.SendMessage(NetworkStream ,$"Сервер принял собщение от '{AcceptedClientID.ToString()}'.");
                        //Trace.WriteLine($"'{GetType().Name}' with id '{AcceptedClientID}' SEND message TO client '{getMessage}'.");

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
    }
}
