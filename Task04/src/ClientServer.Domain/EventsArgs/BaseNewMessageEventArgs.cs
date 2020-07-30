using System;

namespace ClientServer.Domain.EventsArgs
{
    public class BaseNewMessageEventArgs : EventArgs
    {
        public string Name { get; }
        public string Message { get; }

        public BaseNewMessageEventArgs()
        {
        }

        public BaseNewMessageEventArgs(string name, string message)
        {
            Name = name;
            Message = message;
        }
    }
}
