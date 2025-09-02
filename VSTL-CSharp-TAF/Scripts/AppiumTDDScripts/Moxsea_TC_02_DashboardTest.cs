using CSharpTAF.PageFactory.AndriodView;
using NUnit.Framework;

namespace CSharpTAF.Scripts.AppiumTDDScripts
{

    public class Moxsea_TC_02_DashboardTest : AndroidDriver
    {
        DashboardPageAndroidView objDashboardPage_Android;
        private string activity;

        [SetUp]
        public void InitialiseEnvironment()
        {
            InitDriver();
            objDashboardPage_Android = new DashboardPageAndroidView();
        }

        [Test]
        public void moxsea_TC_02_DashboardTest()
        {
            Pojo.getExtentHelper().CreateTest(TestContext.CurrentContext.Test.MethodName.Trim());
            Pojo.getExcelUtils().ReadExcelData(TestContext.CurrentContext.Test.MethodName.Trim());
            Pojo.getTestUtilities().logReporter(objDashboardPage_Android.verifyHeaderPresent(), "Header is verified");
            string Option1 = Pojo.getExcelUtils().GetTestData("option1");
            string Option2 = Pojo.getExcelUtils().GetTestData("option2");
            string Option3 = Pojo.getExcelUtils().GetTestData("option3");
            Pojo.getTestUtilities().logReporter(objDashboardPage_Android.verifyOptionPresent(Option1), Option1 + " is verified");
            Pojo.getTestUtilities().logReporter(objDashboardPage_Android.verifyOptionPresent(Option2), Option2 + " is verified");
            Pojo.getTestUtilities().logReporter(objDashboardPage_Android.verifyOptionPresent(Option3), Option3 + " is verified");
        }
        [TearDown]
        public void CloseEnvironment()
        {
            Pojo.getExtentHelper().InsertReportingSteps();
            CloseDriver();

        }

    }
}
