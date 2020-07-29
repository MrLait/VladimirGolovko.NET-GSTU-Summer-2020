using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace ClientServer.Domain.Util
{
    public static class NetworkStreamIO
    {
        public static void SendMessage(NetworkStream networkStream, string message)
        {
            //using (BinaryWriter binaryWriter = new BinaryWriter(networkStream))
            //{
            //    binaryWriter.Write(message);
            //}

                BinaryWriter binaryWriter = new BinaryWriter(networkStream);
                binaryWriter.Write(message);
        }

        public static string GetMessage(NetworkStream networkStream)
        {
            string message = string.Empty;

            try
            {
                BinaryReader binaryReader = new BinaryReader(networkStream);
                message = binaryReader.ReadString();

            }
            catch (System.ArgumentException e)
            {
                Debug.WriteLine(e.Message);
            }

            return message;
        }


        ///// <summary>
        ///// Write messages.
        ///// </summary>
        ///// <param name="message"> Output messages. </param>
        ///// <param name="_networkStream"> Network stream to write messages. </param>
        //public static void SendMessage(NetworkStream _networkStream, string message )
        //{
        //    byte[] data = Encoding.Unicode.GetBytes(message);

        //    _networkStream.Write(data, 0, data.Length);
        //}

        ///// <summary>
        ///// Get messages.
        ///// </summary>
        ///// <param name="_networkStream">Network stream to read messages</param>
        ///// <returns>Input messages.</returns>
        //public static string GetMessage(NetworkStream _networkStream)
        //{
        //    byte[] data = new byte[256];
        //    StringBuilder stringBuilder = new StringBuilder();

        //    do
        //    {
        //        int bytes = _networkStream.Read(data, 0, data.Length);
        //        stringBuilder.Append(Encoding.Unicode.GetString(data, 0, bytes));
        //    }
        //    while (_networkStream.DataAvailable);

        //    return stringBuilder.ToString();
        //}
    }
}
