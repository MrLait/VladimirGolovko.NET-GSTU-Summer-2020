using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformation.Domain.Interfaces
{
    public interface IRepository<T>
    {
        void Insert(T obj);
        IEnumerable<T> GetAll(Func<T, string> orderBySelector, bool descending);
    }
}
