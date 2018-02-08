namespace JoomlaUpdater.Pages.AdminUpdateJoomla
{
    using System;
    using OpenQA.Selenium;

    public partial class AdminJoomlaUpdate: BasePage
    {
        public AdminJoomlaUpdate(IWebDriver driver, string baseUrl)
            : base(driver, baseUrl)
        {
            
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl($"{BaseUrl}/administrator/index.php?option=com_joomlaupdate");
        }

        public bool StartUpdate()
        {
            bool result;

            if (ButtonInstallUpdate.Count > 0)
            {
                ButtonInstallUpdate[0].Click();
                result = true;
            }
            else
            {
                Console.WriteLine("No updates available");
                result = false;
            }

            return result;
        }
    }
}
