using OpenQA.Selenium;

namespace CSharpTAF.PageFactory.Desktop_View
{
    public class LoginPageDesktopView
    {
        
        By email = By.XPath("//input[@id='Email']");
        By passWord = By.XPath("//input[@id='Password']");
        By loginBtn = By.XPath("//button[text()='Log in']");
        public void verifyLoginPage(string strTitle) {
            Pojo.getTestUtils().verifyPageTitle(strTitle);
        }
        public bool EnterUsername(string strUsername) {
            if (Pojo.getTestUtils().IsElementVisible(email)) {
                Pojo.getTestUtils().setText(email, strUsername);
                return true;
            }
            return false;
        }
        public bool EnterPassword(string strPassword)
        {
            if (Pojo.getTestUtils().IsElementVisible(passWord))
            {
                Pojo.getTestUtils().setText(passWord, strPassword);
                return true;
            }
            return false;
        }
        public bool ClickOnLoginBtn() {
            if (Pojo.getTestUtils().IsElementVisible(loginBtn)) {
                Pojo.getTestUtils().ClickElement(loginBtn);
                return true;
            }
            return false;
        }
    }
}
