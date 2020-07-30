using NUnit.Framework;
using ClientServer.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using ClientServer.Domain.Repositories;
using System.Threading;

namespace ClientServer.Domain.Model.Tests
{
    [TestFixture()]
    public class ClientTests
    {
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