using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderIntoArray
{
    public interface IReaderRepository<T>
    {
        T GetAll();
    }
}
