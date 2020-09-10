using NUnit.Framework;

namespace DAO.DataAccess.Singleton.Tests
{
    /// <summary>
    /// Test cases for singleton dbo access class.
    /// </summary>
    [TestFixture()]
    public class SingletonDboAccessTests
    {
        /// <summary>
        /// Checkin to create instance.
        /// </summary>
        /// <param name="expectedIsInstanceCreate">Is instance created?</param>
        [TestCase(true)]
        public void GivenGetInstance_ThenOutIsNotNullInstance(bool expectedIsInstanceCreate)
        {
            //Arrange
            SingletonDboAccess singleton = SingletonDboAccess.GetInstance();
            var actualIsInstanceCreate = false;
            //Act
            if (singleton.ADORepositoryFactory != null)
                actualIsInstanceCreate = true;
            //Assert
            Assert.AreEqual(expectedIsInstanceCreate, actualIsInstanceCreate);
        }
    }
}