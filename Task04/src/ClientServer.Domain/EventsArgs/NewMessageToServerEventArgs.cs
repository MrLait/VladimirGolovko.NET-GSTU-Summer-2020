namespace ClientServer.Domain.EventsArgs
{
    /// <summary>
    /// Type contains additional information about the new message to server event.
    /// </summary>
    public class NewMessageToServerEventArgs : BaseNewMessageEventArgs
    {
        /// <summary>
        /// Client id property.
        /// </summary>
        public int ClientId { get; }

        /// <summary>
        /// Constructor for init property.
        /// </summary>
        /// <param name="clientId">Client id.</param>
        /// <param name="name">Client name.</param>
        /// <param name="message">Client message.</param>
        public NewMessageToServerEventArgs(int clientId, string name, string message) : base(name, message)
        {
            ClientId = clientId;
        }
    }
}
