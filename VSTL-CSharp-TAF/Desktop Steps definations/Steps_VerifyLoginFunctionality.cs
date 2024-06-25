using CSharpTAF.PageFactory.Desktop_View;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CSharpTAF.Desktop_Steps_definations
{
    [Binding]
    public class Steps_VerifyLoginFunctionality
    {
        LoginPageDesktopView loginPageDesktopView = new LoginPageDesktopView();
        HomePageDesktopView objHomePageDesktopView = new HomePageDesktopView();
        [Given(@"User is on login page of the website")]
        public void GivenUserIsOnLoginPageOfTheWebsite()
        {
            loginPageDesktopView.verifyLoginPage("Your store. Login");
        }

        [When(@"User logs in using ""([^""]*)"" and ""([^""]*)""")]
        public void WhenUserLogsInUsingAnd(string email, string password)
        {
            email = Pojo.getTestUtils().readConfigFile("EmailId");
            password = Pojo.getTestUtils().readConfigFile("PassWord");
            Assert.IsTrue(loginPageDesktopView.EnterUsername(email),"email is entered");
            Assert.IsTrue(loginPageDesktopView.EnterPassword(password),"password is entered");
        }


        [When(@"clicks on login button")]
        public void WhenClicksOnLoginButton()
        {
            Assert.IsTrue(loginPageDesktopView.ClickOnLoginBtn(),"Click on login button");
            
        }

        [Then(@"home page opens")]
        public void ThenHomePageOpens()
        {
            objHomePageDesktopView.VerifyHomePage();
        }
        [Given(@"User navigate to ""([^""]*)""")]
        public void GivenUserNavigateTo(string URL)
        {
           
            URL = Pojo.getTestUtils().readConfigFile("Url");
            Pojo.GetDriver().Navigate().GoToUrl(URL);
            Pojo.getTestUtils().waitForMilliSeconds(2000);
           
        }


    }
}
