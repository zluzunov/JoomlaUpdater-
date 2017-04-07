namespace MySelenium.Tests.Pages.HomePage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;


    public partial class HomePage
    {
        public IWebElement RegirstratonButton => Driver.FindElement(By.PartialLinkText("Registration"));
    }
}
