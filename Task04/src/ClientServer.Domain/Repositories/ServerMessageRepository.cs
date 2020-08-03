using ClientServer.Domain.Interfaces;
using ClientServer.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace ClientServer.Domain.Repositories
{
    /// <summary>
    /// Server message repository class which is subscribed to the event of a message arriving at the server.
    /// </summary>
    public class ServerMessageRepository : IRepository<string>
    {
        /// <summary>
        /// Property with arrived messages.
        /// </summary>
        public List<string> Messages { get; set; }

        /// <summary>
        /// Constructor for initialize property messages.
        /// </summary>
        public ServerMessageRepository() 
        {
            Messages = new List<string>();
        }

        /// <summary>
        /// Constructor with anonymous event handler.
        /// </summary>
        /// <param name="acceptedTcpClient">Accepted tcp client.</param>
        public ServerMessageRepository(AcceptedTcpClient acceptedTcpClient): this()
        {
            acceptedTcpClient.NewMessage += (sender, e) => Messages.Add(
                $"Id: '{e.ClientId}'; " +
                $"Client name: '{e.Name}'; " +
                $"Message: '{e.Message}'.");
        }

        /// <summary>
        /// Comparing one message with another.
        /// </summary>
        /// <param name="obj">The compared rectangle.</param>
        /// <returns>True if equal. False if not equal.</returns>
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
