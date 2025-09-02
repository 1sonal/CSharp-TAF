using CSharpTAF.PageFactory.Desktop_View;
using NUnit.Framework;

namespace CSharpTAF.Scripts.UITDDScripts
{
    public class TCID_002_VerifyLHSMenu : DesktopDriver
    {
        LoginPageDesktopView loginPageDesktopView;
        HomePageDesktopView homePageDesktopView;
        string URL, email, password;
        [SetUp]
        public void InitialiseEnvironment()
        {
            InitDriver();
            loginPageDesktopView = new LoginPageDesktopView();
            homePageDesktopView = new HomePageDesktopView();
        }
        [Test]
        public void TCID_002_verifyLHSMenu()
        {
            Pojo.getExtentHelper().CreateTest(TestContext.CurrentContext.Test.MethodName.Trim());
            Pojo.getExcelUtils().ReadExcelData(TestContext.CurrentContext.Test.MethodName.Trim());
            URL = Pojo.getTestUtils().readConfigFile("Url");
            Pojo.GetDriver().Navigate().GoToUrl(URL);
            Pojo.getTestUtils().waitForMilliSeconds(2000);
            email = Pojo.getTestUtils().readConfigFile("EmailId");
            password = Pojo.getTestUtils().readConfigFile("PassWord");
            Pojo.getTestUtils().logReporter(loginPageDesktopView.EnterUsername(email), "email is entered");
            Pojo.getTestUtils().logReporter(loginPageDesktopView.EnterPassword(password), "password is entered");
            Pojo.getTestUtils().logReporter(loginPageDesktopView.ClickOnLoginBtn(), "Click on login button");
            Pojo.getTestUtils().logReporter(homePageDesktopView.VerifyHomePage(), "On Home Page");
            string strTxtFileName = Pojo.getExcelUtils().GetTestData("strTextFileName");
            Pojo.getTestUtils().logReporter(homePageDesktopView.verifyLHSMenuFromTextFile(strTxtFileName), "LHS menu verified");

        }
        [TearDown]
        public void CloseEnvironment()
        {
            Pojo.getExtentHelper().InsertStepsForReporting();

            CloseDriver();

        }
    }
}
