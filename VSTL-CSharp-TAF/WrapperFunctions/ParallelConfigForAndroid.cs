using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace CSharpTAF.WrapperFunctions
{
    public class ParallelConfigForAndroid : AndroidDriver
    {
        //captures screenshot for Appium testing
        public MediaEntityModelProvider CaptureScreenshotAndReturnModelForAppium(string Name)
        {
            var screenshot = ((ITakesScreenshot)AppiumDriver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, Name).Build();
        }
    }
}
