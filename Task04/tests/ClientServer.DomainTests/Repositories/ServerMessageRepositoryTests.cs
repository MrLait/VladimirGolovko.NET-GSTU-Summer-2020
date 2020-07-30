using NUnit.Framework;
using ClientServer.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using ClientServer.Domain.Model;
using System.Threading;

namespace ClientServer.Domain.Repositories.Tests
{
    [TestFixture()]
    public class ServerMessageRepositoryTests
    {
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

            //Initial client one
            Client clientOne = new Client(clientOneName, ipAddress, 8801) { Message = clientOneMessage };
            Thread clientThreadOne = new Thread(new ThreadStart(clientOne.OpenStream));
            clientThreadOne.Start();

            List<ServerMessageRepository> ServerMessageRepositoryOne = server.ServerMessageRepositories;

            //Assert
            clientThreadOne.Join();

            Assert.AreEqual(ServerMessageRepositoryOne, expectedServerMessageRepositories);
        }
    }
}