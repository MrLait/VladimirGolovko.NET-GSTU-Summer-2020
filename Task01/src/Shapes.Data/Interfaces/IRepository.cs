using Shapes.Domain;

namespace Shapes.Data.Interfaces
{
    /// <summary>
    /// IRepository interface.
    /// </summary>
    interface IRepository
    {
        /// <summary>
        /// Get baseShape array with shapes.
        /// </summary>
        /// <returns>Returns baseShape array with shapes.</returns>
        BaseShape[] GetShapeArray();
    }
}
