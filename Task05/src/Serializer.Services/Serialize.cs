using Serializers.Services.Interfaces;
using Version.Domain;
using System.Reflection;

namespace Serializers.Services
{
    public class Serialize
    {
        public ISerializer Serializer { get; set; }
        public bool CheckISerialize { get; set; }
        public bool CheckVersion { get; set; }
        public ModuleVersion Version { get; set; }

        public Serialize(ISerializer serializer)
        {
            Serializer = serializer;
        }
        public Serialize(ISerializer serializer, bool checkISerialize, bool checkVersion, ModuleVersion version) : this(serializer)
        {
            CheckISerialize = checkISerialize;
            CheckVersion = checkVersion;
            Version = version;
        }

        public void GetSerialize<T>(T obj)
        {
            ISerialize serialize = (ISerialize)Serializer;

            if (CheckISerialize)
            {
                if (obj is InterfaceMarkers.ISerialize)
                    serialize.Serialize(obj);
                else
                    throw new System.InvalidCastException();
            }
            else
            {
                serialize.Serialize(obj);
            }
        }

        public T GetDeserialize<T>(string path)
        {
            IDeserialize deserialize = (IDeserialize)Serializer;
            var deserializedObj = deserialize.Deserialize<T>(path);

            if (CheckVersion)
            {
                ModuleVersion version = (ModuleVersion)deserializedObj.GetType().GetProperty("Version").GetValue(deserializedObj, null );

                if (!Version.Equals(version))
                    throw new System.ArgumentException("Version don't equal");

                return deserializedObj;
            }
            else
            {
                return deserializedObj;
            }

        }
    }
}
