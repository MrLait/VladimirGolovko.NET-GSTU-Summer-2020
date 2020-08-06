using Serializers.Services.Interfaces;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serializer.Services.Util
{
    public class BinarySerialaizer : ISerialize, IDeserialize
    {
        public void Serialize<T>(T obj)
        {
            var objTypeName = obj.GetType().Name;
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(objTypeName + ".dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }
        }

        public T Deserialize<T>(string path)
        {
            if (!new FileInfo(path).Exists)
                throw new FileNotFoundException("Path to file is not correct.");

            BinaryFormatter formatter = new BinaryFormatter();
            T newDeserialaize;

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                newDeserialaize = (T)formatter.Deserialize(fs);
            }
            return newDeserialaize;
        }
    }
}
