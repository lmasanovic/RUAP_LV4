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
    public class DodavanjeIBrisanje
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
        public void TheDodavanjeIBrisanjeTest()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Navigate().GoToUrl(baseURL + "/");
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Electronics")));
            driver.FindElement(By.LinkText("Electronics")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("img[alt=\"Picture for category Cell phones\"]")));
            driver.FindElement(By.CssSelector("img[alt=\"Picture for category Cell phones\"]")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input.button-2.product-box-add-to-cart-button")));
            driver.FindElement(By.CssSelector("input.button-2.product-box-add-to-cart-button")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//input[@value='Add to cart'])[2]")));
            driver.FindElement(By.XPath("(//input[@value='Add to cart'])[2]")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("shopping cart")));
            driver.FindElement(By.LinkText("shopping cart")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("removefromcart")));
            driver.FindElement(By.Name("removefromcart")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("updatecart")));
            driver.FindElement(By.Name("updatecart")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("continueshopping")));
            driver.FindElement(By.Name("continueshopping")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("img[alt=\"Tricentis Demo Web Shop\"]")));
            driver.FindElement(By.CssSelector("img[alt=\"Tricentis Demo Web Shop\"]")).Click();
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
