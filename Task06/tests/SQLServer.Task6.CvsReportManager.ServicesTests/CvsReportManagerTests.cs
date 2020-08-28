using NUnit.Framework;
using SQLServer.Task6.CvsReportManager.Services.Utils;
using SQLServer.Task6.PresentationTests.TestCaseSources;
using System.IO;

namespace SQLServer.Task6.CvsReportManager.Services.Tests
{
    [TestFixture()]
    public class CvsReportManagerTests
    {
        private string directoryInfoFullName = new DirectoryInfo(@"xlsxData\\").FullName;

        [TestCase("SessionsResultsSesOnePM_1")]
        public void GivenPrint_WhenSessionsResultsView_ThenOutIsSessionOneGroupPM_1_Ordered(string fileName)
        {
            //Arrange
            CvsReportManager cvsReportManager = new CvsReportManager(new Excel(directoryInfoFullName, fileName), MyFactorySessionsResultsViewTests.SessionOneGroupPM_1_Ordered, ';');
            var expected = MyFactorySessionsResultsViewTests.SessionOneGroupPM_1_Ordered.Replace(" ", "");
            //Act
            cvsReportManager.Print();
            var actual = new Excel(directoryInfoFullName, fileName).Read(';').Replace(" ", "");
            //Arrange
            Assert.AreEqual(expected, actual);
        }

        [TestCase("SessionsResultsSesOnePM_2")]
        public void GivenPrint_WhenSessionsResultsView_ThenOutIsSessionOneGroupPM_2_Ordered(string fileName)
        {
            //Arrange
            CvsReportManager cvsReportManager = new CvsReportManager(new Excel(directoryInfoFullName, fileName), MyFactorySessionsResultsViewTests.SessionOneGroupPM_2_Ordered, ';');
            var expected = MyFactorySessionsResultsViewTests.SessionOneGroupPM_2_Ordered.Replace(" ", "");
            //Act
            cvsReportManager.Print();
            var actual = new Excel(directoryInfoFullName, fileName).Read(';').Replace(" ", "");
            //Arrange
            Assert.AreEqual(expected, actual);
        }

        [TestCase("SessionsResultsSesTwoPM_1")]
        public void GivenPrint_WhenSessionsResultsView_ThenOutIsSessionTwoGroupPM_1_Ordered(string fileName)
        {
            //Arrange
            CvsReportManager cvsReportManager = new CvsReportManager(new Excel(directoryInfoFullName, fileName), MyFactorySessionsResultsViewTests.SessionTwoGroupPM_1_Ordered, ';');
            var expected = MyFactorySessionsResultsViewTests.SessionTwoGroupPM_1_Ordered.Replace(" ", "");
            //Act
            cvsReportManager.Print();
            var actual = new Excel(directoryInfoFullName, fileName).Read(';').Replace(" ", "");
            //Arrange
            Assert.AreEqual(expected, actual);
        }

        [TestCase("SessionsResultsSesTwoPM_2")]
        public void GivenPrint_WhenSessionsResultsView_ThenOutIsSessionTwoGroupPM_2_Ordered(string fileName)
        {
            //Arrange
            CvsReportManager cvsReportManager = new CvsReportManager(new Excel(directoryInfoFullName, fileName), MyFactorySessionsResultsViewTests.SessionTwoGroupPM_2_Ordered, ';');
            var expected = MyFactorySessionsResultsViewTests.SessionTwoGroupPM_2_Ordered.Replace(" ", "");
            //Act
            cvsReportManager.Print();
            var actual = new Excel(directoryInfoFullName, fileName).Read(';').Replace(" ", "");
            //Arrange
            Assert.AreEqual(expected, actual);
        }

        [TestCase("AggregateOperationsSesOnePM_1")]
        public void GivenPrint_WhenAggregateOperationsView_ThenOutIsSessionOneGroupPM_1(string fileName)
        {
            //Arrange
            CvsReportManager cvsReportManager = new CvsReportManager(new Excel(directoryInfoFullName, fileName), MyFactoryAggregateOperationsViewTests.SessionOneGroupPM_1, ';');
            var expected = MyFactoryAggregateOperationsViewTests.SessionOneGroupPM_1.Replace(" ", "");
            //Act
            cvsReportManager.Print();
            var actual = new Excel(directoryInfoFullName, fileName).Read(';').Replace(" ", "");
            //Arrange
            Assert.AreEqual(expected, actual);
        }

        [TestCase("AggregateOperationsSesOnePM_2")]
        public void GivenPrint_WhenAggregateOperationsView_ThenOutIsSessionOneGroupPM_2(string fileName)
        {
            //Arrange
            CvsReportManager cvsReportManager = new CvsReportManager(new Excel(directoryInfoFullName, fileName), MyFactoryAggregateOperationsViewTests.SessionOneGroupPM_2, ';');
            var expected = MyFactoryAggregateOperationsViewTests.SessionOneGroupPM_2.Replace(" ", "");
            //Act
            cvsReportManager.Print();
            var actual = new Excel(directoryInfoFullName, fileName).Read(';').Replace(" ", "");
            //Arrange
            Assert.AreEqual(expected, actual);
        }

