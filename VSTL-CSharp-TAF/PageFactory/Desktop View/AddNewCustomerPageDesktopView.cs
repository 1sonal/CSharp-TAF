using System;
using OpenQA.Selenium;

namespace CSharpTAF.PageFactory.Desktop_View
{
    public class AddNewCustomerPageDesktopView
    {
        By btnSave = By.XPath("//button[@name='save']");
        public bool EnterCustomerDetails(string strId) {
            string randomEmail = Pojo.getTestUtils().GenerateRandomEmailAddress();
            string randomName = Pojo.getTestUtils().RandomAlphaNumberic();
            By txtDetail = By.XPath("//input[@id='" + strId + "']");
            Console.WriteLine("strId=" + strId);
            if (strId.Equals("Email"))
            {
                if(Pojo.getTestUtils().IsElementVisible(txtDetail)) {
                    Pojo.getTestUtils().setText(txtDetail, randomEmail);
                    return true;
                }
            }
            if (strId.Equals("FirstName"))
            {
                if (Pojo.getTestUtils().IsElementVisible(txtDetail))
                {
                    Pojo.getTestUtils().setText(txtDetail, randomName);
                    return true;
                }
            }
            return false;
        }
        public bool clickOnSaveBtn() {
            if (Pojo.getTestUtils().IsElementVisible(btnSave)) {
                Pojo.getTestUtils().ClickElement(btnSave);
                return true;
            }
            return false;
        }
    }
}
