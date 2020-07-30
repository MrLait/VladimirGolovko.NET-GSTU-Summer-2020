using System.IO;
using System.Net.Sockets;

namespace ClientServer.Domain.Util
{
    public static class NetworkStreamIO
    {
        public static void SendMessage(NetworkStream networkStream, string message)
        {
            BinaryWriter binaryWriter = new BinaryWriter(networkStream);
            binaryWriter.Write(message);
        }

        public static string GetMessage(NetworkStream networkStream)
        {
            BinaryReader binaryReader = new BinaryReader(networkStream);
            var message = binaryReader.ReadString();

            return message;
        }
    }
}
