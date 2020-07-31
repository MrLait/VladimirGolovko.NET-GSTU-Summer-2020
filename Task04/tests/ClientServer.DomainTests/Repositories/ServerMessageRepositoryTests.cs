using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using ClientServer.Domain.Model;
using System.Threading;

namespace ClientServer.Domain.Repositories.Tests
{
    /// <summary>
    /// ServerMessageRepository class tests.
    /// </summary>
    [TestFixture()]
    public class ServerMessageRepositoryTests
    {
        /// <summary>
        /// Test case ServerMessageRepository with a client connection on the server.
        /// </summary>
        /// <param name="serverName">Server name.</param>
        /// <param name="serverMessage">Server message.</param>
        /// <param name="clientOneId">Client one id.</param>
        /// <param name="clientOneName">Client one name.</param>
        /// <param name="clientOneMessage">Client one message.</param>
        [TestCase(
            "BasaOne", "ServerMessage",
            0, "Vova", "FirstVovaMessage")]
        public void GetServerMessageRepository_WhenOneClientConnection(string serverName, string serverMessage,
            int clientOneId, string clientOneName, string clientOneMessage)
        {
            //Arrange
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            List<ServerMessageRepository> expectedServerMessageRepositories = new List<ServerMessageRepository>()
            {
                new ServerMessageRepository() 
                { 
                    Messages = new List<string>() { $"Id: '{clientOneId}'; Client name: '{clientOneName}'; Message: '{clientOneMessage}'."} 
                }
            };

            //Act
            //Initial server
            Server server = new Server(serverName, IPAddress.Any, 8801) { Message = serverMessage };
            Thread thread = new Thread(new ThreadStart(server.Start));
            thread.Start();

            List<ServerMessageRepository> actualServerMessageRepositoryOne = server.ServerMessageRepositories;

            //Initial client one
            Client clientOne = new Client(clientOneName, ipAddress, 8801) { Message = clientOneMessage };
            Thread clientThreadOne = new Thread(new ThreadStart(clientOne.OpenStream));
            clientThreadOne.Start();
            clientThreadOne.Join(100);

            //Assert
            Assert.AreEqual(expectedServerMessageRepositories, actualServerMessageRepositoryOne);
        }
    }
}