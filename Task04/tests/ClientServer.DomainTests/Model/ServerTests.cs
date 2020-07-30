using NUnit.Framework;
using System.Net;
using System.Text;
using System.Threading;

namespace ClientServer.Domain.Model.Tests
{
    [TestFixture()]
    public class ServerTests
    {
        [TestCase()]
        public void AcceptedTcpClientTest()
        {
            var ipString = "127.0.0.1";
            IPAddress ipAddress = IPAddress.Parse(ipString);

            Server server = new Server("BasaOne", IPAddress.Any, 8888);
            server.Message = "ServerMessage";
            Thread thread = new Thread(new ThreadStart(server.Start));
            thread.Start();


            Client client = new Client("Vova", ipAddress, 8888);
            client.Message = "FirstVovaMessage";
            Thread clientThreadOne = new Thread(new ThreadStart(client.OpenStream));
            
            clientThreadOne.Start();


            Client clientTwo = new Client("Dima", ipAddress, 8888);
            clientTwo.Message = "FirstDimaMessage";
            Thread clientThreadTwo = new Thread(new ThreadStart(clientTwo.OpenStream));
            clientThreadTwo.Start();

        }
    }
}