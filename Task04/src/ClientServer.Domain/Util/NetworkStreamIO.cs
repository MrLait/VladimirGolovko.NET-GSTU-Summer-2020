using System.IO;
using System.Net.Sockets;

namespace ClientServer.Domain.Util
{
    /// <summary>
    /// Type for network messaging.
    /// </summary>
    public static class NetworkStreamIO
    {
        /// <summary>
        /// Send messages.
        /// </summary>
        /// <param name="networkStream"> Network stream to send messages. </param>
        /// <param name="message"> Output messages. </param>
        public static void SendMessage(NetworkStream networkStream, string message)
        {
            BinaryWriter binaryWriter = new BinaryWriter(networkStream);
            binaryWriter.Write(message);
        }

        /// <summary>
        /// Get messages.
        /// </summary>
        /// <param name="networkStream"> Network stream to get messages. </param>
        /// <returns>Input messages.</returns>
        public static string GetMessage(NetworkStream networkStream)
        {
            BinaryReader binaryReader = new BinaryReader(networkStream);
            var message = binaryReader.ReadString();

            return message;
        }
    }
}
