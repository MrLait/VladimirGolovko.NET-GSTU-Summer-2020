using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.Task6.Domain.Models
{
    public class SessionsResults
    {
        public int Id { get; set; }
        public int StudentsId { get; set; }
        public int ExamSchedulesId { get; set; }
        public string Value { get; set; }
    }
}
