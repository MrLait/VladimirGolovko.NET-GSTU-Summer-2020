using DAO.DataAccess.Interfaces;
using SQLServer.Task6.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace DAO.DataAccess.Repositories.ADO.NetUsingReflection
{
    public class ADORepository<T> : ICRUD<T> where T : IEntity, new()
    {
        /// <summary>
        /// Connection string to database
        /// </summary>
        public string DbConString { get; private set; }

        /// <summary>
        /// Constructor <see cref="AbstractRepository{T}"/>
        /// </summary>
        /// <param name="dbConString"><see cref="DbConString"/></param>
        public ADORepository(string dbConString)
        {
            DbConString = dbConString;
        }

        public void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentException(typeof(T).Name + "object Should not be Null when Saving to database");

            var storedProcedure = "Add" + entity.GetType().Name;

            using (SqlConnection sqlConnection = new SqlConnection(DbConString))
            {
                SqlCommand sqlCommand = SqlCommandInstance(storedProcedure, sqlConnection); //using

                try
                {
                    sqlCommand.Parameters.AddRange(GetAddParameter(entity).ToArray());
                    sqlConnection.Open();
                    var test = sqlCommand.ExecuteScalar();
                }
                catch (SqlException sqlEx)
                {
                    throw new ArgumentException("Some Error occured at database, if error in stored procedure: " + storedProcedure, sqlEx);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
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


        /// <summary>
        /// Creating sqlCommand.
        /// </summary>
        /// <param name="storedProcedure">Name of stored procedure.</param>
        /// <param name="sqlConnection"> Sql connection sting</param>
        /// <returns>return sql command</returns>
        private SqlCommand SqlCommandInstance(string storedProcedure, SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand(storedProcedure, sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };
            return sqlCommand;
        }

        /// <summary>
        /// Creating sqlCommand.
        /// </summary>
        /// <param name="storedProcedure">Name of stored procedure.</param>
        /// <param name="sqlConnection"> Sql connection sting</param>
        /// <param name="sqlParamArr"> SqlParameters</param>
        /// <returns>return sql command</returns>
        private SqlCommand SqlCommandInstance(string storedProcedure, SqlConnection sqlConnection, SqlParameter[] sqlParamArr)
        {
            SqlCommand sqlCommand = SqlCommandInstance(storedProcedure, sqlConnection);
            sqlCommand.Parameters.AddRange(sqlParamArr);
            return sqlCommand;
        }

        /// <summary>
        /// Private method for get property from objects and add their to list for sqlParameters
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>returns list of sqlParameters.</returns>
        private List<SqlParameter> GetAddParameter(object obj)
        {
            PropertyInfo[] fields = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var sqlParams = new List<SqlParameter>();
            foreach (var f in fields)
            {
                if (f.GetCustomAttributes(false).Length != 0)
                {
                    if (f.GetCustomAttributesData()[0].AttributeType.Name != "KeyAttribute") //f.GetCustomAttributes(false).Length == 0 && 
                    {
                        sqlParams.Add(new SqlParameter(f.Name, f.GetValue(obj, null)));
                    }
                }
                else
                {
                    sqlParams.Add(new SqlParameter(f.Name, f.GetValue(obj, null)));
                }
            }
            return sqlParams;
        }

    }
}
