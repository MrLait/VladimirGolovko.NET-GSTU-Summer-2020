using SQLServer.Task6.CvsReportManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.Task6.CvsReportManager.Services
{
    public class CvsReportManager
    {
        public IPrint Printer { get; set; }
        public string CvsText { get; set; }
        public char Separator { get; set; }

        public CvsReportManager(IPrint print, string cvsText, char separator)
        {
            Printer = print;
            CvsText = cvsText;
            Separator = separator;
        }

        public void Print()
        {
            Printer.Print(CvsText, Separator);
        }
    }
}
