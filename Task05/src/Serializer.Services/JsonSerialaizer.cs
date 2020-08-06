using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Serializer.Services.Interfaces;
using Serilog.Formatting.Json;
using System.IO;
using System.Text;

namespace Serializer.Services
{
    public class JsonSerialaizer : ISerialize, IDeserialize
    {
        public void Serialize<T>(T obj)
        {
            var objTypeName = obj.GetType().Name;

            using (FileStream fs = new FileStream(objTypeName +".json", FileMode.OpenOrCreate))
            {
                byte[] array = Encoding.Default.GetBytes(JsonConvert.SerializeObject(obj));
                fs.Write(array, 0, array.Length);
            }
        }

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
