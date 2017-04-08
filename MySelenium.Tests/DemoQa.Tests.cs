namespace MySelenium.Tests
{
    using System;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
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
            Assert.AreEqual("Registration | Demoqa", home.Title, "You are not on the registration page!");
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

        private void InitiateUser()
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
            InitiateUser();
        }

        [TearDown]
        public void CleanUp()
        {
            _chromeDriver.Quit();
        }

        [Test,Property("Priority", 0)]
        public void RegisterWithNegativePhone()
        {
            // short phone number
            _user.PhoneNumber = "21346";
            _page.FillAndSubmit(_user);

            var messageElement = _page.FormErrorPhone.ElementAtOrDefault(0);
            Assert.AreEqual(
                messageElement != null ? messageElement.Text : "",
                actual: InvalidAndShortPhoneMessage,
                message: "No error message when phone is incorrect!"
                );
        }

        [Test, Property("Priority", 1)]
        public void RegisterWithNegativeMail()
        {
            // email without @
            _user.Email = "badMail.com";
            _page.FillAndSubmit(_user);

            var messageElement = _page.FormErrorEmail.ElementAtOrDefault(0);
            Assert.AreEqual(
                messageElement != null ? messageElement.Text : "",
                actual: "* Invalid email address",
                message: "No error message when 'Email' is not valid!"
                );
        }

        [Test, Property("Priority", 2)]
        public void RegisterWithMismatchPasswords()
        {
            // passwords do not match
            _user.PasswordConfirm = "notMatching";
            _page.FillAndSubmit(_user);

            var messageElement = _page.FormErrorPasswordConfirm.ElementAtOrDefault(0);
            Assert.AreEqual(
                messageElement != null ? messageElement.Text : "",
                actual: "* Fields do not match", 
                message: "No error message when passwords do not match!"
                );
        }

        [Test, Property("Priority", 3)]
        public void RegisterWithEmptyUsername()
        {
            // user name should not be empty
            _user.UserName = "";
            _page.FillAndSubmit(_user);

            var messageElement = _page.FormErrorUserName.ElementAtOrDefault(0);
            Assert.AreEqual(
                messageElement != null ? messageElement.Text : "", 
                actual: EmptyFieldMessage, 
                message: "No error message when 'User Name' is empty!"
                );
        }

        [Test, Property("Priority", 4)]
        public void RegisterWithoutHobby()
        {
            // no hobbies selected
            _user.Hobbies = new List<bool>(){ false, false, false };
            _page.FillAndSubmit(_user);

            var messageElement = _page.FormErrorHobbies.ElementAtOrDefault(0);
            Assert.AreEqual(
                messageElement != null ? messageElement.Text : "",
                actual: EmptyFieldMessage,
                message: "No error message when field 'Hobby' is empty!"
            );
        }

        [Test, Property("Priority", 5)]
        public void RegisterWithoutLastName()
        {
            // empty last name
            _user.LastName = "";
            _page.FillAndSubmit(_user);

            var messageElement = _page.FormErrorFirstLastName.ElementAtOrDefault(0);
            Assert.AreEqual(
                messageElement != null ? messageElement.Text : "",
                actual: EmptyFieldMessage,
                message: "No error message when field 'Last Name' is empty!"
            );
        }

        [Test, Property("Priority", 6)]
        public void RegisterWithNoPhone()
        {
            // empty phone number
            _user.PhoneNumber = "";
            _page.FillAndSubmit(_user);

            var messageElement = _page.FormErrorPhone.ElementAtOrDefault(0);
            Assert.AreEqual(
                messageElement != null ? messageElement.Text : "",
                actual: EmptyFieldMessage,
                message: "No error message when field 'Phone' is empty!"
                );
        }

        [Test, Property("Priority", 7)]
        public void RegisterWithNotDigitsPhone()
        {
            // no digits
            _user.PhoneNumber = "aaaaaaaaaaa";
            _page.FillAndSubmit(_user);

            var messageElement = _page.FormErrorPhone.ElementAtOrDefault(0);
            Assert.AreEqual(
                messageElement != null ? messageElement.Text : "",
                actual: InvalidAndShortPhoneMessage,
                message: "No error message when field 'Phone' does not contain digits!"
                );
        }

        [Test, Property("Priority", 8)]
        public void RegisterWithLongPhone()
        {
            // too long teleophone number
            _user.PhoneNumber = "12345678123456789";
            _page.FillAndSubmit(_user);

            var messageElement = _page.FormErrorPhone.ElementAtOrDefault(0);
            Assert.AreEqual(
                messageElement != null ? messageElement.Text : "",
                actual: LongPhoneMessage,
                message: "No error message/incorrect message when field 'Phone' longer then 16 digits!"
                );
        }

        [Test, Property("Priority", 9)]
        public void RegisterWithDigitsAndCharPhone()
        {
            // phone with other characters
            _user.PhoneNumber = "+35999999999";
            _page.FillAndSubmit(_user);

            var messageElement = _page.FormErrorPhone.ElementAtOrDefault(0);
            Assert.AreEqual(
                messageElement != null ? messageElement.Text : "",
                actual: InvalidAndShortPhoneMessage,
                message: "No error message when field 'Phone' is not only digits!"
                );
        }

        [Test, Property("Priority", 10)]
        public void RegisterWithShortPassword()
        {
            // short password
            _user.Password = "1";
            _page.FillAndSubmit(_user);

            var messageElement = _page.FormErrorPassword.ElementAtOrDefault(0);
            Assert.AreEqual(
                messageElement != null ? messageElement.Text : "",
                actual: ShortPasswordMessage,
                message: "No error message when field 'Password' is less than 8 chars!"
                );
        }

        [Test, Property("Priority", 11)]
        public void RegisterWithExistingUser()
        {
            // Register twice with the same user
            _page.FillAndSubmit(_user);

            // change hobbies to prevent error
            _user.Hobbies = new List<bool>(){false, true, false};

            _page.FillAndSubmit(_user);

            var messageElement = _page.FormErrorExistingUserName.ElementAtOrDefault(0);
            Assert.AreEqual(
                messageElement != null ? messageElement.Text : "",
                actual: "Error: Username already exists",
                message: "No error message when existing username has been used!"
                );
        }

        [Test, Property("Priority", 12)]
        public void RegisterWithLongEmail()
        {
            // e-mails can't be longer than 254 chars
            var longEmail = new String('a', 254) + "@260.com";

            _user.Email = longEmail;
            _page.FillAndSubmit(_user);

            var messageElement = _page.FormErrorEmail.ElementAtOrDefault(0);
            Assert.AreEqual(
                messageElement != null ? messageElement.Text : "",
                actual: InvalidEmailAddress,
                message: "No error message when e-mail is longer than 254 chars!"
                );
        }

        [Test, Property("Priority", 13)]
        public void RegisterWithWrongEmail()
        {
            // e-mails can't have more than one @
            var wrong = "slslsls@lsl@260.com";

            _user.Email = wrong;
            _page.FillAndSubmit(_user);

            var messageElement = _page.FormErrorEmail.ElementAtOrDefault(0);
            Assert.AreEqual(
                messageElement != null ? messageElement.Text : "",
                actual: InvalidEmailAddress,
                message: "No error message when e-mail has '@' Longer than 254 chars!"
                );
        }

        [Test, Property("Priority", 14)]
        public void RegisterWithVeryWeakPassword()
        {
            // use very weak password
            _user.Password = "11111111";
            _user.PasswordConfirm = "11111111";
            _page.Fill(_user);

            var messageElement = _page.PasswordStrength.Text;
            Assert.AreEqual(
                messageElement ?? "",
                actual: "Very weak",
                message: "No warining message when field 'Password' is very weak!"
                );

            _page.ImplicitWait(0);
        }

        [Test, Property("Priority", 15)]
        public void RegisterWithMeadiumPassword()
        {
            // use medium password
            _user.Password = "1-aAbB1-";
            _user.PasswordConfirm = "1-aAbB1-";
            _page.Fill(_user);

            var messageElement = _page.PasswordStrength.Text;
            Assert.AreEqual(
                messageElement ?? "",
                actual: "Medium",
                message: "No warining message when field 'Password' is of medium strength!"
                );
        }

        [Test, Property("Priority", 16)]
        public void RegisterWithWeakPassword()
        {
            // use weak password
            _user.Password = "1-AAAB1-";
            _user.PasswordConfirm = "1-AAAB1-";
            _page.Fill(_user);

            var messageElement = _page.PasswordStrength.Text;
            Assert.AreEqual(
                messageElement ?? "",
                actual: "Weak",
                message: "No warining message when field 'Password' is weak!"
                );
        }

        [Test, Property("Priority", 17)]
        public void RegisterWithStrongPassword()
        {
            // use strong password
            _user.Password = "+x4D*v@5-A66ExW2PE_nQE6MJMqmeGGg";
            _user.PasswordConfirm = "+x4D*v@5-A66ExW2PE_nQE6MJMqmeGGg";
            _page.Fill(_user);

            var messageElement = _page.PasswordStrength.Text;
            Assert.AreEqual(
                messageElement ?? "",
                actual: "Strong",
                message: "No warining message when field 'Password' is strong!"
                );
        }


    }
}
