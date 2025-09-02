using System;
using System.Collections.Generic;
using System.Linq;
using CSharpTAF.PageFactory.Desktop_View;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CSharpTAF.Desktop_Steps_definations
{
    [Binding]
    public class Steps_VerifyLHSMenu
    {
        HomePageDesktopView objHomePageDesktopView = new HomePageDesktopView();
        [Given(@"User is on home page")]
        public void GivenUserIsOnHomePage()
        {
            objHomePageDesktopView.VerifyHomePage();

        }

        [Given(@"User can verify following menu")]
        public void GivenUserCanVerifyFollowingMenu(Table table)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Dictionary<string, string> tableValues = table.Rows[i].ToDictionary(r => r.Key, r => r.Value);
                objHomePageDesktopView.verifyLHSMenu(tableValues.Last().Value);
                Console.WriteLine(tableValues.Last().Value + " menu Verified Successfully");
               
            }
        }
        [Then(@"User can verify following menu")]
        public void ThenUserCanVerifyFollowingMenu(Table table)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Dictionary<string, string> tableValues = table.Rows[i].ToDictionary(r => r.Key, r => r.Value);
                Assert.IsTrue(objHomePageDesktopView.verifyLHSMenu(tableValues.Last().Value), tableValues.Last().Value + " menu Verified Successfully");
           
            }

           
        }
        
    }
   
}
