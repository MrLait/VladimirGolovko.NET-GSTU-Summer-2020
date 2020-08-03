using System;

namespace ClientServer.Domain.EventsArgs
{
    /// <summary>
    /// Base type contains additional information about the new message.
    /// </summary>
    public abstract class BaseNewMessageEventArgs : EventArgs
    {
        /// <summary>
        /// Name property.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Message property.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Constructor for init property.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="message">Message.</param>
        public BaseNewMessageEventArgs(string name, string message)
        {
            Name = name;
            Message = message;
        }
    }
}
