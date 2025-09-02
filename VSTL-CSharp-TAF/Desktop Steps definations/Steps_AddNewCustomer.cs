using CSharpTAF.PageFactory.Desktop_View;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CSharpTAF.Desktop_Steps_definations
{
    [Binding]
    public class Steps_AddNewCustomer
    {
       
        HomePageDesktopView homePageDesktopView = new HomePageDesktopView();
        CustomerPageDesktopView customerPageDesktopView = new CustomerPageDesktopView();
        AddNewCustomerPageDesktopView addNewCustomerPageDesktopView = new AddNewCustomerPageDesktopView();
        [When(@"User click on ""([^""]*)"" menu")]
        public void WhenUserClickOnMenu(string strCustomersMenu)
        {
            Assert.IsTrue(homePageDesktopView.ClickMenuOnDashboard(strCustomersMenu), "Clicked on " + strCustomersMenu + " menu");
        }

        [When(@"click on ""([^""]*)"" submenu")]
        public void WhenClickOnSubmenu(string strCustomersSubMenu)
        {
            Assert.IsTrue(homePageDesktopView.ClickSubMenuOnDashboard(strCustomersSubMenu), "Clicked on " + strCustomersSubMenu + " submenu");
        }


        [When(@"click on Add new button")]
        public void WhenClickOnAddNewButton()
        {
            Assert.IsTrue(customerPageDesktopView.clickAddNewBtn(), "Clicked on Add New Button");
        }

        [When(@"User enter '([^']*)' and '([^']*)'")]
        public void WhenUserEnterAnd(string email, string firstName)
        {
            Assert.IsTrue(addNewCustomerPageDesktopView.EnterCustomerDetails(email), "Email is entered");
            Assert.IsTrue(addNewCustomerPageDesktopView.EnterCustomerDetails(firstName), "FirstName is entered");
        }

        [When(@"User clicks on Save button")]
        public void WhenUserClicksOnSaveButton()
        {
            Assert.IsTrue(addNewCustomerPageDesktopView.clickOnSaveBtn(), "Clicked on save button");
        }

        [Then(@"verify the added customer")]
        public void ThenVerifyTheAddedCustomer()
        {
            Assert.IsTrue(customerPageDesktopView.verifyCustomerAdded(), "The new customer has been added successfully.");
        }


    }
}
