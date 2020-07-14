using System;

namespace ReaderIntoArray.Model
{
    public class ConvertStringToArray
    {
        public IReaderRepository<string> ReadDataFromTxtFile { get; private set; }

        public string[] Strings { get; }

        public ConvertStringToArray(IReaderRepository<string> readDataFromTxtFile)
        {
            ReadDataFromTxtFile = readDataFromTxtFile;
            Strings = SaveDataToStringArray();
        }

        private string[] SaveDataToStringArray()
        {
            string[] dataFromTxt = ReadDataFromTxtFile.GetAll().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
         
            return dataFromTxt;
        }
    }
}
