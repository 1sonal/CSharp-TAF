using OpenQA.Selenium;

namespace CSharpTAF.PageFactory.AndriodView
{
    public class MOXSEAPageAndroidView
    {
        By BookABoatOption=By.XPath("(//android.view.ViewGroup/com.horcrux.svg.SvgView)[3]");
        public bool ClickOnBookABoatOption() {
            Pojo.getTestUtilities().waitForMilliSeconds(3000);
            if (Pojo.getTestUtilities().IsElementVisible(BookABoatOption)) {
                Pojo.getTestUtilities().ClickElement(BookABoatOption);
                return true;
            }
            return false;
            
        }
    }
}
