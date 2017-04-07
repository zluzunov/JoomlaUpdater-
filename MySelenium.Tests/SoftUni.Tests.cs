namespace MySelenium.Tests
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class SoftUni
    {
        [Test]
        public void GoToQaAutomationTest()
        {
            {
                IWebDriver chromeDriver = new ChromeDriver();
                chromeDriver.Manage().Window.Maximize();
                //go to website
                chromeDriver.Url = "http://www.softuni.bg";

                //open navigation bar by XPath with wait
                WebDriverWait driverWait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(60));
                IWebElement button = driverWait.Until<IWebElement>(
                        ExpectedConditions.ElementToBeClickable(
                            By.XPath("//*[@id='header-nav']/div[1]/ul/li[2]/a"
                            )
                        )
                    );
                button.Click();

                //open QA-Automation link from Active Courses
                IWebElement openQaAutomaiton = driverWait
                    .Until<IWebElement>(
                        ExpectedConditions.ElementToBeClickable(
                            By.XPath("//*[@id=\"header-nav\"]/div[1]/ul/li[2]/div/div/div/div[2]/div[2]/ul/li[8]/a")
                                )
                            );
                openQaAutomaiton.Click();

                //Assert that titlez is Курс QA Automation - март 2017
                Assert.IsTrue(chromeDriver.Title.Contains("Курс QA Automation - март 2017"), "This page is not: Курс QA Automation - март 2017");

                chromeDriver.Quit();
            }
        }
    }
}
