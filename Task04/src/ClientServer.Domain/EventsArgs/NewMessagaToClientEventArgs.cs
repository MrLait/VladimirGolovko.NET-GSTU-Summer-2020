using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServer.Domain.EventsArgs
{
    public class NewMessagaToClientEventArgs : BaseNewMessageEventArgs
    {
        public NewMessagaToClientEventArgs(string name, string message) : base(name,message)
        {
        }
    }
}
