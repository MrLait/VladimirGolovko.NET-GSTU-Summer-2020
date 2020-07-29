using NUnit.Framework;
using System.Net;
using System.Threading;

namespace ClientServer.Domain.Model.Tests
{
    [TestFixture()]
    public class ServerTests
    {
        [TestCase()]
        public void AcceptedTcpClientTest()
        {
            Server server = new Server(IPAddress.Any, 8888);
            Thread thread = new Thread(new ThreadStart(server.Start));
            thread.Start();


        }
    }
}