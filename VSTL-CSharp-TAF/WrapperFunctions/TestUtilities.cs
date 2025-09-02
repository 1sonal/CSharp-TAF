using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace CSharpTAF.WrapperFunctions
{//Wrapper methods used for Appium testing
    public class TestUtilities
    {
        /**
        * @Description : This is wrapper method to read value of a key
        *              congif file
        * @param :
        *            key from config file
        * @return : - value of the key
        */
        public string readConfigFile(string key)
        {
            
            var config = new ConfigurationBuilder().AddJsonFile("AppConfig.json").Build();
            string value = config[key];
            return value;
        }

        /**
        * @Description : This is wrapper method to check the web element is visible
        *              on the page
        * @param :
        *            locator - By identification of element
        * @return : - element 
        */
        public AndroidElement WaitUntilElementVisible(By locator)
        {

            string timeOutSeconds = readConfigFile("TimeOutSeconds");

            WebDriverWait wait = new WebDriverWait(Pojo.getDriver(), TimeSpan.FromSeconds(int.Parse(timeOutSeconds)));
            AndroidElement element = (AndroidElement)wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            return element;
        }

        /**
	     * @Method : waitFor
	     * @Description : Waits for the specified amount of [timeInMilliseconds].
	     * @param :
	     *            timeUnitSeconds - wait time seconds
	     */
        public bool waitForMilliSeconds(int timeUnitMilliSeconds)
        {
            try
            {
                Thread.Sleep(timeUnitMilliSeconds);
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return false;
            }
        }

        /**
        * @Method : logReporter
        * @Description : This is wrapper method to log in report
        * @param :
        *            condition - condition as bool
        * @param :
        *            msg - msg as string
        */
        public void logReporter(bool condition, string msg)
        {
            string screenShot = readConfigFile("IsScreenShotReqdAtEveryStep");
            bool screenShotReqd = bool.Parse(screenShot);
            try
            {
                Assert.IsTrue(condition, msg);
                if (screenShotReqd == true)
                {
                    ExtentHelper.AddTestPassScreeshot();//flag for every step,config
                }
                ExtentHelper.SetStepStatusPass(msg);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

        }

        /**
	     * @Method : click
	     * @Description : This is wrapper method to click on web element
	     * @param :
	     *            locator - By identification of element
	     * @return : - true if click successful
	 	 */
        public bool ClickElement(By locator)
        {
            bool returnValue = false;
            try
            {
                WaitUntilElementVisible(locator).Click();

                //    returnValue = true;
            }
            catch (NoSuchElementException e)
            {
                TestContext.WriteLine("Element " + locator + "not found on page ");
                returnValue = false;
            }
            catch (Exception e)
            {
                TestContext.WriteLine("Unknown error " + e.Message + " occurred on page ");
                returnValue = false;
            }
            return returnValue;
        }

        /**
	     * @Description : This is wrapper method to check the web element is
	     *              displayed on the page
	     * @param :
	     *            locator - By identification of element
	     *            
	     * @return : - true if element present
	     */
        public bool IsElementVisible(By locator)
        {
            bool returnValue = false;
            try
            {
                returnValue = WaitUntilElementVisible(locator).Displayed;
            }
            catch (NoSuchElementException e)
            {
                TestContext.WriteLine("Element " + locator + "not found on page ");
                returnValue = false;
            }
            catch (Exception e)
            {
                TestContext.WriteLine("Unknown error " + e.Message + " occurred on page ");
                returnValue = false;
            }
            return returnValue;
        }

        /**
        * @Method : setText
        * @Description : This is wrapper method to set text for input element
        * @param :
        *            locator - By identification of element
        * @param :
        *            fieldValue - field value as string
        * @return : - true if text entered successfully
        */
        public bool setText(By locator, String fieldValue)
        {
            bool returnValue = false;
            try
            {
                WaitUntilElementVisible(locator).SendKeys(fieldValue);
                
            }
            catch (NoSuchElementException e)
            {
                TestContext.WriteLine("Element " + locator + "not found on page ");
                returnValue = false;
            }
            catch (Exception e)
            {
                TestContext.WriteLine("Unknown error " + e.Message + " occurred on page ");
                returnValue = false;
            }
            return returnValue;
        }

        //close and launch App again
        public void closeAndLauchApplication()
        {
            Pojo.getDriver().CloseApp();
            waitForMilliSeconds(4000);
            Pojo.getDriver().LaunchApp();
            waitForMilliSeconds(4000);
        }


        public Dictionary<string, string> ToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);

            }
            return dictionary;


        }

    }
    
}

