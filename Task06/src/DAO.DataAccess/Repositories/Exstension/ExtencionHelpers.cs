using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace DAO.DataAccess.Repositories.Exstension
{
    /// <summary>
    /// Extension helpers for convert to list
    /// </summary>
    public static class ExtensionHelpers
    {
        /// <summary>
        /// Method to convert table to IEnumerable<T>
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="table">input table</param>
        /// <returns>Returns IEnumerable<T> of table</returns>
        public static IEnumerable<T> ToEnumerable<T>(this DataTable table) where T : new()
        {
            List<T> list = new List<T>();

            foreach (var row in table.AsEnumerable())
            {
                T obj = new T();

                foreach (var prop in obj.GetType().GetProperties())
                {
                    try
                    {
                        PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                        propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                    }
                    catch
                    {
                        continue;
                    }
                }
                list.Add(obj);
            }
            return list;
        }
    }
}
