namespace MySelenium.Tests.Pages.RegistrationPage
{
    using System;
    using OpenQA.Selenium;


    public partial class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl("http://www.demoqa.com/registration");
        }

        public void Fill()
        {
            throw new NotImplementedException();
        }

        public void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
