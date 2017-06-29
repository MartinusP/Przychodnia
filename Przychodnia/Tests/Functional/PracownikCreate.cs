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
    public class PracownikCreate
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost:55584/Pracownik";
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
        public void ThePracownikCreateTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/Pracownik");
            driver.FindElement(By.CssSelector("p > a")).Click();
            driver.FindElement(By.Id("IMIE")).Clear();
            driver.FindElement(By.Id("IMIE")).SendKeys("Piotr");
            driver.FindElement(By.Id("NAZWISKO")).Clear();
            driver.FindElement(By.Id("NAZWISKO")).SendKeys("Jankowski");
            driver.FindElement(By.Id("ADRES")).Clear();
            driver.FindElement(By.Id("ADRES")).SendKeys("Rzgowska 17a, 93-008 Łódź");
            driver.FindElement(By.Id("EMAIL_KONTAKTOWY")).Clear();
            driver.FindElement(By.Id("EMAIL_KONTAKTOWY")).SendKeys("piotr@jankowski.uk");
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
