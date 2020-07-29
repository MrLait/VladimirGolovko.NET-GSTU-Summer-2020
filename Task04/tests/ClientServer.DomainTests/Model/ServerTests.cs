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

            Server server = new Server(IPAddress.Any, 8888);
            Thread thread = new Thread(new ThreadStart(server.Start));
            thread.Start();


            Client client = new Client("vova", ipAddress, 8888);
            Thread clientThreadOne = new Thread(new ThreadStart(client.OpenStream));
            clientThreadOne.Start();
            //client.OpenStream();
        }
    }
}