namespace JoomlaUpdater.Pages.AdminHome
{
    using OpenQA.Selenium;


    public partial class AdminHome: BasePage
    {
        public AdminHome(IWebDriver driver, string baseUrl)
            : base(driver, baseUrl)
        {
            
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl($"{BaseUrl}/administrator/");
        }
    }
}
