namespace JoomlaUpdater
{
    using System;
    using Models;

    class Startup
    {
        private static string _userName;
        private static string _password;

        static void Main()
        {
            //set test user and password
            _userName = "SelenUserzc0skC4fy";
            _password = "examplePassword";

            //Exaple site data
            //CheckUrl("https://localhost", "secredDirectory");
        }
        
        private static void CheckUrl(string baseUrl, string secretFolder)
        {
            JoomlaUser user = new JoomlaUser(_userName, _password);

            JoomlaWebsite website = new JoomlaWebsite(baseUrl, secretFolder, user);
            website.LogIn();
            website.UpdateExtensions();
            website.Close();
        }
    }
}
