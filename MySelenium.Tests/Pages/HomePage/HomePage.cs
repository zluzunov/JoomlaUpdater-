namespace MySelenium.Tests.Pages.HomePage
{
    using OpenQA.Selenium;


    public partial class HomePage : BasePage
    {
        public HomePage(IWebDriver driver)
            : base(driver)
        {
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl("http://www.demoqa.com");
        }
    }
}
