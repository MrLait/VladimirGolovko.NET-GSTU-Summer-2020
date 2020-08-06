using Serializers.Services.Interfaces;

namespace Serializers.Services
{
    public class Serialize
    {
        public ISerializer Serializer { get; set; }

        public Serialize(ISerializer serializer)
        {
            Serializer = serializer;
        }

        public void GetSerialize<T>(T obj)
        {
            ISerialize serialize = (ISerialize)Serializer;
            serialize.Serialize(obj);
        }

        public T GetDeserialize<T>(string path)
        {
            IDeserialize deserialize = (IDeserialize)Serializer;
            return deserialize.Deserialize<T>(path);
        }
    }
}
