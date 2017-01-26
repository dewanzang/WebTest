using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ValtechTestProject.src.Utilities;

namespace ValtechTestProject.src.PageObjects
{
    public class ServicesPage : TestHelper
    {

        public static string ServicesPageH1Tag = "//*[@id='container']/section/header/h1";
        private IWebDriver driver1;

        public ServicesPage(IWebDriver driver1)
        {
            this.driver1 = driver1;
        }
                
        public static ServicesPage createServicesPage(IWebDriver driver)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.TitleIs("Services - Valtech"));

                return new ServicesPage(driver);

            }
            catch (Exception)
            {
                return null;
            }
        }
    }


}

