namespace ClientServer.Domain.EventsArgs
{
    /// <summary>
    /// Type contains additional information about the new message to client event.
    /// </summary>
    public class NewMessagaToClientEventArgs : BaseNewMessageEventArgs
    {

        /// <summary>
        /// Constructor for init property.
        /// </summary>
        /// <param name="name">Server name.</param>
        /// <param name="message">Server message.</param>
        public NewMessagaToClientEventArgs(string name, string message) : base(name,message)
        {
        }
    }
}
