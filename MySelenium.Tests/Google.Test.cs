namespace MySelenium.Tests
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class GoogleSelenium
    {
        [Test]
        public void TestFirstResult()
        {
            IWebDriver chromeDriver = new ChromeDriver();
            chromeDriver.Manage().Window.Maximize();
            
            //go to target web page
            chromeDriver.Url = "http://www.google.com";

            //enter the search term
            var searchInput = chromeDriver.FindElement(By.Id("lst-ib"));
            searchInput.Clear();
            searchInput.SendKeys("Selenium");

            //use name and click the search button
            var searchButton1 = chromeDriver.FindElement(By.Name("btnG"));
            searchButton1.Click();

            //open the selenium result - 60 seconds wait needed. It may not be the first.
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(60));
            IWebElement seleniumLink = wait.Until<IWebElement>(
                ExpectedConditions.ElementToBeClickable(
                    By.LinkText("Selenium - Web Browser Automation")
                    )
                );
            seleniumLink.Click();

            //check URL address
            String currentUrl = chromeDriver.Url;
            Assert.AreEqual("http://www.seleniumhq.org/", currentUrl, "Current URL is different from www.seleniumhq.org");

            //assert that the title is "Selenium - Web Browser Automation"
            Assert.AreEqual("Selenium - Web Browser Automation", chromeDriver.Title, "Title is different from Selenium - Web Browser Automation");

            chromeDriver.Quit();
        }
    }
}
