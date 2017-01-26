using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ValtechTestProject.src.Utilities
{
    public class TestBase
    {
        public static IWebDriver driver;
        private const string IE_DRIVER_PATH = @"C:\Projects\Workspace\ValtechTestProject\packages";
        private TestContext testContextInstance;
        public const string URL = "http://www.valtech.com/";
        private const string browser = "firefox";               
      
        //Gets or sets the test context which provides        
        //information about and functionality for the current test run.        
        public TestContext TestContext 
        { 
            get 
            { 
                return testContextInstance; 
            } 
            set 
            { 
                testContextInstance = value; 
            } 
        }

        [TestInitialize()]         
        public void SyncDriver()           
        {             
            // New up the driver to boot up a new browser for each test  
            if (browser.Equals("firefox"))
            {
                driver = new FirefoxDriver();

            }
            else if (browser.Equals("chrome"))
            {
                driver = new ChromeDriver();

            }
            else if (browser.Equals("iexplore"))
            {
                var options = new InternetExplorerOptions();
                options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                options.ElementScrollBehavior = InternetExplorerElementScrollBehavior.Bottom;
                driver = new InternetExplorerDriver(IE_DRIVER_PATH, options);

            }
            else if (browser.Equals("safari"))
            {
                driver = new SafariDriver();

            }
                      
            //maximize browser window
            driver.Manage().Window.Maximize();

            //navigate to home page
            driver.Navigate().GoToUrl(URL);
        }

        // This closes the driver down after the test has finished.
        [TestCleanup]
        public void TearDown()
        {
            if (driver != null)
               driver.Quit(); 
        }

        /*
        public static IWebElement FindElementAndWait(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }
        */
    }
}
