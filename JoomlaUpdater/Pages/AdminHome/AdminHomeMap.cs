namespace JoomlaUpdater.Pages.AdminHome
{
    using OpenQA.Selenium;


    public partial class AdminHome
    {
        public IWebElement ButtonUpdateJoomla => Driver
            .FindElement(
            By.CssSelector(
                "html body.admin.com_cpanel.view-.layout-.task-.itemid- div.container-fluid.container-main section#content div.row-fluid div.span12 div#system-message-container div.alert.alert-error.alert-joomlaupdate button.btn.btn-primary"
                )
            );

        public IWebElement MenuComponents => Driver
            .FindElement(
                By.XPath(
                    "//*[@id=\"menu\"]/li[5]/a"
                )
            );

        public IWebElement MenuComponentsJUpdate => Driver
            .FindElement(
                By.XPath(
                    "//*[@id=\"menu\"]/li[5]/ul/li[7]/a"
                )
            );
    }
}
