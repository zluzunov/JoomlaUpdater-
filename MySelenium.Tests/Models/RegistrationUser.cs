namespace MySelenium.Tests.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class RegistrationUser
    {
        private string _firstName;
        private string _lastName;
        private List<bool> _martialStatus;
        private List<bool> _hobbies;
        private string _country;
        private string _birthYear;
        private string _birthMonth;
        private string _birthDay;
        private string _phoneNumber;
        private string _userName;
        private string _email;
        private string _profilePicturePath;
        private string _about;
        private string _password;
        private string _passwordRepeat;

        public RegistrationUser(
            string firstName,
            string lastName,
            List<bool> martialStatus,
            List<bool> hobbies,
            string country,
            string phoneNumber,
            string userName,
            string email,
            string password,
            string passwordRepeat
            )
        {
            
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public List<bool> MartialStatus
        {
            get { return _martialStatus; }
            set { _martialStatus = value; }
        }

        public List<bool> Hobbies
        {
            get { return _hobbies; }
            set { _hobbies = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public string BirthYear
        {
            get { return _birthYear; }
            set { _birthYear = value; }
        }

        public string BirthMonth
        {
            get { return _birthMonth; }
            set { _birthMonth = value; }
        }

        public string BirthDay
        {
            get { return _birthDay; }
            set { _birthDay = value; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string ProfilePicturePath
        {
            get { return _profilePicturePath; }
            set { _profilePicturePath = value; }
        }

        public string About
        {
            get { return _about; }
            set { _about = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string PasswordRepeat
        {
            get { return _passwordRepeat; }
            set { _passwordRepeat = value; }
        }
    }
}
