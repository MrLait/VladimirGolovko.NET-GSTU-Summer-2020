using DAO.DataAccess.Singleton;
using SQLServer.Task7.Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.Task7.Presentation.Views
{
    public class AverageScoreSubjectByYears : BaseView
    {
        public AverageScoreSubjectByYears()
        {
        }

        public AverageScoreSubjectByYears(IView view) : base(view)
        {
        }

        public AverageScoreSubjectByYears(SingletonDboAccess singletonDboAccess, IView view) : base(singletonDboAccess, view)
        {
        }
    }
}
