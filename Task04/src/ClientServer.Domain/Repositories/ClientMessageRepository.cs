using ClientServer.Domain.Interfaces;
using ClientServer.Domain.Model;
using ClientServer.Domain.Util;
using System.Collections.Generic;
using System.Linq;

namespace ClientServer.Domain.Repositories
{
    /// <summary>
    /// Client message repository class which is subscribed to the event of a message arriving at the client.
    /// </summary>
    public class ClientMessageRepository : IRepository<string>
    {
        /// <summary>
        /// Property with arrived messages.
        /// </summary>
        public List<string> Messages { get; set; }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public ClientMessageRepository(){}

        /// <summary>
        /// Constructor with anonymous event handler.
        /// </summary>
        /// <param name="client">Client.</param>
        public ClientMessageRepository(Client client)
        {
            Messages = new List<string>();

            client.NewMessage += (sender, e) =>
                Messages.Add
                ( 
                    ($"Server name: '{e.Name}'; " + $"Message: '{e.Message}'.").MakeTransliterationFromRusIntoEnglish()
                );
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
            ClientMessageRepository r = (ClientMessageRepository)obj;
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
