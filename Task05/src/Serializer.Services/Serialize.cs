using Serializers.Services.Interfaces;
using Version.Domain;

namespace Serializers.Services
{
    /// <summary>
    /// Serialize.
    /// </summary>
    public class Serialize
    {
        /// <summary>
        /// Property Serializer.
        /// </summary>
        public ISerializer Serializer { get; set; }

        /// <summary>
        /// Property CheckISerialize.
        /// </summary>
        public bool CheckISerialize { get; set; }

        /// <summary>
        /// Property CheckVersion.
        /// </summary>
        public bool CheckVersion { get; set; }

        /// <summary>
        /// Property Version.
        /// </summary>
        public ModuleVersion Version { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="serializer"></param>
        public Serialize(ISerializer serializer)
        {
            Serializer = serializer;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="serializer">serializer.</param>
        /// <param name="checkISerialize">checkISerialize.</param>
        /// <param name="checkVersion">checkVersion.</param>
        /// <param name="version">version.</param>
        public Serialize(ISerializer serializer, bool checkISerialize, bool checkVersion, ModuleVersion version) : this(serializer)
        {
            CheckISerialize = checkISerialize;
            CheckVersion = checkVersion;
            Version = version;
        }

        /// <summary>
        /// Get serialize.
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="obj">obj</param>
        /// <param name="path">path</param>
        public void GetSerialize<T>(T obj, string path)
        {
            ISerialize serialize = (ISerialize)Serializer;

            if (CheckISerialize)
            {
                if (obj is InterfaceMarkers.ISerialize)
                    serialize.Serialize(obj, path);
                else
                    throw new System.InvalidCastException();
            }
            else
            {
                serialize.Serialize(obj, path);
            }
        }

        /// <summary>
        /// Get deserialize.
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="path">path</param>
        /// <returns></returns>
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
