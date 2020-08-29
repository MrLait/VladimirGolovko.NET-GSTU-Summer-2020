using NUnit.Framework;
using DAO.DataAccessTests;
using SQLServer.Task6.Domain.Models;
using DAO.DataAccess.Interfaces;

namespace DAO.DataAccess.Factory.Tests
{
    /// <summary>
    /// Test cases for ADORepositoryFactory.
    /// </summary>
    [TestFixture()]
    public class ADORepositoryFactoryTests : DatabaseConnectionBase
    {
        /// <summary>
        /// Checking the creation of the expected factory method type.
        /// </summary>
        /// <param name="expected">Expected bool.</param>
        [TestCase(true)]
        public void GivenCreateExamSchedules_ThenOutIsCheckTypeIsTrue(bool expected)
        {
            //Arrange
            ADORepositoryFactory repositoryFactory = new ADORepositoryFactory(DbConnString);
            ICRUD<ExamSchedules> examShedules = repositoryFactory.CreateExamSchedules();
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
            ADORepositoryFactory repositoryFactory = new ADORepositoryFactory(DbConnString);
            ICRUD<ExamSchedules> examShedules = repositoryFactory.CreateExamSchedules();
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
            ADORepositoryFactory repositoryFactory = new ADORepositoryFactory(DbConnString);
            ICRUD<Groups> groups = repositoryFactory.CreateGroups();
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
            ADORepositoryFactory repositoryFactory = new ADORepositoryFactory(DbConnString);
            ICRUD<Groups> groups = repositoryFactory.CreateGroups();
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
            ADORepositoryFactory repositoryFactory = new ADORepositoryFactory(DbConnString);
            ICRUD<Sessions> sessions = repositoryFactory.CreateSessions();
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
            ADORepositoryFactory repositoryFactory = new ADORepositoryFactory(DbConnString);
            ICRUD<Sessions> sessions = repositoryFactory.CreateSessions();
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
            ADORepositoryFactory repositoryFactory = new ADORepositoryFactory(DbConnString);
            ICRUD<SessionsResults> sessionsResults = repositoryFactory.CreateSessionsResults();
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
            ADORepositoryFactory repositoryFactory = new ADORepositoryFactory(DbConnString);
            ICRUD<SessionsResults> sessionsResults = repositoryFactory.CreateSessionsResults();
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
            ADORepositoryFactory repositoryFactory = new ADORepositoryFactory(DbConnString);
            ICRUD<Students> students = repositoryFactory.CreateStudents();
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
            ADORepositoryFactory repositoryFactory = new ADORepositoryFactory(DbConnString);
            ICRUD<Students> students = repositoryFactory.CreateStudents();
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
            ADORepositoryFactory repositoryFactory = new ADORepositoryFactory(DbConnString);
            ICRUD<Subjects> subjects = repositoryFactory.CreateSubjects();
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
            ADORepositoryFactory repositoryFactory = new ADORepositoryFactory(DbConnString);
            ICRUD<Subjects> subjects = repositoryFactory.CreateSubjects();
            
            //Act
            var actual = subjects is ICRUD<Students>;
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}