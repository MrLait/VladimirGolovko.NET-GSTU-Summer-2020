using Serializers.Services.Interfaces;
using System.IO;
using System.Xml.Serialization;

namespace Serializers.Services.Util
{
    /// <summary>
    /// Xml serializers.
    /// </summary>
    public class XmlSerialaizer : ISerialize, IDeserialize
    {
        /// <summary>
        /// Serialize object.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="obj">Object.</param>
        /// <param name="path">Path to file.</param>
        public void Serialize<T>(T obj, string path)
        {
            var objTypeName = obj.GetType().Name;
            
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(path + "/" + objTypeName + ".xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }
        }

        /// <summary>
        /// Deserialize object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns>Desirializer</returns>
        public T Deserialize<T>(string path)
        {
            if (!new FileInfo(path).Exists)
                throw new FileNotFoundException("Path to file is not correct.");

            XmlSerializer formatter = new XmlSerializer(typeof(T));
            T newDeserialaize;

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                newDeserialaize = (T)formatter.Deserialize(fs);
            }
            return newDeserialaize;
        }


    }
}
