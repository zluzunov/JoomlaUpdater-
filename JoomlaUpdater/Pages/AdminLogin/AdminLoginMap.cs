namespace JoomlaUpdater.Pages.AdminLogin
{
    using System.Collections.ObjectModel;
    using OpenQA.Selenium;


    public partial class AdminLogin
    {
        public IWebElement UserName => Driver
            .FindElement(
                By.Id("mod-login-username")
            );

        public IWebElement Password => Driver
            .FindElement(
                By.Id("mod-login-password")
            );
        public ReadOnlyCollection<IWebElement> ButtonLogIn
        {
            get
            {
                //try if
                ReadOnlyCollection<IWebElement> result;

                result = Driver
                    .FindElements(
                    By.CssSelector(
                        "#form-login > fieldset > div:nth-child(5) > div > div > button"
                        )
                        );
                if (result.Count == 0)
                {
                    result = Driver
                        .FindElements(
                            By.CssSelector(
                                "#form-login > fieldset > div:nth-child(4) > div > div > button"
                            )
                        );
                }

                return result;
            }
        }
    }
}
