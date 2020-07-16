using Shapes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shapes.Services
{
    public static class ShapeService<T>
    {
        public static IEnumerable<T> FindEqualsObjectsByObject(IEnumerable<T> objects, T baseShape)
        {
            if (objects == null)
                throw new NullReferenceException("Null reference to the objects");
            if (baseShape == null)
                throw new NullReferenceException("Null reference to the baseShape");

            IEnumerable<T> foundEqualsObjects = objects.ToList().FindAll(x => x.Equals(baseShape));

            return foundEqualsObjects; 
        }
    }
}
