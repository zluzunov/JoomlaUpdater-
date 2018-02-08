namespace JoomlaUpdater.Pages.AdminUpdateJoomla
{
    using System.Collections.ObjectModel;
    using OpenQA.Selenium;

    public partial class AdminJoomlaUpdate
    {
        public IWebElement ButtonUpdateCheck => Driver
            .FindElement(
                By.Id(
                    "toolbar-loop"
                )
            );

        public ReadOnlyCollection<IWebElement> ButtonInstallUpdate => Driver
            .FindElements(
                By.XPath(
                    "//*[@id=\"adminForm\"]/fieldset/table/tfoot/tr/td[2]/button"
                )
            );
    }
}
