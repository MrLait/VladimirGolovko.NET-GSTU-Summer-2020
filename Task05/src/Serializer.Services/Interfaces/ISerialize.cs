namespace Serializer.Services.Interfaces
{
    public interface ISerialize
    {
        void Serialize<T>(T obj);
    }
}
