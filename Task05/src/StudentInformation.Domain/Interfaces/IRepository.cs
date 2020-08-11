using System;
using System.Collections.Generic;

namespace StudentInformation.Domain.Interfaces
{
    /// <summary>
    /// IRepository interface.
    /// </summary>
    /// <typeparam name="T">object</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Insert data.
        /// </summary>
        /// <param name="obj">Object.</param>
        void Insert(T obj);

        /// <summary>
        /// Get all data.
        /// </summary>
        /// <param name="orderBySelector">orderBySelector</param>
        /// <param name="descending">descending</param>
        /// <returns></returns>
        IEnumerable<T> GetAll(Func<T, string> orderBySelector, bool descending);
    }
}
