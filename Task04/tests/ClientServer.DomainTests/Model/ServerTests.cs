using ClientServer.Domain.Repositories;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace ClientServer.Domain.Model.Tests
{
    /// <summary>
    /// Server class tests.
    /// </summary>
    [TestFixture()]
    public class ServerTests
    {
        /// <summary>
        /// Test case with two clients connection on the server.
        /// </summary>
        /// <param name="serverName">Server name.</param>
        /// <param name="serverMessage">Server message.</param>
        /// <param name="clientOneId">Client one id.</param>
        /// <param name="clientOneName">Client one name.</param>
        /// <param name="clientOneMessage">Client one message.</param>
        /// <param name="clientTwoId">Client two id.</param>
        /// <param name="clientTwoName">Client two name.</param>
        /// <param name="clientTwoMessage">Client two message.</param>
        [TestCase(
            "BasaOne", "ServerMessage",  
            0, "Vova", "FirstVovaMessage",
            1, "Dima", "FirstDimaMessage")]
        public void GetServerMessageRepository_WhenTwoClientConnection(string serverName, string serverMessage, 
            int clientOneId, string clientOneName, string clientOneMessage,
            int clientTwoId, string clientTwoName, string clientTwoMessage)
        {
            //Arrange
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            List<string> expectedClientOneMessage = new List<string>() { $"Id: '{clientOneId}'; Client name: '{clientOneName}'; Message: '{clientOneMessage}'." };
            List<string> expectedClientTwoMessage = new List<string>() { $"Id: '{clientTwoId}'; Client name: '{clientTwoName}'; Message: '{clientTwoMessage}'." };

            List<ServerMessageRepository> expectedServerMessageRepositories = new List<ServerMessageRepository>()
            {
                new ServerMessageRepository() { Messages = expectedClientOneMessage },
                new ServerMessageRepository() { Messages = expectedClientTwoMessage }
            };

            //Act

                //Initial server
            Server server = new Server(serverName, IPAddress.Any, 8880) { Message = serverMessage };
            Thread thread = new Thread(new ThreadStart(server.Start));
            thread.Start();

            List<ServerMessageRepository> actualServerMessageRepository = server.ServerMessageRepositories;

            //Initial client one
            Client clientOne = new Client(clientOneName, ipAddress, 8880) { Message = clientOneMessage };
            Thread clientThreadOne = new Thread(new ThreadStart(clientOne.OpenStream));
            clientThreadOne.Start();

                //Initial client two
            Client clientTwo = new Client(clientTwoName, ipAddress, 8880) { Message = clientTwoMessage };
            Thread clientThreadTwo = new Thread(new ThreadStart(clientTwo.OpenStream));
            clientThreadTwo.Start();

            clientThreadOne.Join();
            clientThreadTwo.Join(100);

            //Assert
            Assert.AreEqual(expectedServerMessageRepositories, actualServerMessageRepository);
        }

        /// <summary>
        /// Test case with four clients connection on the server.
        /// </summary>
        /// <param name="serverName">Server name.</param>
        /// <param name="serverMessage">Server message.</param>
        /// <param name="clientOneId">Client one id.</param>
        /// <param name="clientOneName">Client one name.</param>
        /// <param name="clientOneMessage">Client one message.</param>
        /// <param name="clientTwoId">Client two id.</param>
        /// <param name="clientTwoName">Client two name.</param>
        /// <param name="clientTwoMessage">Client two message.</param>
        /// <param name="clientThreeId">Client three id.</param>
        /// <param name="clientThreeName">Client three name.</param>
        /// <param name="clientThreeMessage">Client three message.</param>
        /// <param name="clientFourId">Client four id.</param>
        /// <param name="clientFourName">Client four name.</param>
        /// <param name="clientFourMessage">Client four message.</param>
        [TestCase(
            "BasaOne", "ServerMessage",
            0, "Vova", "FirstVovaMessage",
            1, "Dima", "FirstDimaMessage",
            2, "VovaTwo", "FirstVovaMessage",
            3, "VovaThree", "FirstVovaMessage"
            )]
        public void GetServerMessageRepository_WhenFourClientConnection(
            string serverName, string serverMessage,
            int clientOneId, string clientOneName, string clientOneMessage,
            int clientTwoId, string clientTwoName, string clientTwoMessage,
            int clientThreeId, string clientThreeName, string clientThreeMessage,
            int clientFourId, string clientFourName, string clientFourMessage
            )
        {
            //Arrange
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            List<string> expectedClientOneMessage = new List<string>() { $"Id: '{clientOneId}'; Client name: '{clientOneName}'; Message: '{clientOneMessage}'." };
            List<string> expectedClientTwoMessage = new List<string>() { $"Id: '{clientTwoId}'; Client name: '{clientTwoName}'; Message: '{clientTwoMessage}'." };
            List<string> expectedClientThreeMessage = new List<string>() { $"Id: '{clientThreeId}'; Client name: '{clientThreeName}'; Message: '{clientThreeMessage}'." };
            List<string> expectedClientFourMessage = new List<string>() { $"Id: '{clientFourId}'; Client name: '{clientFourName}'; Message: '{clientFourMessage}'." };

            List<ServerMessageRepository> expectedServerMessageRepositories = new List<ServerMessageRepository>()
            {
                new ServerMessageRepository() { Messages = expectedClientOneMessage },
                new ServerMessageRepository() { Messages = expectedClientTwoMessage },
                new ServerMessageRepository() { Messages = expectedClientThreeMessage },
                new ServerMessageRepository() { Messages = expectedClientFourMessage }
            };

            //Act

            //Initial server
            Server server = new Server(serverName, IPAddress.Any, 8888) { Message = serverMessage };
            List<ServerMessageRepository> actualServerMessageRepository = server.ServerMessageRepositories;
            Thread thread = new Thread(new ThreadStart(server.Start));
            thread.Start();

            //Initial client one
            Client clientOne = new Client(clientOneName, ipAddress, 8888) { Message = clientOneMessage };
            Thread clientThreadOne = new Thread(new ThreadStart(clientOne.OpenStream));
            clientThreadOne.Start();
            clientThreadOne.Join(100);


            //Initial client two
            Client clientTwo = new Client(clientTwoName, ipAddress, 8888) { Message = clientTwoMessage };
            Thread clientThreadTwo = new Thread(new ThreadStart(clientTwo.OpenStream));
            clientThreadTwo.Start();
            clientThreadTwo.Join(100);


            //Initial client three
            Client clientThree = new Client(clientThreeName, ipAddress, 8888) { Message = clientThreeMessage };
            Thread clientThreadThree = new Thread(new ThreadStart(clientThree.OpenStream));
            clientThreadThree.Start();
            clientThreadThree.Join(100);

            //Initial client four
            Client clientFour = new Client(clientFourName, ipAddress, 8888) { Message = clientFourMessage };
            Thread clientThreadFour = new Thread(new ThreadStart(clientFour.OpenStream));
            clientThreadFour.Start();
            clientThreadFour.Join(100);

            //Assert
            Assert.AreEqual(expectedServerMessageRepositories, actualServerMessageRepository);
        }
    }
}