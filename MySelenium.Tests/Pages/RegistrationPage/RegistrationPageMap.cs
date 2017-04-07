namespace MySelenium.Tests.Pages.RegistrationPage
{
    using System.Collections.Generic;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;


    public partial class RegistrationPage
    {
        public IWebElement FirstName => Driver
            .FindElement(
                By.Id("name_3_firstname")
            );

        public IWebElement LirstName => Driver
            .FindElement(
                By.Id("name_3_lastname")
            );

        public IWebElement MatrialStatus => Driver
            .FindElement(
                By.XPath("//*[@id=>\"pie_register\"]/li[2]/div/div/input[1]")
            );

        public List<IWebElement> Hobbys => Driver
            .FindElements(
                By.Name("checkbox_5[]")
            )
            .ToList();

        public SelectElement CountryOption => new SelectElement(
            Driver
            .FindElement(
                By.Id("dropdown_7")
                )
            );

        public SelectElement MountOption => new SelectElement(
            Driver
            .FindElement(
                By.Id("mm_date_8")
                )
            );

        public SelectElement DayOption => new SelectElement(
            Driver
            .FindElement(
                By.Id("dd_date_8")
                )
            );

        public SelectElement YearOption => new SelectElement(
            Driver
            .FindElement(
                By.Id("yy_date_8")
                )
            );

        public IWebElement Telephone => Driver
            .FindElement(By.Id("phone_9"));

        public IWebElement UserName => Driver
            .FindElement(By.Id("username"));

        public IWebElement Email => Driver
            .FindElement(By.Id("email_1"));

        public IWebElement Description => Driver
            .FindElement(By.Id("description"));

        public IWebElement Password => Driver
            .FindElement(By.Id("password_2"));

        public IWebElement ConfirmPassword => Driver
            .FindElement(By.Id("confirm_password_password_2"));
    }
}
