namespace Serializers.Services.Interfaces
{
    public interface ISerialize : ISerializer
    {
        void Serialize<T>(T obj);
    }
}
