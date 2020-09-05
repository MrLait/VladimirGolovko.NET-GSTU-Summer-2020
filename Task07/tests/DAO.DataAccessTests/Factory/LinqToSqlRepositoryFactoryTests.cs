using NUnit.Framework;
using DAO.DataAccess.Interfaces;
using SQLServer.Task7.Domain.Models;
using DAO.DataAccess.Singleton;

namespace DAO.DataAccess.Factory.Tests
{
    /// <summary>
    /// Test cases for LinqToSqlRepositoryFactory class.
    /// </summary>
    [TestFixture()]
    public class LinqToSqlRepositoryFactoryTests
    {
        private AbstractFactory _linqToSqlRepositoryFactory;

        /// <summary>
        /// Initialize _linqToSqlRepositoryFactory.
        /// </summary>
        [OneTimeSetUp]
        public void RepositoryFactoryInit()
        {
            _linqToSqlRepositoryFactory = SingletonLinqToSql.GetInstance().LinqToSqlRepositoryFactory;
        }

        /// <summary>
        /// Checking the creation of the expected factory method type.
        /// </summary>
        /// <param name="expected">Expected bool.</param>
        [TestCase(true)]
        public void GivenCreateExamSchedules_ThenOutIsCheckTypeIsTrue(bool expected)
        {
            //Arrange
            ICRUD<ExamSchedules> examShedules = _linqToSqlRepositoryFactory.CreateExamSchedules();
            //Act
            var actual = examShedules is ICRUD<ExamSchedules>;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checking the creation of the expected factory method type.
        /// </summary>
        /// <param name="expected">Expected bool.</param>
        [TestCase(false)]
        public void GivenCreateExamSchedules_ThenOutIsCheckTypeIsFalse(bool expected)
        {
            //Arrange
            ICRUD<ExamSchedules> examShedules = _linqToSqlRepositoryFactory.CreateExamSchedules();
            //Act
            var actual = examShedules is ICRUD<Students>;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checking the creation of the expected factory method type.
        /// </summary>
        /// <param name="expected">Expected bool.</param>
        [TestCase(true)]
        public void GivenCreateGroups_ThenOutIsCheckTypeIsTrue(bool expected)
        {
            //Arrange
            ICRUD<Groups> groups = _linqToSqlRepositoryFactory.CreateGroups();
            //Act
            var actual = groups is ICRUD<Groups>;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checking the creation of the expected factory method type.
        /// </summary>
        /// <param name="expected">Expected bool.</param>
        [TestCase(false)]
        public void GivenCreateGroups_ThenOutIsCheckTypeIsFalse(bool expected)
        {
            //Arrange
            ICRUD<Groups> groups = _linqToSqlRepositoryFactory.CreateGroups();
            //Act
            var actual = groups is ICRUD<Students>;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checking the creation of the expected factory method type.
        /// </summary>
        /// <param name="expected">Expected bool.</param>
        [TestCase(true)]
        public void GivenCreateSessions_ThenOutIsCheckTypeIsTrue(bool expected)
        {
            //Arrange
            ICRUD<Sessions> sessions = _linqToSqlRepositoryFactory.CreateSessions();
            //Act
            var actual = sessions is ICRUD<Sessions>;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checking the creation of the expected factory method type.
        /// </summary>
        /// <param name="expected">Expected bool.</param>
        [TestCase(false)]
        public void GivenCreateSessions_ThenOutIsCheckTypeIsFalse(bool expected)
        {
            //Arrange
            ICRUD<Sessions> sessions = _linqToSqlRepositoryFactory.CreateSessions();
            //Act
            var actual = sessions is ICRUD<Students>;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checking the creation of the expected factory method type.
        /// </summary>
        /// <param name="expected">Expected bool.</param>
        [TestCase(true)]
        public void GivenCreateSessionsResults_ThenOutIsCheckTypeIsTrue(bool expected)
        {
            //Arrange
            ICRUD<SessionsResults> sessionsResults = _linqToSqlRepositoryFactory.CreateSessionsResults();
            //Act
            var actual = sessionsResults is ICRUD<SessionsResults>;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checking the creation of the expected factory method type.
        /// </summary>
        /// <param name="expected">Expected bool.</param>
        [TestCase(false)]
        public void GivenCreateSessionsResults_ThenOutIsCheckTypeIsFalse(bool expected)
        {
            //Arrange
            ICRUD<SessionsResults> sessionsResults = _linqToSqlRepositoryFactory.CreateSessionsResults();
            //Act
            var actual = sessionsResults is ICRUD<Students>;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checking the creation of the expected factory method type.
        /// </summary>
        /// <param name="expected">Expected bool.</param>
        [TestCase(true)]
        public void GivenCreateStudents_ThenOutIsCheckTypeIsTrue(bool expected)
        {
            //Arrange
            ICRUD<Students> students = _linqToSqlRepositoryFactory.CreateStudents();
            //Act
            var actual = students is ICRUD<Students>;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checking the creation of the expected factory method type.
        /// </summary>
        /// <param name="expected">Expected bool.</param>
        [TestCase(false)]
        public void GivenCreateStudents_ThenOutIsCheckTypeIsFalse(bool expected)
        {
            //Arrange
            ICRUD<Students> students = _linqToSqlRepositoryFactory.CreateStudents();
            //Act
            var actual = students is ICRUD<ExamSchedules>;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checking the creation of the expected factory method type.
        /// </summary>
        /// <param name="expected">Expected bool.</param>
        [TestCase(true)]
        public void GivenCreateSubjects_ThenOutIsCheckTypeIsTrue(bool expected)
        {
            //Arrange
            ICRUD<Subjects> subjects = _linqToSqlRepositoryFactory.CreateSubjects();
            //Act
            var actual = subjects is ICRUD<Subjects>;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checking the creation of the expected factory method type.
        /// </summary>
        /// <param name="expected">Expected bool.</param>
        [TestCase(false)]
        public void GivenCreateSubjects_ThenOutIsCheckTypeIsFalse(bool expected)
        {
            //Arrange
            ICRUD<Subjects> subjects = _linqToSqlRepositoryFactory.CreateSubjects();

            //Act
            var actual = subjects is ICRUD<Students>;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checking the creation of the expected factory method type.
        /// </summary>
        /// <param name="expected">Expected bool.</param>
        [TestCase(true)]
        public void GivenCreateExaminers_ThenOutIsCheckTypeIsTrue(bool expected)
        {
            //Arrange
            ICRUD<Examiners> examiners = _linqToSqlRepositoryFactory.CreateExaminers();
            //Act
            var actual = examiners is ICRUD<Examiners>;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checking the creation of the expected factory method type.
        /// </summary>
        /// <param name="expected">Expected bool.</param>
        [TestCase(false)]
        public void GivenCreateExaminers_ThenOutIsCheckTypeIsFalse(bool expected)
        {
            //Arrange
            ICRUD<Examiners> examiners = _linqToSqlRepositoryFactory.CreateExaminers();

            //Act
            var actual = examiners is ICRUD<Students>;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checking the creation of the expected factory method type.
        /// </summary>
        /// <param name="expected">Expected bool.</param>
        [TestCase(true)]
        public void GivenCreateSpecialties_ThenOutIsCheckTypeIsTrue(bool expected)
        {
            //Arrange
            ICRUD<Specialties> specialties = _linqToSqlRepositoryFactory.CreateSpecialties();
            //Act
            var actual = specialties is ICRUD<Specialties>;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checking the creation of the expected factory method type.
        /// </summary>
        /// <param name="expected">Expected bool.</param>
        [TestCase(false)]
        public void GivenCreateSpecialties_ThenOutIsCheckTypeIsFalse(bool expected)
        {
            //Arrange
            ICRUD<Specialties> specialties = _linqToSqlRepositoryFactory.CreateSpecialties();

            //Act
            var actual = specialties is ICRUD<Students>;
            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}