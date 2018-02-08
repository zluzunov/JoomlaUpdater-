namespace JoomlaUpdater.Pages
{
    using NUnit.Framework;

    public static class BasePageAsserter
    {
        public static void AsserTitleIs(this BasePage page, string text)
        {
            Assert.AreEqual(text, page.Title, $"You are not on the {page.Title} page!");
        }
    }
}
