using NUnit.Framework;
using System.IO;

namespace SQLServer.Task6.CvsReportManager.Services.Utils.Tests
{
    [TestFixture()]
    public class ExcelTests
    {
        private string directoryInfoFullName = new DirectoryInfo(@"xlsxData\\").FullName;

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