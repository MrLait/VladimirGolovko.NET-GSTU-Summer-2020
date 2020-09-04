using DAO.DataAccess.Singleton;
using SQLServer.Task7.Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.Task7.Presentation.Views
{
    public class AverageScoreSubjectByYearsView : BaseView
    {
        public AverageScoreSubjectByYearsView()
        {
        }

        public AverageScoreSubjectByYearsView(ITables view) : base(view)
        {
        }

        public AverageScoreSubjectByYearsView(SingletonLinqToSql singletonDboAccess) : base(singletonDboAccess)
        {
        }
    }
}
