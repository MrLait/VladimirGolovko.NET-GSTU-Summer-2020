namespace Serializers.Services.Interfaces
{
    /// <summary>
    /// ISerialize interface.
    /// </summary>
    public interface ISerialize : ISerializer
    {
        /// <summary>
        /// Serialize
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="obj">Objct</param>
        /// <param name="path">path</param>
        void Serialize<T>(T obj, string path);
    }
}
