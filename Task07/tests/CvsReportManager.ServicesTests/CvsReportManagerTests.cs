using CvsReportManager.Services.Utils;
using NUnit.Framework;
using SQLServer.Task7.PresentationTests.TestCaseSources;
using System.IO;

namespace CvsReportManager.Services.Tests
{
    /// <summary>
    /// Test cases for Cvs report manager.
    /// </summary>
    [TestFixture()]
    public class CvsReportManagerTests
    {
        /// <summary>
        /// Full name to directory path.
        /// </summary>
        private readonly string directoryInfoFullName = new DirectoryInfo(@"xlsxData\\").FullName;

        /// <summary>
        /// Print SessionsResultsView.
        /// </summary>
        /// <param name="fileName">File name.</param>
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

        /// <summary>
        /// Print SessionsResultsView.
        /// </summary>
        /// <param name="fileName">File name.</param>
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

        /// <summary>
        /// Print SessionsResultsView.
        /// </summary>
        /// <param name="fileName">File name.</param>
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

        /// <summary>
        /// Print SessionsResultsView.
        /// </summary>
        /// <param name="fileName">File name.</param>
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

        /// <summary>
        /// Print AggregateOperations.
        /// </summary>
        /// <param name="fileName">File name.</param>
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

        /// <summary>
        /// Print AggregateOperations.
        /// </summary>
        /// <param name="fileName">File name.</param>
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

        /// <summary>
        /// Print AggregateOperations.
        /// </summary>
        /// <param name="fileName">File name.</param>
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

        /// <summary>
        /// Print AggregateOperations.
        /// </summary>
        /// <param name="fileName">File name.</param>
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

