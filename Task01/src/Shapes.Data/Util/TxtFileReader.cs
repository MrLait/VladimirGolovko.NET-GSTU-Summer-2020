using Shapes.Data.Interfaces;
using System;
using System.IO;

namespace Shapes.Data.Util
{
    /// <summary>
    /// A class to read from a text file.
    /// </summary>
    public class TxtFileReader : ITxtFileReader<string>
    {
        /// <summary>
        /// Property to the path to the file.
        /// </summary>
        public string PathToFile { get; private set; }

        /// <summary>
        /// Constructor to initialize property pathToFile.
        /// </summary>
        /// <param name="pathToFile">Parameter path to the file.</param>
		public TxtFileReader(string pathToFile)
        {
            PathToFile = pathToFile;
        }

        /// <summary>
        /// Get all text from file in string.
        /// </summary>
        /// <returns>Returns text from file.</returns>
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

        /// <summary>
        /// Get all rows from file.
        /// </summary>
        /// <returns>Returns array with rows from file.</returns>
        public virtual string[] GetAllRow()
        {
            string[] textRows = GetAllText().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            return textRows;
        }
    }
}
