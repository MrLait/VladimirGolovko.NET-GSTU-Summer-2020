using System.Collections.Generic;

namespace Shape.Data.Interfaces
{
    interface IRepository<T>
            where T : class
    {
        IEnumerable<T> GetShapeList(); // получение всех объектов
    }
}
