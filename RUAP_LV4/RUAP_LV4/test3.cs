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
    public class Test3
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://demowebshop.tricentis.com/";
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
        public void The3Test()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Navigate().GoToUrl(baseURL + "/");
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//a[contains(text(),'Computers')])[3]")));
            driver.FindElement(By.XPath("(//a[contains(text(),'Computers')])[3]")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("img[alt=\"Picture for category Desktops\"]")));
            driver.FindElement(By.CssSelector("img[alt=\"Picture for category Desktops\"]")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("products-orderby")));
            new SelectElement(driver.FindElement(By.Id("products-orderby"))).SelectByText("Name: A to Z");
            new SelectElement(driver.FindElement(By.Id("products-pagesize"))).SelectByText("12");
            new SelectElement(driver.FindElement(By.Id("products-viewmode"))).SelectByText("List");
            driver.FindElement(By.LinkText("Under 1000.00")).Click();
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
