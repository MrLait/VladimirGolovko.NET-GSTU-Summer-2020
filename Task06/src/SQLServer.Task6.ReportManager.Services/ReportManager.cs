using SQLServer.Task6.ReportManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.Task6.ReportManager.Services
{
    public class ReportManager
    {
        public IPrint Printer { get; set; }
        public string CvsText { get; set; }

        public ReportManager(IPrint print, string cvsText)
        {
            Printer = print;
            CvsText = cvsText;
        }

        public void Print()
        {
            Printer.Print(CvsText);
        }
    }
}
