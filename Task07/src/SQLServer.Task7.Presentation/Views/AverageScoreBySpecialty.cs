using DAO.DataAccess.Singleton;
using SQLServer.Task7.Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.Task7.Presentation.Views
{
    public class AverageScoreBySpecialty : BaseView
    {
        public AverageScoreBySpecialty()
        {
        }

        public AverageScoreBySpecialty(IView view) : base(view)
        {
        }

        public AverageScoreBySpecialty(SingletonDboAccess singletonDboAccess, IView view) : base(singletonDboAccess, view)
        {
        }
    }
}
