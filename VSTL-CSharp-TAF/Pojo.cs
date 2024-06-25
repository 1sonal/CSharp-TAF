using CSharpTAF.WrapperFunctions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace CSharpTAF
{
    public class Pojo
    {
        private static AndroidDriver<AndroidElement> AppiumDriver;
        public static AndroidDriver<AndroidElement> getDriver()
        {
            return AppiumDriver;
        }
        public static void setDriver(AndroidDriver<AndroidElement> AppiumDriver)
        {
            Pojo.AppiumDriver = AppiumDriver;
        }

        private static ExcelUtils excelUtils;
        public static ExcelUtils getExcelUtils()
        {
            return excelUtils;
        }

        public static void setExcelUtils(ExcelUtils excelUtils)
        {
            Pojo.excelUtils = excelUtils;
        }

        private static TestUtilities testUtilities;
        public static TestUtilities getTestUtilities()
        {
            return testUtilities;
        }

        public static void setTestUtilities(TestUtilities testUtilities)
        {
            Pojo.testUtilities = testUtilities;
        }
        private static ExtentHelper extentHelper;

        public static ExtentHelper getExtentHelper()
        {
            return extentHelper;
        }

        public static void setExtentHelper(ExtentHelper extentHelper)
        {
            Pojo.extentHelper = extentHelper;
        }
        private static TestUtils testUtils;
        public static TestUtils getTestUtils()
        {
            return testUtils;
        }
        public static void setTestUtils(TestUtils testUtils)
        {
            Pojo.testUtils = testUtils;
        }
        private static IWebDriver Driver;
        public static IWebDriver GetDriver()
        {
            return Driver;
        }
        public static void SetDriver(IWebDriver driver)
        {
            Driver = driver;
        }


    }
}
