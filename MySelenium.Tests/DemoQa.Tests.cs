namespace MySelenium.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;

    [TestFixture]
    public class DemoQaGoToRegPage
    {
        [Test]
        public void GoToRegistration()
        {
            IWebDriver chromeDriver = new ChromeDriver();
            chromeDriver.Manage().Window.Maximize();
            //open DemoQA website
            chromeDriver.Url = "http://www.demoqa.com";

            //open registration page
            WebDriverWait driverWait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(60));

            IWebElement targetButton = driverWait
                .Until<IWebElement>(
                    ExpectedConditions.ElementToBeClickable(
                        By.Id("menu-item-374")
                        )
                    );
            targetButton.Click();

            //Check page title 
            Assert.AreEqual("Registration | Demoqa", chromeDriver.Title, "You are not on the registration page!");

            chromeDriver.Quit();
        }
    }

    [TestFixture]
    public class DemoQaGoRegForm
    {
        [Test]
        public void RegistrateWithNegativePhone()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //open DemoQA website
            driver.Url = "http://www.demoqa.com/registration/";

            IWebElement registrateButton = driver.FindElement(By.XPath("//*[@id=\"menu-item-374\"]/a"));
            registrateButton.Click();
            IWebElement firstName = driver.FindElement(By.Id("name_3_firstname"));
            Type(firstName, "Aaaaa");
            IWebElement lastName = driver.FindElement(By.Id("name_3_lastname"));
            Type(lastName, "Bbbbb");
            IWebElement matrialStatus = driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[2]/div/div/input[1]"));
            matrialStatus.Click();
            List<IWebElement> hobbys = driver.FindElements(By.Name("checkbox_5[]")).ToList();
            hobbys[0].Click();
            hobbys[1].Click();
            IWebElement countryDropDown = driver.FindElement(By.Id("dropdown_7"));
            SelectElement countryOption = new SelectElement(countryDropDown);
            countryOption.SelectByText("Bulgaria");
            IWebElement mountDropDown = driver.FindElement(By.Id("mm_date_8"));
            SelectElement mountOption = new SelectElement(mountDropDown);
            mountOption.SelectByValue("3");
            IWebElement dayDropDown = driver.FindElement(By.Id("dd_date_8"));
            SelectElement dayOption = new SelectElement(dayDropDown);
            dayOption.SelectByText("3");
            IWebElement yearDropDown = driver.FindElement(By.Id("yy_date_8"));
            SelectElement yearOption = new SelectElement(yearDropDown);
            yearOption.SelectByValue("1989");
            IWebElement telephone = driver.FindElement(By.Id("phone_9"));
            Type(telephone, "359");
            IWebElement userName = driver.FindElement(By.Id("username"));
            Type(userName, "aaaa");
            IWebElement email = driver.FindElement(By.Id("email_1"));
            Type(email, "abv@abv.bg");
            IWebElement description = driver.FindElement(By.Id("description"));
            Type(description, "Regarding phone number field - this is a negative test !");
            IWebElement password = driver.FindElement(By.Id("password_2"));
            Type(password, "123456789");
            IWebElement confirmPassword = driver.FindElement(By.Id("confirm_password_password_2"));
            Type(confirmPassword, "123456789");

            var testPhone = driver.FindElement(By.XPath("//*[@id='pie_register']/li[6]/div/div/span"));
            Assert.AreEqual(testPhone.Text, "* Minimum 10 Digits starting with Country Code", "Phone number is in correct format!");

            driver.Quit();
        }

        [Test]
        public void RegistrateWithNegativeMail()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //open DemoQA website
            driver.Url = "http://www.demoqa.com/registration/";

            IWebElement registrateButton = driver.FindElement(By.XPath("//*[@id=\"menu-item-374\"]/a"));
            registrateButton.Click();
            IWebElement firstName = driver.FindElement(By.Id("name_3_firstname"));
            Type(firstName, "Aaaaa");
            IWebElement lastName = driver.FindElement(By.Id("name_3_lastname"));
            Type(lastName, "Bbbbb");
            IWebElement matrialStatus = driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[2]/div/div/input[1]"));
            matrialStatus.Click();
            List<IWebElement> hobbys = driver.FindElements(By.Name("checkbox_5[]")).ToList();
            hobbys[0].Click();
            hobbys[1].Click();
            IWebElement countryDropDown = driver.FindElement(By.Id("dropdown_7"));
            SelectElement countryOption = new SelectElement(countryDropDown);
            countryOption.SelectByText("Bulgaria");
            IWebElement mountDropDown = driver.FindElement(By.Id("mm_date_8"));
            SelectElement mountOption = new SelectElement(mountDropDown);
            mountOption.SelectByValue("3");
            IWebElement dayDropDown = driver.FindElement(By.Id("dd_date_8"));
            SelectElement dayOption = new SelectElement(dayDropDown);
            dayOption.SelectByText("3");
            IWebElement yearDropDown = driver.FindElement(By.Id("yy_date_8"));
            SelectElement yearOption = new SelectElement(yearDropDown);
            yearOption.SelectByValue("1989");
            IWebElement telephone = driver.FindElement(By.Id("phone_9"));
            Type(telephone, "359999999999");
            IWebElement userName = driver.FindElement(By.Id("username"));
            Type(userName, "aaaa");
            IWebElement email = driver.FindElement(By.Id("email_1"));
            Type(email, "abv.bg");
            IWebElement description = driver.FindElement(By.Id("description"));
            Type(description, "Regarding e-mail field - this is a negative test !");
            IWebElement password = driver.FindElement(By.Id("password_2"));
            Type(password, "123456789");
            IWebElement confirmPassword = driver.FindElement(By.Id("confirm_password_password_2"));
            Type(confirmPassword, "123456789");

            var testMail = driver.FindElement(By.XPath("//*[@id='pie_register']/li[8]/div/div/span"));
            Assert.AreEqual(testMail.Text, "* Invalid email address", "E-mail address is correct!");

            driver.Quit();
        }

        [Test]
        public void RegistrateWithMismatchPasswords()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //open DemoQA website
            driver.Url = "http://www.demoqa.com/registration/";

            IWebElement registrateButton = driver.FindElement(By.XPath("//*[@id=\"menu-item-374\"]/a"));
            registrateButton.Click();
            IWebElement firstName = driver.FindElement(By.Id("name_3_firstname"));
            Type(firstName, "Aaaaa");
            IWebElement lastName = driver.FindElement(By.Id("name_3_lastname"));
            Type(lastName, "Bbbbb");
            IWebElement matrialStatus = driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[2]/div/div/input[1]"));
            matrialStatus.Click();
            List<IWebElement> hobbys = driver.FindElements(By.Name("checkbox_5[]")).ToList();
            hobbys[0].Click();
            hobbys[1].Click();
            IWebElement countryDropDown = driver.FindElement(By.Id("dropdown_7"));
            SelectElement countryOption = new SelectElement(countryDropDown);
            countryOption.SelectByText("Bulgaria");
            IWebElement mountDropDown = driver.FindElement(By.Id("mm_date_8"));
            SelectElement mountOption = new SelectElement(mountDropDown);
            mountOption.SelectByValue("3");
            IWebElement dayDropDown = driver.FindElement(By.Id("dd_date_8"));
            SelectElement dayOption = new SelectElement(dayDropDown);
            dayOption.SelectByText("3");
            IWebElement yearDropDown = driver.FindElement(By.Id("yy_date_8"));
            SelectElement yearOption = new SelectElement(yearDropDown);
            yearOption.SelectByValue("1989");
            IWebElement telephone = driver.FindElement(By.Id("phone_9"));
            Type(telephone, "359999999999");
            IWebElement userName = driver.FindElement(By.Id("username"));
            Type(userName, "aaaa");
            IWebElement email = driver.FindElement(By.Id("email_1"));
            Type(email, "abv@abv.bg");
            IWebElement description = driver.FindElement(By.Id("description"));
            Type(description, "Regarding password fields - this is a negative test !");
            IWebElement password = driver.FindElement(By.Id("password_2"));
            Type(password, "123456789");
            IWebElement confirmPassword = driver.FindElement(By.Id("confirm_password_password_2"));
            Type(confirmPassword, "123123123");

            var testPass = driver.FindElement(By.XPath("//*[@id='piereg_passwordStrength']"));
            Assert.AreEqual(testPass.Text, "Mismatch", "There is a match in Password and Confirm Password fields!");

            driver.Quit();
        }

        [Test]
        public void RegistrateWithEmptyUsername()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //open DemoQA website
            driver.Url = "http://www.demoqa.com/registration/";

            IWebElement registrateButton = driver.FindElement(By.XPath("//*[@id=\"menu-item-374\"]/a"));
            registrateButton.Click();
            IWebElement firstName = driver.FindElement(By.Id("name_3_firstname"));
            Type(firstName, "Aaaaa");
            IWebElement lastName = driver.FindElement(By.Id("name_3_lastname"));
            Type(lastName, "Bbbbb");
            IWebElement matrialStatus = driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[2]/div/div/input[1]"));
            matrialStatus.Click();
            List<IWebElement> hobbys = driver.FindElements(By.Name("checkbox_5[]")).ToList();
            hobbys[0].Click();
            hobbys[1].Click();
            IWebElement countryDropDown = driver.FindElement(By.Id("dropdown_7"));
            SelectElement countryOption = new SelectElement(countryDropDown);
            countryOption.SelectByText("Bulgaria");
            IWebElement mountDropDown = driver.FindElement(By.Id("mm_date_8"));
            SelectElement mountOption = new SelectElement(mountDropDown);
            mountOption.SelectByValue("3");
            IWebElement dayDropDown = driver.FindElement(By.Id("dd_date_8"));
            SelectElement dayOption = new SelectElement(dayDropDown);
            dayOption.SelectByText("3");
            IWebElement yearDropDown = driver.FindElement(By.Id("yy_date_8"));
            SelectElement yearOption = new SelectElement(yearDropDown);
            yearOption.SelectByValue("1989");
            IWebElement telephone = driver.FindElement(By.Id("phone_9"));
            Type(telephone, "359999999999");
            IWebElement userName = driver.FindElement(By.Id("username"));
            Type(userName, "");
            IWebElement email = driver.FindElement(By.Id("email_1"));
            Type(email, "abv@abv.bg");
            IWebElement description = driver.FindElement(By.Id("description"));
            Type(description, "Regarding username field - this is a negative test !");
            IWebElement password = driver.FindElement(By.Id("password_2"));
            Type(password, "123456789");
            IWebElement confirmPassword = driver.FindElement(By.Id("confirm_password_password_2"));
            Type(confirmPassword, "123456789");

            var testUsername = driver.FindElement(By.XPath("//*[@id='pie_register']/li[7]/div/div/span"));
            Assert.AreEqual(testUsername.Text, "* This field is required", "Username is correct!");

            driver.Quit();
        }

        [Test]
        public void RegistrateWithoutHobby()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //open DemoQA website
            driver.Url = "http://www.demoqa.com/registration/";

            IWebElement registrateButton = driver.FindElement(By.XPath("//*[@id=\"menu-item-374\"]/a"));
            registrateButton.Click();
            IWebElement firstName = driver.FindElement(By.Id("name_3_firstname"));
            Type(firstName, "Aaaaa");
            IWebElement lastName = driver.FindElement(By.Id("name_3_lastname"));
            Type(lastName, "Bbbbb");
            IWebElement matrialStatus = driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[2]/div/div/input[1]"));
            matrialStatus.Click();
            List<IWebElement> hobbys = driver.FindElements(By.Name("checkbox_5[]")).ToList();
            hobbys[0].Click();
            hobbys[0].Click();
            IWebElement countryDropDown = driver.FindElement(By.Id("dropdown_7"));
            SelectElement countryOption = new SelectElement(countryDropDown);
            countryOption.SelectByText("Bulgaria");
            IWebElement mountDropDown = driver.FindElement(By.Id("mm_date_8"));
            SelectElement mountOption = new SelectElement(mountDropDown);
            mountOption.SelectByValue("3");
            IWebElement dayDropDown = driver.FindElement(By.Id("dd_date_8"));
            SelectElement dayOption = new SelectElement(dayDropDown);
            dayOption.SelectByText("3");
            IWebElement yearDropDown = driver.FindElement(By.Id("yy_date_8"));
            SelectElement yearOption = new SelectElement(yearDropDown);
            yearOption.SelectByValue("1989");
            IWebElement telephone = driver.FindElement(By.Id("phone_9"));
            Type(telephone, "359999999999");
            IWebElement userName = driver.FindElement(By.Id("username"));
            Type(userName, "aaaa");
            IWebElement email = driver.FindElement(By.Id("email_1"));
            Type(email, "abv@abv.bg");
            IWebElement description = driver.FindElement(By.Id("description"));
            Type(description, "Regarding field - this is a negative test !");
            IWebElement password = driver.FindElement(By.Id("password_2"));
            Type(password, "123456789");
            IWebElement confirmPassword = driver.FindElement(By.Id("confirm_password_password_2"));
            Type(confirmPassword, "123456789");

            var testHobby = driver.FindElement(By.XPath("//*[@id='pie_register']/li[3]/div/div[2]/span"));
            Assert.AreEqual(testHobby.Text, "* This field is required", "Hobby is selected!");

            driver.Quit();
        }


        public void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
