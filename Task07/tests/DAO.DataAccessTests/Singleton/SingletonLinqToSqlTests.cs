using NUnit.Framework;

namespace DAO.DataAccess.Singleton.Tests
{
    /// <summary>
    /// Test cases for Singleton linq to sql.
    /// </summary>
    [TestFixture()]
    public class SingletonLinqToSqlTests
    {
        /// <summary>
        /// Checkin to create instance.
        /// </summary>
        /// <param name="expectedIsInstanceCreate">Is instance created?</param>
        [TestCase(true)]
        public void GivenGetInstance_ThenOutIsNotNullInstance(bool expectedIsInstanceCreate)
        {
            //Arrange
            SingletonLinqToSql singleton = SingletonLinqToSql.GetInstance();
            var actualIsInstanceCreate = false;
            //Act
            if (singleton.LinqToSqlRepositoryFactory != null)
                actualIsInstanceCreate = true;
            //Assert
            Assert.AreEqual(expectedIsInstanceCreate, actualIsInstanceCreate);
        }
    }
}