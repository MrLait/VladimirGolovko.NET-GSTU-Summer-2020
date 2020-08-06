using BinaryTree.Domain.Model;
using StudentInformation.Domain.Interfaces;
using StudentInformation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentInformation.Domain.Repository
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : Entity, new()
    {
        public BinaryTree<T> BinaryTree { get; set; }

        public AbstractRepository()
        {
            BinaryTree = new BinaryTree<T>(); ;
        }

        public void Insert(T obj)
        {
            if (obj != null)
                BinaryTree.Insert(obj);
        }

        public IEnumerable<T> GetAll(Func<T, string> orderBySelector, bool descending)
        {
            if (descending)
                return BinaryTree.InOrder().OrderByDescending(orderBySelector);
            else
                return BinaryTree.InOrder().OrderBy(orderBySelector);
        }
    }
}
