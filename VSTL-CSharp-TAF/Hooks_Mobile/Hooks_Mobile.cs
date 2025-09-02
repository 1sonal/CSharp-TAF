using System;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using CSharpTAF.WrapperFunctions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CSharpTAF.Hooks_Mobile
{
//    [Binding]
    public sealed class Hooks_Mobile : AndroidDriver
    {
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        private readonly static string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        private readonly static string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
        private readonly static string projectPath = new Uri(actualPath).LocalPath;

        [BeforeTestRun]
        public static void InitializeReport()
        {        
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
        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
            string sourceFile = projectPath + @"Reports\Index.html";
            FileInfo fi = new FileInfo(sourceFile);
            if (fi.Exists)
            {
                string destination = projectPath + @"Reports\AutomationReport_" + DateTime.Now.ToString().Replace("/", "_").Replace(" ", "_").Replace(":", "_") + ".html";
                fi.MoveTo(destination);
               
            }
        }
        [BeforeFeature]
        public static void BeforeFeature()
        {
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }
        [AfterStep]
        public void InsertReportingSteps()
        {
            var screenshot = ((ITakesScreenshot)AppiumDriver).GetScreenshot();
            var filePath = projectPath + "\\FailedTestcases\\";

            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            var passedTCFilePath = projectPath + "\\PassedTestcases\\";

            string ScreenShot = Pojo.getTestUtilities().readConfigFile("IsScreenShotReqdAtEveryStep");
            bool screenShotReqd = bool.Parse(ScreenShot);
            
            if (ScenarioContext.Current.TestError == null)
            {
                var filePath1 = passedTCFilePath + "\\" + ScenarioContext.Current.ScenarioInfo.Title + "\\";
                System.IO.Directory.CreateDirectory(filePath1);
                var mediaEntity = new ParallelConfigForAndroid().CaptureScreenshotAndReturnModelForAppium(ScenarioContext.Current.ScenarioInfo.Title.Trim());
                if (stepType == "Given")
                {
                    if (screenShotReqd == false)
                    {
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                    }

                    else
                    {
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Pass("", mediaEntity);
                    }

                }

                else if (stepType == "When")
                {
                    if (screenShotReqd == false)
                    {
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                    }
                    else
                    {
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Pass("", mediaEntity);
                    }
                }
                else if (stepType == "Then")
                {
                    
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Pass("", mediaEntity);
                    screenshot.SaveAsFile(Path.Combine(filePath1, ScenarioStepContext.Current.StepInfo.Text + DateTime.Now.ToString().Replace("/", "_").Replace(" ", "_").Replace(":", "_") + ".png"));
                }
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                var filePath1 = filePath + "\\" + ScenarioContext.Current.ScenarioInfo.Title + "\\";
                System.IO.Directory.CreateDirectory(filePath1);
                //screenshot in base 64 format
                var mediaEntity = new ParallelConfigForAndroid().CaptureScreenshotAndReturnModelForAppium(ScenarioContext.Current.ScenarioInfo.Title.Trim());
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, mediaEntity);
                    screenshot.SaveAsFile(Path.Combine(filePath1, ScenarioStepContext.Current.StepInfo.Text + DateTime.Now.ToString().Replace("/", "_").Replace(" ", "_").Replace(":", "_") + ".png"));
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, mediaEntity);
                    screenshot.SaveAsFile(Path.Combine(filePath1, ScenarioContext.Current.ScenarioInfo.Title + DateTime.Now.ToString().Replace("/", "_").Replace(" ", "_").Replace(":", "_") + ".png"));
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, mediaEntity);
                    screenshot.SaveAsFile(Path.Combine(filePath1, ScenarioContext.Current.ScenarioInfo.Title + DateTime.Now.ToString().Replace("/", "_").Replace(" ", "_").Replace(":", "_") + ".png"));
                }

            }
        }

        [BeforeScenario]
        [Obsolete]
        public void BeforeScenario()
        {

            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
            InitDriver();



        }
        [AfterScenario]
        public void AfterScenario()
        {
            
            CloseDriver();
        }

       
    }
}