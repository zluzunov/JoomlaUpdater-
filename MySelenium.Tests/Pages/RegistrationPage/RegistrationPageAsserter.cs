namespace MySelenium.Tests.Pages.RegistrationPage
{
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using OpenQA.Selenium;

    public static class RegistrationPageAsserter
    {
        public static void AssertFormErrorIs(
                this IReadOnlyCollection<IWebElement> page, 
                string expectedMessage, 
                string fieldLabel
            )
        {
            var messageElement = page.ElementAtOrDefault(0);

            Assert.AreEqual(
                messageElement != null ? messageElement.Text : "",
                actual: expectedMessage,
                message: $"No error message when {fieldLabel} is incorrect!"
            );
        }

        public static void AssertTextErrorIs(
            this IWebElement element,
            string expectedMessage,
            string fieldLabel
        )
        {
            Assert.IsTrue(element.Displayed);
            Assert.AreEqual(
                element.Text ?? "",
                actual: expectedMessage,
                message: $"Incorrect message when {fieldLabel}"
            );
        }
    }
}