        /// <summary>
        /// Print StudentsToBeExpelled.
        /// </summary>
        /// <param name="fileName">File name.</param>
        [TestCase("StudentsExpelledSesOne30")]
        public void GivenPrint_WhenStudentsToBeExpelledView_ThenOutIsSessionOneGrade30(string fileName)
        {
            //Arrange
            CvsReportManager cvsReportManager = new CvsReportManager(new Excel(directoryInfoFullName, fileName), MyFactoryStudentsToBeExpelledViewTests.SessionOneGrade30, ';');
            var expected = MyFactoryStudentsToBeExpelledViewTests.SessionOneGrade30.Replace(" ", "");
            //Act
            cvsReportManager.Print();
            var actual = new Excel(directoryInfoFullName, fileName).Read(';').Replace(" ", "");
            //Arrange
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print StudentsToBeExpelled.
        /// </summary>
        /// <param name="fileName">File name.</param>
        [TestCase("StudentsExpelledSesOne50")]
        public void GivenPrint_WhenStudentsToBeExpelledView_ThenOutIsSessionOneGrade50(string fileName)
        {
            //Arrange
            CvsReportManager cvsReportManager = new CvsReportManager(new Excel(directoryInfoFullName, fileName), MyFactoryStudentsToBeExpelledViewTests.SessionOneGrade50, ';');
            var expected = MyFactoryStudentsToBeExpelledViewTests.SessionOneGrade50.Replace(" ", "");
            //Act
            cvsReportManager.Print();
            var actual = new Excel(directoryInfoFullName, fileName).Read(';').Replace(" ", "");
            //Arrange
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print StudentsToBeExpelled.
        /// </summary>
        /// <param name="fileName">File name.</param>
        [TestCase("StudentsExpelledSesOne20Ordered")]
        public void GivenPrint_WhenStudentsToBeExpelledView_ThenOutIsSessionOneGrade20Ordered(string fileName)
        {
            //Arrange
            CvsReportManager cvsReportManager = new CvsReportManager(new Excel(directoryInfoFullName, fileName), MyFactoryStudentsToBeExpelledViewTests.SessionOneGrade20Ordered, ';');
            var expected = MyFactoryStudentsToBeExpelledViewTests.SessionOneGrade20Ordered.Replace(" ", "");
            //Act
            cvsReportManager.Print();
            var actual = new Excel(directoryInfoFullName, fileName).Read(';').Replace(" ", "");
            //Arrange
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print StudentsToBeExpelled.
        /// </summary>
        /// <param name="fileName">File name.</param>
        [TestCase("StudentsExpelledSesOne40Ordered")]
        public void GivenPrint_WhenStudentsToBeExpelledView_ThenOutIsSessionOneGrade40Ordered(string fileName)
        {
            //Arrange
            CvsReportManager cvsReportManager = new CvsReportManager(new Excel(directoryInfoFullName, fileName), MyFactoryStudentsToBeExpelledViewTests.SessionOneGrade40Ordered, ';');
            var expected = MyFactoryStudentsToBeExpelledViewTests.SessionOneGrade40Ordered.Replace(" ", "");
            //Act
            cvsReportManager.Print();
            var actual = new Excel(directoryInfoFullName, fileName).Read(';').Replace(" ", "");
            //Arrange
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print AverageScoreByExaminer.
        /// </summary>
        /// <param name="fileName">File name.</param>
        [TestCase("AvgScoreByExaminerSesOneExamOne")]
        public void GivenPrint_WhenAverageScoreByExaminerView_ThenOutIsSessionOneExaminerOne(string fileName)
        {
            //Arrange
            CvsReportManager cvsReportManager = new CvsReportManager(new Excel(directoryInfoFullName, fileName), MyFactoryAverageScoreByExaminerTests.SessionOneExaminerOne, ';');
            var expected = MyFactoryAverageScoreByExaminerTests.SessionOneExaminerOne.Replace(" ", "");
            //Act
            cvsReportManager.Print();
            var actual = new Excel(directoryInfoFullName, fileName).Read(';').Replace(" ", "");
            //Arrange
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print AverageScoreByExaminer.
        /// </summary>
        /// <param name="fileName">File name.</param>
        [TestCase("AvgScoreByExaminerSesOneExamTwo")]
        public void GivenPrint_WhenAverageScoreByExaminerView_ThenOutIsSessionOneExaminerTwo(string fileName)
        {
            //Arrange
            CvsReportManager cvsReportManager = new CvsReportManager(new Excel(directoryInfoFullName, fileName), MyFactoryAverageScoreByExaminerTests.SessionOneExaminersTwo, ';');
            var expected = MyFactoryAverageScoreByExaminerTests.SessionOneExaminersTwo.Replace(" ", "");
            //Act
            cvsReportManager.Print();
            var actual = new Excel(directoryInfoFullName, fileName).Read(';').Replace(" ", "");
            //Arrange
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print AverageScoreByExaminer.
        /// </summary>
        /// <param name="fileName">File name.</param>
        [TestCase("AvgScoreByExaminerSesTwoExamOne")]
        public void GivenPrint_WhenAverageScoreByExaminerView_ThenOutIsSessionTwoExaminerOne(string fileName)
        {
            //Arrange
            CvsReportManager cvsReportManager = new CvsReportManager(new Excel(directoryInfoFullName, fileName), MyFactoryAverageScoreByExaminerTests.SessionTwoExaminerOne, ';');
            var expected = MyFactoryAverageScoreByExaminerTests.SessionTwoExaminerOne.Replace(" ", "");
            //Act
            cvsReportManager.Print();
            var actual = new Excel(directoryInfoFullName, fileName).Read(';').Replace(" ", "");
            //Arrange
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print AverageScoreByExaminer.
        /// </summary>
        /// <param name="fileName">File name.</param>
        [TestCase("AvgScoreByExaminerSesTwoExamTwo")]
        public void GivenPrint_WhenAverageScoreByExaminerView_ThenOutIsSessionTwoExaminerTwo(string fileName)
        {
            //Arrange
            CvsReportManager cvsReportManager = new CvsReportManager(new Excel(directoryInfoFullName, fileName), MyFactoryAverageScoreByExaminerTests.SessionTwoExaminerTwo, ';');
            var expected = MyFactoryAverageScoreByExaminerTests.SessionTwoExaminerTwo.Replace(" ", "");
            //Act
            cvsReportManager.Print();
            var actual = new Excel(directoryInfoFullName, fileName).Read(';').Replace(" ", "");
            //Arrange
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print AverageScoreBySpecialty.
        /// </summary>
        /// <param name="fileName">File name.</param>
        [TestCase("AvgScoreBySpecSesOneSpecOne")]
        public void GivenPrint_WhenAverageScoreBySpecialtyView_ThenOutIsSessionOneSpecialtyOne(string fileName)
        {
            //Arrange
            CvsReportManager cvsReportManager = new CvsReportManager(new Excel(directoryInfoFullName, fileName), MyFactoryAverageScoreBySpecialtyTests.SessionOneSpecialtyOne, ';');
            var expected = MyFactoryAverageScoreBySpecialtyTests.SessionOneSpecialtyOne.Replace(" ", "");
            //Act
            cvsReportManager.Print();
            var actual = new Excel(directoryInfoFullName, fileName).Read(';').Replace(" ", "");
            //Arrange
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// Print AverageScoreBySpecialty.
        /// </summary>
        /// <param name="fileName">File name.</param>
        [TestCase("AvgScoreBySpecSesOneSpecTwo")]
        public void GivenPrint_WhenAverageScoreBySpecialtyView_ThenOutIsSessionOneSpecialtyTwo(string fileName)
        {
            //Arrange
            CvsReportManager cvsReportManager = new CvsReportManager(new Excel(directoryInfoFullName, fileName), MyFactoryAverageScoreBySpecialtyTests.SessionOneSpecialtyTwo, ';');
            var expected = MyFactoryAverageScoreBySpecialtyTests.SessionOneSpecialtyTwo.Replace(" ", "");
            //Act
            cvsReportManager.Print();
            var actual = new Excel(directoryInfoFullName, fileName).Read(';').Replace(" ", "");
            //Arrange
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print AverageScoreBySpecialty.
        /// </summary>
        /// <param name="fileName">File name.</param>
        [TestCase("AvgScoreBySpecSesTwoSpecOne")]
        public void GivenPrint_WhenAverageScoreBySpecialtyView_ThenOutIsSessionTwoSpecialtyOne(string fileName)
        {
            //Arrange
            CvsReportManager cvsReportManager = new CvsReportManager(new Excel(directoryInfoFullName, fileName), MyFactoryAverageScoreBySpecialtyTests.SessionTwoSpecialtyOne, ';');
            var expected = MyFactoryAverageScoreBySpecialtyTests.SessionTwoSpecialtyOne.Replace(" ", "");
            //Act
            cvsReportManager.Print();
            var actual = new Excel(directoryInfoFullName, fileName).Read(';').Replace(" ", "");
            //Arrange
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print AverageScoreBySpecialty.
        /// </summary>
        /// <param name="fileName">File name.</param>
        [TestCase("AvgScoreBySpecSesTwoSpecTwo")]
        public void GivenPrint_WhenAverageScoreBySpecialtyView_ThenOutIsSessionTwoSpecialtyTwo(string fileName)
        {
            //Arrange
            CvsReportManager cvsReportManager = new CvsReportManager(new Excel(directoryInfoFullName, fileName), MyFactoryAverageScoreBySpecialtyTests.SessionTwoSpecialtyTwo, ';');
            var expected = MyFactoryAverageScoreBySpecialtyTests.SessionTwoSpecialtyTwo.Replace(" ", "");
            //Act
            cvsReportManager.Print();
            var actual = new Excel(directoryInfoFullName, fileName).Read(';').Replace(" ", "");
            //Arrange
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print AverageScoreSubjectByYears.
        /// </summary>
        /// <param name="fileName">File name.</param>
        [TestCase("AvgScoreSubjectByYearsSubjOne")]
        public void GivenPrint_WhenAverageScoreSubjectByYearsView_ThenOutIsSubjectOne(string fileName)
        {
            //Arrange
            CvsReportManager cvsReportManager = new CvsReportManager(new Excel(directoryInfoFullName, fileName), MyFactoryAverageScoreSubjectByYearsTests.SubjectOne, ';');
            var expected = MyFactoryAverageScoreSubjectByYearsTests.SubjectOne.Replace(" ", "");
            //Act
            cvsReportManager.Print();
            var actual = new Excel(directoryInfoFullName, fileName).Read(';').Replace(" ", "");
            //Arrange
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Print AverageScoreSubjectByYears.
        /// </summary>
        /// <param name="fileName">File name.</param>
        [TestCase("AvgScoreSubjectByYearsSubjTwo")]
        public void GivenPrint_WhenAverageScoreSubjectByYearsView_ThenOutIsSubjectTwo(string fileName)
        {
            //Arrange
            CvsReportManager cvsReportManager = new CvsReportManager(new Excel(directoryInfoFullName, fileName), MyFactoryAverageScoreSubjectByYearsTests.SubjectTwo, ';');
            var expected = MyFactoryAverageScoreSubjectByYearsTests.SubjectTwo.Replace(" ", "");
            //Act
            cvsReportManager.Print();
            var actual = new Excel(directoryInfoFullName, fileName).Read(';').Replace(" ", "");
            //Arrange
            Assert.AreEqual(expected, actual);
        }
    }
}