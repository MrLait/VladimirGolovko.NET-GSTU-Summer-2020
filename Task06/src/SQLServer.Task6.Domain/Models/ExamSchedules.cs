using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.Task6.Domain.Models
{
    public class ExamSchedules
    {
        public int Id { get; set; }
        public int SessionsId { get; set; }
        public int GroupsId { get; set; }
        public int SubjectsId { get; set; }
        public DateTime ExamDate { get; set; }
    }
}
