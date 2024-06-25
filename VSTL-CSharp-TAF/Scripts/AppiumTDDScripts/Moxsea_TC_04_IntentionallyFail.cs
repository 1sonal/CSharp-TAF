using CSharpTAF.PageFactory.AndriodView;
using NUnit.Framework;

namespace CSharpTAF.Scripts.AppiumTDDScripts
{
    public class Moxsea_TC_04_IntentionallyFail : AndroidDriver
    {
        LoginPageAndroidView loginPage_Android;
        DashboardPageAndroidView objDashboardPage_Android;
        MOXSEAPageAndroidView objMOXSEAPage_Android;
        BookABoatPageAndroidView objBookABoatPage_Android;

        [SetUp]
        public void InitialiseEnvironment()
        {

            InitDriver();
            loginPage_Android = new LoginPageAndroidView();
            objDashboardPage_Android = new DashboardPageAndroidView();
            objMOXSEAPage_Android = new MOXSEAPageAndroidView();
            objBookABoatPage_Android = new BookABoatPageAndroidView();
        }

        [Test]
        public void moxsea_TC_04_IntentionallyFail()
        {
            Pojo.getExtentHelper().CreateTest(TestContext.CurrentContext.Test.MethodName.Trim());
            Pojo.getExcelUtils().ReadExcelData(TestContext.CurrentContext.Test.MethodName.Trim());
            string option = Pojo.getExcelUtils().GetTestData("option");
            string header1 = Pojo.getExcelUtils().GetTestData("Header1");
            string header2 = Pojo.getExcelUtils().GetTestData("Header2");
            string header3 = Pojo.getExcelUtils().GetTestData("Header3");
            string header4 = Pojo.getExcelUtils().GetTestData("Header4");
            Pojo.getTestUtilities().logReporter(objDashboardPage_Android.clickOption(option), "Clicked on " + option);
            Pojo.getTestUtilities().logReporter(objMOXSEAPage_Android.ClickOnBookABoatOption(), "Clicked on 'Book A Boat' option");
            Pojo.getTestUtilities().logReporter(objBookABoatPage_Android.verifyHeaderPresent(header1), header1 + " header is verified Successfully");
            Pojo.getTestUtilities().logReporter(objBookABoatPage_Android.verifyHeaderPresent(header2), header2 + " header is verified Successfully");
            Pojo.getTestUtilities().logReporter(objBookABoatPage_Android.verifyHeaderPresent(header3), header3 + " header is verified Successfully");
            Pojo.getTestUtilities().logReporter(objBookABoatPage_Android.verifyHeaderPresent(header4), header4 + " header is verified Successfully");
        
        }
        [TearDown]
        public void CloseEnvironment()
        {
            Pojo.getExtentHelper().InsertReportingSteps();
            CloseDriver();

        }

    }
}
