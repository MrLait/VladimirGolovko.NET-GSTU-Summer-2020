using NUnit.Framework;
using SQLServer.Task7.PresentationTests;
using SQLServer.Task7.PresentationTests.TestCaseSources;

namespace SQLServer.Task7.Presentation.Views.Tests
{
    /// <summary>
    /// Test cases for Average score by specialty.
    /// </summary>
    [TestFixture()]
    public class AverageScoreBySpecialtyTests : MockBaseView
    {
        /// <summary>
        /// Tests for Average score by specialty.
        /// </summary>
        /// <param name="sessionName">Session name.</param>
        /// <param name="specialtyName">Specialty name.</param>
        /// <param name="expected">Expected.</param>
        [TestCase(1, "Specialty-1", 58.4)]
        [TestCase(1, "Specialty-2", 37)]
        [TestCase(2, "Specialty-1", 51.75)]
        [TestCase(2, "Specialty-2", 19.5)]
        public void GiveGetView_WhenAverageValue_ThenOutIsAverageValue(int sessionName, string specialtyName, double expected)
        {
            //Arrange
            AverageScoreBySpecialtyView averageScoreBySpecialtyView = new AverageScoreBySpecialtyView(Mock.Object);
            //Act
            var actual = averageScoreBySpecialtyView.GetView(sessionName, specialtyName).AverageValue;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests for Average score by specialty.
        /// </summary>
        /// <param name="sessionName">Session name.</param>
        /// <param name="specialtyName">Specialty name.</param>
        [Test, TestCaseSource(typeof(MyFactoryAverageScoreBySpecialtyTests), "GiveToString_ThenOutIsToString")]
        public string GiveToString_ThenOutIsToString(int sessionName, string specialtyName)
        {
            //Arrange
            AverageScoreBySpecialtyView averageScoreBySpecialtyView = new AverageScoreBySpecialtyView(Mock.Object);
            //Act
            var actual = averageScoreBySpecialtyView.GetView(sessionName, specialtyName);
            var actualString = averageScoreBySpecialtyView.ToString(actual);
            return actualString;
        }
    }
}