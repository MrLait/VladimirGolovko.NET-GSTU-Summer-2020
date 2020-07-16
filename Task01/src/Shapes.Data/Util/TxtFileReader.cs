using Shapes.Data.Interfaces;
using System;
using System.IO;

namespace Shapes.Data.Util
{
    public class TxtFileReader : ITxtFileReader<string>
    {
        public string PathToFile { get; private set; }

		public TxtFileReader(string pathToFile)
        {
            PathToFile = pathToFile;
        }

        public virtual string GetAllText()
        {
            string textFromFile = string.Empty;
            
            try
            {
                using (FileStream fstream = File.OpenRead(PathToFile))
                {
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

        public virtual string[] GetAllRow()
        {
            string[] textRows = GetAllText().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            return textRows;
        }
    }
}
