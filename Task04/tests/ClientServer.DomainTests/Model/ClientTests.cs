using NUnit.Framework;
using System.Net;
using System.Threading;

namespace ClientServer.Domain.Model.Tests
{
    /// <summary>
    /// Server class tests.
    /// </summary>
    [TestFixture()]
    public class ClientTests
    {
        /// <summary>
        /// Test case with a client connection on the server.
        /// </summary>
        /// <param name="serverName">Server name.</param>
        /// <param name="serverMessage">Server message.</param>
        /// <param name="clientOneName">Client one name.</param>
        /// <param name="clientOneMessage">Client one message.</param>
        [TestCase("BasaOne", "ServerMessage","Vova", "FirstVovaMessage")]
        public void GivenOpenStreamWhenServerIsStartedTheOutIsConnectedTrue(string serverName, string serverMessage,
        string clientOneName, string clientOneMessage)
        {
            //Arrange
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            //Act
            //Initial server
            Server server = new Server(serverName, IPAddress.Any, 8870) { Message = serverMessage };
            Thread thread = new Thread(new ThreadStart(server.Start));
            thread.Start();

            //Initial client one
            Client clientOne = new Client(clientOneName, ipAddress, 8870) { Message = clientOneMessage };
            Thread clientThreadOne = new Thread(new ThreadStart(clientOne.OpenStream));
            clientThreadOne.Start();

            //Assert

            Assert.AreEqual(true, clientOne.TcpClient.Connected);
        }

        /// <summary>
        /// Test case with a client connection on the server OutIsSocketException.
        /// </summary>
        /// <param name="serverName">Server name.</param>
        /// <param name="serverMessage">Server message.</param>
        /// <param name="clientOneName">Client one name.</param>
        /// <param name="clientOneMessage">Client one message.</param>
        [TestCase("BasaOne", "ServerMessage","Vova", "FirstVovaMessage")]
        public void GivenOpenStreamWhenServerIsStarted_ThenOutIsSocketException(string serverName, string serverMessage,
        string clientOneName, string clientOneMessage)
        {
            //Arrange
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            //Act
            //Initial server
            Server server = new Server(serverName, IPAddress.Any, 8870) { Message = serverMessage };
            Thread thread = new Thread(new ThreadStart(server.Start));
            thread.Start();

            //Assert
            Assert.That(() => new Client(clientOneName, ipAddress, 8871) { Message = clientOneMessage }, Throws.TypeOf<System.Net.Sockets.SocketException>());
        }
    }
}