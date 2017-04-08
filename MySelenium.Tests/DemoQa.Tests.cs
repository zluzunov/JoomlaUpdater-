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

    [TestFixture]
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

    [TestFixture]
    public class DemoQaGoRegForm
    {
        private IWebDriver _chromeDriver;
        private RegistrationPage _page;
        private RegistrationUser _user; 

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

        [Test]
        public void RegistrateWithNegativePhone()
        {
            _user.PhoneNumber = "21346";
            _page.Fill(_user);

            Assert.AreEqual(
                _page.FormErrorPhone.ElementAt(0).Text,
                "* Minimum 10 Digits starting with Country Code",
                "Phone number is in correct format!"
                );
        }

        [Test]
        public void RegistrateWithNegativeMail()
        {
            _user.Email = "badMail.com";
            _page.Fill(_user);

            var messageElement = _page.FormErrorEmail.ElementAtOrDefault(0);
            Assert.AreEqual(
                messageElement != null ? messageElement.Text : "",
                "* Invalid email address",
                "E-mail address is correct!"
                );
        }

        [Test]
        public void RegistrateWithMismatchPasswords()
        {
            _user.PasswordConfirm = "notMatching";
            _page.Fill(_user);

            var messageElement = _page.FormErrorPasswordConfirm.ElementAtOrDefault(0);
            Assert.AreEqual(
                messageElement != null ? messageElement.Text : "",
                "* Fields do not match", 
                "There is a match in Password and Confirm Password fields!"
                );
        }

        [Test]
        public void RegistrateWithEmptyUsername()
        {
            _user.UserName = "";
            _page.Fill(_user);

            var messageElement = _page.FormErrorUserName.ElementAtOrDefault(0);
            Assert.AreEqual(
                messageElement != null ? messageElement.Text : "", 
                "* This field is required", 
                "Username is correct!"
                );
        }

        [Test]
        public void RegistrateWithoutHobby()
        {
            _user.Hobbies = new List<bool>(){ false, false, false };
            _page.Fill(_user);

            var messageElement = _page.FormErrorHobbies.ElementAtOrDefault(0);
            Assert.AreEqual(
                messageElement != null ? messageElement.Text : "",
                actual: "* This field is required",
                message: "Hobby is selected!"
            );
        }
    }
}
