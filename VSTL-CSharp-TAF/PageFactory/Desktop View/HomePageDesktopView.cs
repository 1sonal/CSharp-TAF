using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace CSharpTAF.PageFactory.Desktop_View
{
    public class HomePageDesktopView
    {
        public bool VerifyHomePage() {
            if (Pojo.getTestUtils().verifyPageTitle("Dashboard"))
            {
                return true;
            }
            return false;   
        }
        public bool verifyLHSMenu(String menu)
        {
            By locator = By.XPath("(//li[@class='nav-item has-treeview']//p[contains(text(),'" + menu + "')])[1]");
            if (Pojo.getTestUtils().IsElementVisible(locator)) {
                return true;
            }
            return false;
        }
        public bool ClickMenuOnDashboard(string menu) {
            By locator = By.XPath("(//li[@class='nav-item has-treeview']//p[contains(text(),'" + menu + "')])[1]");
            if (Pojo.getTestUtils().IsElementVisible(locator)) {
                Pojo.getTestUtils().ClickElement(locator);
                return true;
            }
            return false;
        }
        public bool ClickSubMenuOnDashboard(string subMenu)
        {
            By locator = By.XPath("(//ul[@class='nav nav-treeview']//p[contains(text(),'" + subMenu + "')])[1]");
            if (Pojo.getTestUtils().IsElementVisible(locator))
            {
                Pojo.getTestUtils().ClickElement(locator);
                return true;
            }
            return false;
        }

        public bool verifyLHSMenuFromTextFile(string txtFile)
        {
            IList<IWebElement> list = Pojo.GetDriver().FindElements(By.XPath("//p[contains(text(),'Dashboard')]//parent::a/parent::li/following-sibling::li/a/p"));
            string[] ValuesFromTxtFile = Pojo.getTestUtils().GetDataFromTextFile(txtFile);
           
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].Text.Trim());
                string s1 = list[i].Text.Trim();
                string s2 = ValuesFromTxtFile[i];
                if (s1.Equals(s2)) {
                    Console.WriteLine(s1 + " is present as LHS menu");
                }
            }
            return true;
        }

    }
}
