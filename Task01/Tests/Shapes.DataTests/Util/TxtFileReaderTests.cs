using NUnit.Framework;

namespace Shapes.Data.Util.Tests
{
    [TestFixture()]
    public class TxtFileReaderTests
    {
        private string _pathToTxtFileDifferentText = @"fileData\differentText.txt";
        private string _pathToTxtFiletThreeDifferentShape = @"fileData\threeDifferentShape.txt";
        private string _fileNotFoundExceptionPathToFile = @"figuress.txt";
        private string _directoryNotFoundExceptionPathToFile = @"asd\figuress.txt";

        [TestCase()]
        public void GivenGetAllText_WhenPathtToFileIsDifferentText_ThenOutIsEqual()
        {
            //Arrange
            var expectedResult = "someText;For.Test.123";
            //Act
            var actualText = new TxtFileReader(_pathToTxtFileDifferentText).GetAllText();
            //Assert
            Assert.AreEqual(expectedResult, actualText);
        }

        [TestCase()]
        public void GivenGetAllRow_WhenPathtToFileIsThreeDifferentShape_ThenOutIsEqual()
        {
            //Arrange
            string[] expectedResult = new[] { "Rectangle; 10; 20", "Circle; 30", "Square; 11" };
            //Act
            var actualText = new TxtFileReader(_pathToTxtFiletThreeDifferentShape).GetAllRow();
            //Assert
            Assert.AreEqual(expectedResult, actualText);
        }

        [TestCase()]
        public void GivenGetAllText_WhenPathtToFileIsNotValid_ThenOutIsFileNotFoundException()
        {
            //Assert
            Assert.That(() => new TxtFileReader(_fileNotFoundExceptionPathToFile).GetAllText(), Throws.TypeOf<System.IO.FileNotFoundException>());
        }

        [TestCase()]
        public void GivenGetAllRow_WhenPathtToFileIsNotValid_ThenOutIsFileNotFoundException()
        {
            //Assert
            Assert.That(() => new TxtFileReader(_fileNotFoundExceptionPathToFile).GetAllText(), Throws.TypeOf<System.IO.FileNotFoundException>());
        }

        [TestCase()]
        public void GivenGetAllText_WhenPathtToFileIsNotValid_ThenOutIsDirectoryNotFoundException()
        {
            //Assert
            Assert.That(() => new TxtFileReader(_directoryNotFoundExceptionPathToFile).GetAllText(), Throws.TypeOf<System.IO.DirectoryNotFoundException>());
        }

        [TestCase()]
        public void GivenGetAllRow_WhenPathtToFileIsNotValid_ThenOutIsDirectoryNotFoundException()
        {
            //Assert
            Assert.That(() => new TxtFileReader(_directoryNotFoundExceptionPathToFile).GetAllText(), Throws.TypeOf<System.IO.DirectoryNotFoundException>());
        }
    }
}