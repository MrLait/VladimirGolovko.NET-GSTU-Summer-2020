using System.Collections.Generic;

namespace Shapes.Data.Interfaces
{
    /// <summary>
    /// IRepositoryinterface.
    /// </summary>
    /// <typeparam name="T">Object type</typeparam>
    interface IRepository<T>
            where T : class
    {
        /// <summary>
        /// Get IEnumerable list with shapes.
        /// </summary>
        /// <returns>Returns IEnumerable list with shapes.</returns>
        IEnumerable<T> GetShapeList();
    }
}
