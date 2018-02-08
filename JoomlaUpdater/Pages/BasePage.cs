namespace JoomlaUpdater.Pages
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public class BasePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private string _baseUrl;

        public BasePage(IWebDriver driver, string baseUrl)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driver.Manage()
                .Window
                .Maximize();
            _baseUrl = baseUrl;
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

        public string BaseUrl => _baseUrl;
    }
}
