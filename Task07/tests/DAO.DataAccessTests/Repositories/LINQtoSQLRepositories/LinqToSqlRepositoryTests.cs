using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using SQLServer.Task7.Domain.Models;
using DAO.DataAccess.Singleton;
using DAO.DataAccess.Interfaces;

namespace DAO.DataAccess.Repositories.LINQtoSQLRepositories.Tests
{
    [TestFixture()]
    public class LinqToSqlRepositoryTests
    {
        /// <summary>
        /// Field with group repository.
        /// </summary>
        private ICRUD<Specialties> specialtiesRepository;

        /// <summary>
        /// Field with specialties.
        /// </summary>
        private IQueryable<Specialties> specialties;

        /// <summary>
        /// Initialize repository.
        /// </summary>
        [OneTimeSetUp]
        public void RepositoryFactoryInit()
        {
            specialtiesRepository = SingletonLinqToSql.GetInstance().LinqToSqlRepositoryFactory.CreateSpecialties();
            specialties = specialtiesRepository.GetAll();
        }

        /// <summary>
        /// Test cases for Add.
        /// </summary>
        /// <param name="actualName">Name parameter.</param>
        [TestCase("NameSpecialte")]
        [TestCase("NameSpecialteTest")]
        [TestCase("NameSpecialteTest2")]
        [TestCase("NameSpecialteTest3")]
        public void GivenAdd_ThenOutIsActualName(string actualName)
        {
            //Arrage
            Specialties actual = new Specialties() { Name = actualName };
            //Act
            specialtiesRepository.Add(actual);
            var lastAddedName = specialtiesRepository.GetAll().ToList().Last().Name;
            var lastAddedId = specialtiesRepository.GetAll().ToList().Last().Id;
            specialtiesRepository.Delete(lastAddedId);
            //Assert
            Assert.AreEqual(lastAddedName, actualName);
        }

        /// <summary>
        /// Test cases for GetAll method.
        /// </summary>
        /// <param name="actualName"> Name parameter.</param>
        [TestCase("NameSpecialte")]
        [TestCase("NameSpecialteTest")]
        [TestCase("NameSpecialteTest2")]
        [TestCase("NameSpecialteTest3")]
        public void GivenGetAll_WhenAddedSpecialties_ThenOutGetThisSpecialties(string actualName)
        {
            //Arrage
            Specialties actual = new Specialties() { Name = actualName };
            List<Specialties> allSpecialties = specialties.ToList();
            //Act
            specialtiesRepository.Add(actual);
            allSpecialties.Add(actual);

            var actualSelectRepositoryName = specialtiesRepository.GetAll().Select(x => x.Name).ToList();
            var expectedSelectAllSpecialties = allSpecialties.ToList().Select(x => x.Name);

            var lastAddedName = specialtiesRepository.GetAll().ToList().Last().Name;
            var lastAddedId = specialtiesRepository.GetAll().ToList().Last().Id;
            specialtiesRepository.Delete(lastAddedId); //clear last addded element
            //Assert
            Assert.AreEqual(expectedSelectAllSpecialties, actualSelectRepositoryName);
        }

        /// <summary>
        /// Test cases for GetById method.
        /// </summary>
        /// <param name="expectedName"> Expected name.</param>
        [TestCase("NameSpecialte")]
        [TestCase("NameSpecialteTest")]
        [TestCase("NameSpecialteTest2")]
        [TestCase("NameSpecialteTest3")]
        public void GivenGetByID_WhenAdded_ThenOutGetThisSpecialtiesById(string expectedName)
        {
            //Arrage
            Specialties actual = new Specialties() { Name = expectedName };
            //Act
            specialtiesRepository.Add(actual);
            var lastAddedId = specialtiesRepository.GetAll().ToList().Last().Id;
            var actualNameById = specialtiesRepository.GetByID(lastAddedId).Name;
            specialtiesRepository.Delete(lastAddedId); //clear last addded element
            //Assert
            Assert.AreEqual(expectedName, actualNameById);
        }

