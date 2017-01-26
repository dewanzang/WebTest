using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ValtechTestProject.src.Utilities;

namespace ValtechTestProject.src.PageObjects
{
    public class CasesPage : TestHelper
    {
        
        public static string CasesPageH1Tag = "//*[@id='container']/header/h1";
        private IWebDriver driver1;

        public CasesPage(IWebDriver driver1)
        {
            this.driver1 = driver1;
        }
        
        public static CasesPage createCasesPage(IWebDriver driver)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.TitleIs("Cases - Valtech"));

                return new CasesPage(driver);

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}





