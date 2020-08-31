using DAO.DataAccess.Factory;

namespace DAO.DataAccess.Singleton
{
    /// <summary>
    /// Access to database with singleton pattern.
    /// </summary>
    public sealed class SingletonDboAccess
    {
        /// <summary>
        /// Static field with singleton instance.
        /// </summary>
        private static SingletonDboAccess _instance = null;

        /// <summary>
        /// RepositoryFactory property witch represent access to table models.
        /// </summary>
        public static AbstractFactory RepositoryFactory { get; set; } = null;

        /// <summary>
        /// Private constructor with AbstractFactory parameter.
        /// </summary>
        private SingletonDboAccess() { }

        /// <summary>
        /// Method to create singleton instance.
        /// </summary>
        /// <param name="factory">Input database factory.</param>
        /// <returns>Singleton instance.</returns>
        public static SingletonDboAccess GetInstance(AbstractFactory factory)
        {
            if (RepositoryFactory == null)
            {
                RepositoryFactory = factory;

                if (_instance == null)
                    _instance = new SingletonDboAccess();
            }
            return _instance;
        }
    }
}
