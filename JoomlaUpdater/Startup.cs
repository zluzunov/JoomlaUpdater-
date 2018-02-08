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
            Console.WriteLine("start site data here");
        }

        private static void CheckUrl(string baseUrl, string secretFolder)
        {
            JoomlaUser user = new JoomlaUser(_userName, _password);

            JoomlaWebsite website = new JoomlaWebsite(baseUrl, secretFolder, user);
            website.LogIn();
            website.Update();
            website.Close();
        }
    }
}
