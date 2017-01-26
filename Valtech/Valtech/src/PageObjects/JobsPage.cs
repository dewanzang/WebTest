using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ValtechTestProject.src.Utilities;

namespace ValtechTestProject.src.PageObjects
{

    public class JobsPage : TestHelper
    {

        public static string JobsPageH1Tag = "//*[@id='container']/div[1]/h1";
        private IWebDriver driver1;

        public JobsPage(IWebDriver driver1)
        {
            this.driver1 = driver1;
        }
        
        public static JobsPage createJobsPage(IWebDriver driver)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.TitleIs("Jobs - Valtech"));

                return new JobsPage(driver);

            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}

