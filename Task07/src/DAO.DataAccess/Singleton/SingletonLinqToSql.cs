using DAO.DataAccess.Factory;

namespace DAO.DataAccess.Singleton
{
    /// <summary>
    /// Access to database with singleton pattern.
    /// </summary>
    public sealed class SingletonLinqToSql
    {
        /// <summary>
        /// Connection string to database.
        /// </summary>
        private static string _dbConnString = @"Data Source=LAIT-PC\SQLEXPRESS;Initial Catalog=SQLServer.Task7.Database;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        /// <summary>
        /// Static field with singleton instance.
        /// </summary>
        private static SingletonLinqToSql _instance = null;

        /// <summary>
        /// RepositoryFactory property witch represent access to table models.
        /// </summary>
        public AbstractFactory LinqToSqlRepositoryFactory { get; set; } = null;

        /// <summary>
        /// Private constructor with AbstractFactory parameter.
        /// </summary>
        private SingletonLinqToSql()
        {
            if (LinqToSqlRepositoryFactory == null)
                LinqToSqlRepositoryFactory = new LinqToSqlRepositoryFactory(_dbConnString);
        }

        /// <summary>
        /// Method to create singleton instance.
        /// </summary>
        /// <returns>Singleton instance.</returns>
        public static SingletonLinqToSql GetInstance()
        {
            if (_instance == null)
                _instance = new SingletonLinqToSql();
            return _instance;
        }
    }
}
