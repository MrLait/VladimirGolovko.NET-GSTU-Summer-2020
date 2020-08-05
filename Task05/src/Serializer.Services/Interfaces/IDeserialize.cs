namespace Serializer.Services.Interfaces
{
    public interface IDeserialize
    {
        T Deserialize<T>(string path);
    }
}
