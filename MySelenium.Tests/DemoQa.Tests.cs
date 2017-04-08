namespace MySelenium.Tests
{
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
        private IWebDriver _chromeDriver;
        private RegistrationPage _page;
        private RegistrationUser _user;
        private const string EmptyFieldMessage = "* This field is required";
        private const string BadPhoneMessage = "* Minimum 10 Digits starting with Country Code";
        private const string ShortPasswordMessage = "* Minimum 8 characters required";

        private void InitiateUser()
        {
            _user = new RegistrationUser(
                firstName: "User1",
                lastName: "User3",
                martialStatus: new List<bool>() { true, false, false },
                hobbies: new List<bool>() { true, true, true },
                country: "Bulgaria",
                birthYear: "1970",
                birthMonth: "10",
                birthDay: "4",
                phoneNumber: "35928980243",
                userName: "Tester1$f",
                email: "test@abv.bg",
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
        public void RegistrateWithNegativePhone()
        {
            _user.PhoneNumber = "21346";
            _page.Fill(_user);

            var messageElement = _page.FormErrorPhone.ElementAtOrDefault(0);
            Assert.AreEqual(
                messageElement != null ? messageElement.Text : "",
                actual: BadPhoneMessage,
                message: "No error message when phone is incorrect!"
                );
        }

        [Test, Property("Priority", 1)]
        public void RegistrateWithNegativeMail()
        {
            _user.Email = "badMail.com";
            _page.Fill(_user);

            var messageElement = _page.FormErrorEmail.ElementAtOrDefault(0);
            Assert.AreEqual(
                messageElement != null ? messageElement.Text : "",
                actual: "* Invalid email address",
                message: "No error message when 'Email' is not valid!"
                );
        }

        [Test, Property("Priority", 2)]
        public void RegistrateWithMismatchPasswords()
        {
            _user.PasswordConfirm = "notMatching";
            _page.Fill(_user);

            var messageElement = _page.FormErrorPasswordConfirm.ElementAtOrDefault(0);
            Assert.AreEqual(
                messageElement != null ? messageElement.Text : "",
                actual: "* Fields do not match", 
                message: "No error message when passwords do not match!"
                );
        }

        [Test, Property("Priority", 3)]
        public void RegistrateWithEmptyUsername()
        {
            _user.UserName = "";
            _page.Fill(_user);

            var messageElement = _page.FormErrorUserName.ElementAtOrDefault(0);
            Assert.AreEqual(
                messageElement != null ? messageElement.Text : "", 
                actual: EmptyFieldMessage, 
                message: "No error message when 'User Name' is empty!"
                );
        }

        [Test, Property("Priority", 4)]
        public void RegistrateWithoutHobby()
        {
            _user.Hobbies = new List<bool>(){ false, false, false };
            _page.Fill(_user);

            var messageElement = _page.FormErrorHobbies.ElementAtOrDefault(0);
            Assert.AreEqual(
                messageElement != null ? messageElement.Text : "",
                actual: EmptyFieldMessage,
                message: "No error message when field 'Hobby' is empty!"
            );
        }

        [Test, Property("Priority", 5)]
        public void RegistrateWithoutLastName()
        {
            _user.LastName = "";
            _page.Fill(_user);

            var messageElement = _page.FormErrorFirstLastName.ElementAtOrDefault(0);
            Assert.AreEqual(
                messageElement != null ? messageElement.Text : "",
                actual: EmptyFieldMessage,
                message: "No error message when field 'Last Name' is empty!"
            );
        }

        [Test, Property("Priority", 6)]
        public void RegistrateWithNoPhone()
        {
            _user.PhoneNumber = "";
            _page.Fill(_user);

            var messageElement = _page.FormErrorPhone.ElementAtOrDefault(0);
            Assert.AreEqual(
                messageElement != null ? messageElement.Text : "",
                actual: EmptyFieldMessage,
                message: "No error message when field 'Phone' is empty!"
                );
        }

        [Test, Property("Priority", 7)]
        public void RegistrateWithNotDigitsPhone()
        {
            _user.PhoneNumber = "aaaaaaaaaaa";
            _page.Fill(_user);

            var messageElement = _page.FormErrorPhone.ElementAtOrDefault(0);
            Assert.AreEqual(
                messageElement != null ? messageElement.Text : "",
                actual: BadPhoneMessage,
                message: "No error message when field 'Phone' does not contain digits!"
                );
        }

        [Test, Property("Priority", 8)]
        public void RegistrateWithDigitsAndCharPhone()
        {
            _user.PhoneNumber = "+35999999999";
            _page.Fill(_user);

            var messageElement = _page.FormErrorPhone.ElementAtOrDefault(0);
            Assert.AreEqual(
                messageElement != null ? messageElement.Text : "",
                actual: BadPhoneMessage,
                message: "No error message when field 'Phone' is not only digits!"
                );
        }

        [Test, Property("Priority", 9)]
        public void RegistrateWithshortPassword()
        {
            _user.Password = "1";
            _page.Fill(_user);

            var messageElement = _page.FormErrorPassword.ElementAtOrDefault(0);
            Assert.AreEqual(
                messageElement != null ? messageElement.Text : "",
                actual: ShortPasswordMessage,
                message: "No error message when field 'Password' is less than 8 chars!"
                );
        }
    }
}
