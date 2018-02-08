namespace JoomlaUpdater.Models
{
    public class JoomlaUser
    {
        public JoomlaUser(
            string userName,
            string password
            )
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
