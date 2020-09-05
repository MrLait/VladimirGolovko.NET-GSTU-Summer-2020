using CvsReportManager.Services.Interfaces;
using Microsoft.Office.Interop.Excel;
using System;
using System.IO;
using System.Text;

namespace CvsReportManager.Services.Utils
{
    /// <summary>
    /// Excel reader and writer.
    /// </summary>
    public class Excel : IPrint, IRead
    {
        private string _xlslExtension = ".xlsx";
        private readonly string _directoryPath;
        private readonly string _fileName;
        private readonly Application _excelApplication;
        private Workbook _excelWorkbook;
        private Worksheet _excelWorksheet;

        /// <summary>
        /// Constructor <see cref="Excel"/>
        /// </summary>
        /// <param name="path">Path to save file.</param>
        /// <param name="fileName">Set file name.</param>
        public Excel(string path, string fileName = "outputName")
        {
            _directoryPath = path;
            _fileName = fileName;
            _excelApplication = new Application
            {
                Visible = false,
                DisplayAlerts = false
            };
        }

        /// <summary>
        /// Save to excel format.
        /// </summary>
        /// <param name="cvsString">Input string in CVS format.</param>
        /// <param name="separator">CVS separator.</param>
        public void Print(string cvsString, char separator)
        {
            string outputPath = _directoryPath + _fileName + _xlslExtension;

            if (!Directory.Exists(_directoryPath))
                Directory.CreateDirectory(_directoryPath);
            try
            {
                _excelWorkbook = _excelApplication.Workbooks.Add();
                _excelWorksheet = (Worksheet)_excelWorkbook.Sheets[1];
                _excelWorksheet.Name = _fileName;

                int row = 0;
                int cells = 1;

                foreach (var item in cvsString.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
                {
                    cells = 1;
                    row++;

                    foreach (var cellValue in item.Split(separator))
                    {
                        if (double.TryParse(cellValue, out double doubleValue)) 
                            _excelWorksheet.Cells[row, cells] = doubleValue;
                        else
                            _excelWorksheet.Cells[row, cells] = cellValue;

                        cells++;
                    }
                }

                _excelWorksheet.Rows.AutoFit();
                _excelWorksheet.Columns.AutoFit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _excelWorkbook.SaveAs(outputPath);
                _excelWorkbook.Close(true);
                _excelApplication.Quit();
            }
        }

        /// <summary>
        /// Implemented Read from excel file.
        /// </summary>
        /// <param name="separator">Separator.</param>
        /// <returns>Returns file in string format.</returns>
        public string Read(char separator)
        {
            Range range;
            int rCnt;
            int cCnt;
            string str = string.Empty;
            var appendedLine = new StringBuilder();

            try
            {
                _excelWorkbook = _excelApplication.Workbooks.Open(_directoryPath + _fileName + _xlslExtension, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                _excelWorksheet = (Worksheet)_excelWorkbook.Worksheets.get_Item(1);
                range = _excelWorksheet.UsedRange;

                int rw = range.Rows.Count;
                int cl = range.Columns.Count;

                for (rCnt = 1; rCnt <= rw; rCnt++)
                {
                    for (cCnt = 1; cCnt <= cl; cCnt++)
                    {
                        str = Convert.ToString((range.Cells[rCnt, cCnt] as Range).Value2);
                        appendedLine.Append(str);

                        if (cCnt != cl)
                            appendedLine.Append(separator);
                    }

                    if (rCnt != rw)
                        appendedLine.Append(Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _excelWorkbook.Close(true, null, null);
                _excelApplication.Quit();
            }

            return appendedLine.ToString();

        }
    }
}
