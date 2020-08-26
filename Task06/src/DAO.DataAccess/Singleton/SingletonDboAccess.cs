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
        public AbstractFactory RepositoryFactory { get; set; } = null;

        /// <summary>
        /// Private constructor with AbstractFactory parameter.
        /// </summary>
        /// <param name="factory">AbstractFactory parameter.</param>
        private SingletonDboAccess(AbstractFactory factory) =>  RepositoryFactory = factory;

        /// <summary>
        /// Method to create singleton instance.
        /// </summary>
        /// <param name="factory">Input database factory.</param>
        /// <returns>Singleton instance.</returns>
        public static SingletonDboAccess GetInstance(AbstractFactory factory)
        {
            if (_instance == null)
                _instance = new SingletonDboAccess(factory);
            return _instance;
        }
    }
}
