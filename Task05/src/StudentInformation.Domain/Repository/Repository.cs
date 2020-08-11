using BinaryTree.Domain.Model;
using StudentInformation.Domain.Interfaces;
using StudentInformation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentInformation.Domain.Repository
{
    /// <summary>
    /// Repository class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class Repository<T> : IRepository<T> where T : Entity
    {
        /// <summary>
        /// Property BinaryTree.
        /// </summary>
        public BinaryTree<T> BinaryTree { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Repository() =>  BinaryTree = new BinaryTree<T>();

        /// <summary>
        /// Insert data.
        /// </summary>
        /// <param name="obj">Oobject.</param>
        public void Insert(T obj)
        {
            if (obj != null)
                BinaryTree.Insert(obj);
        }

        /// <summary>
        /// Get all ddata.
        /// </summary>
        /// <param name="orderBySelector">orderBySelector</param>
        /// <param name="descending">descending</param>
        /// <returns>Returns Enumerable</returns>
        public IEnumerable<T> GetAll(Func<T, string> orderBySelector, bool descending)
        {
            if (descending)
                return BinaryTree.InOrder().OrderByDescending(orderBySelector);
            else
                return BinaryTree.InOrder().OrderBy(orderBySelector);
        }

        /// <summary>
        /// Comparing one StudentTestResultRepository with another.
        /// </summary>
        /// <param name="obj">The compared StudentTestResultRepository.</param>
        /// <returns>True if equal. False if not equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Repository<T> repository = (Repository<T>)obj;
            return BinaryTree.Equals(repository.BinaryTree);
        }

        /// <summary>
        /// Calculate hash code.
        /// </summary>
        /// <returns>The total hash code.</returns>
        public override int GetHashCode() => BinaryTree.GetHashCode();
    }
}
