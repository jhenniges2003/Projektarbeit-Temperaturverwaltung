using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesktopanwendungTemperatur
{
    [Table("nutzer")]
    class UserModel : INotifyPropertyChanged
    {
        private int _userId;
        private string _logInName = string.Empty;
        private string _userName = string.Empty;
        private string _password = string.Empty;
        private string _phoneNumber = string.Empty;

        [Key]
        [Column("NutzerId")]
        public int UserId
        {
            get => _userId; set
            {
                if (_userId != value)
                {
                    _userId = value;
                    OnPropertyChanged(nameof(UserId));
                }
            }
        }

        [Column("Anmeldename")]
        public string LogInName
        {
            get => _logInName; set
            {
                if (_logInName != value)
                {
                    _logInName = value;
                    OnPropertyChanged(nameof(LogInName));
                }
            }
        }

        [Column("Name")]
        public string UserName
        {
            get => _userName; set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged(nameof(UserName));
                }
            }
        }

        [Column("Passwort")]
        public string Password
        {
            get => _password; set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        [Column("Telefonnummer")]
        public string PhoneNumber
        {
            get => _phoneNumber; set
            {
                if (_phoneNumber != value)
                {
                    _phoneNumber = value;
                    OnPropertyChanged(nameof(PhoneNumber));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
