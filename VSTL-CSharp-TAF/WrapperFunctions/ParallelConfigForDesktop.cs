using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace CSharpTAF.WrapperFunctions
{
    public class ParallelConfigForDesktop : DesktopDriver
    {
        //captures screenshot for UI testing
        public MediaEntityModelProvider CaptureScreenshotAndReturnModel(string Name)
        {
            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, Name).Build();
        }
    }
}
