using SQLServer.Task6.CvsReportManager.Services.Interfaces;

namespace SQLServer.Task6.CvsReportManager.Services
{
    /// <summary>
    /// Cvs report manager.
    /// </summary>
    public class CvsReportManager
    {
        /// <summary>
        /// Printer with IPrint type.
        /// </summary>
        public IPrint Printer { get; set; }

        /// <summary>
        /// Text in cvs format.
        /// </summary>
        public string CvsText { get; set; }

        /// <summary>
        /// Seporetor between words.
        /// </summary>
        public char Separator { get; set; }

        /// <summary>
        /// Constructor to initializing property.
        /// </summary>
        /// <param name="print">Print parameter.</param>
        /// <param name="cvsText">Cvs text parameter.</param>
        /// <param name="separator">Separator parameter.</param>
        public CvsReportManager(IPrint print, string cvsText, char separator)
        {
            Printer = print;
            CvsText = cvsText;
            Separator = separator;
        }
        
        /// <summary>
        /// Print text.
        /// </summary>
        public void Print() => Printer.Print(CvsText, Separator);
    }
}
