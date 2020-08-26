using NUnit.Framework;
using DAO.DataAccessTests;
using SQLServer.Task6.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAO.DataAccess.Repositories.ADO.NetUsingReflection.Tests
{
    [TestFixture()]
    public class ADORepositoryTests : DatabaseConnectionBase
    {
        private ADORepository<Groups> repository;
        private IEnumerable<Groups> groups;

        [SetUp]
        public void Init()
        {
            repository = new ADORepository<Groups>(DbConnString);
            groups = repository.GetAll();
        }

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

        [TestCase("NameGroup")]
        [TestCase("NameGroupTest")]
        [TestCase("NameGroupTest2")]
        [TestCase("NameGroupTest3")]
        public void GivenGetAll_WhenAddedTwoGroups_ThenOutGetThisTwoGroups(string actualName)
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
            repository.Delete(lastAddedId); ////clear last addded element
            //Assert
            Assert.AreEqual(expectedSelectAllGroups, actualSelectRepositoryName);
        }
    }
}