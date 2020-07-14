using System;
using System.IO;

namespace ReaderIntoArray.Repositories
{
    public class ReadDataFromTxtFileRepository : IReaderRepository<string>
    {
        public string PathToFile { get; private set; }

		public ReadDataFromTxtFileRepository(string pathToFile)
        {
            PathToFile = pathToFile;
        }

        public string GetAll()
        {
            string textFromFile = string.Empty;
            
            try
            {
                using (FileStream fstream = File.OpenRead(PathToFile))
                {
                    // преобразуем строку в байты
                    byte[] array = new byte[fstream.Length];
                    fstream.Read(array, 0, array.Length);
                    textFromFile = System.Text.Encoding.Default.GetString(array);
                }
            }
			catch (FileNotFoundException)
			{
				throw new FileNotFoundException("The file with path: " + PathToFile + " is not found");
			}
            return textFromFile;
        }
    }
}
