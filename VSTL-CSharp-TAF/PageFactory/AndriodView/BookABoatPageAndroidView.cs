using System;
using OpenQA.Selenium;

namespace CSharpTAF.PageFactory.AndriodView
{
    public class BookABoatPageAndroidView
    {
        public bool verifyHeaderPresent(string strText)
        {
            Pojo.getTestUtilities().waitForMilliSeconds(2000);
            By loc = By.XPath("//android.widget.TextView[@text='" + strText + "']");
            if (Pojo.getTestUtilities().IsElementVisible(loc)) {
                Pojo.getTestUtilities().waitForMilliSeconds(1000);
                Console.WriteLine(strText + " header is visible");
                return true;
            }
            return false;
        }
    }
}
