using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace CSharpTAF

{
    public abstract class BaseDriverHelper 
    {
        public static IWebDriver Driver;
    
        public static AndroidDriver<AndroidElement> AppiumDriver;
        public static AppiumOptions options;
        public static ExtentReports extent;
  
        public abstract void InitDriver();
        public abstract void CloseDriver();
        public static ExtentTest test { get; set; }

    }
}
