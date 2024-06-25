using CSharpTAF.PageFactory.AndriodView;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CSharpTAF.Appium_Steps_Definations
{
    [Binding]
    public class Steps_DashboardOptions
    {

        DashboardPageAndroidView objDashboardPage_Android = new DashboardPageAndroidView();


        [Given(@"User is on Dashboard page")]
        public void GivenUserIsOnDashboardPage()
        {
            Assert.IsTrue(objDashboardPage_Android.verifyHeaderPresent(), "Header is verified");
        }


        [When(@"User Verify '([^']*)' are visible on Dashboard")]
        public void WhenUserVerifyAreVisibleOnDashboard(string options)
        {

            Assert.IsTrue(objDashboardPage_Android.verifyOptionPresent(options), options + " is verified");
        }


        [Then(@"User Verify '([^']*)' are visible on Dashboard")]
        public void ThenUserVerifyAreVisibleOnDashboard(string options)
        {
            Assert.IsTrue(objDashboardPage_Android.verifyOptionPresent(options), options + " is verified");
        }


    }
}
