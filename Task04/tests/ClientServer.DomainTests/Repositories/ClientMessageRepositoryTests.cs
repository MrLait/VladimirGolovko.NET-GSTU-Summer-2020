using NUnit.Framework;
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
    public class ClientMessageRepositoryTests
    {

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
                        $"Poluchennoe soobshchenie klienta: '{clientOneMessage}''."
                    }
            };

            //Act
            //Initial server
            Server server = new Server(serverName, IPAddress.Any, 7813) { Message = serverMessage };
            Thread thread = new Thread(new ThreadStart(server.Start));
            thread.Start();

            //Initial client one
            Client clientOne = new Client(clientOneName, ipAddress, 7813) { Message = clientOneMessage };
            Thread clientThreadOne = new Thread(new ThreadStart(clientOne.OpenStream));
            clientThreadOne.Start();

            ClientMessageRepository actualClientMessageRepository = new ClientMessageRepository(clientOne);

            //Assert
            clientThreadOne.Join();
            Assert.AreEqual(expectedClientMessageRepository, actualClientMessageRepository);
        }

    }
}