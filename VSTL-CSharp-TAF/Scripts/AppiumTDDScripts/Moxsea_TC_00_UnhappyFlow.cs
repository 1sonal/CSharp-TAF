using CSharpTAF.PageFactory.AndriodView;
using NUnit.Framework;

namespace CSharpTAF.Scripts.AppiumTDDScripts
{

    public class Moxsea_TC_00_UnhappyFlow : AndroidDriver
    {
        LoginPageAndroidView loginPage_Android;
        string username;
        string password;

        [SetUp]
        public void InitialiseEnvironment()
        {

            InitDriver();
            loginPage_Android = new LoginPageAndroidView();
        }

        [Test]
        public void moxsea_TC_00_UnhappyFlow()
        {
            Pojo.getExtentHelper().CreateTest(TestContext.CurrentContext.Test.MethodName.Trim());

            Pojo.getExcelUtils().ReadExcelData(TestContext.CurrentContext.Test.MethodName.Trim());
            username = Pojo.getExcelUtils().GetTestData("Username");
            password = Pojo.getExcelUtils().GetTestData("Password");
            Pojo.getTestUtilities().logReporter(loginPage_Android.VerifyLoginPage(), "User is on Login page");
            Pojo.getTestUtilities().logReporter(loginPage_Android.EnterUserName(username), "Username Successfully entered");
            Pojo.getTestUtilities().logReporter(loginPage_Android.EnterPassword(password), "Password Successfully entered");
            Pojo.getTestUtilities().logReporter(loginPage_Android.ClickOnLoginBtn(), "Successfully clicked on login button");
            Pojo.getTestUtilities().logReporter(loginPage_Android.VerifyLoginPage(), "User not able to login");
        
        }

        [TearDown]
        public void CloseEnvironment()
        {
            Pojo.getExtentHelper().InsertReportingSteps();

            CloseDriver();

        }

    }
}
