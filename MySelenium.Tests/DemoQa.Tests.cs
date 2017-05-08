namespace MySelenium.Tests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using Pages;
    using Pages.HomePage;

    [TestFixture, Property("Priority",0)]
    [Author("Some", "Guy")]
    public class DemoQaGoToRegPage
    {
        private IWebDriver _chromeDriver;

        [SetUp]
        public void Init()
        {
            _chromeDriver = new ChromeDriver();
        }

        [TearDown]
        public void CleanUp()
        {
            _chromeDriver.Quit();
        }

        [Test]
        public void GoToRegistration()
        {
            var home = new HomePage(_chromeDriver);

            home.NavigateTo();
            home.RegirstratonButton.Click();

            //Check page title
            home.AsserTitleIs("Registration | Demoqa");
        }
    }

}
