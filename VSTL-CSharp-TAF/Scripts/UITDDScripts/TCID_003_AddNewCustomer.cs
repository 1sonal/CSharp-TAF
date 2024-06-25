using CSharpTAF.PageFactory.Desktop_View;
using NUnit.Framework;

namespace CSharpTAF.Scripts.UITDDScripts
{
    public class TCID_003_AddNewCustomer : DesktopDriver
    {
        LoginPageDesktopView loginPageDesktopView;
        HomePageDesktopView homePageDesktopView;
        CustomerPageDesktopView customerPageDesktopView;
        AddNewCustomerPageDesktopView addNewCustomerPageDesktopView;
        string URL, email, password;
        [SetUp]
        public void InitialiseEnvironment()
        {
            InitDriver();

            loginPageDesktopView = new LoginPageDesktopView();
            homePageDesktopView = new HomePageDesktopView();
            customerPageDesktopView = new CustomerPageDesktopView();
            addNewCustomerPageDesktopView = new AddNewCustomerPageDesktopView();
        }
        [Test]
        public void TCID_003_addNewCustomer()
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
            string strMenu = Pojo.getExcelUtils().GetTestData("strMenu");
            string strSubMenu = Pojo.getExcelUtils().GetTestData("strSubMenu");
            Pojo.getTestUtils().logReporter(homePageDesktopView.ClickMenuOnDashboard(strMenu), "Clicked on Customers menu");
            Pojo.getTestUtils().logReporter(homePageDesktopView.ClickSubMenuOnDashboard(strSubMenu), "Clicked on Customers submenu");
            Pojo.getTestUtils().logReporter(customerPageDesktopView.clickAddNewBtn(), "Clicked on Add New Button");
            Pojo.getTestUtils().logReporter(addNewCustomerPageDesktopView.EnterCustomerDetails("Email"), "Email Id is entered");
            Pojo.getTestUtils().logReporter(addNewCustomerPageDesktopView.EnterCustomerDetails("FirstName"), "First name is entered");
            Pojo.getTestUtils().logReporter(addNewCustomerPageDesktopView.clickOnSaveBtn(), "Clicked on save button");
            Pojo.getTestUtils().logReporter(customerPageDesktopView.verifyCustomerAdded(), "Add new customer is verified");
        }
        [TearDown]
        public void CloseEnvironment()
        {
            Pojo.getExtentHelper().InsertStepsForReporting();

            CloseDriver();

        }

    }
}
