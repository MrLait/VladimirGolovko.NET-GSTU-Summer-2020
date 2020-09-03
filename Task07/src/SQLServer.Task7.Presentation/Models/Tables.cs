using DAO.DataAccess.Interfaces;
using SQLServer.Task7.Domain.Models;
using SQLServer.Task7.Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.Task7.Presentation.Models
{
    public class Tables : ITables
    {
        public IQueryable<Examiners> Examiners { get; set; }
        public IQueryable<Groups> Groups { get; set; }
        public IQueryable<Sessions> Sessions { get; set; }
        public IQueryable<Students> Students { get; set; }
        public IQueryable<ExamSchedules> ExamSchedules { get; set; }
        public IQueryable<SessionsResults> SessionsResults { get; set; }
        public IQueryable<Specialties> Specialties { get; set; }
        public IQueryable<Subjects> Subjects { get; set; }
    }
}
