using System;
using System.Collections.Generic;

namespace ClientServer.Domain.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Messages { get; set; }
    }
}
