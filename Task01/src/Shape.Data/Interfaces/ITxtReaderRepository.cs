using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape.Data.Interfaces
{
    public interface ITxtFileReader<T>
    {
        T GetAllText();
        T[] GetAllRow();
    }
}
