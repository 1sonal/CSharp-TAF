using OpenQA.Selenium;

namespace CSharpTAF.PageFactory.Desktop_View
{
    public class CustomerPageDesktopView
    {
        By btnAddNew = By.XPath("//a[@class='btn btn-primary']");
        By successAlert = By.XPath("//div[@class='alert alert-success alert-dismissable']");
        public bool clickAddNewBtn() {
            if (Pojo.getTestUtils().IsElementVisible(btnAddNew)) {
                Pojo.getTestUtils().ClickElement(btnAddNew);
                return true;
            }
            return false;
        }
        public bool verifyCustomerAdded() {
            if (Pojo.getTestUtils().IsElementVisible(successAlert)) {
                return true;
            }
            return false;
        }
    }
}
