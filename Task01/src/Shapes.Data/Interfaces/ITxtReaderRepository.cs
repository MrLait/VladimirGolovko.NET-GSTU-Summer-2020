namespace Shapes.Data.Interfaces
{
    public interface ITxtFileReader<T>
    {
        T GetAllText();
        T[] GetAllRow();
    }
}
