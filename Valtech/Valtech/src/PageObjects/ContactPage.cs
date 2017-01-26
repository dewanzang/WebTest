using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using ValtechTestProject.src.Utilities;

namespace ValtechTestProject.src.PageObjects
{
    public class ContactPage : TestHelper
    {

        public static string ContactPageH1Tag = "//*[@id='container']/div[1]/h1";
        private IWebDriver driver1;

        public ContactPage(IWebDriver driver1)
        {
            this.driver1 = driver1;
        }

        public static ContactPage createContactPage(IWebDriver driver)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.TitleIs("Contact - Valtech"));

                return new ContactPage(driver);

            }
            catch (Exception)
            {
                return null;
            }
        }
                
        public virtual int numberOfContacts()
        {
            try
            {
                int totalContacts = 0;
                totalContacts = driver.FindElements(By.ClassName("office-country__heading")).Count;
                IList<IWebElement> elements = driver.FindElements(By.ClassName("office-country__heading"));

                totalContacts = elements.Count;

                return totalContacts;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }


}

