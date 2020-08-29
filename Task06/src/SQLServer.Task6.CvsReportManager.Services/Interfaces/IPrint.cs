namespace SQLServer.Task6.CvsReportManager.Services.Interfaces
{
    /// <summary>
    /// Intarface with print contract.
    /// </summary>
    public interface IPrint
    {
        /// <summary>
        /// Print method.
        /// </summary>
        /// <param name="cvsString">String in cvs format.</param>
        /// <param name="separator">Seporator between words.</param>
        void Print(string cvsString, char separator);
    }
}