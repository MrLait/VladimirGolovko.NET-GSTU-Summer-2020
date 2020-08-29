namespace DAO.DataAccessTests
{
    /// <summary>
    /// Class with database connection string.
    /// </summary>
    public class DatabaseConnectionBase
    {
        /// <summary>
        /// Connection string to database.
        /// </summary>
        public string DbConnString { get; } = @"Data Source=LAIT-PC\SQLEXPRESS;Initial Catalog=SQLServer.Task6.Database;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
