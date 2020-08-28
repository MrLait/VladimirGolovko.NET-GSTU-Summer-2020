using Moq;
using NUnit.Framework;
using SQLServer.Task6.PresentationTests;
using SQLServer.Task6.PresentationTests.TestCaseSources;
using System.Linq;

namespace SQLServer.Task6.Presentation.Views.Tests
{
    [TestFixture()]
    public class StudentsToBeExpelledViewTests : MockBaseView
    {
        [Test, TestCaseSource(typeof(MyFactoryStudentsToBeExpelledViewTests), "GiveToString_WhenNoOrdered_ThenOutIsToString")]
        public string GiveToString_WhenNoOrdered_ThenOutIsToString(string sessionName, int minPassingGrade)
        {
            //Arrange
            StudentsToBeExpelledView studentsToBeExpelledView = new StudentsToBeExpelledView(Mock.Object);
            //Act
            var actual = studentsToBeExpelledView.GetView(sessionName, minPassingGrade).ToList();
            var actualString = studentsToBeExpelledView.ToString(actual);
            return actualString;
        }

        [Test, TestCaseSource(typeof(MyFactoryStudentsToBeExpelledViewTests), "GiveToString_WhenOrderByGroupNameAndStudentId_ThenOutIsToStringOrderByGroupNameAndStudentId")]
        public string GiveToString_WhenOrderByGroupNameAndStudentId_ThenOutIsToStringOrderByGroupNameAndStudentId(string sessionName, int minPassingGrade)
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