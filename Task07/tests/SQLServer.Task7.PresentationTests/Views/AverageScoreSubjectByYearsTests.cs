using NUnit.Framework;
using SQLServer.Task7.Presentation.Views;
using SQLServer.Task7.PresentationTests;
using SQLServer.Task7.PresentationTests.TestCaseSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.Task7.Presentation.Views.Tests
{
    [TestFixture()]
    public class AverageScoreSubjectByYearsTests : MockBaseView
    {
        /// <summary>
        /// Tests for Average score by examiner.
        /// </summary>
        /// <param name="sessionName">Session name.</param>
        /// <param name="groupName">Group name.</param>
        /// <param name="expected">Expected.</param>
        [TestCase("Subject-1.0", 20, 29.25, 57)]
        [TestCase("Subject-2.0", 22, 60.833333333333336, 46.5)]
        public void GiveGetView_WhenAverageValue_ThenOutIsAverageValue(string subjectName, 
            double expectedYear18, double expectedYear19, double expectedYear20)
        {
            //Arrange
            AverageScoreSubjectByYearsView averageScoreSubjectByYearsView = new AverageScoreSubjectByYearsView(Mock.Object);
            //Act
            IEnumerable<double> actual = averageScoreSubjectByYearsView.GetView(subjectName).OrderBy(x => x.Year).Select(y => y.AverageValue).ToList();
            List<double> expected = new List<double>();
            expected.Add(expectedYear18);
            expected.Add(expectedYear19);
            expected.Add(expectedYear20);
            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for AggregateOperations.
        /// </summary>
        /// <param name="sessionName">Session name.</param>
        /// <param name="groupName">Group name.</param>
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