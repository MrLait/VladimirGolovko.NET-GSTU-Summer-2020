using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Girls.Data.Util
{
    /// <summary>
    /// Static type to save and load XML document using StreamWriter and StreaReader.
    /// </summary>
    public class StreamIO
    {
        /// <summary>
        /// Static method to save xDocument with StreamWriter.
        /// </summary>
        /// <param name="document">Input xDocument.</param>
        /// <param name="path">Path to file to save xDocument.</param>
        public static void SaveXmlDocumentUsingStreamWriter(XDocument document, string path)
        {
            try
            {
                using (StreamWriter stream = new StreamWriter(path))
                {
                    document.Save(stream);
                }
            }
            catch (DirectoryNotFoundException)
            {

                throw new DirectoryNotFoundException();
            }
        }

        /// <summary>
        /// Static method to load xml using StreamReader.
        /// </summary>
        /// <param name="path">Path to file to load xml document using StramReader.</param>
        /// <returns>Returns xmlDocuments.</returns>
        public static XmlDocument LoadXmlDocumentUsingStreamReader(string path)
        {
            XmlDocument xmlDocument = new XmlDocument();
            string sb = string.Empty;

            try
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    string xmlData;
                    // the file is reached.
                    while ((xmlData = streamReader.ReadLine()) != null)
                    {
                        sb += xmlData;
                    }
                    xmlDocument.Load(new StringReader(sb.ToString()));
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            
            return xmlDocument;
        }

    }
}
