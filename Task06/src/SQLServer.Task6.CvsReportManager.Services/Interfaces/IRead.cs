namespace SQLServer.Task6.CvsReportManager.Services.Interfaces
{
    /// <summary>
    /// Interface with read method.
    /// </summary>
    public interface IRead
    {
        /// <summary>
        /// Read method.
        /// </summary>
        /// <param name="separator">Separator.</param>
        /// <returns>Returns string.</returns>
        string Read(char separator);
    }
}
