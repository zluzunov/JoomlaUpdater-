namespace MySelenium.Tests.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System;

    public class BasePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driver.Manage()
                .Window
                .Maximize();
        }

        public void ImplicitWait(int seconds)
        {
            _driver
                .Manage()
                .Timeouts()
                .ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public IWebDriver Driver => _driver;

        public WebDriverWait Wait => _wait;

        public string Title => _driver.Title;
    }
}
