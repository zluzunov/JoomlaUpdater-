namespace JoomlaUpdater.Pages.AdminUpdate
{
    using System.Collections.ObjectModel;
    using OpenQA.Selenium;


    public partial class AdminUpdate
    {
        public ReadOnlyCollection<IWebElement> ButtonSelectAll => Driver
            .FindElements(
                By.XPath(
                    "//*[@id=\"j-main-container\"]/table/thead/tr/th[1]/input"
                )
            );

        public IWebElement ButtonUpdate => Driver
            .FindElement(
                By.Id(
                    "toolbar-upload"
                )
            );

        public IWebElement ButtonFindUpdate => Driver
            .FindElement(
                By.Id(
                    "toolbar-refresh"
                )
            );

        public IWebElement ButtonClearCache => Driver
            .FindElement(
                By.Id(
                    "toolbar-purge"
                )
            );
    }
}
