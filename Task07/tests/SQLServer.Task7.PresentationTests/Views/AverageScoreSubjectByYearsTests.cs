using NUnit.Framework;
using SQLServer.Task7.PresentationTests;
using SQLServer.Task7.PresentationTests.TestCaseSources;
using System.Collections.Generic;
using System.Linq;

namespace SQLServer.Task7.Presentation.Views.Tests
{
    /// <summary>
    /// Test cases for Average score subject by years.
    /// </summary>
    [TestFixture()]
    public class AverageScoreSubjectByYearsTests : MockBaseView
    {
        /// <summary>
        /// Tests for Average score by examiner.
        /// </summary>
        /// <param name="subjectName">Subject name.</param>
        /// <param name="expectedYear18">Expected average value for year 2018.</param>
        /// <param name="expectedYear19">Expected average value for year 2019.</param>
        /// <param name="expectedYear20">Expected average value for year 2020.</param>
        [TestCase("Subject-1.0", 20, 29.25, 57)]
        [TestCase("Subject-2.0", 22, 60.833333333333336, 46.5)]
        public void GiveGetView_WhenAverageValue_ThenOutIsAverageValue(string subjectName, 
            double expectedYear18, double expectedYear19, double expectedYear20)
        {
            //Arrange
            AverageScoreSubjectByYearsView averageScoreSubjectByYearsView = new AverageScoreSubjectByYearsView(Mock.Object);
            //Act
            IEnumerable<double> actual = averageScoreSubjectByYearsView.GetView(subjectName).OrderBy(x => x.Year).Select(y => y.AverageValue).ToList();
            List<double> expected = new List<double>
            {
                expectedYear18,
                expectedYear19,
                expectedYear20
            };
            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for AggregateOperations.
        /// </summary>
        /// <param name="subjectName">Subject name.</param>
        [Test, TestCaseSource(typeof(MyFactoryAverageScoreSubjectByYearsTests), "GiveToString_ThenOutIsToString")]
        public string GiveToString_ThenOutIsToString(string subjectName)
        {
            //Arrange
            AverageScoreSubjectByYearsView averageScoreBySpecialtyView = new AverageScoreSubjectByYearsView(Mock.Object);
            //Act
            var actual = averageScoreBySpecialtyView.GetView(subjectName).OrderBy(x => x.Year);
            var actualString = averageScoreBySpecialtyView.ToString(actual);
            return actualString;
        }
    }
}