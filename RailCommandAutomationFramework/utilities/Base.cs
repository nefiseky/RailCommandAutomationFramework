using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Configuration;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;




namespace RailCommandAutomationFramework.utilities
{
    internal class Base
    {
        public ExtentReports extent;
        public  ExtentTest test;
        //report file 
        [OneTimeSetUp]
        public void Setup() {


          string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string reportPath = projectDirectory + "//TestReport.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("dev environment", "QA");
            extent.AddSystemInfo("Username", "Nefise");
        
        
        }
        // public IWebDriver driver;
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        [SetUp]

        public void StartBrowser()
        {
          test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            //Configuration
            string browserName = ConfigurationManager.AppSettings["browserName"];
              InitBrowser(browserName);

            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver.Value = new ChromeDriver();


            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Value.Manage().Window.Maximize();
            driver.Value.Url = "https://dev.rsinext.com/";

        }

       public IWebDriver getDriver()

        {
            return driver.Value;
        }

        public void InitBrowser(string browserName) {
               switch (browserName)
               {
                   case "Firefox":
                       new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                       driver.Value = new FirefoxDriver(); 
                       break;

                   case "Chrome":
                       new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                       driver.Value = new ChromeDriver();
                       break;

                   case "Edge":

                       driver.Value = new EdgeDriver();
                       break;

               }
           }


        public static JsonReader getDataParser() {

            return new JsonReader();
        }
        [TearDown]
        public void AfterTest()

        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;



            DateTime time = DateTime.Now;
            string fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";

            if (status == TestStatus.Failed)
            {

                test.Fail("Test failed", captureScreenShot(driver.Value, fileName));
                test.Log(Status.Fail, "test failed with logtrace" + stackTrace);

            }
            else if (status == TestStatus.Passed)
            {

            }
            
                extent.Flush(); // Flush the report to save the changes
           
            driver.Value.Quit();
        }

        public MediaEntityModelProvider captureScreenShot(IWebDriver driver, string screenShotName)

        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot,screenShotName).Build();



        }
    }
}

