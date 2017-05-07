namespace MySelenium.Tests.Pages.HomePage
{
    using OpenQA.Selenium;


    public partial class HomePage
    {
        public IWebElement RegirstratonButton => Driver.FindElement(By.PartialLinkText("Registration"));
    }
}
