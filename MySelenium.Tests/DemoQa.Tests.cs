namespace MySelenium.Tests
{
    using System;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using Pages;
    using Pages.HomePage;
    using Pages.RegistrationPage;

    [TestFixture, Property("Priority",0)]
    [Author("Some", "Guy")]
    public class DemoQaGoToRegPage
    {
        private IWebDriver _chromeDriver;

        [SetUp]
        public void Init()
        {
            _chromeDriver = new ChromeDriver();
        }

        [TearDown]
        public void CleanUp()
        {
            _chromeDriver.Quit();
        }

        [Test]
        public void GoToRegistration()
        {
            var home = new HomePage(_chromeDriver);

            home.NavigateTo();
            home.RegirstratonButton.Click();

            //Check page title
            home.AsserTitleIs("Registration | Demoqa");
        }
    }

    [TestFixture, Property("Priority",1)]
    [Author("Jhon","Duddle")]
    public class DemoQaGoRegForm
    {
        // objects for the test
        private IWebDriver _chromeDriver;
        private RegistrationPage _page;
        private RegistrationUser _user;

        // Expected error messages
        private const string EmptyFieldMessage = "* This field is required";
        private const string InvalidAndShortPhoneMessage = "* Minimum 10 Digits starting with Country Code";
        private const string LongPhoneMessage = "* Maximum 16 Digits starting with Country Code";
        private const string ShortPasswordMessage = "* Minimum 8 characters required";
        private const string InvalidEmailAddress = "* Invalid email address";

        private void Arrange()
        {
            _user = new RegistrationUser(
                firstName: "User1",
                lastName: "User3",
                martialStatus: new List<bool>() { true, false, false },
                hobbies: new List<bool>() { true, false, true },
                country: "Bulgaria",
                birthYear: "1970",
                birthMonth: "10",
                birthDay: "4",
                phoneNumber: "35928980243",
                userName: "Tester123door",
                email: "o2620715@mvrht.com",
                picture: "../../66.jpg",
                about: "Not mutch ....",
                password: "mySuperSecretPass",
                passwordConfirm: "mySuperSecretPass"
                );
        }

        [SetUp]
        public void Init()
        {
            _chromeDriver = new ChromeDriver();
            _page = new RegistrationPage(_chromeDriver);
            _page.NavigateTo();
            Arrange();
        }

        [TearDown]
        public void CleanUp()
        {
            _chromeDriver.Quit();
        }

        [Test,Property("Priority", 0)]
        public void RegisterWithNegativePhone()
        {
            // Arrange - short phone number
            _user.PhoneNumber = "21346";

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
            _user.Email = "badMail.com";

            // Act - fill in form
            _page.ActFillAndSubmit(_user);

            // Assert
            _page.FormErrorEmail.AssertFormErrorIs("* Invalid email address", "Email");
        }

        [Test, Property("Priority", 2)]
        public void RegisterWithMismatchPasswords()
        {
            // Arrange - email without @
            _user.PasswordConfirm = "notMatching";

            // Act - fill in form
            _page.ActFillAndSubmit(_user);

            // Assert
            _page.FormErrorPasswordConfirm.AssertFormErrorIs("* Fields do not match", "Repeat Password");
        }

        [Test, Property("Priority", 3)]
        public void RegisterWithEmptyUsername()
        {
            // Arrange - user name should not be empty
            _user.UserName = "";

            _page.ActFillAndSubmit(_user);

            _page.FormErrorUserName.AssertFormErrorIs(EmptyFieldMessage, "User Name");
        }

        [Test, Property("Priority", 4)]
        public void RegisterWithoutHobby()
        {
            // no hobbies selected
            _user.Hobbies = new List<bool>(){ false, false, false };
            // A
            _page.ActFillAndSubmit(_user);
            // A
            _page.FormErrorHobbies.AssertFormErrorIs(EmptyFieldMessage,"Hobby");
        }

        [Test, Property("Priority", 5)]
        public void RegisterWithoutLastName()
        {
            // empty last name
            _user.LastName = "";

            _page.ActFillAndSubmit(_user);

            _page.FormErrorFirstLastName.AssertFormErrorIs(EmptyFieldMessage,"Last Name");
        }

        [Test, Property("Priority", 6)]
        public void RegisterWithNoPhone()
        {
            // empty phone number
            _user.PhoneNumber = "";

            _page.ActFillAndSubmit(_user);

            _page.FormErrorPhone.AssertFormErrorIs(EmptyFieldMessage,"Phone");
        }

        [Test, Property("Priority", 7)]
        public void RegisterWithNotDigitsPhone()
        {
            // Arrange - no digits
            _user.PhoneNumber = "aaaaaaaaaaa";

            _page.ActFillAndSubmit(_user);

            _page.FormErrorPhone.AssertFormErrorIs(InvalidAndShortPhoneMessage,"Phone");
        }

        [Test, Property("Priority", 8)]
        public void RegisterWithLongPhone()
        {
            // too long teleophone number
            _user.PhoneNumber = "12345678123456789";

            _page.ActFillAndSubmit(_user);

            _page.FormErrorPhone.AssertFormErrorIs(LongPhoneMessage,"Phone");
        }

        [Test, Property("Priority", 9)]
        public void RegisterWithDigitsAndCharPhone()
        {
            // phone with other characters
            _user.PhoneNumber = "+35999999999";

            _page.ActFillAndSubmit(_user);

            _page.FormErrorPhone.AssertFormErrorIs(InvalidAndShortPhoneMessage,"Phone");
        }

        [Test, Property("Priority", 10)]
        public void RegisterWithShortPassword()
        {
            // short password
            _user.Password = "1";

            _page.ActFillAndSubmit(_user);

            _page.FormErrorPassword.AssertFormErrorIs(ShortPasswordMessage,"Password");
        }

        [Test, Property("Priority", 11)]
        public void RegisterWithExistingUser()
        {
            // Register twice with the same user
            _page.ActFillAndSubmit(_user);
            // change hobbies to prevent error
            _user.Hobbies = new List<bool>(){false, true, false};

            _page.ActFillAndSubmit(_user);

            _page.FormErrorExistingUserName.AssertFormErrorIs("Error: Username already exists", "User name");
        }

        [Test, Property("Priority", 12)]
        public void RegisterWithLongEmail()
        {
            // e-mails can't be longer than 254 chars
            var longEmail = new String('a', 254) + "@260.com";

            _user.Email = longEmail;
            _page.ActFillAndSubmit(_user);

            _page.FormErrorEmail.AssertFormErrorIs(InvalidEmailAddress,"Email");
        }

        [Test, Property("Priority", 13)]
        public void RegisterWithWrongEmail()
        {
            // e-mails can't have more than one @
            var wrong = "slslsls@lsl@260.com";

            _user.Email = wrong;
            _page.ActFillAndSubmit(_user);

            _page.FormErrorEmail.AssertFormErrorIs(InvalidEmailAddress,"Email");
        }

        [Test, Property("Priority", 14)]
        public void RegisterWithVeryWeakPassword()
        {
            // use very weak password
            _user.Password = "11111111";
            _user.PasswordConfirm = "11111111";

            _page.ActFill(_user);

            _page.PasswordStrength.AssertTextErrorIs("Very weak", "Password is very weak");
        }

        [Test, Property("Priority", 15)]
        public void RegisterWithMeadiumPassword()
        {
            // use medium password
            _user.Password = "1-aAbB1-";
            _user.PasswordConfirm = "1-aAbB1-";

            _page.ActFill(_user);

            _page.PasswordStrength.AssertTextErrorIs("Medium", "Password is of medium strength");
        }

        [Test, Property("Priority", 16)]
        public void RegisterWithWeakPassword()
        {
            // use weak password
            _user.Password = "1-AAAB1-";
            _user.PasswordConfirm = "1-AAAB1-";
            _page.ActFill(_user);

            _page.PasswordStrength.AssertTextErrorIs("Weak","Password is weak");
        }

        [Test, Property("Priority", 17)]
        public void RegisterWithStrongPassword()
        {
            // use strong password
            _user.Password = "+x4D*v@5-A66ExW2PE_nQE6MJMqmeGGg";
            _user.PasswordConfirm = "+x4D*v@5-A66ExW2PE_nQE6MJMqmeGGg";

            _page.ActFill(_user);

            _page.PasswordStrength.AssertTextErrorIs("Strong", "Password is strong");
        }


    }
}
