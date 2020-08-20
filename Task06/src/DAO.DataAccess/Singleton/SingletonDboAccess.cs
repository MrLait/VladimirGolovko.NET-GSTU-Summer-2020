using DAO.DataAccess.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DataAccess.Singleton
{
    public sealed class SingletonDboAccess
    {
        private static SingletonDboAccess _instance = null;
        //private static string _dbConnectionString = null;

        public AbstractFactory AbstractFactory { get; set; } = null;

        private SingletonDboAccess(AbstractFactory factory)
        {
            AbstractFactory = factory;
        }

        public static SingletonDboAccess GetInstance(AbstractFactory factory)
        {
            //if (AbstractFactory == null)
            //{
            //    //_dbConnectionString = dbConnectionStrig;

            if (_instance == null)
                _instance = new SingletonDboAccess(factory);
            //}
            return _instance;
        }
    }
}
