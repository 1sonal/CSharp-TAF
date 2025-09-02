using CSharpTAF.PageFactory.AndriodView;
using NUnit.Framework;

namespace CSharpTAF.Scripts.AppiumTDDScripts
{

    public class Moxsea_TC_01_LoginTest : AndroidDriver 
    {
        LoginPageAndroidView loginPage_Android;
       
        [SetUp]
        public void InitialiseEnvironment()
        {

            InitDriver();
            loginPage_Android = new LoginPageAndroidView();
        }
       
        [Test]
        public void moxsea_TC_01_LoginTest()
        {
            Pojo.getExtentHelper().CreateTest(TestContext.CurrentContext.Test.MethodName.Trim());
            Pojo.getExcelUtils().ReadExcelData(TestContext.CurrentContext.Test.MethodName.Trim());
            string UserName = Pojo.getExcelUtils().GetTestData("username");
            string PassWord = Pojo.getExcelUtils().GetTestData("password");
            Pojo.getTestUtilities().logReporter(loginPage_Android.EnterUserName(UserName), "Username Successfully entered");
            Pojo.getTestUtilities().logReporter(loginPage_Android.EnterPassword(PassWord), "Password Successfully entered");
            Pojo.getTestUtilities().logReporter(loginPage_Android.ClickOnLoginBtn(), "Successfully clicked on login button");
            loginPage_Android.CloseAndLaunchAppAgain();
               }
        [TearDown]
        public void CloseEnvironment()
        {
        //    Pojo.getExtentHelper().InsertReportingSteps();
            CloseDriver();

        }

    }
}
