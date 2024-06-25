using System;
using OpenQA.Selenium;

namespace CSharpTAF.PageFactory.AndriodView
{
    public class DashboardPageAndroidView
    {
        By Header = By.XPath("//android.widget.TextView[@text='Choose Boat Club']");
        public bool verifyHeaderPresent()
        {
            if (Pojo.getTestUtilities().IsElementVisible(Header)) {
                return true;
            }
            return false;
        }
        public bool verifyOptionPresent(string strOption)
        {
            By loc = By.XPath("//android.view.ViewGroup[@content-desc='" + strOption + "']");
            if (Pojo.getTestUtilities().IsElementVisible(loc)) {
                Console.WriteLine(strOption + " is verified");
                return true;
            }
            return false;
        }

        public bool clickOption(string strOption) {
            By option = By.XPath("//android.view.ViewGroup[@content-desc='" + strOption + "']");
            if (Pojo.getTestUtilities().IsElementVisible(option)) {
                Pojo.getTestUtilities().ClickElement(option);
                return true;
            }
            return false;
        }
    }
}
