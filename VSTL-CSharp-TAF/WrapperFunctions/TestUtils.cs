using System;
using System.IO;
using System.Text;
using System.Threading;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSharpTAF.WrapperFunctions
{//Wrapper methods used for UI
    public class TestUtils
    {
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
        public IWebElement WaitUntilElementVisible(By locator)
        {

            string timeOutSeconds = readConfigFile("TimeOutSeconds");

            WebDriverWait wait = new WebDriverWait(Pojo.GetDriver(), TimeSpan.FromSeconds(int.Parse(timeOutSeconds)));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            return element;
        }

        /**
	     * @Description : This is wrapper method to verify page title
	     * @param :
	     *            strTitle - strTitle as string
	     * @return : - true if verified 
	     */
        public bool verifyPageTitle(String strTitle)
        {
            bool returnValue = false;
            string title = Pojo.GetDriver().Title;
            try
            {
                if (title.Contains(strTitle))
                {
                    returnValue = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
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
        public bool setText(By locator, string fieldValue)
        {
            bool returnValue = false;
            try
            {
                WaitUntilElementVisible(locator).Clear();
                WaitUntilElementVisible(locator).SendKeys(fieldValue);
            
                returnValue = true;
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

        //generate random numbers between two numbers
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
            {
                return builder.ToString().ToLower();
            }
            return builder.ToString();
        }

        //generate random alphanumeric string
        public string RandomAlphaNumberic()
        {
            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }

        //Generates random email Id
        public string GenerateRandomEmailAddress()
        {
            return "Autoscript" + RandomNumber(10000, 99999) + "@" + RandomString(5, true) + "mail.com";
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
                ExtentHelper.SetStepStatusPass(msg);
                Assert.IsTrue(condition, msg);
                if (screenShotReqd == true)
                {
                    ExtentHelper.AddPassScreeshot();
                }
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        // get data from text file
        public string[] GetDataFromTextFile(string textFile)
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;

            string file = projectPath + @"Text Files\" + textFile + ".txt";
            string[] lines = null;
            try
            {
                if (File.Exists(file))
                {
                    // Store each line in array of strings 
                    lines = File.ReadAllLines(file);
                   
                    return lines;
                }
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
               
            }
            return lines;




        }
    }
}
