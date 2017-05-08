namespace MySelenium.Tests.Models
{
    using System.Collections.Generic;
    using System.Linq;


    public class RegistrationUser
    {
        private string _firstName;
        private string _lastName;
        private List<bool> _martialStatus;
        private List<bool> _hobbies;
        private string _country;
        private string _birthDay;
        private string _birthMonth;
        private string _birthYear;
        private string _phoneNumber;
        private string _userName;
        private string _email;
        private string _profilePicturePath;
        private string _about;
        private string _password;
        private string _passwordConfirm;

        public RegistrationUser(
            string firstName,
            string lastName,
            List<bool> martialStatus,
            List<bool> hobbies,
            string country,
            string birthYear,
            string birthMonth,
            string birthDay,
            string phoneNumber,
            string userName,
            string email,
            string picture,
            string about,
            string password,
            string passwordConfirm
            )
        {
            _firstName = firstName;
            _lastName = lastName;
            _martialStatus = martialStatus;
            _hobbies = hobbies;
            _country = country;
            _birthYear = birthYear;
            _birthMonth = birthMonth;
            _birthDay = birthDay;
            _phoneNumber = phoneNumber;
            _userName = userName;
            _email = email;
            _profilePicturePath = picture;
            _about = about;
            _password = password;
            _passwordConfirm = passwordConfirm;
        }

        public RegistrationUser(List<string> paraList)
        {
            _firstName = paraList[0];
            _lastName = paraList[1];

            List<bool> mStatus = paraList[2].Split(',').Select(bool.Parse).ToList();
            _martialStatus = mStatus;

            List<bool> hobbiesList = paraList[3].Split(',').Select(bool.Parse).ToList();
            _hobbies = hobbiesList;
            _country = paraList[4];
            _birthYear = paraList[5];
            _birthMonth = paraList[6];
            _birthDay = paraList[7];
            _phoneNumber = paraList[8];
            _userName = paraList[9];
            _email = paraList[10];
            _profilePicturePath = paraList[11];
            _about = paraList[12];
            _password = paraList[13];
            _passwordConfirm = paraList[14];
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

        public string PasswordConfirm
        {
            get { return _passwordConfirm; }
            set { _passwordConfirm = value; }
        }
    }
}
