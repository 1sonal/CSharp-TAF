using CSharpTAF.WrapperFunctions;
using OpenQA.Selenium;

namespace CSharpTAF.PageFactory.AndriodView
{
    public class LoginPageAndroidView 
    {
        By UserName = By.XPath("//android.widget.EditText[@content-desc='username-input']");
        By Password = By.XPath("//android.widget.EditText[@content-desc='password-input']");
        By LoginBtn = By.XPath("//android.view.ViewGroup[@content-desc='login-button']");
        
        
        public bool EnterUserName(string StrUserName)
        {
            if (Pojo.getTestUtilities().IsElementVisible(UserName)) {
                Pojo.getTestUtilities().setText(UserName, StrUserName);
                return true;
            }
            
            return false;
        }
        public bool EnterPassword(string StrPassword) {
            if (Pojo.getTestUtilities().IsElementVisible(Password))
            {
                Pojo.getTestUtilities().setText(Password, StrPassword);
            
                return true;
            }
            return false;
        }
        public bool ClickOnLoginBtn() {
            if (Pojo.getTestUtilities().IsElementVisible(LoginBtn)) {

                Pojo.getTestUtilities().ClickElement(LoginBtn);
                Pojo.getTestUtilities().waitForMilliSeconds(4000);
                return true;
            }
            return false;
        }
        public void CloseAndLaunchAppAgain()
        {
            Pojo.getTestUtilities().closeAndLauchApplication();
            string framework = Pojo.getTestUtilities().readConfigFile("Framework");
            string screenShot = Pojo.getTestUtilities().readConfigFile("IsScreenShotReqdAtEveryStep");
            bool screenShotReqd = bool.Parse(screenShot);
            if (screenShotReqd == true && framework == "TDD") {
                ExtentHelper.AddTestPassScreeshot();
                ExtentHelper.SetStepStatusPass("App is closed and launched again");
            }
        }
        public bool VerifyLoginPage() {
            if (Pojo.getTestUtilities().IsElementVisible(LoginBtn)) { 
                return true;
            }
            return false;
        }
       
    }
}
