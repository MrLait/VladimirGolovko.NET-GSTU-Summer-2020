using DAO.DataAccess.Interfaces;
using SQLServer.Task6.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace DAO.DataAccess.Repositories.ADO.NetUsingReflection
{
    public class ADORepository<T> : ICRUD<T> where T : IEntity, new()
    {
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int byID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetByID(int byID)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
