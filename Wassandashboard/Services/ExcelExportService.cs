using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;


namespace Wassandashboard.Services
{
    public class ExcelExportService
    {
        public byte[] GenerateExcelFile<T>(List<T> data, List<string> columnHeaders, Func<T, object[]> dataSelector)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Add headers
                for (int i = 0; i < columnHeaders.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = columnHeaders[i];
                }

                // Add data
                for (int i = 0; i < data.Count; i++)
                {
                    var rowData = dataSelector(data[i]);
                    for (int j = 0; j < rowData.Length; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = rowData[j];
                    }
                }

                return package.GetAsByteArray();
            }
        }
    }
}
