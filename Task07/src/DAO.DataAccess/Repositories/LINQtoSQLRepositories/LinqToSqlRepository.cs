using DAO.DataAccess.Interfaces;
using SQLServer.Task7.Domain.Interfaces;
using System;
using System.Data.Linq;
using System.Linq;
using System.Reflection;

namespace DAO.DataAccess.Repositories.LINQtoSQLRepositories
{
    /// <summary>
    /// Abstract repository with implemented CRUD methods.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinqToSqlRepository<T> : ICRUD<T> where T : class, IEntity, new()
    {
        /// <summary>
        /// Connection string to database
        /// </summary>
        protected DataContext DataContext { get; private set; }

        /// <summary>
        /// Initialize DataContext.
        /// </summary>
        /// <param name="dbConString">Connection string.</param>
        public LinqToSqlRepository(string dbConString)
        {
            DataContext = new DataContext(dbConString)
            {
                DeferredLoadingEnabled = false
            };
        }

        /// <inheritdoc/>
        public void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(typeof(T).Name + "object Should not be Null when Saving to database");

            DataContext.GetTable<T>().InsertOnSubmit(entity);
            DataContext.SubmitChanges();

        }

        /// <summary>
        /// Implementation Delete <see cref="ICRUD{T}.Delete(int)"/>
        /// </summary>
        /// <param name="byId">Id.</param>
        public void Delete(int byId)
        {
            if (byId == 0) throw new ArgumentNullException("byId should not be 0");

            DataContext.GetTable<T>().DeleteOnSubmit(DataContext.GetTable<T>().Where(x => x.Id.Equals(byId)).SingleOrDefault());
            DataContext.SubmitChanges();

        }

        /// <summary>
        /// Implementation GetAll <see cref="ICRUD{T}.GetAll"/>
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return DataContext.GetTable<T>();
        }

        /// <summary>
        /// Get object by ID from table in database.
        /// </summary>
        /// <param name="byId">Id.</param>
        /// <returns>Returns object.</returns>
        public T GetByID(int byId)
        {
            if (byId == 0) throw new ArgumentNullException("byId should not be 0");

            return DataContext.GetTable<T>().Where(x => x.Id.Equals(byId)).SingleOrDefault();
        }

        /// <summary>
        /// Implementation Update <see cref="ICRUD{T}.Update(T)"/>
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Returns updated elements.</returns>
        public T Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException();

            var tableElement = DataContext.GetTable<T>().Where(x => x.Id.Equals(entity.Id)).SingleOrDefault();
            var updatedTableElement = GetUpdateParameter(entity, tableElement);
            DataContext.SubmitChanges();
            return updatedTableElement;
        }

        /// <summary>
        /// Updata fields from one object to other.
        /// </summary>
        /// <param name="from">Main object.</param>
        /// <param name="to">Target object.</param>
        /// <returns>Returns updated object.</returns>
        private T GetUpdateParameter(T from, T to)
        {
            if (from == null) throw new ArgumentNullException();
            if (to == null) throw new ArgumentNullException();

            PropertyInfo[] fieldsTo = to.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo[] fieldsFrom = from.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var fTo in fieldsTo)
            {
                foreach (var fFrom in fieldsFrom)
                {
                    if (fTo.Name == fFrom.Name)
                    {
                        fTo.SetValue(to, fFrom.GetValue(from));
                        break;
                    }
                }
            }
            return to;
        }
    }
}
