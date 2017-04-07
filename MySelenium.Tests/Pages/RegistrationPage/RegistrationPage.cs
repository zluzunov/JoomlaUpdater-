namespace MySelenium.Tests.Pages.RegistrationPage
{
    using System.Collections.Generic;
    using Models;
    using OpenQA.Selenium;


    public partial class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl("http://www.demoqa.com/registration");
        }

        public void Fill(RegistrationUser user)
        {
            WriteValue(FirstName, user.FirstName);
            WriteValue(LastName, user.LastName);
            ClickOnElements(MatrialStatus, user.MartialStatus);
            ClickOnElements(Hobbies, user.Hobbies);
            CountryOption.SelectByText(user.Country);

            MonthOption.SelectByValue(user.BirthMonth);
            DayOption.SelectByValue(user.BirthDay);
            YearOption.SelectByValue(user.BirthYear);

            WriteValue(PhoneNumber, user.PhoneNumber);
            WriteValue(UserName, user.UserName);
            WriteValue(Email, user.Email);

            if (user.ProfilePicturePath != "")
            {
                ProfilePicture.Click();
            }

            WriteValue(AboutMe, user.About);

            WriteValue(Password, user.Password);
            WriteValue(PasswordConfirm, user.PasswordConfirm);

            ButtonSubmit.Click();
        }

        public void WriteValue(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        private void ClickOnElements(List<IWebElement> elements, List<bool> conditions)
        {
            for (int i = 0; i < conditions.Count - 1; i++)
            {
                if (!conditions[i])
                {
                    elements[i].Click();
                }
            }
        }
    }
}
