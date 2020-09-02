using NUnit.Framework;
using SQLServer.Task7.Domain.Models;
using System.Linq;

namespace DAO.DataAccess.Singleton.Tests
{
    [TestFixture()]
    public class SingletonLinqToSqlTests
    {
        [Test()]
        public void GetInstanceTest()
        {
            // var groups = SingletonLinqToSql.GetInstance().LinqToSqlRepositoryFactory.CreateGroups().GetAll();
            //var groupsASC = SingletonLinqToSql.GetInstance().LinqToSqlRepositoryFactory.CreateGroups().GetAll().OrderBy(x => x.Name);


            var groupsDESC = SingletonLinqToSql.GetInstance().LinqToSqlRepositoryFactory.CreateGroups().GetAll().OrderByDescending(x => x.Id);
            var groupsWhereIdEqual2 = SingletonLinqToSql.GetInstance().LinqToSqlRepositoryFactory.CreateGroups().GetAll().Where(x => x.Id == 2);

        }
    }
}