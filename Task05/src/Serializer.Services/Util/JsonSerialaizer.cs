using Newtonsoft.Json;
using Serializers.Services.Interfaces;
using System.IO;
using System.Text;

namespace Serializers.Services.Util
{
    /// <summary>
    /// 
    /// </summary>
    public class JsonSerialaizer : ISerialize, IDeserialize
    {
        /// <summary>
        /// Serialize classes.
        /// </summary>
        /// <typeparam name="T"> T</typeparam>
        /// <param name="obj">object</param>
        /// <param name="path">path</param>
        public void Serialize<T>(T obj, string path)
        {
            var objTypeName = obj.GetType().Name;
            if (File.Exists(objTypeName + ".json"))
                File.Delete(objTypeName + ".json");

            using (FileStream fs = new FileStream(path + "/" + objTypeName +".json", FileMode.OpenOrCreate))
            {
                byte[] array = Encoding.Default.GetBytes(JsonConvert.SerializeObject(obj));
                fs.Write(array, 0, array.Length);
            }
        }

        /// <summary>
        /// Deserialize classes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public T Deserialize<T>(string path)
        {
            if (!new FileInfo(path).Exists)
                throw new FileNotFoundException($"Path:'{path}' to file is not correct.");
            T newDeserialaize;

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] array = new byte[fs.Length];
                fs.Read(array, 0, array.Length);
                var str = Encoding.Default.GetString(array);

                newDeserialaize = JsonConvert.DeserializeObject<T>(str);
            }

            return newDeserialaize;
        }
    }
}
