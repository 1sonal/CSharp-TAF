using CSharpTAF.PageFactory.AndriodView;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CSharpTAF.Appium_Steps_Definations
{
    [Binding]
    public class Steps_Login
    {
        string UserName;
        string PassWord;
        public LoginPageAndroidView loginPage_Android = new LoginPageAndroidView();
        public DashboardPageAndroidView objDashboardPage_Android = new DashboardPageAndroidView();

        [Given(@"User is on login page")]
        public void GivenUserIsOnLoginPage()
        {

            Assert.IsTrue(loginPage_Android.VerifyLoginPage(), "User is on Login page");
        }

        [When(@"User enters Username and Password")]
        public void WhenUserEntersUsernameAndPassword()
        {
            Assert.IsTrue(loginPage_Android.EnterUserName(UserName), "Username Successfully enterred");
            Assert.IsTrue(loginPage_Android.EnterPassword(PassWord), "Password Successfully entered");
          

        }
        [When(@"User clicks on login button")]
        public void WhenUserClicksOnLoginButton()
        {
            Assert.IsTrue(loginPage_Android.ClickOnLoginBtn(), "Successfully clicked on login button");
        }

        [Then(@"App is launched")]
        public void ThenAppIsLaunched()
        {
            loginPage_Android.CloseAndLaunchAppAgain();

        }

        [Given(@"User loads test data for ""([^""]*)""")]
        public void GivenUserLoadsTestDataFor(string TCIDName)
        {
            
            Pojo.getExcelUtils().ReadExcelData(TCIDName);
            UserName = Pojo.getExcelUtils().GetTestData("username");
            PassWord = Pojo.getExcelUtils().GetTestData("password");
        }

        [When(@"User enters ""([^""]*)"" and ""([^""]*)""")]
        public void WhenUserEntersAnd(string username, string password)
        {
            username = Pojo.getExcelUtils().GetTestData("username");
            password = Pojo.getExcelUtils().GetTestData("password");
            Assert.IsTrue(loginPage_Android.EnterUserName(username), "Username Successfully enterred");
            Assert.IsTrue(loginPage_Android.EnterPassword(password), "Password Successfully entered");
        }
        [When(@"User enters ""([^""]*)"" and ""([^""]*)"" for login")]
        public void WhenUserEntersAndForLogin(string username, string password)
        {
            username = Pojo.getExcelUtils().GetTestData("Username");
            password = Pojo.getExcelUtils().GetTestData("Password");
            Assert.IsTrue(loginPage_Android.EnterUserName(username), "Username Successfully enterred");
            Assert.IsTrue(loginPage_Android.EnterPassword(password), "Password Successfully entered");
        }
    }



}
