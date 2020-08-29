using NUnit.Framework;
using DAO.DataAccess.Factory;
using DAO.DataAccessTests;

namespace DAO.DataAccess.Singleton.Tests
{
    /// <summary>
    /// Test cases for singleton dbo access class.
    /// </summary>
    [TestFixture()]
    public class SingletonDboAccessTests : DatabaseConnectionBase
    {
        /// <summary>
        /// Checkin to create instance.
        /// </summary>
        /// <param name="expectedIsInstanceCreate">Is instance created?</param>
        [TestCase(true)]
        public void GivenGetInstance_ThenOutIsNotNullInstance(bool expectedIsInstanceCreate)
        {
            //Arrange
            SingletonDboAccess singleton = SingletonDboAccess.GetInstance(new ADORepositoryFactory(DbConnString));
            var actualIsInstanceCreate = false;
            //Act
            if (singleton.RepositoryFactory != null)
                actualIsInstanceCreate = true;
            //Assert
            Assert.AreEqual(expectedIsInstanceCreate, actualIsInstanceCreate);
        }
    }
}