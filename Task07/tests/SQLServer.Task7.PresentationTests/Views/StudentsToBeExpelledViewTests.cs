using NUnit.Framework;
using SQLServer.Task7.PresentationTests;
using SQLServer.Task7.PresentationTests.TestCaseSources;
using System.Linq;

namespace SQLServer.Task7.Presentation.Views.Tests
{
    [TestFixture()]
    public class StudentsToBeExpelledViewTests : MockBaseView
    {
        /// <summary>
        /// Test for students to be expelled view no ordered.
        /// </summary>
        /// <param name="sessionName">Session name parameter.</param>
        /// <param name="minPassingGrade">Minimum passing grade parameter.</param>
        /// <returns>Returns string.</returns>
        [Test, TestCaseSource(typeof(MyFactoryStudentsToBeExpelledViewTests), "GiveToString_WhenNoOrdered_ThenOutIsToString")]
        public string GiveToString_WhenNoOrdered_ThenOutIsToString(int sessionName, int minPassingGrade)
        {
            //Arrange
            StudentsToBeExpelledView studentsToBeExpelledView = new StudentsToBeExpelledView(Mock.Object);
            //Act
            var actual = studentsToBeExpelledView.GetView(sessionName, minPassingGrade).ToList();
            var actualString = studentsToBeExpelledView.ToString(actual);
            return actualString;
        }

        /// <summary>
        /// Test for students to be expelled view no ordered.
        /// </summary>
        /// <param name="sessionName">Session name parameter.</param>
        /// <param name="minPassingGrade">Minimum passing grade parameter.</param>
        /// <returns>Returns string.</returns>
        [Test, TestCaseSource(typeof(MyFactoryStudentsToBeExpelledViewTests), "GiveToString_WhenOrderByGroupNameAndStudentId_ThenOutIsToStringOrderByGroupNameAndStudentId")]
        public string GiveToString_WhenOrderByGroupNameAndStudentId_ThenOutIsToStringOrderByGroupNameAndStudentId(int sessionName, int minPassingGrade)
        {
            //Arrange
            StudentsToBeExpelledView studentsToBeExpelledView = new StudentsToBeExpelledView(Mock.Object);
            //Act
            var actual = studentsToBeExpelledView.GetView(sessionName, minPassingGrade).ToList().OrderBy(x => x.Key).Select(k => k.OrderBy(g => g.GroupName).ThenBy(i => i.StudentId));
            var actualString = studentsToBeExpelledView.ToString(actual);
            return actualString;
        }
    }
}