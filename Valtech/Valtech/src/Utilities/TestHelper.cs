using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;

namespace ValtechTestProject.src.Utilities
{
    public class TestHelper : TestBase
    {
        public static IWebElement WebElement;
        
        public void acceptAlert()
        {
            try
            {
                //WebDriverWait wait = new WebDriverWait(driver, 2);
                //wait.until(ExpectedConditions.alertIsPresent());

                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
            }
            catch (Exception ex)
            {
                var error = ex.Message;
               
            }
        }

        public void acceptIFrameConfirmation(String windowFrameID, String btnID)
        {
            try
            {
                //make sure it is in the main document right now
                driver.SwitchTo().DefaultContent();

                //find frame, and use switch to frame method
                IWebElement windowFrame = driver.FindElement(By.Id(windowFrameID));
                driver.SwitchTo().Frame(windowFrame);

                //accept confirmation
                driver.FindElement(By.Id(btnID)).Click();

            }
            finally
            {
                // don't forget to switch back to the DefaultContent
                driver.SwitchTo().DefaultContent();
            }
        }

        public void acceptWindowDialogueConfirmation(String btnID)
        {
            try
            {
                //make sure it is in the main document right now
                driver.SwitchTo().DefaultContent();
                string BaseWindow = driver.CurrentWindowHandle;

                ReadOnlyCollection<string> handles = driver.WindowHandles;

                foreach (string handle in handles)
                {

                    if (handle != BaseWindow)
                    {
                        driver.SwitchTo().Window(handle);
                        driver.FindElement(By.Id(btnID)).Click();
                    }
                }
            }
            finally
            {
                // don't forget to switch back to the DefaultContent
                driver.SwitchTo().DefaultContent();
            }
        }

        public void sendKeyByID(String ID, String Value)
        {
            WebElement = driver.FindElement(By.Id(ID));
            WebElement.SendKeys(Keys.Control + "a");
            WebElement.SendKeys(Keys.Delete);
            //WebElement.Clear();
            WebElement.SendKeys(Value);

        }

        public void sendKeyByName(String ID, String Value)
        {
            WebElement = driver.FindElement(By.Name(ID));
            WebElement.SendKeys(Keys.Control + "a");
            WebElement.SendKeys(Keys.Delete);

            //WebElement.Clear();
            WebElement.SendKeys(Value);           
        }

        /// <summary>
        /// return text in the xpath locator 
        /// 
        /// </summary>
        public virtual string getValueByXPath(string xpathlocator)
        {
            string Value = "";
            try
            {
                Value = driver.FindElement(By.XPath(xpathlocator)).Text;
            }
            catch (Exception)
            {

            }
            return Value;
        }
         
        /// <summary>
        /// An expectation for checking that an element is present on the DOM of a page and visible. 
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns>The <see cref="IWebElement"/> once it is located and visible.</returns>
        public Func<IWebDriver, IWebElement> ElementIsVisible(By locator)
        {
            return (driver) =>
            {
                try
                {
                    return ElementIfVisible(driver.FindElement(locator));
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        private IWebElement ElementIfVisible(IWebElement element)
        {
            if (element.Displayed)
            {
                return element;
            }
            else
            {
                return null;
            }
        }

    }
}
