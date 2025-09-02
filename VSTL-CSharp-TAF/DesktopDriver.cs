using System;
using System.IO;
using CSharpTAF.WrapperFunctions;
using OpenQA.Selenium.Chrome;

namespace CSharpTAF
{
    public class DesktopDriver : BaseDriverHelper
    {
        TestUtils testUtils;
        ExcelUtils excelUtils;
        private readonly static string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        private readonly static string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
        private readonly static string projectPath = new Uri(actualPath).LocalPath;
        public override void InitDriver()
        {
                  
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Pojo.SetDriver(Driver);
            testUtils = new TestUtils();
            Pojo.setTestUtils(testUtils);
            excelUtils = new ExcelUtils(Path.Combine(projectPath, @"ExcelFiles\UITestDataSheet.xlsx"));
            Pojo.setExcelUtils(excelUtils);
        }
        public override void CloseDriver()
        {
            Driver.Quit();
        }
    }
}
