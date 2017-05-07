namespace MySelenium.Tests.Pages.HomePage
{
    using NUnit.Framework;
    using RegistrationPage;

    public static class HomePageAsserter
    {
        public static void AsserHomePageIsOpen(this RegistrationPage page, string text)
        {
            Assert.AreEqual(text, page.Title, "You are not on the registration page!");
        }
    }
}
