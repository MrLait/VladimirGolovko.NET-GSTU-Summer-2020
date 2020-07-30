using ClientServer.Domain.Interfaces;
using ClientServer.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace ClientServer.Domain.Repositories
{
    public class ServerMessageRepository : IRepository<string>
    {
        public List<string> Messages { get; set; }

        public ServerMessageRepository() 
        {
            Messages = new List<string>();
        }

        public ServerMessageRepository(AcceptedTcpClient acceptedTcpClient): this()
        {
            acceptedTcpClient.NewMessage += (sender, e) => Messages.Add(
                $"Id: '{e.ClientId}'; " +
                $"Client name: '{e.Name}'; " +
                $"Message: '{e.Message}'.");
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            ServerMessageRepository r = (ServerMessageRepository)obj;
            return Messages.SequenceEqual(r.Messages);
        }

        /// <summary>
        /// Calculate hash code.
        /// </summary>
        /// <returns>The total hesh code.</returns>
        public override int GetHashCode()
        {
            return Messages.GetHashCode();
        }

    }
}
