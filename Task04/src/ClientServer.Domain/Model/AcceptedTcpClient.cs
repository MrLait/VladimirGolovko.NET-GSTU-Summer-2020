using System;
using System.Net.Sockets;

namespace ClientServer.Domain.Model
{
    public class AcceptedTcpClient
    {
        public TcpClient TcpClient { get;}
        public int AcceptedClientID { get;}

        public AcceptedTcpClient(TcpClient tcpClient, int acceptedClientId)
        {
            TcpClient = tcpClient;
            AcceptedClientID = acceptedClientId;
        }

        internal void OpenStreamConnection()
        {
            try
            {
                NetworkStream networkStream = TcpClient.GetStream();

                while (true)
                {

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
