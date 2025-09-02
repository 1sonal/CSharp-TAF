using System;
using System.IO;
using CSharpTAF.WrapperFunctions;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace CSharpTAF
{

    public class AndroidDriver : BaseDriverHelper
    {

        ExcelUtils excelUtils;
        TestUtilities testUtilities;
        private readonly static string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        private readonly static string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
        private readonly static string projectPath = new Uri(actualPath).LocalPath;

        public override void InitDriver()
        {
            //    excelUtils = new ExcelUtils();
            excelUtils = new ExcelUtils(Path.Combine(projectPath, @"ExcelFiles\MobileTestDataSheet.xlsx"));
            Pojo.setExcelUtils(excelUtils);
            testUtilities = new TestUtilities();
            Pojo.setTestUtilities(testUtilities);
            options = new AppiumOptions();
            string DeviceName = Pojo.getTestUtilities().readConfigFile("DeviceName");
            string PlatformVersion = Pojo.getTestUtilities().readConfigFile("PlatformVersion");
            string AutomationName = Pojo.getTestUtilities().readConfigFile("AutomationName");
            string Udid = Pojo.getTestUtilities().readConfigFile("Udid");
            string PlatformName = Pojo.getTestUtilities().readConfigFile("PlatformName");
            string URI = Pojo.getTestUtilities().readConfigFile("URI");
            string AppPackage = Pojo.getTestUtilities().readConfigFile("AppPackage");
            string AppActivity = Pojo.getTestUtilities().readConfigFile("AppActivity");
            options.AddAdditionalCapability("deviceName", DeviceName);
            options.AddAdditionalCapability("platformVersion", PlatformVersion);
            options.AddAdditionalCapability("automationName", AutomationName);
            options.AddAdditionalCapability("udid", Udid);
            options.AddAdditionalCapability("platformName", PlatformName);
            //    options.AddAdditionalCapability("app", projectPath + @"Resources\\app-release.apk");
            //    options.AddAdditionalCapability("fullReset", true);
            //options.AddAdditionalCapability("NoReset", false);
            //options.AddAdditionalCapability("pre-launch", true);
            //options.AddAdditionalCapability("session-override", true);

            options.AddAdditionalCapability("appPackage", AppPackage);
            options.AddAdditionalCapability("appActivity", AppActivity);
            options.AddAdditionalCapability("fastReset", true);
            options.AddAdditionalCapability("noReset", true);
            Uri url = new Uri(URI);
            AppiumDriver = new AndroidDriver<AndroidElement>(url, options);
            AppiumDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Pojo.setDriver(AppiumDriver);
            
            


        }
        
        public override void CloseDriver()
        {
            
            AppiumDriver.Quit();
        
            
        }
       
    }
}
