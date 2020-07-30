using ClientServer.Domain.Repositories;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;

namespace ClientServer.Domain.Model.Tests
{
    [TestFixture()]
    public class ServerTests
    {
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

                //Initial client one
            Client clientOne = new Client(clientOneName, ipAddress, 8880) { Message = clientOneMessage };
            Thread clientThreadOne = new Thread(new ThreadStart(clientOne.OpenStream));
            clientThreadOne.Start();

                //Initial client two
            Client clientTwo = new Client(clientTwoName, ipAddress, 8880) { Message = clientTwoMessage };
            Thread clientThreadTwo = new Thread(new ThreadStart(clientTwo.OpenStream));
            clientThreadTwo.Start();

            List<ServerMessageRepository> ServerMessageRepositoryOne = server.ServerMessageRepositories;

            //Assert
            clientThreadOne.Join();
            clientThreadTwo.Join();

            Assert.AreEqual(ServerMessageRepositoryOne, expectedServerMessageRepositories);
        }

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
            Thread thread = new Thread(new ThreadStart(server.Start));
            thread.Start();

            //Initial client one
            Client clientOne = new Client(clientOneName, ipAddress, 8888) { Message = clientOneMessage };
            Thread clientThreadOne = new Thread(new ThreadStart(clientOne.OpenStream));
            clientThreadOne.Start();

            //Initial client two
            Client clientTwo = new Client(clientTwoName, ipAddress, 8888) { Message = clientTwoMessage };
            Thread clientThreadTwo = new Thread(new ThreadStart(clientTwo.OpenStream));
            clientThreadTwo.Start();

            //Initial client three
            Client clientThree = new Client(clientThreeName, ipAddress, 8888) { Message = clientThreeMessage };
            Thread clientThreadThree = new Thread(new ThreadStart(clientThree.OpenStream));
            clientThreadThree.Start();

            //Initial client four
            Client clientFour = new Client(clientFourName, ipAddress, 8888) { Message = clientFourMessage };
            Thread clientThreadFour = new Thread(new ThreadStart(clientFour.OpenStream));
            clientThreadFour.Start();

            List<ServerMessageRepository> ServerMessageRepositoryOne = server.ServerMessageRepositories;

            //Assert
            clientThreadOne.Join();
            clientThreadTwo.Join();
            clientThreadThree.Join();
            clientThreadFour.Join();

            Assert.AreEqual(ServerMessageRepositoryOne, expectedServerMessageRepositories);
        }
    }
}