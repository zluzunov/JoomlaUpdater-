namespace JoomlaUpdater.Pages.AdminLogin
{
    using System;
    using Models;
    using OpenQA.Selenium;

    public partial class AdminLogin: BasePage
    {
        private readonly string _adminFolder;

        public AdminLogin(IWebDriver driver, string baseUrl)
            : base(driver, baseUrl)
        {
            _adminFolder = "administrator";
        }

        public AdminLogin(IWebDriver driver, string baseUrl, string secretFolder)
            : base(driver, baseUrl)
        {
            _adminFolder = secretFolder;
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl($"{BaseUrl}/{_adminFolder}/");
        }

        public void ActFill(JoomlaUser user)
        {
            WriteValue(UserName,user.UserName);
            WriteValue(Password, user.Password);
        }

        public void ActFillAndSubmit(JoomlaUser user)
        {
            // Fills And Submits the form
            ActFill(user);
            if (ButtonLogIn[0].Displayed)
            {
                ButtonLogIn[0].Click();
            }
            else
            {
                throw new Exception($"The {ButtonLogIn[0].Text} button is not displayed!");
            }
        }

        public void WriteValue(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
