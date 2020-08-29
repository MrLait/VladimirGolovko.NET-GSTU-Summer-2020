namespace SQLServer.Task6.CvsReportManager.Services.Interfaces
{
    internal interface IRead
    {
        /// <summary>
        /// Implemented Read from excel file.
        /// </summary>
        /// <param name="separator">Separator.</param>
        /// <returns>Returns file in string format.</returns>
        string Read(char separator);
    }
}