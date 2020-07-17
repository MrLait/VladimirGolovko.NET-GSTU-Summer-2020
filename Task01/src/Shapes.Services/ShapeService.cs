using System;
using System.Collections.Generic;
using System.Linq;

namespace Shapes.Services
{
    /// <summary>
    /// Static class for searching in the array of all figures equal to this shape.
    /// </summary>
    /// <typeparam name="T">Object</typeparam>
    public static class ShapeService<T>
    {
        /// <summary>
        /// Static method for searching in the array of all figures equal to this shape.
        /// </summary>
        /// <param name="objects">Shapes array.</param>
        /// <param name="baseShape">A sample of the figure to be found.</param>
        /// <returns></returns>
        public static T[] FindEqualsObjectsByObject(IEnumerable<T> objects, T baseShape)
        {
            if (objects == null)
                throw new NullReferenceException("Null reference to the objects");
            if (baseShape == null)
                throw new NullReferenceException("Null reference to the baseShape");

            IEnumerable<T> foundEqualsObjects = objects.ToList().FindAll(x => x.Equals(baseShape));

            return foundEqualsObjects.ToArray();
        }
    }
}
