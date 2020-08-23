using Microsoft.Office.Interop.Excel;
using SQLServer.Task6.ReportManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace SQLServer.Task6.ReportManager.Services.Utils
{
    public class Excel : IPrint
    {
        private readonly string _path;
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
            _path = path;
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
        /// <param name="report">Input data for save to excel file.</param>
        public void Print(string cvsString)
        {
            string outputPath = _path + _fileName;

            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);

            _excelWorkbook = _excelApplication.Workbooks.Add();
            _excelWorksheet = (Worksheet)_excelWorkbook.Sheets[1];
            _excelWorksheet.Name = _fileName;

            try
            {
                int row = 1;
                int cells = 1;

                foreach (var item in cvsString.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
                {
                    cells = 1;
                    row++;

                    foreach (var cellValue in item.Split(','))
                    {
                        _excelWorksheet.Cells[row, cells] = cellValue;
                        cells++;
                    }
                }

                _excelWorksheet.Rows.AutoFit();
                _excelWorksheet.Columns.AutoFit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _excelWorkbook.SaveAs(outputPath);
                _excelWorkbook.Close(true);
                _excelApplication.Quit();
            }
        }
    }
}
