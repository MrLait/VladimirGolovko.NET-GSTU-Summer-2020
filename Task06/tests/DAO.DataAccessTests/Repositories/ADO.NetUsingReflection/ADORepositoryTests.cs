using NUnit.Framework;
using DAO.DataAccessTests;
using SQLServer.Task6.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DAO.DataAccess.Repositories.ADO.NetUsingReflection.Tests
{
    /// <summary>
    /// Test cases for CRUD method.
    /// </summary>
    [TestFixture()]
    public class ADORepositoryTests : DatabaseConnectionBase
    {
        /// <summary>
        /// Field with group repository.
        /// </summary>
        private ADORepository<Groups> repository;

        /// <summary>
        /// Field with groups.
        /// </summary>
        private IEnumerable<Groups> groups;

        /// <summary>
        /// Initialize repository.
        /// </summary>
        [SetUp]
        public void Init()
        {
            repository = new ADORepository<Groups>(DbConnString);
            groups = repository.GetAll();
        }

        /// <summary>
        /// Test cases for Add.
        /// </summary>
        /// <param name="actualName">Name parameter.</param>
        [TestCase("NameGroup")]
        [TestCase("NameGroupTest")]
        [TestCase("NameGroupTest2")]
        [TestCase("NameGroupTest3")]
        public void GivenAdd_ThenOutIsActualName(string actualName)
        {
            //Arrage
            Groups actual = new Groups(){ Name = actualName};
            //Act
            repository.Add(actual);
            var lastAddedName = repository.GetAll().ToList().Last().Name;
            var lastAddedId = repository.GetAll().ToList().Last().Id;
            repository.Delete(lastAddedId);
            //Assert
            Assert.AreEqual(lastAddedName, actualName);
        }

        /// <summary>
        /// Test cases for GetAll method.
        /// </summary>
        /// <param name="actualName"> Name parameter.</param>
        [TestCase("NameGroup")]
        [TestCase("NameGroupTest")]
        [TestCase("NameGroupTest2")]
        [TestCase("NameGroupTest3")]
        public void GivenGetAll_WhenAddedGroups_ThenOutGetThisGroups(string actualName)
        {
            //Arrage
            Groups actual = new Groups() { Name = actualName };
            List<Groups> allGroups = groups.ToList();
            //Act
            repository.Add(actual);
            allGroups.Add(actual);

            var actualSelectRepositoryName = repository.GetAll().Select(x => x.Name);
            var expectedSelectAllGroups = allGroups.ToList().Select(x => x.Name);
            
            var lastAddedName = repository.GetAll().ToList().Last().Name;
            var lastAddedId = repository.GetAll().ToList().Last().Id;
            repository.Delete(lastAddedId); //clear last addded element
            //Assert
            Assert.AreEqual(expectedSelectAllGroups, actualSelectRepositoryName);
        }

        /// <summary>
        /// Test cases for GetById method.
        /// </summary>
        /// <param name="expectedName"> Expected name.</param>
        [TestCase("NameGroup")]
        [TestCase("NameGroupTest")]
        [TestCase("NameGroupTest2")]
        [TestCase("NameGroupTest3")]
        public void GivenGetByID_WhenAdded_ThenOutGetThisGroupsById(string expectedName)
        {
            //Arrage
            Groups actual = new Groups() { Name = expectedName };
            //Act
            repository.Add(actual);
            var lastAddedId = repository.GetAll().ToList().Last().Id;
            var actualNameById = repository.GetByID(lastAddedId).Name;
            repository.Delete(lastAddedId); //clear last addded element
            //Assert
            Assert.AreEqual(expectedName, actualNameById);
        }

        /// <summary>
        /// Test cases Update method.
        /// </summary>
        /// <param name="name">Name parameter.</param>
        /// <param name="actualUpdateName">Actual update name.</param>
        [TestCase("NameGroup", "VaseOne")]
        [TestCase("NameGroupTest", "VaseTwo")]
        [TestCase("NameGroupTest2", "VaseThree")]
        [TestCase("NameGroupTest3", "VaseFour")]
        public void GivenUpdate_WhenAdded_ThenOutUpdateThisGroups(string name, string actualUpdateName)
        {
            //Arrage
            Groups actual = new Groups() { Name = name };
            //Act
            repository.Add(actual);
            var lastAddedId = repository.GetAll().ToList().Last().Id;
            repository.Update(new Groups() { Id = lastAddedId, Name = actualUpdateName });
            var expectedUpdetedName = repository.GetByID(lastAddedId);
            repository.Delete(lastAddedId); //clear last addded element
            //Assert
            Assert.AreEqual(expectedUpdetedName.Name, actualUpdateName);
        }

        /// <summary>
        /// Test cases for Delete method.
        /// </summary>
        /// <param name="name">Name.</param>
        [TestCase("NameGroup")]
        [TestCase("NameGroupTest")]
        [TestCase("NameGroupTest2")]
        [TestCase("NameGroupTest3")]
        public void GivenDelete_WhenAddedOneGroups_ThenOutIsDelete(string name)
        {
            //Arrage
            Groups actual = new Groups() { Name = name };
            //Act
            repository.Add(actual);
            var lastAddedId = repository.GetAll().ToList().Last().Id;
            var countElement = repository.GetAll().Count();
            repository.Delete(lastAddedId);
            var countElementAfterDelete = repository.GetAll().Count();
            //Assert
            Assert.AreNotEqual(countElement, countElementAfterDelete);
        }

        /// <summary>
        /// Given GetById for checkin on null.
        /// </summary>
        [TestCase()]
        public void GivenGetByID_WhenArgumentIsNotFound_ThenOutIsNull() => 
            Assert.AreEqual(null, repository.GetByID(20));

        /// <summary>
        /// Given Update for checkin on null.
        /// </summary>
        [TestCase()]
        public void GivenUpdate_WhenArgumentIsNotFound_ThenOutIsNull() =>
            Assert.AreEqual(null, repository.Update(new Groups() {Id = 20, Name = "vov" }));

        /// <summary>
        /// Given add for checkin on ArgumentNullException. 
        /// </summary>
        [TestCase()]
        public void GivenAdd_WhenArgumentIsNull_ThenOutIsArgumentNullException() => 
            Assert.That(() => repository.Add(null), Throws.TypeOf<ArgumentNullException>());

        /// <summary>
        /// Given add for checkin on ArgumentException. 
        /// </summary>
        [TestCase()]
        public void GivenAdd_WhenObjectIsEmpty_ThenOutIsArgumentException() =>
            Assert.That(() => repository.Add(new Groups() ), Throws.TypeOf<ArgumentException>());

        /// <summary>
        /// Give Delete for checkin on ArgumentNullException.
        /// </summary>
        [TestCase()]
        public void GivenDelete_WhenArgumentIsZero_ThenOutIsArgumentNullException() =>
            Assert.That(() => repository.Delete(0), Throws.TypeOf<ArgumentNullException>());

        /// <summary>
        /// Given GetById for checkin on ArgumentNullException.
        /// </summary>
        [TestCase()]
        public void GivenGetByID_WhenArgumentIsZero_ThenOutIsArgumentNullException() =>
            Assert.That(() => repository.GetByID(0), Throws.TypeOf<ArgumentNullException>());

        /// <summary>
        /// Given Update for checkin on ArgumentNullException. 
        /// </summary>
        [TestCase()]
        public void GivenUpdate_WhenArgumentIsNull_ThenOutIsArgumentNullException() =>
            Assert.That(() => repository.Update(null), Throws.TypeOf<ArgumentNullException>());


    }
}