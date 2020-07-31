using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using ClientServer.Domain.Model;
using System.Threading;

namespace ClientServer.Domain.Repositories.Tests
{
    /// <summary>
    /// ClientMessageRepository class tests.
    /// </summary>
    [TestFixture()]
    public class ClientMessageRepositoryTests
    {

        /// <summary>
        /// Test case ClientMessageRepository with a client connection on the server.
        /// </summary>
        /// <param name="serverName">Server name.</param>
        /// <param name="serverMessage">Server message.</param>
        /// <param name="clientOneId">Client one id.</param>
        /// <param name="clientOneName">Client one name.</param>
        /// <param name="clientOneMessage">Client one message.</param>
        [TestCase(
        "BasaOne", "ServerMessage",
        0, "Vova", "FirstVovaMessage")]
            public void GetClientMessageRepository_WhenOneClientConnection(string serverName, string serverMessage,
        int clientOneId, string clientOneName, string clientOneMessage)
        {
            //Arrange
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            ClientMessageRepository expectedClientMessageRepository = new ClientMessageRepository() 
            {
                    Messages = new List<string>() 
                    { 
                        $"Server name: '{serverName}'; " +
                        $"Message: 'Soobshchenie polucheno ot servera: '{serverName}'; " +
                        $"Poluchatel': '{clientOneName}', '{clientOneId}'; " +
                        $"Soobshchenie servera: '{serverMessage}'; " +
                        $"Poluchennoe soobshchenie klienta: '{clientOneMessage}'.'."
                    }
            };

            //Act
            //Initial server
            Server server = new Server(serverName, IPAddress.Any, 7813) { Message = serverMessage };
            Thread thread = new Thread(new ThreadStart(server.Start));
            thread.Start();

            //Initial client one
            Client clientOne = new Client(clientOneName, ipAddress, 7813) { Message = clientOneMessage };
            ClientMessageRepository actualClientMessageRepository = new ClientMessageRepository(clientOne);
            Thread threadClientOne = new Thread(new ThreadStart(clientOne.OpenStream));
            threadClientOne.Start();
            threadClientOne.Join(200);
            //Assert
            Assert.AreEqual(expectedClientMessageRepository, actualClientMessageRepository);
        }
    }
}