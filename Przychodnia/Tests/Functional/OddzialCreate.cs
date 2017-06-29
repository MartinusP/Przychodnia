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
    public class OddzialCreate
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost:55584/Oddzial";
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
        public void TheOddzialCreateTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/Oddzial");
            driver.FindElement(By.CssSelector("p > a")).Click();
            driver.FindElement(By.Id("NAZWA")).Clear();
            driver.FindElement(By.Id("NAZWA")).SendKeys("Geriatria");
            driver.FindElement(By.Id("MIEJSCOWOSC")).Clear();
            driver.FindElement(By.Id("MIEJSCOWOSC")).SendKeys("Łódź");
            new SelectElement(driver.FindElement(By.Id("ID_PLACOWKA"))).SelectByText("Przychodnia Słoneczna");
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
