namespace JoomlaUpdater.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using OpenQA.Selenium.Chrome;
    using Pages.AdminLogin;
    using Pages.AdminUpdate;
    using Pages.AdminUpdateJoomla;


    public class JoomlaWebsite
    {
        private string _url;
        private string _secret;
        private JoomlaUser _user;
        private readonly ChromeDriver _chromeDriver;


        public JoomlaWebsite(string url, string secret, JoomlaUser user)
        {
            _url = url;
            _secret = secret;
            _user = user;
            _chromeDriver = new ChromeDriver();
            _chromeDriver
                .Manage()
                .Timeouts()
                .ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public JoomlaWebsite(string url, JoomlaUser user)
        {
            _url = url;
            _secret = "administrator";
            _user = user;
            _chromeDriver = new ChromeDriver();
            _chromeDriver
                .Manage()
                .Timeouts()
                .ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public void LogIn()
        {
            AdminLogin joomlaSite = new AdminLogin(_chromeDriver, _url, _secret);
            Console.WriteLine($"Logging in to {_url}!");
            joomlaSite.NavigateTo();

            // Go to login and fill the form
            joomlaSite.ActFillAndSubmit(_user);
        }

        public void Update()
        {
            AdminJoomlaUpdate joomlaUpdate = new AdminJoomlaUpdate(_chromeDriver, _url);
            joomlaUpdate.NavigateTo();

            joomlaUpdate.ButtonUpdateCheck.Click();
            Console.WriteLine("Waiting the check update ...");
            Thread.Sleep(20000);

            if (joomlaUpdate.StartUpdate())
            {
                Console.WriteLine("Waiting the update ...");
                Thread.Sleep(30000);
            }
            else
            {
                Console.WriteLine($"No updates found for {_url}!");
            }
        }

        public void UpdateExtensions()
        {
            AdminUpdate componentsUpdate = new AdminUpdate(_chromeDriver, _url);
            componentsUpdate.NavigateTo();

            componentsUpdate.ButtonClearCache.Click();
            Console.WriteLine("Waiting the clear ...");
            Thread.Sleep(20000);

            componentsUpdate.ButtonFindUpdate.Click();
            Console.WriteLine("Waiting the search updates ...");
            Thread.Sleep(60000);

            if (componentsUpdate.SelectUpdates())
            {
                componentsUpdate.ButtonUpdate.Click();
                Console.WriteLine("Waiting the end ...");
                Thread.Sleep(40000);
            }
            else
            {
                Console.WriteLine($"No extension updates for {_url}!");
            }
        }

        public void UpdateAll()
        {
            Console.WriteLine($"\nStarting update of {_url}");

            LogIn();
            Update();
            UpdateExtensions();
            _chromeDriver.Close();

            Console.WriteLine($"{_url} checked and updated!");
        }

        public void Close()
        {
            Console.WriteLine($"\nClosed website {this._url}");
            this._chromeDriver.Close();
        }
    }
}
