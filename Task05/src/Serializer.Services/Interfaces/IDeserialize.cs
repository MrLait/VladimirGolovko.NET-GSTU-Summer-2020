namespace Serializers.Services.Interfaces
{
    public interface IDeserialize : ISerializer
    {
        T Deserialize<T>(string path);
    }
}
