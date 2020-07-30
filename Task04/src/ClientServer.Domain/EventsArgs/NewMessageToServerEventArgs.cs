using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServer.Domain.EventsArgs
{
    public class NewMessageToServerEventArgs : BaseNewMessageEventArgs
    {
        public int ClientId { get;}

        public NewMessageToServerEventArgs(int clientId, string name, string message) : this(name, message)
        {
            ClientId = clientId;
        }

        private NewMessageToServerEventArgs(string name, string message) : base(name, message)
        {
        }
    }
}
