using System;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CSharpTAF.WrapperFunctions
{

    public class ExtentHelper
    {
       
        private static ExtentReports extent;
        private readonly static string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        private readonly static string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
        private readonly static string projectPath = new Uri(actualPath).LocalPath;
        public static ExtentTest test { get; set; }

        public void InitializeReport()
        {
            Console.WriteLine("Report started");
            
            var htmlReporter = new ExtentV3HtmlReporter(projectPath + @"Reports\Index.html");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            htmlReporter.LoadConfig(projectPath + @"ConfigXMLFiles\\ReportsConfig.xml");
            //prevoius report clearance
            string sourceFile = projectPath + "\\Reports\\";
            string directory = Path.GetDirectoryName(sourceFile);
            if (Directory.Exists(directory))
            {
                Directory.Delete(directory, true);

            }
            Directory.CreateDirectory(directory);
        }
        public void TearDownReport()
        {
           
            extent.Flush();
            
            string sourceFile1 = projectPath + @"Reports\\index.html";
            FileInfo fi = new FileInfo(sourceFile1);
            if (fi.Exists)
            {
               
                string destination = projectPath + @"Reports\AutomationReport_" + DateTime.Now.ToString().Replace("/", "_").Replace(" ", "_").Replace(":", "_") + ".html";
                fi.MoveTo(destination);
               
            }

            
        }
        public void CreateTest(string testName)
        {
            test = extent.CreateTest(testName);
        }
        public static void SetStepStatusPass(string stepDescription)
        {
            test.Log(Status.Pass, stepDescription);
        }
        public static void SetStepStatusWarning(string stepDescription)
        {
            test.Log(Status.Warning, stepDescription);
        }
        public static void SetTestStatusFail(string message = null)
        {
            var printMessage = "<p><b>Test FAILED!</b></p>";
            if (!string.IsNullOrEmpty(message))
            {
                printMessage += $"Message: <br>{message}<br>";
            }
            test.Fail(printMessage);
        }
        public static void AddTestFailureScreenshot(string base64ScreenCapture)
        {
            test.AddScreenCaptureFromBase64String(base64ScreenCapture, "Screenshot on Error:");
        }
        public static void AddTestPassScreeshot()
        {
            var mediaEntity = new ParallelConfigForAndroid().CaptureScreenshotAndReturnModelForAppium(TestContext.CurrentContext.Test.MethodName.Trim());
        
            test.Log(Status.Pass, mediaEntity);
        }
        public static void SetTestStatusSkipped()
        {
            test.Skip("Test skipped!");
        }
        public static void SetTestStatusPass()
        {
       
            test.Pass("Test Executed Sucessfully!");
        }
        //For Appium
        public void InsertReportingSteps()
        {
            
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = TestContext.CurrentContext.Result.StackTrace;
                var errorMessage = "<pre>" + TestContext.CurrentContext.Result.Message + "</pre>";
                var screenshot = ((ITakesScreenshot)Pojo.getDriver()).GetScreenshot();
               
                
                var filePath = projectPath + "\\FailedTestcases\\";
                var passedTCFilePath = projectPath + "\\PassedTestcases\\";
                var mediaEntity = new ParallelConfigForAndroid().CaptureScreenshotAndReturnModelForAppium(TestContext.CurrentContext.Test.MethodName.Trim());
                switch (status)
                {
                    case TestStatus.Failed:
                       
                        SetTestStatusFail($"<br>{errorMessage}<br>Stack Trace: <br>{stacktrace}<br>");
                        var filePath1 = filePath + "\\" + TestContext.CurrentContext.Test.MethodName.Trim() + "\\";
                        string directory = Path.GetDirectoryName(filePath1);
                        if (Directory.Exists(directory))
                        {
                            Directory.Delete(directory, true);

                        }
                        Directory.CreateDirectory(directory);
                        screenshot.SaveAsFile(Path.Combine(filePath1, "screenshot" + DateTime.Now.ToString().Replace("/", "_").Replace(" ", "_").Replace(":", "_") + ".png"));
                        AddTestFailureScreenshot(Path.Combine(filePath1, "screenshot" + DateTime.Now.ToString().Replace("/", "_").Replace(" ", "_").Replace(":", "_") + ".png"));
                        test.Log(Status.Fail, mediaEntity);
                        break;
                    case TestStatus.Skipped:
                        SetTestStatusSkipped();
                        break;
                    default:
                        
                        var filePath2 = passedTCFilePath + "\\" + TestContext.CurrentContext.Test.MethodName.Trim() + "\\";
                        string directory1 = Path.GetDirectoryName(filePath2);
                        if (Directory.Exists(directory1))
                        {
                            Directory.Delete(directory1, true);

                        }
                        Directory.CreateDirectory(directory1);
                        screenshot.SaveAsFile(Path.Combine(filePath2, "screenshot" + DateTime.Now.ToString().Replace("/", "_").Replace(" ", "_").Replace(":", "_") + ".png"));
                        SetTestStatusPass();
                        break;
                }
            }
            catch (Exception e)
            {
              
                Console.WriteLine(e);
            }

        }
        public static void addFailedScreenshot() {
            var mediaEntity = new ParallelConfigForAndroid().CaptureScreenshotAndReturnModelForAppium(ScenarioContext.Current.ScenarioInfo.Title.Trim());
        
            test.CreateNode(TestContext.CurrentContext.Result.Message).Fail(TestContext.CurrentContext.Result.StackTrace, mediaEntity);
        }
        //For UI
        public void InsertStepsForReporting()
        {

            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = TestContext.CurrentContext.Result.StackTrace;
                var errorMessage = "<pre>" + TestContext.CurrentContext.Result.Message + "</pre>";
                var screenshot = ((ITakesScreenshot)Pojo.GetDriver()).GetScreenshot();


                var filePath = projectPath + "\\FailedTestcases\\";
                var passedTCFilePath = projectPath + "\\PassedTestcases\\";
                var mediaEntity = new ParallelConfigForDesktop().CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.MethodName.Trim());
                switch (status)
                {
                    case TestStatus.Failed:
                        
                        SetTestStatusFail($"<br>{errorMessage}<br>Stack Trace: <br>{stacktrace}<br>");
                        var filePath1 = filePath + "\\" + TestContext.CurrentContext.Test.MethodName.Trim() + "\\";
                        string directory = Path.GetDirectoryName(filePath1);
                        if (Directory.Exists(directory))
                        {
                            Directory.Delete(directory, true);

                        }
                        Directory.CreateDirectory(directory);
                        screenshot.SaveAsFile(Path.Combine(filePath1, "screenshot" + DateTime.Now.ToString().Replace("/", "_").Replace(" ", "_").Replace(":", "_") + ".png"));
                        AddTestFailureScreenshot(Path.Combine(filePath1, "screenshot" + DateTime.Now.ToString().Replace("/", "_").Replace(" ", "_").Replace(":", "_") + ".png"));
                        test.Log(Status.Fail, mediaEntity);
                        break;
                    case TestStatus.Skipped:
                        SetTestStatusSkipped();
                        break;
                    default:
                        SetTestStatusPass();
                        var filePath2 = passedTCFilePath + "\\" + TestContext.CurrentContext.Test.MethodName.Trim() + "\\";
                        string directory1 = Path.GetDirectoryName(filePath2);
                        
                        if (Directory.Exists(directory1))
                        {
                            Directory.Delete(directory1, true);

                        }
                        Directory.CreateDirectory(directory1);
                       
                            
                        screenshot.SaveAsFile(Path.Combine(filePath2, "screenshot" + DateTime.Now.ToString().Replace("/", "_").Replace(" ", "_").Replace(":", "_") + ".png"));
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
              
            }

        }
        public static void AddPassScreeshot()
        {
            var mediaEntity = new ParallelConfigForDesktop().CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.MethodName.Trim());

            test.Log(Status.Pass, mediaEntity);
        }
    }
}
