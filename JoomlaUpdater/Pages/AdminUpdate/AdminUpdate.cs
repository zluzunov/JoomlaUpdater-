namespace JoomlaUpdater.Pages.AdminUpdate
{
    using System;
    using OpenQA.Selenium;


    public partial class AdminUpdate: BasePage
    {
        public AdminUpdate(IWebDriver driver, string baseUrl)
            : base(driver, baseUrl)
        {
            
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl($"{BaseUrl}/administrator/index.php?option=com_installer&view=update");
        }

        public bool SelectUpdates()
        {
            bool result;

            if (ButtonSelectAll.Count > 0)
            {
                ButtonSelectAll[0].Click();
                result = true;
            }
            else
            {
                Console.WriteLine("No updates discovered!");
                result = false;
            }

            return result;
        }
    }
}
