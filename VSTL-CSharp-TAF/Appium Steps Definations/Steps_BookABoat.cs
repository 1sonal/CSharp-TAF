using System.Collections.Generic;
using System.Linq;
using CSharpTAF.PageFactory.AndriodView;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CSharpTAF.Appium_Steps_Definations
{
    [Binding]
    public class Steps_BookABoat
    {
        string Options;
        DashboardPageAndroidView objDashboardPage_Android = new DashboardPageAndroidView();
        MOXSEAPageAndroidView objMOXSEAPage_Android = new MOXSEAPageAndroidView();
        BookABoatPageAndroidView objBookABoatPage_Android = new BookABoatPageAndroidView();

        [When(@"User click on a option on dashboard")]
        public void WhenUserClickOnAOptionOnDashboard()
        {
           
            Assert.IsTrue(objDashboardPage_Android.clickOption(Options), "Clicked on " + Options);
         
        }
        [When(@"User click on Book a boat option")]
        public void WhenUserClickOnBookABoatOption()
        {
            Assert.IsTrue(objMOXSEAPage_Android.ClickOnBookABoatOption(), "Clicked on 'Book A Boat' option");
        }



        [Given(@"User gets test data for ""([^""]*)""")]
        public void GivenUserGetsTestDataFor(string TCIDName)
        {
           
            Pojo.getExcelUtils().ReadExcelData(TCIDName);
            Options = Pojo.getExcelUtils().GetTestData("option");
            
        }


        [Then(@"User verify Headers on Book A Boat Page")]
        public void ThenUserVerifyHeadersOnBookABoatPage(Table table)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Dictionary<string, string> tableValues = table.Rows[i].ToDictionary(r => r.Key, r => r.Value);
                Assert.IsTrue(objBookABoatPage_Android.verifyHeaderPresent(tableValues.Last().Value), tableValues.Last().Value + " Header Verified Successfully");
            }
        }


    }
}
