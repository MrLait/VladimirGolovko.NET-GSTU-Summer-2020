using NUnit.Framework;
using System.IO;

namespace SQLServer.Task6.CvsReportManager.Services.Utils.Tests
{
    /// <summary>
    /// Test cases for Excel class.
    /// </summary>
    [TestFixture()]
    public class ExcelTests
    {
        /// <summary>
        /// Full name to directory path.
        /// </summary>
        private string directoryInfoFullName = new DirectoryInfo(@"xlsxData\\").FullName;

        /// <summary>
        /// Test case to tests Read method.
        /// </summary>
        /// <param name="actual">Actrual string.</param>
        /// <param name="fileName">File name.</param>
        /// <param name="seporator">Seporator between word.</param>
        [TestCase("SessionName;GroupName;AverageValue;MaxValue;MinValue\r\n1;PM-1;58,4;97;27", "ExcelTestsOne", ';')]
        public void GivenRead_WhenInXlsxFile_ThenOutIsInputXlsxFile(string actual, string fileName, char seporator)
        {
            //Arrange
            Excel excel = new Excel(directoryInfoFullName, fileName);
            //Act
            var expetedRead = excel.Read(seporator);
            //Assert
            Assert.AreEqual(expetedRead, actual);
        }

        /// <summary>
        /// Test case to tests Print method.
        /// </summary>
        /// <param name="actual">Actrual string.</param>
        /// <param name="fileName">File name.</param>
        /// <param name="seporator">Seporator between words.</param>
        [TestCase("SessionName;GroupName;AverageValue;MaxValue;MinValue\r\n1;PM-1;58,4;97;27", "ExcelTestsOne", ';')]
        public void GivenPrint_WhenInXlsxFile_ThenOutIsXlsxFile(string actual, string fileName, char seporator)
        {
            //Arrange
            Excel excel = new Excel(directoryInfoFullName, fileName);
            //Act
            excel.Print(actual, seporator);
            var expetedRead = excel.Read(seporator);
            //Assert
            Assert.AreEqual(expetedRead, actual);
        }
    }
}