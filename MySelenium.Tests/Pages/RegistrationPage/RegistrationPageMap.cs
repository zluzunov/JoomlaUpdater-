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

        public IWebElement LastName => Driver
            .FindElement(
                By.Id("name_3_lastname")
            );

        public List<IWebElement> MatrialStatus => Driver
            .FindElements(
                By.Name("radio_4[]")
            )
            .ToList();

        public List<IWebElement> Hobbies => Driver
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

        public SelectElement MonthOption => new SelectElement(
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

        public IWebElement PhoneNumber => Driver
            .FindElement(By.Id("phone_9"));

        public IWebElement UserName => Driver
            .FindElement(By.Id("username"));

        public IWebElement Email => Driver
            .FindElement(By.Id("email_1"));

        public IWebElement ProfilePicture => Driver
            .FindElement(By.Id("profile_pic_10"));

        public IWebElement AboutMe => Driver
            .FindElement(By.Id("description"));

        public IWebElement Password => Driver
            .FindElement(By.Id("password_2"));

        public IWebElement PasswordConfirm => Driver
            .FindElement(By.Id("confirm_password_password_2"));

        public IWebElement ButtonSubmit => Driver
            .FindElement(By.Name("pie_submit"));

        public IReadOnlyCollection<IWebElement> FormErrorFirstLastName => Driver
            .FindElements(By.XPath("//*[@id=\"pie_register\"]/li[1]/div[1]/div[2]/span"));

        public IReadOnlyCollection<IWebElement> FormErrorHobbies => Driver
            .FindElements(By.XPath("//*[@id=\"pie_register\"]/li[3]/div/div[2]/span"));

        public IReadOnlyCollection<IWebElement> FormErrorPhone => Driver
            .FindElements(By.XPath("//*[@id=\"pie_register\"]/li[6]/div/div/span"));

        public IReadOnlyCollection<IWebElement> FormErrorUserName => Driver
            .FindElements(By.XPath("//*[@id=\"pie_register\"]/li[7]/div/div/span"));

        public IReadOnlyCollection<IWebElement> FormErrorEmail => Driver
            .FindElements(By.XPath("//*[@id=\"pie_register\"]/li[8]/div/div/span"));

        public IReadOnlyCollection<IWebElement> FormErrorPassword => Driver
            .FindElements(By.XPath("//*[@id=\"pie_register\"]/li[11]/div/div/span"));

        public IReadOnlyCollection<IWebElement> FormErrorPasswordConfirm => Driver
            .FindElements(By.XPath("//*[@id=\"pie_register\"]/li[12]/div/div/span"));
    }
}
