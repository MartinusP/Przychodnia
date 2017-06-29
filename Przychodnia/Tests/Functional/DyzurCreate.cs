using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class DyzurCreate
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost:55584/Dyzur";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheDyzurCreateTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/Dyzur");
            driver.FindElement(By.CssSelector("p > a")).Click();
            driver.FindElement(By.Id("DZIEN_DYZURU")).Clear();
            driver.FindElement(By.Id("DZIEN_DYZURU")).SendKeys("2017/06/29");
            driver.FindElement(By.Id("OD")).Clear();
            driver.FindElement(By.Id("OD")).SendKeys("2017/06/29 08:00");
            driver.FindElement(By.Id("DO")).Clear();
            driver.FindElement(By.Id("DO")).SendKeys("2017/06/29 17:00");
            new SelectElement(driver.FindElement(By.Id("ID_PRACOWNIK"))).SelectByText("Piotr");
            new SelectElement(driver.FindElement(By.Id("ID_ODDZIAL"))).SelectByText("Geriatria");
            driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
            Assert.AreEqual("Index", driver.FindElement(By.CssSelector("h2")).Text);
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
