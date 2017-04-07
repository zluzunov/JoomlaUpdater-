namespace MySelenium.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
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

        [SetUp]
        public void Init()
        {
            _chromeDriver = new ChromeDriver();
            _page = new RegistrationPage(_chromeDriver);
        }

        [TearDown]
        public void CleanUp()
        {
            _chromeDriver.Quit();
        }

        [Test]
        public void RegistrateWithNegativePhone()
        {
            _page.NavigateTo();

            var user = new RegistrationUser(
                "Aaaaa",
                "Bbbbb",
                new List<bool>() { true, false, false },
                new List<bool>() { true, true, true },
                "Bulgaria",
                "4",
                "10",
                "1970",
                "+35928980243",
                "Tester1$f",
                "abv@abv.bg",
                "../../66.jpg",
                "Not mutch ....",
                "mySuperSecretPass",
                "mySuperSecretPass"
                );

            _page.Fill(user);

            Assert.AreEqual(
                _page.FormErrorPhone.Text,
                "* Minimum 10 Digits starting with Country Code",
                "Phone number is in correct format!"
                );
        }

        [Test]
        public void RegistrateWithNegativeMail()
        {
            IWebElement registrateButton = _chromeDriver.FindElement(By.XPath("//*[@id=\"menu-item-374\"]/a"));
            registrateButton.Click();
            IWebElement firstName = _chromeDriver.FindElement(By.Id("name_3_firstname"));
            _page.WriteValue(firstName, "Aaaaa");
            IWebElement lastName = _chromeDriver.FindElement(By.Id("name_3_lastname"));
            _page.WriteValue(lastName, "Bbbbb");
            IWebElement matrialStatus = _chromeDriver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[2]/div/div/input[1]"));
            matrialStatus.Click();
            List<IWebElement> hobbys = _chromeDriver.FindElements(By.Name("checkbox_5[]")).ToList();
            hobbys[0].Click();
            hobbys[1].Click();
            IWebElement countryDropDown = _chromeDriver.FindElement(By.Id("dropdown_7"));
            SelectElement countryOption = new SelectElement(countryDropDown);
            countryOption.SelectByText("Bulgaria");
            IWebElement mountDropDown = _chromeDriver.FindElement(By.Id("mm_date_8"));
            SelectElement mountOption = new SelectElement(mountDropDown);
            mountOption.SelectByValue("3");
            IWebElement dayDropDown = _chromeDriver.FindElement(By.Id("dd_date_8"));
            SelectElement dayOption = new SelectElement(dayDropDown);
            dayOption.SelectByText("3");
            IWebElement yearDropDown = _chromeDriver.FindElement(By.Id("yy_date_8"));
            SelectElement yearOption = new SelectElement(yearDropDown);
            yearOption.SelectByValue("1989");
            IWebElement telephone = _chromeDriver.FindElement(By.Id("phone_9"));
            _page.WriteValue(telephone, "359999999999");
            IWebElement userName = _chromeDriver.FindElement(By.Id("username"));
            _page.WriteValue(userName, "aaaa");
            IWebElement email = _chromeDriver.FindElement(By.Id("email_1"));
            _page.WriteValue(email, "abv.bg");
            IWebElement description = _chromeDriver.FindElement(By.Id("description"));
            _page.WriteValue(description, "Regarding e-mail field - this is a negative test !");
            IWebElement password = _chromeDriver.FindElement(By.Id("password_2"));
            _page.WriteValue(password, "123456789");
            IWebElement confirmPassword = _chromeDriver.FindElement(By.Id("confirm_password_password_2"));
            _page.WriteValue(confirmPassword, "123456789");

            var testMail = _chromeDriver.FindElement(By.XPath("//*[@id='pie_register']/li[8]/div/div/span"));
            Assert.AreEqual(testMail.Text, "* Invalid email address", "E-mail address is correct!");
        }

        [Test]
        public void RegistrateWithMismatchPasswords()
        {
            IWebElement registrateButton = _chromeDriver.FindElement(By.XPath("//*[@id=\"menu-item-374\"]/a"));
            registrateButton.Click();
            IWebElement firstName = _chromeDriver.FindElement(By.Id("name_3_firstname"));
            _page.WriteValue(firstName, "Aaaaa");
            IWebElement lastName = _chromeDriver.FindElement(By.Id("name_3_lastname"));
            _page.WriteValue(lastName, "Bbbbb");
            IWebElement matrialStatus = _chromeDriver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[2]/div/div/input[1]"));
            matrialStatus.Click();
            List<IWebElement> hobbys = _chromeDriver.FindElements(By.Name("checkbox_5[]")).ToList();
            hobbys[0].Click();
            hobbys[1].Click();
            IWebElement countryDropDown = _chromeDriver.FindElement(By.Id("dropdown_7"));
            SelectElement countryOption = new SelectElement(countryDropDown);
            countryOption.SelectByText("Bulgaria");
            IWebElement mountDropDown = _chromeDriver.FindElement(By.Id("mm_date_8"));
            SelectElement mountOption = new SelectElement(mountDropDown);
            mountOption.SelectByValue("3");
            IWebElement dayDropDown = _chromeDriver.FindElement(By.Id("dd_date_8"));
            SelectElement dayOption = new SelectElement(dayDropDown);
            dayOption.SelectByText("3");
            IWebElement yearDropDown = _chromeDriver.FindElement(By.Id("yy_date_8"));
            SelectElement yearOption = new SelectElement(yearDropDown);
            yearOption.SelectByValue("1989");
            IWebElement telephone = _chromeDriver.FindElement(By.Id("phone_9"));
            _page.WriteValue(telephone, "359999999999");
            IWebElement userName = _chromeDriver.FindElement(By.Id("username"));
            _page.WriteValue(userName, "aaaa");
            IWebElement email = _chromeDriver.FindElement(By.Id("email_1"));
            _page.WriteValue(email, "abv@abv.bg");
            IWebElement description = _chromeDriver.FindElement(By.Id("description"));
            _page.WriteValue(description, "Regarding password fields - this is a negative test !");
            IWebElement password = _chromeDriver.FindElement(By.Id("password_2"));
            _page.WriteValue(password, "123456789");
            IWebElement confirmPassword = _chromeDriver.FindElement(By.Id("confirm_password_password_2"));
            _page.WriteValue(confirmPassword, "123123123");

            var testPass = _chromeDriver.FindElement(By.XPath("//*[@id='piereg_passwordStrength']"));
            Assert.AreEqual(testPass.Text, "Mismatch", "There is a match in Password and Confirm Password fields!");
        }

        [Test]
        public void RegistrateWithEmptyUsername()
        {
            IWebElement registrateButton = _chromeDriver.FindElement(By.XPath("//*[@id=\"menu-item-374\"]/a"));
            registrateButton.Click();
            IWebElement firstName = _chromeDriver.FindElement(By.Id("name_3_firstname"));
            _page.WriteValue(firstName, "Aaaaa");
            IWebElement lastName = _chromeDriver.FindElement(By.Id("name_3_lastname"));
            _page.WriteValue(lastName, "Bbbbb");
            IWebElement matrialStatus = _chromeDriver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[2]/div/div/input[1]"));
            matrialStatus.Click();
            List<IWebElement> hobbys = _chromeDriver.FindElements(By.Name("checkbox_5[]")).ToList();
            hobbys[0].Click();
            hobbys[1].Click();
            IWebElement countryDropDown = _chromeDriver.FindElement(By.Id("dropdown_7"));
            SelectElement countryOption = new SelectElement(countryDropDown);
            countryOption.SelectByText("Bulgaria");
            IWebElement mountDropDown = _chromeDriver.FindElement(By.Id("mm_date_8"));
            SelectElement mountOption = new SelectElement(mountDropDown);
            mountOption.SelectByValue("3");
            IWebElement dayDropDown = _chromeDriver.FindElement(By.Id("dd_date_8"));
            SelectElement dayOption = new SelectElement(dayDropDown);
            dayOption.SelectByText("3");
            IWebElement yearDropDown = _chromeDriver.FindElement(By.Id("yy_date_8"));
            SelectElement yearOption = new SelectElement(yearDropDown);
            yearOption.SelectByValue("1989");
            IWebElement telephone = _chromeDriver.FindElement(By.Id("phone_9"));
            _page.WriteValue(telephone, "359999999999");
            IWebElement userName = _chromeDriver.FindElement(By.Id("username"));
            _page.WriteValue(userName, "");
            IWebElement email = _chromeDriver.FindElement(By.Id("email_1"));
            _page.WriteValue(email, "abv@abv.bg");
            IWebElement description = _chromeDriver.FindElement(By.Id("description"));
            _page.WriteValue(description, "Regarding username field - this is a negative test !");
            IWebElement password = _chromeDriver.FindElement(By.Id("password_2"));
            _page.WriteValue(password, "123456789");
            IWebElement confirmPassword = _chromeDriver.FindElement(By.Id("confirm_password_password_2"));
            _page.WriteValue(confirmPassword, "123456789");

            var testUsername = _chromeDriver.FindElement(By.XPath("//*[@id='pie_register']/li[7]/div/div/span"));
            Assert.AreEqual(testUsername.Text, "* This field is required", "Username is correct!");
        }

        [Test]
        public void RegistrateWithoutHobby()
        {
            IWebElement registrateButton = _chromeDriver.FindElement(By.XPath("//*[@id=\"menu-item-374\"]/a"));
            registrateButton.Click();
            IWebElement firstName = _chromeDriver.FindElement(By.Id("name_3_firstname"));
            _page.WriteValue(firstName, "Aaaaa");
            IWebElement lastName = _chromeDriver.FindElement(By.Id("name_3_lastname"));
            _page.WriteValue(lastName, "Bbbbb");
            IWebElement matrialStatus = _chromeDriver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[2]/div/div/input[1]"));
            matrialStatus.Click();
            List<IWebElement> hobbys = _chromeDriver.FindElements(By.Name("checkbox_5[]")).ToList();
            hobbys[0].Click();
            hobbys[0].Click();
            IWebElement countryDropDown = _chromeDriver.FindElement(By.Id("dropdown_7"));
            SelectElement countryOption = new SelectElement(countryDropDown);
            countryOption.SelectByText("Bulgaria");
            IWebElement mountDropDown = _chromeDriver.FindElement(By.Id("mm_date_8"));
            SelectElement mountOption = new SelectElement(mountDropDown);
            mountOption.SelectByValue("3");
            IWebElement dayDropDown = _chromeDriver.FindElement(By.Id("dd_date_8"));
            SelectElement dayOption = new SelectElement(dayDropDown);
            dayOption.SelectByText("3");
            IWebElement yearDropDown = _chromeDriver.FindElement(By.Id("yy_date_8"));
            SelectElement yearOption = new SelectElement(yearDropDown);
            yearOption.SelectByValue("1989");
            IWebElement telephone = _chromeDriver.FindElement(By.Id("phone_9"));
            _page.WriteValue(telephone, "359999999999");
            IWebElement userName = _chromeDriver.FindElement(By.Id("username"));
            _page.WriteValue(userName, "aaaa");
            IWebElement email = _chromeDriver.FindElement(By.Id("email_1"));
            _page.WriteValue(email, "abv@abv.bg");
            IWebElement description = _chromeDriver.FindElement(By.Id("description"));
            _page.WriteValue(description, "Regarding field - this is a negative test !");
            IWebElement password = _chromeDriver.FindElement(By.Id("password_2"));
            _page.WriteValue(password, "123456789");
            IWebElement confirmPassword = _chromeDriver.FindElement(By.Id("confirm_password_password_2"));
            _page.WriteValue(confirmPassword, "123456789");

            var testHobby = _chromeDriver.FindElement(By.XPath("//*[@id='pie_register']/li[3]/div/div[2]/span"));
            Assert.AreEqual(testHobby.Text, "* This field is required", "Hobby is selected!");
        }
    }
}
