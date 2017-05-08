namespace MySelenium.Tests.Pages.RegistrationPage
{
    using Models;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using NPOI.SS.UserModel;

    [TestFixture, Property("Priority", 1)]
    [Author("Jhon", "Duddle")]
    public class RegistrationPageTests
    {
        // objects for the test
        private IWebDriver _chromeDriver;
        private RegistrationPage _page;
        private RegistrationUser _user;
        private string _usersData = @"C:\01tech\RegistrationUsers.xlsx";

        // Expected error messages
        private const string EmptyFieldMessage = "* This field is required";
        private const string InvalidAndShortPhoneMessage = "* Minimum 10 Digits starting with Country Code";
        private const string LongPhoneMessage = "* Maximum 16 Digits starting with Country Code";
        private const string ShortPasswordMessage = "* Minimum 8 characters required";
        private const string InvalidEmailAddress = "* Invalid email address";

        private List<string> Arrange(int rowIndex)
        {
            using (FileStream file = new FileStream(_usersData, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook = WorkbookFactory.Create(file);

                ISheet worksheet = workbook.GetSheet("TestData");

                var result = worksheet
                    .GetRow(rowIndex)
                    .Select(x => x.ToString())
                    .ToList();

                return result;
            }
        }

        [SetUp]
        public void Init()
        {
            _chromeDriver = new ChromeDriver();
            _page = new RegistrationPage(_chromeDriver);
            _page.NavigateTo();
        }

        [TearDown]
        public void CleanUp()
        {
            _chromeDriver.Quit();
        }

        [Test, Property("Priority", 0)]
        public void RegisterWithNegativePhone()
        {
            // Arrange - short phone number
            var paramsList = Arrange(2);
            _user = new RegistrationUser(paramsList);

            // Act - fill in form
            _page.ActFillAndSubmit(_user);

            // Assert
            _page
                .FormErrorPhone
                .AssertFormErrorIs(InvalidAndShortPhoneMessage, "Phone");
        }

        [Test, Property("Priority", 1)]
        public void RegisterWithNegativeMail()
        {
            // Arrange - email without @
            var paramsList = Arrange(3);
            _user = new RegistrationUser(paramsList);

            // Act - fill in form
            _page.ActFillAndSubmit(_user);

            // Assert
            _page.FormErrorEmail.AssertFormErrorIs("* Invalid email address", "Email");
        }

        [Test, Property("Priority", 2)]
        public void RegisterWithMismatchPasswords()
        {
            // Arrange - email without @
            var paramsList = Arrange(4);
            _user = new RegistrationUser(paramsList);

            // Act - fill in form
            _page.ActFillAndSubmit(_user);

            // Assert
            _page.FormErrorPasswordConfirm.AssertFormErrorIs("* Fields do not match", "Repeat Password");
        }

        [Test, Property("Priority", 3)]
        public void RegisterWithEmptyUsername()
        {
            // Arrange - user name should not be empty
            var paramsList = Arrange(5);
            _user = new RegistrationUser(paramsList);

            _page.ActFillAndSubmit(_user);

            _page.FormErrorUserName.AssertFormErrorIs(EmptyFieldMessage, "User Name");
        }

        [Test, Property("Priority", 4)]
        public void RegisterWithoutHobby()
        {
            // no hobbies selected
            var paramsList = Arrange(6);
            _user = new RegistrationUser(paramsList);
            // A
            _page.ActFillAndSubmit(_user);
            // A
            _page.FormErrorHobbies.AssertFormErrorIs(EmptyFieldMessage, "Hobby");
        }

        [Test, Property("Priority", 5)]
        public void RegisterWithoutLastName()
        {
            // empty last name
            var paramsList = Arrange(7);
            _user = new RegistrationUser(paramsList);

            _page.ActFillAndSubmit(_user);

            _page.FormErrorFirstLastName.AssertFormErrorIs(EmptyFieldMessage, "Last Name");
        }

        [Test, Property("Priority", 6)]
        public void RegisterWithNoPhone()
        {
            // empty phone number
            var paramsList = Arrange(8);
            _user = new RegistrationUser(paramsList);

            _page.ActFillAndSubmit(_user);

            _page.FormErrorPhone.AssertFormErrorIs(EmptyFieldMessage, "Phone");
        }

        [Test, Property("Priority", 7)]
        public void RegisterWithNotDigitsPhone()
        {
            // Arrange - no digits
            var paramsList = Arrange(9);
            _user = new RegistrationUser(paramsList);

            _page.ActFillAndSubmit(_user);

            _page.FormErrorPhone.AssertFormErrorIs(InvalidAndShortPhoneMessage, "Phone");
        }

        [Test, Property("Priority", 8)]
        public void RegisterWithLongPhone()
        {
            // too long teleophone number
            var paramsList = Arrange(10);
            _user = new RegistrationUser(paramsList);

            _page.ActFillAndSubmit(_user);

            _page.FormErrorPhone.AssertFormErrorIs(LongPhoneMessage, "Phone");
        }

        [Test, Property("Priority", 9)]
        public void RegisterWithDigitsAndCharPhone()
        {
            // phone with other characters
            var paramsList = Arrange(11);
            _user = new RegistrationUser(paramsList);

            _page.ActFillAndSubmit(_user);

            _page.FormErrorPhone.AssertFormErrorIs(InvalidAndShortPhoneMessage, "Phone");
        }

        [Test, Property("Priority", 10)]
        public void RegisterWithShortPassword()
        {
            // short password
            var paramsList = Arrange(12);
            _user = new RegistrationUser(paramsList);

            _page.ActFillAndSubmit(_user);

            _page.FormErrorPassword.AssertFormErrorIs(ShortPasswordMessage, "Password");
        }

        [Test, Property("Priority", 11)]
        public void RegisterWithExistingUser()
        {
            // Register twice with the same user
            var paramsList = Arrange(13);
            _user = new RegistrationUser(paramsList);

            _page.ActFillAndSubmit(_user);
            // change hobbies to prevent error
            _user.Hobbies = new List<bool>() { false, true, false };

            _page.ActFillAndSubmit(_user);

            _page.FormErrorExistingUserName.AssertFormErrorIs("Error: Username already exists", "User name");
        }

        [Test, Property("Priority", 12)]
        public void RegisterWithLongEmail()
        {
            // e-mails can't be longer than 254 chars
            var paramsList = Arrange(14);
            _user = new RegistrationUser(paramsList);

            _page.ActFillAndSubmit(_user);

            _page.FormErrorEmail.AssertFormErrorIs(InvalidEmailAddress, "Email");
        }

        [Test, Property("Priority", 13)]
        public void RegisterWithWrongEmail()
        {
            // e-mails can't have more than one @
            var paramsList = Arrange(15);
            _user = new RegistrationUser(paramsList);

            _page.ActFillAndSubmit(_user);

            _page.FormErrorEmail.AssertFormErrorIs(InvalidEmailAddress, "Email");
        }

        [Test, Property("Priority", 14)]
        public void RegisterWithVeryWeakPassword()
        {
            // use very weak password
            var paramsList = Arrange(16);
            _user = new RegistrationUser(paramsList);

            _page.ActFill(_user);

            _page.PasswordStrength.AssertTextErrorIs("Very weak", "Password is very weak");
        }

        [Test, Property("Priority", 15)]
        public void RegisterWithMeadiumPassword()
        {
            // use medium password
            var paramsList = Arrange(17);
            _user = new RegistrationUser(paramsList);

            _page.ActFill(_user);

            _page.PasswordStrength.AssertTextErrorIs("Medium", "Password is of medium strength");
        }

        [Test, Property("Priority", 16)]
        public void RegisterWithWeakPassword()
        {
            // use weak password
            var paramsList = Arrange(18);
            _user = new RegistrationUser(paramsList);

            _page.ActFill(_user);

            _page.PasswordStrength.AssertTextErrorIs("Weak", "Password is weak");
        }

        [Test, Property("Priority", 17)]
        public void RegisterWithStrongPassword()
        {
            // use strong password
            var paramsList = Arrange(19);
            _user = new RegistrationUser(paramsList);

            _page.ActFill(_user);

            _page.PasswordStrength.AssertTextErrorIs("Strong", "Password is strong");
        }


    }
}
