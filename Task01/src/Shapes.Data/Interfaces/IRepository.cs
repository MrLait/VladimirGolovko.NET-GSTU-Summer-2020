using System.Collections.Generic;

namespace Shapes.Data.Interfaces
{
    interface IRepository<T>
            where T : class
    {
        IEnumerable<T> GetShapeList(); // получение всех объектов
    }
}
