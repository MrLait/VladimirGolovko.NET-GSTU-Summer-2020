using DAO.DataAccess.Interfaces;
using DAO.DataAccess.Repositories.Exstension;
using SQLServer.Task6.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace DAO.DataAccess.Repositories.ADO.NetUsingReflection
{
    /// <summary>
    /// Abstract repository with implemented CRUD methods.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ADORepository<T> : ICRUD<T> where T : IEntity, new()
    {
        /// <summary>
        /// Connection string to database
        /// </summary>
        protected string DbConString { get; private set; }

        /// <summary>
        /// Constructor <see cref="ADORepository{T}"/>
        /// </summary>
        /// <param name="dbConString"><see cref="DbConString"/></param>
        public ADORepository(string dbConString)
        {
            DbConString = dbConString;
        }

        /// <summary>
        /// Implementation Add <see cref="ICRUD{T}.Add(T)"/>
        /// </summary>
        /// <param name="entity">Models.</param>
        public void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(typeof(T).Name + "object Should not be Null when Saving to database");

            var storedProcedure = "Add" + entity.GetType().Name;

            using (SqlConnection sqlConnection = new SqlConnection(DbConString))
            {
                using (SqlCommand sqlCommand = SqlCommandInstance(storedProcedure, sqlConnection))
                {
                    try
                    {
                        sqlCommand.Parameters.AddRange(GetAddParameter(entity).ToArray());
                        sqlConnection.Open();
                        sqlCommand.ExecuteScalar();
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
        }

        /// <summary>
        /// Implementation Delete <see cref="ICRUD{T}.Delete(int)"/>
        /// </summary>
        /// <param name="byId">Id.</param>
        public void Delete(int byId)
        {
            if (byId == 0)
                throw new ArgumentNullException("byId should not be 0");

            string tableName = new T().GetType().Name;
            string storedProcedure = "Delete" + tableName + "ById";

            using (SqlConnection sqlConnection = new SqlConnection(DbConString))
            {
                using (SqlCommand sqlCommand = SqlCommandInstance(storedProcedure, sqlConnection, new SqlParameter[] { new SqlParameter("Id", byId) }))
                {
                    try
                    {
                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (SqlException sqlEx)
                    {
                        throw new ArgumentException("Some Error occured at database, if error in stored procedure: " + storedProcedure, sqlEx);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// Implementation GetAll <see cref="ICRUD{T}.GetAll"/>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            string tableName = new T().GetType().Name;
            string storedProcedure = "GetAll" + tableName;

            using (SqlConnection sqlConnection = new SqlConnection(DbConString))
            {
                using (SqlCommand sqlCommand = SqlCommandInstance(storedProcedure, sqlConnection))
                {
                    SqlDataAdapter adpt = new SqlDataAdapter(sqlCommand);

                    try
                    {
                        DataSet ds = new DataSet();
                        adpt.Fill(ds);
                        return ds.Tables[0].ToEnumerable<T>();
                    }
                    catch (SqlException sqlEx)
                    {
                        throw new ArgumentException("Some Error occured at database, if error in stored procedure. See inner exception for more detail exception." + storedProcedure, sqlEx);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Get object by ID from table in database.
        /// </summary>
        /// <param name="byId">Id.</param>
        /// <returns>Returns object.</returns>
        public T GetByID(int byId)
        {
            if (byId == 0)
                throw new ArgumentNullException("byId should not be 0");

            string tableName = new T().GetType().Name;
            string storedProcedure = "Get" + tableName + "ById";

            using (SqlConnection sqlConnection = new SqlConnection(DbConString))
            {
                using (SqlCommand sqlCommand = SqlCommandInstance(storedProcedure, sqlConnection, new SqlParameter[] { new SqlParameter("Id", byId) }))
                {
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                    try
                    {
                        DataSet ds = new DataSet();
                        sqlDataAdapter.Fill(ds);
                        return ds.Tables[0].ToEnumerable<T>().ToList().SingleOrDefault();
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
        }

        /// <summary>
        /// Implementation Update <see cref="ICRUD{T}.Update(T)"/>
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Returns updated elements.</returns>
        public T Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            string tableName = new T().GetType().Name;
            string storedProcedure = "Update" + tableName;

            using (SqlConnection sqlConnection = new SqlConnection(DbConString))
            {
                using (SqlCommand sqlCommand = SqlCommandInstance(storedProcedure, sqlConnection))
                {
                    sqlCommand.Parameters.AddRange(GetUpdateParameter(entity).ToArray());

                    SqlDataAdapter adpt = new SqlDataAdapter(sqlCommand);
                    DataSet ds = new DataSet();

                    try
                    {
                        adpt.Fill(ds);
                        return ds.Tables[0].ToEnumerable<T>().ToList().SingleOrDefault();
                    }
                    catch (SqlException sqlEx)
                    {
                        throw new ArgumentException("Class Name and Table name must be same for this method. See inner exception", sqlEx);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
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
        /// Private method for get property from objects and add their to list for sqlParameters
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>returns list of sqlParameters.</returns>
        private List<SqlParameter> GetUpdateParameter(object obj)
        {
            PropertyInfo[] fields = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var sqlParams = new List<SqlParameter>();
            foreach (var f in fields)
            {
                sqlParams.Add(new SqlParameter(f.Name, f.GetValue(obj, null)));
            }
            return sqlParams;
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
                        sqlParams.Add(new SqlParameter(f.Name, f.GetValue(obj, null)));
                }
                else
                    sqlParams.Add(new SqlParameter(f.Name, f.GetValue(obj, null)));
            }
            return sqlParams;
        }
    }
}
