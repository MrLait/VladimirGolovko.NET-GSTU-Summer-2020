using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.Task6.ReportManager.Presentation.Models
{
    public class SessionSummary
    {
        public int Id { get; set; }

        public int SessionName { get; set; }

        public string GroupName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }
    }
}
