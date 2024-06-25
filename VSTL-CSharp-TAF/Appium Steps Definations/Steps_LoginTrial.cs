using System.Linq;
using CSharpTAF.PageFactory.AndriodView;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CSharpTAF.Appium_Steps_Definations
{
    [Binding]
    public class Steps_LoginTrial
    {
        public LoginPageAndroidView objLoginPage_Android = new LoginPageAndroidView();
        public DashboardPageAndroidView objDashboardPage_Android = new DashboardPageAndroidView();

        [Given(@"Login page is open")]
        public void GivenLoginPageIsOpen()
        {

            Assert.IsTrue(objLoginPage_Android.VerifyLoginPage(), "User is on Login page");
        }

        [When(@"User enters username and password")]
        public void WhenUserEntersUsernameAndPassword(Table table)
        {

            var dictionary = Pojo.getTestUtilities().ToDictionary(table);
            if (dictionary.First().Key == "username")
            {
                Assert.IsTrue(objLoginPage_Android.EnterUserName(dictionary.First().Value), "Username Successfully enterred");
            }
            if (dictionary.Last().Key == "password")
            {
                Assert.IsTrue(objLoginPage_Android.EnterPassword(dictionary.Last().Value), "Password Successfully entered");
            }
        }


        [When(@"User enters invalid username and valid password")]
        public void WhenUserEntersInvalidUsernameAndValidPassword(Table table)
        {
            var dictionary = Pojo.getTestUtilities().ToDictionary(table);
            if (dictionary.First().Key == "username")
            {
                Assert.IsTrue(objLoginPage_Android.EnterUserName(dictionary.First().Value), "Username Successfully enterred");
            }
            if (dictionary.Last().Key == "password")
            {
                Assert.IsTrue(objLoginPage_Android.EnterPassword(dictionary.Last().Value), "Password Successfully entered");
            }

        }

        [Then(@"User can not login")]
        public void ThenUserCanNotLogin()
        {
            Assert.IsTrue(objLoginPage_Android.VerifyLoginPage(), "User not able to login");
        }
    }
}
