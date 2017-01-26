using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValtechTestProject.src.Utilities;
using ValtechTestProject.src.PageObjects;


namespace ValtechTestProject.src.testsuite
{
    [TestClass]
    public class Suite1 : TestHelper
    {
        private HomePage HomePageOj;
        private CasesPage CasesPageOj;
        private ServicesPage ServicesPageOj;
        private JobsPage JobsPageOj;
        private ContactPage ContactPageOj;
       
        [TestMethod]
        public void validateHomePageLatestNewsTest() 
        {
            {
                try
                {
                    if (HomePageOj == null)
                    {
                        HomePageOj = HomePage.createHomePage(driver);
                        Assert.IsNotNull(HomePageOj);
                    }
                    Assert.AreEqual("LATEST NEWS", driver.FindElement(By.XPath(HomePage.LatestNewsHeader)).Text);

                }
                catch (Exception t)
                {
                    Assert.Fail();
                }
            }

        }

        [TestMethod]
        public void validateCasesPageH1TagTest()
        {
            {
                try
                {
                    if (HomePageOj == null)
                    {
                        HomePageOj = HomePage.createHomePage(driver);
                        Assert.IsNotNull(HomePageOj);
                    }

                    CasesPageOj = HomePageOj.clickCasesMenuItem(driver);
                    Assert.IsNotNull(CasesPageOj);

                    Assert.AreEqual("Cases", driver.FindElement(By.XPath(CasesPage.CasesPageH1Tag)).Text);

                }
                catch (Exception t)
                {
                    Assert.Fail();
                }
            }

        }

        [TestMethod]
        public void validateServicesPageH1TagTest()
        {
            {
                try
                {
                    if (HomePageOj == null)
                    {
                        HomePageOj = HomePage.createHomePage(driver);
                        Assert.IsNotNull(HomePageOj);
                    }
                    
                    ServicesPageOj = HomePageOj.clickServicesMenuItem(driver);
                    Assert.IsNotNull(ServicesPageOj);

                    Assert.AreEqual("Services", driver.FindElement(By.XPath(ServicesPage.ServicesPageH1Tag)).Text);
                }
                catch (Exception t)
                {
                    Assert.Fail();
                }
            }

        }

        [TestMethod]
        public void validateJobsPageH1TagTest()
        {
            {
                try
                {
                    if (HomePageOj == null)
                    {
                        HomePageOj = HomePage.createHomePage(driver);
                        Assert.IsNotNull(HomePageOj);
                    }
                    
                    JobsPageOj = HomePageOj.clickJobsMenuItem(driver);
                    Assert.IsNotNull(JobsPageOj);

                    Assert.AreEqual("Jobs", driver.FindElement(By.XPath(JobsPage.JobsPageH1Tag)).Text);
                }
                catch (Exception t)
                {
                    Assert.Fail();
                }
            }

        }

        [TestMethod]
        public void validateNumberOfValtechOfficesTest()
        {
            {
                try
                {
                    if (HomePageOj == null)
                    {
                        HomePageOj = HomePage.createHomePage(driver);
                        Assert.IsNotNull(HomePageOj);
                    }
                   
                    ContactPageOj = HomePageOj.clickContactIcon(driver);
                    Assert.IsNotNull(ContactPageOj);

                    Assert.AreEqual(12, ContactPageOj.numberOfContacts());

                }
                catch (Exception t)
                {
                    Assert.Fail();
                }
            }

        }

    }
}

