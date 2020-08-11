using Serializers.Services.Interfaces;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serializer.Services.Util
{
    /// <summary>
    /// BinarySerialaizer class.
    /// </summary>
    public class BinarySerialaizer : ISerialize, IDeserialize
    {
        /// <summary>
        /// Serialize object.
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="obj">obj</param>
        /// <param name="path">path</param>
        public void Serialize<T>(T obj, string path)
        {
            var objTypeName = obj.GetType().Name;
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(path + "/" +  objTypeName + ".dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }
        }

        /// <summary>
        /// Deserialize object.
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="path">path</param>
        /// <returns>object</returns>
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
