using NUnit.Framework;
using SQLServer.Task7.PresentationTests;
using SQLServer.Task7.PresentationTests.TestCaseSources;

namespace SQLServer.Task7.Presentation.Views.Tests
{
    /// <summary>
    /// Test cases for Average score by examiner.
    /// </summary>
    [TestFixture()]
    public class AverageScoreByExaminerTests : MockBaseView
    {
        /// <summary>
        /// Tests for Average score by examiner.
        /// </summary>
        /// <param name="sessionName">Session name.</param>
        /// <param name="firstName">First name.</param>
        /// <param name="lastName">Last name.</param>
        /// <param name="middleName">Middle name.</param>
        /// <param name="expected">Expected.</param>
        [TestCase(1, "FirstName1", "LastName1", "MiddleName1", 29.8)]
        [TestCase(1, "FirstName2", "LastName2", "MiddleName2", 60.833333333333336)]
        [TestCase(2, "FirstName1", "LastName1", "MiddleName1", 30.333333333333332)]
        [TestCase(2, "FirstName2", "LastName2", "MiddleName2", 30.166666666666668)]
        public void GiveGetView_WhenAverageValue_ThenOutIsAverageValue(int sessionName, string firstName, string lastName, string middleName, double expected)
        {
            //Arrange
            AverageScoreByExaminerView averageScoreByExaminer = new AverageScoreByExaminerView(Mock.Object);
            //Act
            var actual = averageScoreByExaminer.GetView(sessionName, firstName, lastName, middleName).AverageValue;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for AggregateOperations.
        /// </summary>
        /// <param name="sessionName">Session name.</param>
        /// /// <param name="firstName">First name.</param>
        /// <param name="lastName">Last name.</param>
        /// <param name="middleName">Middle name.</param>
        [Test, TestCaseSource(typeof(MyFactoryAverageScoreByExaminerTests), "GiveToString_ThenOutIsToString")]
        public string GiveToString_ThenOutIsToString(int sessionName, string firstName, string lastName, string middleName)
        {
            //Arrange
            AverageScoreByExaminerView averageScoreByExaminer = new AverageScoreByExaminerView(Mock.Object);
            //Act
            var actual = averageScoreByExaminer.GetView(sessionName, firstName, lastName, middleName);
            var actualString = averageScoreByExaminer.ToString(actual);
            return actualString;
        }
    }
}