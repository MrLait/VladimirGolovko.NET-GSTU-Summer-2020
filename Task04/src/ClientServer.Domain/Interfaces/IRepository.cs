using System;
using System.Collections.Generic;

namespace ClientServer.Domain.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> Messages { get; private set; }
    }
}
