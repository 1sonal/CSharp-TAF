using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;

namespace CSharpTAF.WrapperFunctions
{
    public class ExcelUtils
    {
        public string path;
       
        static Dictionary<string, string> testData = new Dictionary<string, string>();
        public ExcelUtils(string path) {
            this.path = path;
        }
        public Dictionary<string, string> ReadExcelData(string testCaseID)
        {
            int TCRowNum = 2;
            Dictionary<string, int> TCID = new Dictionary<string, int>();
            using (var package = new ExcelPackage(new FileInfo(path)))
            {
                var worksheet = package.Workbook.Worksheets["Sheet1"];
                while (true)
                {
                    var cell = worksheet.Cells[TCRowNum, 1];
                    string TCValue = cell.Text;
                    if (string.IsNullOrEmpty(TCValue))
                    {
                        break;
                    }
                    TCID[TCValue] = TCRowNum;
                    TCRowNum += 2;
                }
                int TCIDRowNum = TCID[testCaseID];
                int columnNum = 1;
                var keyRow = worksheet.Cells[TCIDRowNum - 1, columnNum];
                var valueRow = worksheet.Cells[TCIDRowNum, columnNum];
                while (true)
                {
                    string key = keyRow.Text;
                    string value = valueRow.Text;
                    if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value))
                    {
                        break;
                    }
                    testData[key] = value;
                    columnNum++;
                    keyRow = worksheet.Cells[TCIDRowNum - 1, columnNum];
                    valueRow = worksheet.Cells[TCIDRowNum, columnNum];
                }
            }
            return testData;
        }

        public string GetTestData(string strKey)
        {
            if (testData.ContainsKey(strKey))
            {
                return testData[strKey];
            }
            return null;
        }




















       

    }
}