        /// <summary>
        /// Test cases Update method.
        /// </summary>
        /// <param name="name">Name parameter.</param>
        /// <param name="actualUpdateName">Actual update name.</param>
        [TestCase("NameSpecialte", "VaseOne")]
        [TestCase("NameSpecialteTest", "VaseTwo")]
        [TestCase("NameSpecialteTest2", "VaseThree")]
        [TestCase("NameSpecialteTest3", "VaseFour")]
        public void GivenUpdate_WhenAdded_ThenOutUpdateThisSpecialties(string name, string actualUpdateName)
        {
            //Arrage
            Specialties actual = new Specialties() { Name = name };
            //Act
            specialtiesRepository.Add(actual);
            var lastAddedId = specialtiesRepository.GetAll().ToList().Last().Id;
            specialtiesRepository.Update(new Specialties() { Id = lastAddedId, Name = actualUpdateName });
            var expectedUpdetedName = specialtiesRepository.GetByID(lastAddedId);
            specialtiesRepository.Delete(lastAddedId); //clear last addded element
            //Assert
            Assert.AreEqual(expectedUpdetedName.Name, actualUpdateName);
        }

        /// <summary>
        /// Test cases for Delete method.
        /// </summary>
        /// <param name="name">Name.</param>
        [TestCase("NameSpecialte")]
        [TestCase("NameSpecialteTest")]
        [TestCase("NameSpecialteTest2")]
        [TestCase("NameSpecialteTest3")]
        public void GivenDelete_WhenAddedOneSpecialties_ThenOutIsDelete(string name)
        {
            //Arrage
            Specialties actual = new Specialties() { Name = name };
            //Act
            specialtiesRepository.Add(actual);
            var lastAddedId = specialtiesRepository.GetAll().ToList().Last().Id;
            var countElement = specialtiesRepository.GetAll().Count();
            specialtiesRepository.Delete(lastAddedId);
            var countElementAfterDelete = specialtiesRepository.GetAll().Count();
            //Assert
            Assert.AreNotEqual(countElement, countElementAfterDelete);
        }

        /// <summary>
        /// Given GetById for checkin on null.
        /// </summary>
        [TestCase()]
        public void GivenGetByID_WhenArgumentIsNotFound_ThenOutIsNull() =>
            Assert.AreEqual(null, specialtiesRepository.GetByID(20));

        /// <summary>
        /// Given Update for checkin on null.
        /// </summary>
        [TestCase()]
        public void GivenUpdate_WhenArgumentIsNotFound_ThenOutIsArgumentNullException() =>
            Assert.That(() => specialtiesRepository.Update(new Specialties() { Id = 20, Name = "vov" }), Throws.TypeOf<ArgumentNullException>());

        /// <summary>
        /// Given add for checkin on ArgumentNullException. 
        /// </summary>
        [TestCase()]
        public void GivenAdd_WhenArgumentIsNull_ThenOutIsArgumentNullException() =>
            Assert.That(() => specialtiesRepository.Add(null), Throws.TypeOf<ArgumentNullException>());

        /// <summary>
        /// Given add for checkin on ArgumentException. 
        /// </summary>
        [TestCase()]
        public void GivenAdd_WhenObjectIsEmpty_ThenOutIsArgumentException() =>
            Assert.That(() => specialtiesRepository.Add(null), Throws.TypeOf<ArgumentNullException>());

        /// <summary>
        /// Give Delete for checkin on ArgumentNullException.
        /// </summary>
        [TestCase()]
        public void GivenDelete_WhenArgumentIsZero_ThenOutIsArgumentNullException() =>
            Assert.That(() => specialtiesRepository.Delete(0), Throws.TypeOf<ArgumentNullException>());

        /// <summary>
        /// Given GetById for checkin on ArgumentNullException.
        /// </summary>
        [TestCase()]
        public void GivenGetByID_WhenArgumentIsZero_ThenOutIsArgumentNullException() =>
            Assert.That(() => specialtiesRepository.GetByID(0), Throws.TypeOf<ArgumentNullException>());

        /// <summary>
        /// Given Update for checkin on ArgumentNullException. 
        /// </summary>
        [TestCase()]
        public void GivenUpdate_WhenArgumentIsNull_ThenOutIsArgumentNullException() =>
            Assert.That(() => specialtiesRepository.Update(null), Throws.TypeOf<ArgumentNullException>());
    }
}