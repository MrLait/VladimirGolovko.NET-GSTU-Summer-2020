using System.Collections.Generic;

namespace ClientServer.Domain.Interfaces
{
    /// <summary>
    /// Interface repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// List with messages.
        /// </summary>
        List<T> Messages { get; set; }
    }
}
