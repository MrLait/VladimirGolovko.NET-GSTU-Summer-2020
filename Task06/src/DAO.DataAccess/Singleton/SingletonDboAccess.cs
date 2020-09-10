using DAO.DataAccess.Factory;

namespace DAO.DataAccess.Singleton
{
    /// <summary>
    /// Access to database with singleton pattern.
    /// </summary>
    public sealed class SingletonDboAccess
    {
        /// <summary>
        /// Connection string to database.
        /// </summary>
        private static readonly string _dbConnString = @"Data Source=LAIT-PC\SQLEXPRESS;Initial Catalog=SQLServer.Task6.Database;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        /// <summary>
        /// Static field with singleton instance.
        /// </summary>
        private static SingletonDboAccess _instance = null;

        /// <summary>
        /// RepositoryFactory property witch represent access to table models.
        /// </summary>
        public AbstractFactory ADORepositoryFactory { get; set; } = null;

        /// <summary>
        /// Private constructor with AbstractFactory parameter.
        /// </summary>
        private SingletonDboAccess()
        {
            if (ADORepositoryFactory == null)
                ADORepositoryFactory =  new ADORepositoryFactory(_dbConnString);
        }

        /// <summary>
        /// Method to create singleton instance.
        /// </summary>
        /// <returns>Singleton instance.</returns>
        public static SingletonDboAccess GetInstance()
        {
            if (_instance == null)
                _instance = new SingletonDboAccess();
            return _instance;
        }
    }
}
