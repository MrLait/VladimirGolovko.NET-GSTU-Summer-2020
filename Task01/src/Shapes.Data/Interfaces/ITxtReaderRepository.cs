namespace Shapes.Data.Interfaces
{
    /// <summary>
    /// Txt reader interface.
    /// </summary>
    /// <typeparam name="T">Object type</typeparam>
    public interface ITxtFileReader<T>
    {
        /// <summary>
        /// Get all text from file.
        /// </summary>
        /// <returns>Returns text from file.</returns>
        T GetAllText();

        /// <summary>
        /// Get all rows from file.
        /// </summary>
        /// <returns>Returns rows array.</returns>
        T[] GetAllRow();
    }
}