        [TestCase("AggregateOperationsSesTwoPM_1")]
        public void GivenPrint_WhenAggregateOperationsView_ThenOutIsSessionTwoGroupPM_1(string fileName)
        {
            //Arrange
            CvsReportManager cvsReportManager = new CvsReportManager(new Excel(directoryInfoFullName, fileName), MyFactoryAggregateOperationsViewTests.SessionTwoGroupPM_1, ';');
            var expected = MyFactoryAggregateOperationsViewTests.SessionTwoGroupPM_1.Replace(" ", "");
            //Act
            cvsReportManager.Print();
            var actual = new Excel(directoryInfoFullName, fileName).Read(';').Replace(" ", "");
            //Arrange
            Assert.AreEqual(expected, actual);
        }

        [TestCase("AggregateOperationsSesTwoPM_2")]
        public void GivenPrint_WhenAggregateOperationsView_ThenOutIsSessionTwoGroupPM_2(string fileName)
        {
            //Arrange
            CvsReportManager cvsReportManager = new CvsReportManager(new Excel(directoryInfoFullName, fileName), MyFactoryAggregateOperationsViewTests.SessionTwoGroupPM_2, ';');
            var expected = MyFactoryAggregateOperationsViewTests.SessionTwoGroupPM_2.Replace(" ", "");
            //Act
            cvsReportManager.Print();
            var actual = new Excel(directoryInfoFullName, fileName).Read(';').Replace(" ", "");
            //Arrange
            Assert.AreEqual(expected, actual);
        }

        [TestCase("StudentsExpelledSesOne30")]
        public void GivenPrint_WhenStudentsToBeExpelledView_ThenOutIsSessionOneGrade30(string fileName)
        {
            //Arrange
            CvsReportManager cvsReportManager = new CvsReportManager(new Excel(directoryInfoFullName, fileName), MyFactoryStudentsToBeExpelledViewTests.SessionOneGrade30, ';');
            var expected = MyFactoryStudentsToBeExpelledViewTests.SessionOneGrade30.Replace(" ", "").Remove(495);
            //Act
            cvsReportManager.Print();
            var actual = new Excel(directoryInfoFullName, fileName).Read(';').Replace(" ", "");
            //Arrange
            Assert.AreEqual(expected, actual);
        }

        [TestCase("StudentsExpelledSesOne50")]
        public void GivenPrint_WhenStudentsToBeExpelledView_ThenOutIsSessionOneGrade50(string fileName)
        {
            //Arrange
            CvsReportManager cvsReportManager = new CvsReportManager(new Excel(directoryInfoFullName, fileName), MyFactoryStudentsToBeExpelledViewTests.SessionOneGrade50, ';');
            var expected = MyFactoryStudentsToBeExpelledViewTests.SessionOneGrade50.Replace(" ", "").Remove(495);
            //Act
            cvsReportManager.Print();
            var actual = new Excel(directoryInfoFullName, fileName).Read(';').Replace(" ", "");
            //Arrange
            Assert.AreEqual(expected, actual);
        }

        [TestCase("StudentsExpelledSesOne20Ordered")]
        public void GivenPrint_WhenStudentsToBeExpelledView_ThenOutIsSessionOneGrade20Ordered(string fileName)
        {
            //Arrange
            CvsReportManager cvsReportManager = new CvsReportManager(new Excel(directoryInfoFullName, fileName), MyFactoryStudentsToBeExpelledViewTests.SessionOneGrade20Ordered, ';');
            var expected = MyFactoryStudentsToBeExpelledViewTests.SessionOneGrade20Ordered.Replace(" ", "").Remove(452);
            //Act
            cvsReportManager.Print();
            var actual = new Excel(directoryInfoFullName, fileName).Read(';').Replace(" ", "");
            //Arrange
            Assert.AreEqual(expected, actual);
        }

        [TestCase("StudentsExpelledSesOne40Ordered")]
        public void GivenPrint_WhenStudentsToBeExpelledView_ThenOutIsSessionOneGrade40Ordered(string fileName)
        {
            //Arrange
            CvsReportManager cvsReportManager = new CvsReportManager(new Excel(directoryInfoFullName, fileName), MyFactoryStudentsToBeExpelledViewTests.SessionOneGrade40Ordered, ';');
            var expected = MyFactoryStudentsToBeExpelledViewTests.SessionOneGrade40Ordered.Replace(" ", "").Remove(495);
            //Act
            cvsReportManager.Print();
            var actual = new Excel(directoryInfoFullName, fileName).Read(';').Replace(" ", "");
            //Arrange
            Assert.AreEqual(expected, actual);
        }
    }
}