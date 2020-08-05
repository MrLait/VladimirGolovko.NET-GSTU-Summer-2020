using Serializer.Services.Interfaces;
using System.IO;
using System.Xml.Serialization;

namespace Serializer.Services
{
    public class XmlSerialaizer : ISerialize, IDeserialize
    {
        public void Serialize<T>(T obj)
        {
            var objTypeName = obj.GetType().Name;
            XmlSerializer formatter = new XmlSerializer(typeof(T));

            using (FileStream fs = new FileStream(objTypeName + ".xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }
        }

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
