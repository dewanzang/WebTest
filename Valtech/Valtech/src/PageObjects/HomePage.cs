using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ValtechTestProject.src.Utilities;

namespace ValtechTestProject.src.PageObjects
{
    public class HomePage : TestHelper
    {

        public static string LatestNewsHeader = "//*[@id='container']/div[2]/div[3]/div[1]/h5";
        public static string HomePageHeader = "//*[@id='wrapper']/header/div/a/i";
        public static string CasesMenuItem = "//*[@id='navigationMenuWrapper']/div/ul/li[1]/a/span";
        public static string CasesPageTitleElement = "//*[@id='container']/header/h1";
        public static string ServicesMenuItem = "//*[@id='navigationMenuWrapper']/div/ul/li[2]/a/span";
        public static string ServicesPageTitleElement = "//*[@id='container']/header/h1";
        public static string JobsMenuItem = "//*[@id='navigationMenuWrapper']/div/ul/li[4]/a/span";
        public static string JobsPageTitleElement = "//*[@id='container']/header/h1";
        public static string ContactIcon = "//*[@id='wrapper']/header/div/nav/div[2]/div/a/i";
        public static string ContactPageTitleElement = "//*[@id='container']/header/h1";

        public static string CasesPageH1Tag = "//*[@id='container']/header/h1";
        private IWebDriver driver1;

        public HomePage(IWebDriver driver1)
        {
            this.driver1 = driver1;
        }

        public static HomePage createHomePage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(TestBase.URL);

            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath(HomePageHeader)));
                return new HomePage(driver);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public CasesPage clickCasesMenuItem(IWebDriver driver)
        {
            try
            {
                driver.FindElement(By.XPath(CasesMenuItem)).Click();

            }
            catch (Exception)
            {
                return null;
            }
            return CasesPage.createCasesPage(driver);
        }

        public ServicesPage clickServicesMenuItem(IWebDriver driver)
        {
            try
            {
                driver.FindElement(By.XPath(ServicesMenuItem)).Click();
                
            }
            catch (Exception)
            {
                return null;
            }
            return ServicesPage.createServicesPage(driver);
        }

        public JobsPage clickJobsMenuItem(IWebDriver driver)
        {
            try
            {
                driver.FindElement(By.XPath(JobsMenuItem)).Click();
            }
            catch (Exception)
            {
                return null;
            }
            return JobsPage.createJobsPage(driver);
        }

        public ContactPage clickContactIcon(IWebDriver driver)
        {
            try
            {
                driver.FindElement(By.XPath(ContactIcon)).Click();
                
            }
            catch (Exception)
            {
                return null;
            }
            return ContactPage.createContactPage(driver);
        }
    }
}





