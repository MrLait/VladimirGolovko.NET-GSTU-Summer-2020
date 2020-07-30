using ClientServer.Domain.Interfaces;
using ClientServer.Domain.Model;
using ClientServer.Domain.Util;
using System.Collections.Generic;
using System.Linq;

namespace ClientServer.Domain.Repositories
{
    public class ClientMessageRepository : IRepository<string>
    {
        public List<string> Messages { get; set; }

        public ClientMessageRepository()
        {
        }

        public ClientMessageRepository(Client client)
        {
            Messages = new List<string>();

            client.NewMessage += (sender, e) =>
                Messages.Add
                ( 
                    ($"Server name: '{e.Name}'; " + $"Message: '{e.Message}'.").MakeTransliterationFromRusIntoEnglish()
                );
        }

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
